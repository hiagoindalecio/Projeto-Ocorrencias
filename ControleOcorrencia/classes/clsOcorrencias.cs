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
    class clsOcorrencias
    {
        public string ds_msg;

        int mNr_ocorrencia;
        int mId_departamento;
        string mDs_Defeito;
        string mDs_solucao;
        DateTime mDt_entrada;
        DateTime mDt_saida;
        string mNm_retirante;
        string mNm_maquina;
        string mDs_status;
        string mPatrimonio_os;
        int mId_usuario;

        public int Nr_ocorrencia
        {
            get { return mNr_ocorrencia; }
            set { mNr_ocorrencia = value; }
        }
        public int Id_departamento
        {
            get { return mId_departamento; }
            set { mId_departamento = value; }
        }
        public int Id_usuario
        {
            get { return mId_usuario; }
            set { mId_usuario = value; }
        }
        public string Ds_Defeito
        {
            get { return mDs_Defeito; }
            set { mDs_Defeito = value; }
        }
        public string Ds_solucao
        {
            get { return mDs_solucao; }
            set { mDs_solucao = value; }
        }
        public DateTime Dt_entrada
        {
            get { return mDt_entrada; }
            set { mDt_entrada = value; }
        }
        public DateTime Dt_saida
        {
            get { return mDt_saida; }
            set { mDt_saida = value; }
        }
        public string Nm_retirante
        {
            get { return mNm_retirante; }
            set { mNm_retirante = value; }
        }
        public string Nm_maquina
        {
            get { return mNm_maquina; }
            set { mNm_maquina = value; }
        }
        public string Patrimonio_os
        {
            get { return mPatrimonio_os; }
            set { mPatrimonio_os = value; }
        }
        public string Ds_status
        {
            get { return mDs_status; }
            set { mDs_status = value; }
        }
        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarOcorrencia");
                sql_cmd.CommandType = CommandType.StoredProcedure;              
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_defeito", Ds_Defeito).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_solucao", Ds_solucao).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_entrada", Dt_entrada).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_saida", Dt_saida).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_retirante", Nm_retirante).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_status", Ds_status).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_maquina", Nm_maquina).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pPatrimonio_os", Patrimonio_os).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_usuario", Id_usuario).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Ocorrência aberta com sucesso!";

                getLastOcorrencia();
                MandarHistorico();
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao gravar ocorrência!" + ex.Message;
            }

            return ds_msg;
        }
        public void update()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_editarOcorrencia");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_defeito", Ds_Defeito).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_solucao", Ds_solucao).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_entrada", Dt_entrada).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_saida", Dt_saida).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_retirante", Nm_retirante).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_maquina", Nm_maquina).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_status", Ds_status).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pPatrimonio_os", Patrimonio_os).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNr_ocorrencia", Nr_ocorrencia).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Ocorrência atualizada com sucesso!";

            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar ocorrência!" + ex.Message;
            }
            
        }

        public void remove()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_retirarOcorrencia");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_departamento", Id_departamento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_defeito", Ds_Defeito).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_solucao", Ds_solucao).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_entrada", Dt_entrada).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_saida", Dt_saida).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_retirante", Nm_retirante).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_maquina", Nm_maquina).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_status", Ds_status).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pPatrimonio_os", Patrimonio_os).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNr_ocorrencia", Nr_ocorrencia).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Ocorrência removida com sucesso!";

            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar ocorrência!" + ex.Message;
            }

        }

        public void MandarHistorico()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarHistorico");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pDs_defeito", Ds_Defeito).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDt_entrada", Dt_entrada).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNm_maquina", Nm_maquina).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDs_status", Ds_status).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pId_usuario", Id_usuario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNr_ocorrencia", Nr_ocorrencia).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Ocorrência salva no historico!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao salvar historico!" + ex.Message;
            }

        }
        public MySqlDataReader getOcorrenciasByID()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT" +
                                    " O.id_usuario, O.nr_ocorrencia,O.id_departamento, D.nm_departamento, O.ds_defeito, O.ds_solucao, O.dt_entrada, O.dt_saida, O.nm_retirante, O.nm_maquina, O.ds_status, O.patrimonio_os" +
                                    " FROM tb_ocorrencia O INNER JOIN tb_departamento D" +
                                    " ON O.id_departamento = D.id_departamento" +
                                    " INNER JOIN tb_usuario U" + 
                                    " ON O.id_usuario = U.id_usuario" +
                                    " WHERE O.nr_ocorrencia = " + Nr_ocorrencia;
            sql_cmd.CommandText = sql_query;
            ds_msg = "";
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader getOcorrenciasByFiltro(string ds_filtro)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT" +
                                    " O.id_usuario, O.nr_ocorrencia,O.id_departamento, D.nm_departamento, O.ds_defeito, O.ds_solucao, O.dt_entrada, O.dt_saida, O.nm_retirante, O.nm_maquina, O.ds_status, U.nm_usuario" +
                                    " FROM tb_ocorrencia O INNER JOIN tb_departamento D" +
                                    " ON O.id_departamento = D.id_departamento " +
                                    " INNER JOIN tb_usuario U" +
                                    " ON O.id_usuario = U.id_usuario " + ds_filtro;
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader getOcorenciasByDate(string month, string year)
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT" +
                " O.nm_maquina, O.dt_entrada, O.dt_saida " +
                " FROM tb_ocorrencia O" +
                " WHERE dt_entrada like '" + year + "-" + month + "%'";
            sql_cmd.CommandText = sql_query;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            return sql_dr;
        }
        public void getLastOcorrencia()
        {
            ds_msg = "";
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand();
            sql_cmd.CommandType = CommandType.Text;
            string sql_query = "SELECT" +
                                    " O.id_usuario, O.nr_ocorrencia, O.id_departamento, O.ds_defeito, O.ds_solucao, O.dt_entrada, O.dt_saida, O.nm_retirante, O.nm_maquina, O.ds_status" +
                                    " FROM tb_ocorrencia O "+
                                    " ORDER BY nr_ocorrencia DESC LIMIT 1";
            sql_cmd.CommandText = sql_query;

            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);

            if (sql_dr.Read())
            {
                Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                Nr_ocorrencia = Convert.ToInt32(sql_dr["nr_ocorrencia"].ToString());
                Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                Ds_Defeito = sql_dr["ds_defeito"].ToString();
                Ds_solucao = sql_dr["ds_solucao"].ToString();
                Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                try
                {
                    Dt_saida = Convert.ToDateTime(sql_dr["dt_saida"].ToString());
                }
                catch
                { }
                Nm_retirante = sql_dr["nm_retirante"].ToString();
                Nm_maquina = sql_dr["nm_maquina"].ToString();
                Ds_status = sql_dr["ds_status"].ToString();
            }
            else
            {
                ds_msg = "Erro ao obter ocorrência!";
            }
        }

    }
}
