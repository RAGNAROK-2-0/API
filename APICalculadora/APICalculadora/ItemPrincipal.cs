using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_calculadora.Models
{
    public class ItemPrincipal
    {
        public int idItem;
        public string nomeItem { get; set; }
        public DateTime dataInserido { get; set; }
        public string nomeIcone { get; set; }

        //private List<CustoVariado> custosVariados = new List<CustoVariado>();

        //private List<CustoFixo> custosFixos = new List<CustoFixo>();

        public ItemPrincipal(int id, string nome, DateTime data, string icone)
        {
            idItem = id;
            nomeIcone = nome;
            dataInserido = data;
            nomeIcone = icone;
        }
    }
}