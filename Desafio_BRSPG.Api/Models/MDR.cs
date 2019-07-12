using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BRSPG.Api.Models
{
    public class MDR
    {
        public MDR()
        {
            Create();
        }
        
        public IList<AdquirenteMDR> Adquirentes { get; private set; }

        private void Create()
        {
            Adquirentes = new List<AdquirenteMDR>
            {
                new AdquirenteMDR
                {
                    Adquirente = "Adquirente A",
                    Taxas = new List<Taxa>
                    {
                        new Taxa
                        {
                            Bandeira = "Visa",
                            Credito = (decimal)2.25,
                            Debito = (decimal)2.00
                        },
                        new Taxa
                        {
                            Bandeira = "Master",
                            Credito = (decimal)2.35,
                            Debito = (decimal)1.98
                        }
                    }
                },
                new AdquirenteMDR
                {
                    Adquirente = "Adquirente B",
                    Taxas = new List<Taxa>
                    {
                        new Taxa
                        {
                            Bandeira = "Visa",
                            Credito = (decimal)2.50,
                            Debito = (decimal)2.08
                        },
                        new Taxa
                        {
                            Bandeira = "Master",
                            Credito = (decimal)2.65,
                            Debito = (decimal)1.75
                        }
                    }
                },
                new AdquirenteMDR
                {
                    Adquirente = "Adquirente C",
                    Taxas = new List<Taxa>
                    {
                        new Taxa
                        {
                            Bandeira = "Visa",
                            Credito = (decimal)2.75,
                            Debito = (decimal)2.16
                        },
                        new Taxa
                        {
                            Bandeira = "Master",
                            Credito = (decimal)3.10,
                            Debito = (decimal)1.58
                        }
                    }
                }
            };
        }

    }
}
