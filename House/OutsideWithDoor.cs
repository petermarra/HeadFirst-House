using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
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
        public OutsideWithDoor (string name,string doorDescription, bool hot)
            :base(hot,name)
        {
            DoorDescription = doorDescription;
        }
    }
}
