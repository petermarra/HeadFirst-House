using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public string DoorDescription { get; set; }
        public string DoorLocation { get;  private set; }
        
        public OutsideWithDoor (string doorDescription, string doorlocation, bool hot, string description)
            :base(hot,description)
        {
            DoorDescription = doorDescription;
            DoorLocation = doorlocation;
        }
    }
}
