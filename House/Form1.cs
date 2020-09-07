using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void CreateObjects()
        {
            RoomWithDoor livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
            RoomWithDoor kitchen = new RoomWithDoor("Kitchen", "a stove", "a screen door");
            Room diningRoom = new Room("a table", "Dining Room");
            OutsideWithDoor frontYard = new OutsideWithDoor("Front Yard", "an oak door with a brass knob", false);
            OutsideWithDoor backYard = new OutsideWithDoor("Back Yard", "a screen door", true);
            Outside garden = new Outside(false, "Garden");

            livingRoom.Exits = new Location[] { diningRoom, frontYard };
            kitchen.Exits = new Location[] { backYard, diningRoom };
            diningRoom.Exits = new Location[] {livingRoom,kitchen };
            frontYard.Exits = new Location[] {livingRoom,garden };
            backYard.Exits = new Location[] { kitchen,garden};
            garden.Exits = new Location[] {frontYard,backYard };
        }
    }
}
