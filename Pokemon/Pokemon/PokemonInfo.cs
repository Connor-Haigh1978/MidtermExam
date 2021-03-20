using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class PokemonInfo
    {
        public string height { get; set; }
        public string weight { get; set; }

        public string name { get; set; }

        public Sprites sprites { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public string front_default { get; set; }

    }
}
