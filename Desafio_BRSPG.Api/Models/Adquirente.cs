using Newtonsoft.Json;
using System.Collections.Generic;

namespace Desafio_BRSPG.Api.Models
{
    public class AdquirenteMDR
    {
        [JsonIgnoreAttribute]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Adquirente")]
        public string Adquirente { get; set; }
        [JsonProperty(PropertyName = "Taxas")]
        public IList<Taxa> Taxas { get; set; }
    }
}