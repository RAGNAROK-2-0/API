using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiCS.Models;

namespace webApiCS.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> Get()
        {
            return clientes;
        }

        public void Post(string _name)
        {
            bool isNull = string.IsNullOrEmpty(_name);

            if (!isNull)
                clientes.Add(new Cliente(_name));
        }

        public void Delete(string nome)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
        }

    }
}
