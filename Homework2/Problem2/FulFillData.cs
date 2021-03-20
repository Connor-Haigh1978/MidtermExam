using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    class FulFillData
    {
       public string State { get; set; }
       public string Gender { get; set; }
       public double Mean { get; set; }
       public double N { get; set; }

        public FulFillData()
        {
            State = string.Empty;
            Gender = string.Empty;
            Mean = 0;
            N = 0;
        }

    }
}
