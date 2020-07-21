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
    class clsDepartamento
    {
        public string ds_msg = "";
        int mId_departamento;
        string mNm_departamento;

        public int Id_departamento
        {
            get { return mId_departamento; }
            set { mId_departamento = value; }
        }
        public string Nm_departamento
        {
            get { return mNm_departamento; }
            set { mNm_departamento = value; }
        }
        //selecionar departamento por nome
        public MySqlDataReader carregarDeptByName(string nm_departamento)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_departamento, nm_departamento FROM tb_departamento WHERE nm_departamento LIKE '%" + nm_departamento + "%' ORDER BY nm_departamento ASC";
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public void carregarDeptByID()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT id_departamento, nm_departamento FROM tb_departamento WHERE id_departamento = " + Id_departamento + " ORDER BY nm_departamento ASC";
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);

            if(sql_dr.Read())
            {
                Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                Nm_departamento = sql_dr["nm_departamento"].ToString();
            }
        }
        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarDept");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pNm_departamento", Nm_departamento).Direction = ParameterDirection.Input;
                
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Departamento gravado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao gravar Departamento!" + ex.Message;
            }

            return ds_msg;
        }
        public void update()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_editarDept");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pNm_departamento", Nm_departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_departamento).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Departamento atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar Departamento!" + ex.Message;
            }

        }
    }
    
}
