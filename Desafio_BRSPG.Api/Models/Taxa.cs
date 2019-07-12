using Newtonsoft.Json;

namespace Desafio_BRSPG.Api.Models
{
    public class Taxa
    {
        [JsonIgnoreAttribute]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Bandeira")]
        public string Bandeira { get; set; }
        [JsonProperty(PropertyName = "Debito")]
        public decimal Debito { get; set; }
        [JsonProperty(PropertyName = "Credito")]
        public decimal Credito { get; set; }
    }
}