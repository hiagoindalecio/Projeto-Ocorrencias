using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleOcorrencia.classes;
using MySql.Data.MySqlClient;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    
    public partial class FRM_saidaOcorrencia : Form
    {
        FRM_Ocorrencias frm_ocorrenciasLocal;
        int ocorrenciaLocal = 0;
        public FRM_saidaOcorrencia(int nr_ocorrencia, FRM_Ocorrencias frm_Ocorrencias)
        {
            InitializeComponent();
            ocorrenciaLocal = nr_ocorrencia;
            frm_ocorrenciasLocal = frm_Ocorrencias;
            cmbStatus.SelectedIndex = 0;
            CarregarCampos(nr_ocorrencia);
            Parametros();
        }
        public void Parametros()//deixando as informações digitadas em maiusculo
        {
            txtSolucao.CharacterCasing = CharacterCasing.Upper;
            txtRetirante.CharacterCasing = CharacterCasing.Upper;
        }
        private void CarregarCampos(int nr_ocorrencia)
        {
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            objOcorrencia.Nr_ocorrencia = nr_ocorrencia;
            MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();

            if(sql_dr.Read())
            {
                txtRetirante.Text = sql_dr["NM_RETIRANTE"].ToString();
                txtSolucao.Text = sql_dr["DS_SOLUCAO"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           if(ocorrenciaLocal != 0)
           {
               clsOcorrencias objOcorrencia = new clsOcorrencias();
               objOcorrencia.Nr_ocorrencia = ocorrenciaLocal;
               MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();

               if (sql_dr.Read())
               {
                   objOcorrencia.Ds_Defeito = sql_dr["ds_defeito"].ToString();
                   objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                   objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                   objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                   objOcorrencia.Nm_maquina = sql_dr["nm_maquina"].ToString();

                   objOcorrencia.Nm_retirante =  txtRetirante.Text;
                   objOcorrencia.Dt_saida = Convert.ToDateTime(txtSaida.Text);
                   objOcorrencia.Ds_solucao = txtSolucao.Text;
                   objOcorrencia.Ds_status = cmbStatus.Text;
                   objOcorrencia.update();
                   MessageBox.Show(objOcorrencia.ds_msg);
                   this.Close();
               }
           }
        }

        private void FRM_saidaOcorrencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_ocorrenciasLocal.carregarOcorrencias();
            frm_ocorrenciasLocal.txtFiltro.Text = "";
        }
    }
}
