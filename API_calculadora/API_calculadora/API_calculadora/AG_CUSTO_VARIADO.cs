using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_calculadora.Models
{
    public class AG_CUSTO_VARIADO
    {
        public AG_CUSTO_VARIADO(int id, string descricao, float valor, string um, float quantidade, DateTime data)
        {
            ID_ITEM = id;
            DESCRICAO = descricao;
            VALOR = valor;
            UNIDADE_MEDIDA = um;
            QUANTIDADE = quantidade;
            DATA_INSERIDO = data;
        }

        public int ID_ITEM { get; set; }
        public string DESCRICAO { get; set; }
        public float VALOR { get; set; }
        public string UNIDADE_MEDIDA { get; set; }
        public float QUANTIDADE { get; set; }
        public DateTime DATA_INSERIDO { get; set; }

    }
}