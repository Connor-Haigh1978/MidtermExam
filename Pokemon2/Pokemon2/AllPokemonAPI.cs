using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon2
{
    public class AllPokemonAPI
    {
        public List<Results> results { get; set; }

    }

    public class Results
    {
        public string name {get; set;}
        public string url { get; set; }

        public override string ToString()
        {
            return name; 
        }

    }
}
