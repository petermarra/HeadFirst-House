using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithDoor : OutsideWithHidingPlace, IHasExteriorDoor
    {
        public string DoorDescription { get; private set; }
        public Location DoorLocation { get; set; }

        public override string Description
        {
            get
            {
                return $"{base.Description}  \r\nYou see {DoorDescription}.";
            }
        }
        public OutsideWithDoor (string name, bool hot, string hidingPlace, string doorDescription)
            :base( name,hot,hidingPlace )
        {
            DoorDescription = doorDescription;
        }
    }
}
