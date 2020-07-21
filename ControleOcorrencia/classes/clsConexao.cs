using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.classes
{
    class clsConexao
    {
        string ds_erro;
        public string ipServer, portServer, nameDb, loginServer, senhaServer;

        public MySqlConnection instancia_conexao = new MySqlConnection();

        public MySqlConnection conectar()
        {
            ipServer = clsDados.IpCnx;
            portServer = clsDados.PortCnx;
            nameDb = clsDados.NameDb;
            loginServer = clsDados.LoginCnx;
            senhaServer = clsDados.SenhaCnx;
            try
            {
                instancia_conexao.ConnectionString = "Server=" + ipServer + "; Port=" + portServer + "; Database='" + nameDb + "'; Uid='" + loginServer + "'; Pwd='" + senhaServer + "';";
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
        //INSERT, UPDADE, DELETE
        public void CRUD(MySqlCommand sql_cmd)
        {
            try
            {
                conectar();
                sql_cmd.Connection = instancia_conexao;
                sql_cmd.ExecuteReader(CommandBehavior.SingleRow);
                desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Comando inválido! Contate o suporte.\nVerifique as configuração de coneção e tente novamente.\n" + e, "ERRO",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SELECT
        public MySqlDataReader selecionar(MySqlCommand sql_cmd)
        {
            conectar();
            sql_cmd.Connection = instancia_conexao;
            MySqlDataReader sql_dr = sql_cmd.ExecuteReader();
            return sql_dr;
        }
    }
}
