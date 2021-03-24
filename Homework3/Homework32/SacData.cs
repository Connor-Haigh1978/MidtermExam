using System;
using System.Collections.Generic;
using System.Text;

namespace Homework32
{
    public class SacData
    {
        public string street    {get; set;}
        public string city      {get; set;}
        public string zip       {get; set;}
        public string state     {get; set;}
        public string beds      {get; set;}
        public string baths     {get; set;}
        public double sq__ft    {get; set;}
        public string type      {get; set;}
        public string sale_date {get; set;}
        public double price     {get; set;}
        public string latitude  {get; set;}
        public string longitude { get; set; }

        public SacData()
        {
            street      =string.Empty;
            city        =string.Empty;
            zip         =string.Empty;
            state       =string.Empty;
            beds        =string.Empty;
            baths       =string.Empty;
            sq__ft = 0;
            type        =string.Empty;
            sale_date   =string.Empty;
            price = 0;
            latitude    =string.Empty;
            longitude = string.Empty;

        }

    }
}
