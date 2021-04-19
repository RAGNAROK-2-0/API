using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_calculadora.Models
{
    public class AG_CUSTO_VARIADO
    {
        public int ID_ITEM { get; set; }
        public string DESCRICAO { get; set; }
        public float VALOR { get; set; }
        public string UNIDADE_MEDIDA { get; set; }
        public float QUANTIDADE { get; set; }
        public DateTime DATA_INSERIDO { get; set; }

    }
}