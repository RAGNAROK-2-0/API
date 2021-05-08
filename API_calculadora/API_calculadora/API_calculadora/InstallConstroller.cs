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
    public class InstallController : ApiController
    {

        private string queryItem = "CREATE TABLE AG_ITEM_PRINCIPAL (ID_ITEM SERIAL  PRIMARY KEY NOT NULL,NOME_ITEM VARCHAR NOT NULL,DATA_INSERIDO TIMESTAMP NOT NULL,NOME_ICONE VARCHAR)";

        private string queryCVariado = "CREATE TABLE AG_CUSTO_VARIADO(ID_ITEM SERIAL  NOT NULL,ID_CUSTO_VARIADO SERIAL PRIMARY KEY,DESCRICAO VARCHAR NOT NULL,VALOR NUMERIC(10,2) NOT NULL,UNIDADE_MEDIDA VARCHAR NOT NULL,QUANTIDADE NUMERIC(10,2)  NOT NULL,DATA_INSERIDO TIMESTAMP NOT NULL, CONSTRAINT FK_ID_ITEM  FOREIGN KEY(ID_ITEM)  REFERENCES AG_ITEM_PRINCIPAL(ID_ITEM))";

        private string querryCFixo = "CREATE TABLE AG_CUSTO_FIXO(ID_ITEM SERIAL  NOT NULL,ID_CUSTO_FIXO SERIAL PRIMARY KEY,DESCRICAO VARCHAR NOT NULL,VALOR NUMERIC(10,2) NOT NULL,UNIDADE_MEDIDA VARCHAR NOT NULL,QUANTIDADE NUMERIC(10,2)  NOT NULL,DATA_INSERIDO TIMESTAMP NOT NULL,  CONSTRAINT FK_ID_ITEM  FOREIGN KEY(ID_ITEM)   REFERENCES AG_ITEM_PRINCIPAL(ID_ITEM))";

        private string connection = "User ID =lmzbqjgdarlvte; Password =1bb829a00da2d53999826b2e32b86af9aff29a33a7d9fff483f6f1f7f4f87b61; Host =ec2-52-87-107-83.compute-1.amazonaws.com; Port =5432; Database =db9lde3i86qlva; Pooling = true; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True; ";

        public void Post()
        {
           
            using (var conn = new NpgsqlConnection(connection))
            {

                conn.Open();

                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command = new NpgsqlCommand(queryCVariado, conn);
                    command.ExecuteReader();
                }
                conn.Close();

                conn.Open();
                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command2 = new NpgsqlCommand(querryCFixo, conn);
                    command2.ExecuteReader();
                    
                }
                conn.Close();
                conn.Open();

                {
                    // NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM AG_ITEM_PRINCIPAL", conn);
                    NpgsqlCommand command3 = new NpgsqlCommand(queryItem, conn);
                    command3.ExecuteReader();
                    
                }

                conn.Close();

            }


        }
    }
}

