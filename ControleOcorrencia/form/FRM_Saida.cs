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
    public partial class FRM_Saida : Form
    {
        int nr_ocorrenciaLocal;
        FRM_Ocorrencias frm_ocoAtual;
        public FRM_Saida(int nr_ocorrencia, FRM_Ocorrencias form_ocorrencia)
        {
            InitializeComponent();
            nr_ocorrenciaLocal = nr_ocorrencia;
            frm_ocoAtual = form_ocorrencia;
            CarregarOS();
            Parametros();
        }
        public void Parametros()//deixando as informações digitadas em maiusculo
        {
            txtRetirante.CharacterCasing = CharacterCasing.Upper;
        }
        private void CarregarOS()
        {
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            objOcorrencia.Nr_ocorrencia = nr_ocorrenciaLocal;
            MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();
            if (sql_dr.Read())
            {
                objOcorrencia.Ds_Defeito = sql_dr["ds_defeito"].ToString();
                objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                objOcorrencia.Nm_maquina = sql_dr["nm_maquina"].ToString();
            }
            txtMaquina.Text = objOcorrencia.Nm_maquina;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!Equals(txtMaquina, ""))
            {
                clsOcorrencias objOcorrencia = new clsOcorrencias();
                objOcorrencia.Nr_ocorrencia = nr_ocorrenciaLocal;
                MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();
                if (sql_dr.Read())
                {
                    objOcorrencia.Ds_Defeito = sql_dr["ds_defeito"].ToString();
                    objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                    objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                    objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                    objOcorrencia.Nm_maquina = sql_dr["nm_maquina"].ToString();
                    objOcorrencia.Ds_solucao = sql_dr["ds_solucao"].ToString();
                    objOcorrencia.Ds_status = "ENTREGUE";
                    objOcorrencia.Nm_retirante = txtRetirante.Text;
                    objOcorrencia.Dt_saida = DateTime.Today;
                    objOcorrencia.remove();
                    MessageBox.Show(objOcorrencia.ds_msg);
                    this.Close();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sair(object sender, FormClosedEventArgs e)
        {
            frm_ocoAtual.carregarOcorrencias();
            frm_ocoAtual.txtFiltro.Text = "";
        }

    }
}
