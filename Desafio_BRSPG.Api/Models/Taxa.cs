using Newtonsoft.Json;

namespace Desafio_BRSPG.Api.Models
{
    public class Taxa
    {
        [JsonProperty(PropertyName = "Bandeira")]
        public string Bandeira { get; set; }
        [JsonConverter(typeof(DecimalFormatConverter))]
        [JsonProperty(PropertyName = "Debito")]
        public decimal Debito { get; set; }
        [JsonConverter(typeof(DecimalFormatConverter))]
        [JsonProperty(PropertyName = "Credito")]
        public decimal Credito { get; set; }
    }
}