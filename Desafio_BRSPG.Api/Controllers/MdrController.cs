using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BRSPG.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_BRSPG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MdrController : ControllerBase
    {
        private readonly MDRContext mDRContext;

        public MdrController(MDRContext mDRContext)
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