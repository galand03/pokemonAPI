using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;

namespace pokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PokemonController : ControllerBase
    {

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/getAll")]
        public async Task<ResponsePokemons> getAll()
        {
            var DefaultSiteURL = "https://pokeapi.co";
            var DefaultBaseURL = DefaultSiteURL + "/api/v2/pokemon/?offset=0&limit=1200";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponse = await client.GetAsync(DefaultBaseURL, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStringAsync();

                try
                {
                    ResponsePokemons result = new ResponsePokemons();
                    result = JsonConvert.DeserializeObject<ResponsePokemons>(contentStream);//await System.Text.Json.JsonSerializer.DeserializeAsync<dynamic>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
                    
                    return result;
                }
                catch (System.Text.Json.JsonException) // Invalid JSON
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }

        [HttpGet]
        
        [Route("[controller]/getByName/{name}")]
        public async Task<Pokemon> getByName(string name)
        {
            var DefaultSiteURL = "https://pokeapi.co";
            var DefaultBaseURL = DefaultSiteURL + "/api/v2/pokemon/" + name;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponse = await client.GetAsync(DefaultBaseURL, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStringAsync();

                try
                {
                    var result = JsonConvert.DeserializeObject<Pokemon>(contentStream);//await System.Text.Json.JsonSerializer.DeserializeAsync<dynamic>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                    Pokemon pokemon = new Pokemon();

                    pokemon.BaseExperience = result.BaseExperience;
                    pokemon.IsDefault = result.IsDefault;
                    pokemon.Mass = result.Mass;
                    pokemon.Order = result.Order;
                    pokemon.Name = result.Name;
                    pokemon.Sprites = result.Sprites;

                    return result;
                }
                catch (System.Text.Json.JsonException) // Invalid JSON
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }
    }
}
