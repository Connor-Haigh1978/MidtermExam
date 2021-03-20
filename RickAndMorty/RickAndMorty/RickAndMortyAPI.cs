using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty
{
    public class RickAndMortyAPI
    {
        public Info info {get; set;}
        public List<Results> results { get; set; }

    }
    public class Results
    {
        public string name { get; set; }

        public string image { get; set; }

        public string status { get; set; }
        public override string ToString()
        {
            return name; 
        }

    }

    public class Info
    {
        public string next { get; set; }

    }
}
