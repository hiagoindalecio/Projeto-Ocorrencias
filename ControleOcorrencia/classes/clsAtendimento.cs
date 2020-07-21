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
    class clsAtendimento
    {
        public string ds_msg;
        int mId_Departamento, mId_User;
        string mNm_Solicitante, mNm_Maquina, mProblema, mSolucao;

        public int Id_departamento
        {
            get { return mId_Departamento; }
            set { mId_Departamento = value; }
        }
        public int Id_user
        {
            get { return mId_User; }
            set { mId_User = value; }
        }
        public string Nm_solicitante
        {
            get { return mNm_Solicitante; }
            set { mNm_Solicitante = value; }
        }
        public string Nm_maquina
        {
            get { return mNm_Maquina; }
            set { mNm_Maquina = value; }
        }
        public string Problema
        {
            get { return mProblema; }
            set { mProblema = value; }
        }
        public string Solucao
        {
            get { return mSolucao; }
            set { mSolucao = value; }
        }

        public string Insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarAtendimento");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Departamento", Id_departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_User", Id_user).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_Solicitante", Nm_solicitante).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_Maquina", Nm_maquina).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pProblema", Problema).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pSolucao", Solucao).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Atendimento salvo com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao gravar Procedimento!" + ex.Message;
            }
            return ds_msg;
        }

        public MySqlDataReader getAtendimentoByDate(string month, string year)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT" +
                " A.id_atendimento, A.id_departamento, A.id_user, A.nm_solicitante, A.nm_maquina, A.problema, A.solucao, A.dt_atendimento " +
                " FROM tb_historico_atendimento A" +
                " WHERE dt_atendimento like '" + year + "-" + month + "%'";
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
    }
}
