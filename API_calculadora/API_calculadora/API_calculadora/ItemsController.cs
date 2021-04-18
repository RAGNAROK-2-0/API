using API_calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_calculadora.Controllers
{
    public class ItemsController : ApiController
    {
        private static List<ItemPrincipal> itens = new List<ItemPrincipal>();

        //[HttpGet]
        public List<ItemPrincipal> Get()
        {
            return itens;
        }

    }
}
