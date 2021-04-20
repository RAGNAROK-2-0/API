using API_calculadora.DataAccess;
using API_calculadora.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Web.Http;


namespace API_calculadora.Controllers
{
    public class ItemsController : ApiController
    {
        private static List<AG_ITEM_PRINCIPAL> itens = new List<AG_ITEM_PRINCIPAL>();

        //[HttpGet]
        public List<AG_ITEM_PRINCIPAL> Get()
        {
            fillItens();

            return itens;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        /*
         * 
         * select * from AG_CUSTO_VARIADO
SELECT * FROM AG_CUSTO_FIXO
SELECT * FROM AG_ITEM_PRINCIPAL
select * from AG_CUSTO_VARIADO
SELECT * FROM AG_CUSTO_FIXO
SELECT * FROM AG_ITEM_PRINCIPAL
CREATE TABLE AG_ITEM_PRINCIPAL (
ID_ITEM SERIAL  PRIMARY KEY NOT NULL,
NOME_ITEM VARCHAR NOT NULL,
DATA_INSERIDO TIMESTAMP NOT NULL,
NOME_ICONE VARCHAR
)

CREATE TABLE AG_CUSTO_VARIADO (
ID_ITEM SERIAL  NOT NULL,
ID_CUSTO_VARIADO SERIAL PRIMARY KEY,
DESCRICAO VARCHAR NOT NULL,
VALOR  NUMERIC(10,2) NOT NULL,
UNIDADE_MEDIDA VARCHAR NOT NULL,
QUANTIDADE NUMERIC(10,2)  NOT NULL,
DATA_INSERIDO TIMESTAMP NOT NULL,
    CONSTRAINT FK_ID_ITEM
      FOREIGN KEY(ID_ITEM) 
      REFERENCES AG_ITEM_PRINCIPAL(ID_ITEM)
)

CREATE TABLE AG_CUSTO_FIXO (
ID_ITEM SERIAL  NOT NULL,
ID_CUSTO_FIXO SERIAL PRIMARY KEY,
DESCRICAO VARCHAR NOT NULL,
VALOR  NUMERIC(10,2) NOT NULL,
UNIDADE_MEDIDA VARCHAR NOT NULL,
QUANTIDADE NUMERIC(10,2)  NOT NULL,
DATA_INSERIDO TIMESTAMP NOT NULL,
    CONSTRAINT FK_ID_ITEM
      FOREIGN KEY(ID_ITEM) 
      REFERENCES AG_ITEM_PRINCIPAL(ID_ITEM)
)

        INSERT INTO AG_ITEM_PRINCIPAL (NOME_ITEM,DATA_INSERIDO,NOME_ICONE) VALUES ('COXINHA',NOW(),'')
         * */ //DB DATA

        public void fillItens()
        {
            itens.Clear();

            

            using (var conn = new NpgsqlConnection("User ID =; Password =; Host =; Port =5432; Database =; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
            {
                conn.Open();

                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);

                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {

                        //(int id, string nome, DateTime data, string icone)


                        int id = dr.GetInt32(0);
                        string nome = dr.GetString(1);
                        DateTime data = dr.GetDateTime(2);
                        string icone = dr.GetString(3);
                        itens.Add(new AG_ITEM_PRINCIPAL(id, nome, data, icone));
                    }
                }
                conn.Close();

                conn.Open();
                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command2 = new NpgsqlCommand("SELECT * FROM AG_CUSTO_VARIADO ", conn);

                    NpgsqlDataReader dr2 = command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        int id = dr2.GetInt32(1);
                        string descricao = dr2.GetString(2);
                        float valor = dr2.GetFloat(3);
                        string unidade_medida = dr2.GetString(4);
                        int quantidade = dr2.GetInt32(5);
                        DateTime data_inserido = dr2.GetDateTime(6);

                        foreach(AG_ITEM_PRINCIPAL item in itens)
                        {
                            if(item.ID_ITEM == int.Parse(dr2.GetString(0)))
                            {
                                item.custosVariados.Add(new AG_CUSTO_VARIADO(id, descricao, valor, unidade_medida, quantidade, data_inserido));
                                break;
                            }
                        }

                    }
                }
                conn.Close();
                conn.Open();

                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM AG_CUSTO_FIXO  ", conn);

                    NpgsqlDataReader dr3 = command3.ExecuteReader();
                    while (dr3.Read())
                    {
                        int id = dr3.GetInt32(1);
                        string descricao = dr3.GetString(2);
                        float valor = dr3.GetFloat(3);
                        string unidade_medida = dr3.GetString(4);
                        int quantidade = dr3.GetInt32(5);
                        DateTime data_inserido = dr3.GetDateTime(6);

                        foreach (AG_ITEM_PRINCIPAL item in itens)
                        {
                            if (item.ID_ITEM == int.Parse(dr3.GetString(0)))
                            {
                                item.custosVariados.Add(new AG_CUSTO_VARIADO(id, descricao, valor, unidade_medida, quantidade, data_inserido));
                                break;
                            }
                        }
                    }
                }

                //Console.WriteLine("I hope that works");
                //NpgsqlDataReader dr = command.ExecuteReader();

                /*
                while (dr.Read())
                {
                    int id = int.Parse(dr.GetString(0));
                    string nome = dr.GetString(1);
                    DateTime data = DateTime.Parse(dr.GetString(2));
                    string icone = dr.GetString(3);
                    itens.Add(new AG_ITEM_PRINCIPAL(id, nome, data, icone));
                }
                */

                conn.Close();

            }
            

            //NpgsqlTransaction tran = conn.BeginTransaction();

            //var command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);

            //var reader = command.ExecuteReader();

            
                

            /*
            command.CommandType = System.Data.CommandType.StoredProcedure;

            NpgsqlDataReader dr = command.ExecuteReader();

            if (conn.State == ConnectionState.Open)
            {
                Console.WriteLine("Connected!!");
            }

            while (dr.Read())
            {
                Console.Write("{0} \t {1} \t {2} \t {3}", dr[0], dr[1], dr[2], dr[3]);
            }
            */
            //tran.Commit();

        }

    }
}
