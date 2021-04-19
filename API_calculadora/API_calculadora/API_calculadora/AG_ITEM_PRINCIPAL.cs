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
        public string NOME_ITEM { get; set; }
        public DateTime DATA_INSERIDO { get; set; }
        public string NOME_ICONE { get; set; }

        private List<AG_CUSTO_VARIADO> custosVariados = new List<AG_CUSTO_VARIADO>();

        private List<AG_CUSTO_FIXO> custosFixos = new List<AG_CUSTO_FIXO>();

        public AG_ITEM_PRINCIPAL(int id, string nome, DateTime data, string icone)
        {
            ID_ITEM = id;
            NOME_ITEM = nome;
            DATA_INSERIDO = data;
            NOME_ICONE = icone;
        }

        public void addCustoVariado(AG_CUSTO_VARIADO cv)
        {
            custosVariados.Add(cv);
        }
        public void addCustoFixo(AG_CUSTO_FIXO cf)
        {
            custosFixos.Add(cf);
        }
    }
}