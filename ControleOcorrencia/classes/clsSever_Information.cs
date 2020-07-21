using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ControleOcorrencia.classes
{
    class clsSever_Information
    {
        string ds_erro = "";
        public SqlConnection instancia_conexao = new SqlConnection();

        public SqlConnection conectar()
        {
            try
            {
                
                instancia_conexao.ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\hiago.indalecio\\Documents\\ControleOcorrencia v1.2\\ControleOcorrencia\\db_server.mdf;Integrated Security=True;Connect Timeout=30";
                instancia_conexao.Open();
            }
            catch (Exception ex)
            {
                ds_erro = ex.Message;
            }

            return instancia_conexao;
        }

        public void desconectar()
        {
            instancia_conexao.Close();
        }
        public void CRUD(SqlCommand sql_cmd)//UPDATE
        {
            conectar();
            sql_cmd.Connection = instancia_conexao;
            sql_cmd.ExecuteReader(CommandBehavior.SingleRow);
            desconectar();
        }
    }
}
