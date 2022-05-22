using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pokemon
{
    public class PokemonSprites
    {
        //! NOTE: some props can be null, fall back on male, non-shiny (if all shinies are null) values!

        [JsonProperty("back_female")]
        public string BackFemale
        {
            get;
            internal set;
        }
        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale
        {
            get;
            internal set;
        }
        [JsonProperty("back_default")]
        public string BackMale
        {
            get;
            internal set;
        }
        [JsonProperty("front_female")]
        public string FrontFemale
        {
            get;
            internal set;
        }
        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale
        {
            get;
            internal set;
        }
        [JsonProperty("back_shiny")]
        public string BackShinyMale
        {
            get;
            internal set;
        }
        [JsonProperty("front_default")]
        public string FrontMale
        {
            get;
            internal set;
        }
        [JsonProperty("front_shiny")]
        public string FrontShinyMale
        {
            get;
            internal set;
        }
    }

}