using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Opponent
    {
        Location myLocation;
        Random random;
        public Opponent(Location location)
        {
            myLocation = location;
            random = new Random();
        }
        public void Move()
        {
            bool hiding = true;
            while (hiding)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    if (random.Next(2) == 1)
                    {
                        //go through the door
                        IHasExteriorDoor hasDoor = myLocation as IHasExteriorDoor;
                        myLocation = hasDoor.DoorLocation;
                    }
                }
                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                if (myLocation is IHidingPlace)
                    hiding = false;
            }
        }

        public bool Check(Location location)
        {
            if (myLocation == location)
            {
                return true;
            }
            else
                return false;
        }
    }
}
