using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public string DoorLocation { get; set; }
        public string DoorDescription { get; private set; }
        public RoomWithDoor(string doorLocation, string decoration, string doorDescription)
            : base(decoration,doorLocation)
        {
            DoorDescription = doorDescription;
            DoorLocation = DoorLocation;
        }
    }
}
