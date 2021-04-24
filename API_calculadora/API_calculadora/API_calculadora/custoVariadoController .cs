using API_calculadora.Models;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Web.Http;


namespace API_calculadora.Controllers
{
    public class custoVariadoController : ApiController
    {

        public AG_CUSTO_VARIADO cVariadoList;

        public AG_CUSTO_VARIADO Get(int Id) //get by ID_CUSTO_FIXO
        {

            using (var conn = new NpgsqlConnection("User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
            {
                conn.Open();
                AG_CUSTO_VARIADO cVariadoList;
                {

                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_CUSTO_VARIADO WHERE ID_CUSTO_VARIADO =" + Id, conn);

                    NpgsqlDataReader dr = command.ExecuteReader();
                    dr.Read();

                    DateTime _data = dr.GetDateTime(6);
                    string data = _data.ToString("dd/MM/yyyy");
                    //int id, int id_cv, string descricao, float valor, string um, float quantidade, string data
                    cVariadoList = new AG_CUSTO_VARIADO(dr.GetInt32(0),
                                                dr.GetInt32(1),
                                                dr.GetString(2),
                                                dr.GetFloat(3),
                                                dr.GetString(4),
                                                dr.GetFloat(5),
                                                data
                                                );


                }
                conn.Close();
                return cVariadoList;
            }

        }

        public string Delete(string Id)
        {
            NpgsqlDataReader dr;
            using (var conn = new NpgsqlConnection("User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
            {
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("DELETE FROM AG_CUSTO_VARIADO WHERE ID_CUSTO_VARIADO =" + Id, conn);

                dr = command.ExecuteReader();

                conn.Close();
            }
            return "{return:200, data:'Deletado com sucesso!'}"; 

        }

        public string Post(string ItemId, string Desc, string valor, string um, string qt)
        {
            NpgsqlDataReader dr;
            using (var conn = new NpgsqlConnection("User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
            {
                conn.Open();

                NpgsqlCommand command =
                    new NpgsqlCommand("INSERT INTO AG_CUSTO_VARIADO (ID_ITEM, DESCRICAO, VALOR, UNIDADE_MEDIDA, QUANTIDADE, DATA_INSERIDO) VALUES" +
                    "('" + ItemId + "','" + Desc + "', '" + valor + "', '" + um + "', '" + qt + "', NOW())", conn);

                dr = command.ExecuteReader();

                conn.Close();
            }

            return "{return:200, data:'Adicionado com sucesso!'}";
        }

        public string Post(string type, string ItemId, string Desc, string valor, string um, string qt)
        {
            if (type == "update")
            {
                NpgsqlDataReader dr;
                using (var conn = new NpgsqlConnection("User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
                {
                    conn.Open();

                    NpgsqlCommand command =
                         new NpgsqlCommand("UPDATE AG_CUSTO_VARIADO SET DESCRICAO ='" + Desc
                         + "', VALOR ='" + valor
                         + "', UNIDADE_MEDIDA='" + um
                         + "', QUANTIDADE = '" + qt
                         + "' WHERE ID_CUSTO_VARIADO='"+ ItemId + "'", conn);

                    dr = command.ExecuteReader();

                    conn.Close();
                }

                return "{return:200, data:'Alterado com sucesso!'}";
            }
            return "{error:'What i need to do ?'}";
        }

    }
}

