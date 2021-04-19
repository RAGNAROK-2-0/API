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
            pegarDados();

            return itens;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
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
         * */

        public void pegarDados()
        {
            itens.Clear();

            //NpgsqlConnection conn = new NpgsqlConnection("postgres://qplkemryuxkzar:b5b4b8a68c0eb36a8d7d28d4a1a3c2d6fe3ed8d75badd09f611ade3a38100f69@Server=ec2-23-21-229-200.compute-1.amazonaws.com:5432/d1n6ia2nei0rp0");

            //var connString = "Server=ec2-23-21-229-200.compute-1.amazonaws.com;Port=5432;User Id=qplkemryuxkzar;Password=b5b4b8a68c0eb36a8d7d28d4a1a3c2d6fe3ed8d75badd09f611ade3a38100f69;Database=d1n6ia2nei0rp0;";


            using (var conn = new NpgsqlConnection("User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; "))
            {
                conn.Open();

                // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO AG_ITEM_PRINCIPAL (NOME_ITEM,DATA_INSERIDO,NOME_ICONE) VALUES ('COXINHA',NOW(),'')", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                Console.WriteLine("I hope that works");


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
