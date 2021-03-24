using System;
using System.Collections.Generic;
using System.Text;

namespace MemeJson
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
        public string name {get; set;}
        public string url { get; set; }
        public override string ToString()
        {
            return name; 
        }
    }
}
