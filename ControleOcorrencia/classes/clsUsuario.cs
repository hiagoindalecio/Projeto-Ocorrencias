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
    class clsUsuario
    {
        public string ds_msg = "";
        int mId_usuario;
        string mNm_Usuario;
        string mDs_login;
        string mDs_senha;
        string mDs_perfil;
        string mDs_email;
        int mDs_ativo;
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
        public string Nm_Usuario
        {
            get { return mNm_Usuario; }
            set { mNm_Usuario = value; }
        }
        public string Ds_login
        {
            get { return mDs_login; }
            set { mDs_login = value; }
        }
        public string Ds_senha
        {
            get { return mDs_senha; }
            set { mDs_senha = value; }
        }
        public string Ds_perfil
        {
            get { return mDs_perfil; }
            set { mDs_perfil = value; }
        }
        public string email
        {
            get { return mDs_email; }
            set { mDs_email = value; }
        }
        public int Ds_ativo
        {
            get { return mDs_ativo; }
            set { mDs_ativo = value; }
        }
        public void AutenticarUser()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, nm_usuario, ds_perfil, email, ds_ativo FROM tb_usuario WHERE ds_login = '"+ Ds_login +"' AND ds_senha = '"+ Ds_senha+"'";
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);

            if (sql_dr.Read())
            {
                if (Convert.ToInt32(sql_dr["ds_ativo"]) == 0)
                {
                    ds_msg = "Usuário inativo!";
                }
                else
                {
                    Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                    Nm_Usuario = sql_dr["nm_usuario"].ToString();
                    Ds_perfil = sql_dr["ds_perfil"].ToString();
                    ds_msg = "";
                }
            }
            else
            {
                ds_msg = "Usuario/senha inválidos";
            }
        }
        public void getUserById()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, nm_usuario, ds_perfil, ds_login, ds_senha, email, ds_ativo, u.id_departamento, d.nm_departamento FROM tb_usuario u INNER JOIN tb_departamento d on u.id_departamento = d.id_departamento WHERE id_usuario = " + Id_usuario;
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);

            if (sql_dr.Read())
            {
                Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                Nm_Usuario = sql_dr["nm_usuario"].ToString();
                Ds_perfil = sql_dr["ds_perfil"].ToString();
                Ds_login = sql_dr["ds_login"].ToString();
                Ds_senha = sql_dr["ds_senha"].ToString();
                email = sql_dr["email"].ToString();
                Ds_ativo = Convert.ToInt32(sql_dr["ds_ativo"]);
                Id_Departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
            }
        }
        public MySqlDataReader getUserByFiltro(string filtro, string orderBy)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_usuario, nm_usuario, ds_perfil, id_departamento, email, ds_ativo FROM tb_usuario WHERE nm_usuario LIKE '%" + filtro + "%' OR ds_perfil LIKE '%" + filtro + "%' " + orderBy;
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            /*if (sql_dr.Read())
            {
                Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
            }*/
            return sql_dr;
        }
        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarUser");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pNm_usuario", Nm_Usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_login", Ds_login).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_senha", Ds_senha).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_perfil", Ds_perfil).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_Departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pemail", email).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_ativo", Ds_ativo).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Usuário cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao gravar usuário!" + ex.Message;
            }

            return ds_msg;
        }
        public void update()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_editarUser");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pNm_usuario", Nm_Usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_login", Ds_login).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_senha", Ds_senha).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_perfil", Ds_perfil).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_dept", Id_Departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pemail", email).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_ativo", Ds_ativo).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Usuário atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar usuário!" + ex.Message;
            }

        }
    }
}
