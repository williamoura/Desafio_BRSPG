using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BRSPG.Api.Models
{
    public class ValorLiquido
    {
        public ValorLiquido(decimal value)
        {
            this.Value = value;
        }
        [JsonProperty(PropertyName = "ValorLiquido")]
        public decimal Value { get; set; }
    }
}
