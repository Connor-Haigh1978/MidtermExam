using System;
using System.Collections.Generic;
using System.Text;

namespace FulFill
{
    public class StateClass
    {
       public string state { get; set; }
        public string gender {get; set;}
        public double mean {get; set;}
        public int n { get; set; }


        public StateClass()
        {
            state = string.Empty;
            gender = string.Empty;
            mean = 0;
            n = 0;
        }
    }

    
}
