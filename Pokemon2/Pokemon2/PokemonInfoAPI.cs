using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon2
{
    public class PokemonInfoAPI
    {
        public string name {get; set;}
        public string height {get; set;}
        public string weight { get; set; }

        public Sprite sprites { get; set; }

    }
    public class Sprite
    {
        public string back_default {get; set;}
        public string front_default { get; set; }

    }
}
