using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_calculadora.Models
{
    public class AG_ITEM_PRINCIPAL
    {
        public int ID_ITEM;
        public string NOME_ICONE { get; set; }

        public List<AG_CUSTO_VARIADO> custosVariados = new List<AG_CUSTO_VARIADO>();

        public List<AG_CUSTO_FIXO> custosFixos = new List<AG_CUSTO_FIXO>();
        public string NOME_ITEM { get; set; }
        public string DATA_INSERIDO { get; set; }

        public AG_ITEM_PRINCIPAL(int id, string nome, string data, string icone)
        {
            ID_ITEM = id;
            NOME_ITEM = nome;
            DATA_INSERIDO = data;
            NOME_ICONE = icone;
        }
    }
}