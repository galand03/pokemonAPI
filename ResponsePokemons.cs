using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace pokemon
{
    public class ResponsePokemons
    {
        [JsonProperty("count")]
        public int Count
        {
            get;
            internal set;
        }

        [JsonProperty("results")]
        public List<Pokemon> Pokemons
        {
            get;
            internal set;
        }
    }
}
