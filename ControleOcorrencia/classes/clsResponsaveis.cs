using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.classes
{
    class clsResponsaveis
    {
        public string ds_msg = "";
        int mId_usuario;
        int mId_Departamento;

        public int Id_usuario
        {
            get { return mId_usuario; }
            set { mId_usuario = value; }
        }
        public int Id_Departamento
        {
            get { return mId_Departamento; }
            set { mId_Departamento = value; }
        }

        public MySqlDataReader getList(string orderBy)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, id_departamento FROM tb_responsaveis " + orderBy;
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarResponsavel");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_Departamento).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Responsável atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar responsável!" + ex.Message;
            }

            return ds_msg;
        }
        public string update()
        {
            try
            {
                clsConexao instancia_cnx = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_editarResp");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_User", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_Dept", Id_Departamento).Direction = ParameterDirection.Input;
                instancia_cnx.CRUD(sql_cmd);
                ds_msg = "Responsável atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar responsável!" + ex.Message;
            }
            return ds_msg;
        }
        public string delete()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_deleteResp");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_Departamento", Id_Departamento).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Responsável deletado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao deletar responsável!" + ex.Message;
            }
            return ds_msg;
        }
        public MySqlDataReader getRespByIdUser(int idUser)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, id_departamento FROM tb_responsaveis WHERE id_usuario = " + idUser.ToString();
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader getRespByIdDept(int idDept)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, id_departamento FROM tb_responsaveis WHERE id_departamento = " + idDept.ToString();
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
    }
}
