using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMWYL.Models
{
    public class info
    {
        public string success { get; set; }
        public Memes data { get; set; }

    }

    public class Memes
    {
        public List<IndividualInfo> memes { get; set; }

    }

    public class IndividualInfo
    {
        public string name { get; set; }
        public string url { get; set; }
        public override string ToString()
        {
            return name;
        }
        public int id { get; set; }

        public Nullable<int> RandomId { get; set; }
    }
}