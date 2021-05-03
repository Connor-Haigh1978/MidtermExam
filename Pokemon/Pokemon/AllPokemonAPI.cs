using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class AllPokemonAPI
    {
        public List<ResultObject> restaurants { get; set; }

    }

    public class ResultObject
    {
        public string name {get; set;}
        public int id { get; set; }

        public override string ToString()
        {
            return name; 
        }

    }
}
