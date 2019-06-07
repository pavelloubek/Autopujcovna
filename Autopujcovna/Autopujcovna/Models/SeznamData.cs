using System;
using System.Collections.Generic;
using System.Text;
using Autopujcovna.Models;

namespace Autopujcovna.Models
{
    class SeznamData
    {

        public static SeznamData seznamData = new SeznamData();

        protected List<SeznamViewItem> list;

        public SeznamData()
        {
            list = new List<SeznamViewItem>();
        }
        public List<SeznamViewItem> List { get { return list; } set { list = value; } }
    }
}
