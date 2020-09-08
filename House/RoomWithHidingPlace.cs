using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public string HidingPlace { get; private set; }
        public RoomWithHidingPlace(string name, string decoration, string hidingPlace )
            :base(decoration,name)
        {
            this.HidingPlace = hidingPlace;
        }
    }
}
