using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Outside : Location
    {
        bool hot;

        public Outside(bool hot, string name)
            : base(name)
        {
            this.hot = hot;
        }
        public override string Description
        {
            get
            {
                string description = base.Description;
                if (hot)
                    description += "\r\nIt's very hot here.";
                return description;
            }
        }


    }
}

