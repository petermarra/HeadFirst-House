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
        Location currentLocation;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        RoomWithHidingPlace hallway;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;
        RoomWithHidingPlace diningRoom;
        Room stairs;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;

        Opponent opponent;

        int moves = 0;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            opponent = new Opponent(frontYard);
            ResetGame(false);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "in the closet", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances","in the cabinet", "a screen door");
            hallway = new RoomWithHidingPlace("Hallway", "a picture of a dog", "in the closet");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "a sink and a toilet", "in the shower");
            diningRoom = new RoomWithHidingPlace("Dining Room", "a crystal chandelier","in a tall armoire");
            stairs = new Room("Stairs", "a wooden bannister");
            
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
            backYard = new OutsideWithDoor("Back Yard",true,  "a screen door");
            garden = new OutsideWithHidingPlace("Garden", false, "in the shed");
            driveway = new OutsideWithHidingPlace("Driveway", true,"in the Garage");

            livingRoom.Exits = new Location[] { diningRoom,stairs };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen};
            stairs.Exits = new Location[] { livingRoom, hallway };
            hallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { hallway };
            secondBedroom.Exits = new Location[] { hallway };
            bathroom.Exits = new Location[] { hallway };


            frontYard.Exits = new Location[] { backYard, garden,driveway };
            backYard.Exits = new Location[] { frontYard, garden,driveway };
            garden.Exits = new Location[] { frontYard, backYard };
            driveway.Exits = new Location[] { frontYard, backYard };
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }
        void MoveToANewLocation(Location newLocation)
        {
            moves++;
            
            currentLocation = newLocation;
            RedrawForm();
            
 
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
            RedrawForm();
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
            RedrawForm();
        }

        private void check_Click(object sender, EventArgs e)
        {
            moves++;
            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                RedrawForm();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;

            for (int i = 0; i < 10; i++)
            {
                opponent.Move();
                description.Text = $"{i + 1}";
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            description.Text = "Ready or not, here I come";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            goHere.Visible = true;
            exits.Visible = true; 
            MoveToANewLocation(livingRoom);
        }

        private void RedrawForm()
        {
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;

            description.Text = $"{currentLocation.Description}\r\n(move # {moves})";

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;

            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hasHidingPlace = currentLocation as IHidingPlace;
                check.Text = $"Check {hasHidingPlace.HidingPlace}";
                check.Visible = true;
            }
            else check.Visible = false;
        }
        private void ResetGame(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show($"You found me in {moves} moves.");
                IHidingPlace foundLocation = currentLocation as IHidingPlace;
                description.Text = $"You found your opponent in {moves} moves! He was hiding {foundLocation.HidingPlace}.";
            }
            moves = 0;
            goHere.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
            exits.Visible = false;
            hide.Visible = true;
        }
    }
}
