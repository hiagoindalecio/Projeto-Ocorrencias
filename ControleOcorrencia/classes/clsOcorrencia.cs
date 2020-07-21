using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControleOcorrencia.classes
{
    class clsOcorrencia
    {
        string ds_msg = "";
        int mNr_ocorrencia;
        int mId_departamento;
        string mDs_defeito;
        string mDs_solucao;
        DateTime mDt_entrada;
        DateTime mDt_saida;
        string mNm_retirante;
        string mNm_maquina;
        string mDs_status;

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
        public string Ds_defeito
        {
            get { return mDs_defeito; }
            set { mDs_defeito = value; }
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
            get { return mDt_saida;  }
            set { mDt_saida = value; }
        }
        
    }
}
