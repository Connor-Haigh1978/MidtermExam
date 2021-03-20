using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTwo
{
    public class FufillDataClass
    {
        public string state {get; set;}
        public string gender {get; set;}
        public double mean {get; set;}
        public int N { get; set; }

        public FufillDataClass()
        {
            state = string.Empty;
            gender = string.Empty;
            mean = 0;
            N = 0;
        }

        public override string ToString()
        {
            return state;
        }

    }
}
