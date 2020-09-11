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
            :base(name,decoration)
        {
            this.HidingPlace = hidingPlace;
        }

        public override string Description
        {
            get
            {
                return $"{base.Description} \r\nSomeone could hide {HidingPlace}";
            }
        }
    }
}
