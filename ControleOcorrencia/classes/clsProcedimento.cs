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
    class clsProcedimento
    {
        public string ds_msg;
        int mNr_ocorrencia;
        string mDs_Procedimento, mStatus_Atual;

        public int Nr_ocorrencia
        {
            get { return mNr_ocorrencia; }
            set { mNr_ocorrencia = value; }
        }
        public string Ds_Procedimento
        {
            get { return mDs_Procedimento; }
            set { mDs_Procedimento = value; }
        }
        public string Status_atual
        {
            get { return mStatus_Atual; }
            set { mStatus_Atual = value; }
        }

        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("sp_salvarProcedimento");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pDs_procedimento", Ds_Procedimento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNr_Ocorrencia", Nr_ocorrencia).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pStatus_Atual", Status_atual).Direction = ParameterDirection.Input;
                instancia_conexao.CRUD(sql_cmd);
                ds_msg = "Procedimento registrado com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao gravar Procedimento!" + ex.Message;
            }

            return ds_msg;
        }
    }
}
