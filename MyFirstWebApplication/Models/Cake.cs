using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Models
{
    public class Cake
    {
        [JsonPropertyName("cakeId")]
        public int cakeId { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("price")]
        public double price { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Cake>(this);
    }
}
