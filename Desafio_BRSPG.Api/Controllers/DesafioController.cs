using Desafio_BRSPG.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_BRSPG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafioController : ControllerBase
    {
        private readonly MDRContext mDRContext;

        public DesafioController(MDRContext mDRContext)
        {
            this.mDRContext = mDRContext;

            if (mDRContext.AdquirenteMDRItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                AddAdquirentes(mDRContext);

                mDRContext.SaveChanges();
            }
        }
        
        [HttpGet]
        [Route("mdr")]
        public ActionResult<IList<AdquirenteMDR>> GetMdr()
        {
            return mDRContext.AdquirenteMDRItems.ToList();
        }

        [HttpPost]
        [Route("transaction")]
        public ActionResult<ValorLiquido> Transaction([FromBody] Transacao transacao)
        {
            ValorLiquido valorLiquido = null;

            if (transacao.Adquirente.Length != 1)
                throw new ArgumentCustomException("A propriedade deve conter um caracter", $"Por favor revise o adquirente enviado: {transacao.Adquirente}");

            if (!string.Equals(transacao.Bandeira, "visa", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(transacao.Bandeira, "master", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentCustomException("Não temos suporte para essa bandeira", $"Por favor revise a bandeira enviada: {transacao.Bandeira}");

            if (!string.Equals(transacao.Tipo, "credito", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(transacao.Tipo, "debito", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentCustomException("Os tipos de transação são 'Credito' e 'Debito'",$"Por favor revise o tipo enviado: {transacao.Tipo}");

            var adquirente = mDRContext.AdquirenteMDRItems.SingleOrDefault(x => string.Equals(x.Adquirente[x.Adquirente.Length - 1].ToString(), transacao.Adquirente, StringComparison.OrdinalIgnoreCase));

            if (adquirente == null)
                throw new NotFoundCustomException("O adquirente não foi encontrado", $"Por favor revise o adquirente enviado: {transacao.Adquirente}");

            var taxa = adquirente.Taxas.Single(x => string.Equals(x.Bandeira, transacao.Bandeira, StringComparison.OrdinalIgnoreCase));

            if (string.Equals(transacao.Tipo, "credito", StringComparison.OrdinalIgnoreCase))
            {
                valorLiquido = new ValorLiquido(CalcularValorLiquido(taxa.Credito, transacao.Valor));
            }
            else
            {
                valorLiquido = new ValorLiquido(CalcularValorLiquido(taxa.Debito, transacao.Valor));
            }

            return valorLiquido;
        }

        private decimal CalcularValorLiquido(decimal taxa, decimal valor)
        {
            decimal resultado = valor - ((taxa / 100) * valor);
            return resultado;
        }

        private static void AddAdquirentes(MDRContext mDRContext)
        {
            mDRContext.AdquirenteMDRItems.Add(new AdquirenteMDR
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
            });

            mDRContext.AdquirenteMDRItems.Add(new AdquirenteMDR
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
            });


            mDRContext.AdquirenteMDRItems.Add(new AdquirenteMDR
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
            });
        }
    }
}
