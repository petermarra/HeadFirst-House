using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Room:Location
    {
        string decoration;
        public Room(string decoration, string name)
                : base(name)
        {
            this.decoration = decoration;
        }
        public override string Description
        { get
            {
                string description = base.Description;
                description += $"\r\nYou see {decoration}.";
                return description;
            } 
        }
    }
}
