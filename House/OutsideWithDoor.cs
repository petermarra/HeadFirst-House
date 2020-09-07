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
        
        public OutsideWithDoor (string doorlocation,string doorDescription, bool hot)
            :base(hot,doorlocation)
        {
            DoorDescription = doorDescription;
            DoorLocation = doorlocation;
        }
    }
}
