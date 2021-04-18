using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_calculadora.Models
{
    public class CustoFixo
    {
        public int idItem { get; set; }
        public string descricao { get; set; }
        public float valor { get; set; }
        public string unidadeMedida { get; set; }
        public float quantidade { get; set; }
        public string data { get; set; }

    }
}