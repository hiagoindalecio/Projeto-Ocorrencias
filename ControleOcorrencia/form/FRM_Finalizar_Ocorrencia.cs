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
using System.Net.Mail;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    
    public partial class FRM_Finalizar_Ocorrencia : Form
    {
        FRM_Ocorrencias frm_ocorrenciasLocal;
        int ocorrenciaLocal = 0;
        public FRM_Finalizar_Ocorrencia(int nr_ocorrencia, FRM_Ocorrencias frm_Ocorrencias)
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
        }
        private void CarregarCampos(int nr_ocorrencia)
        {
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            objOcorrencia.Nr_ocorrencia = nr_ocorrencia;
            MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();

            if(sql_dr.Read())
            {
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
                   objOcorrencia.Ds_solucao = txtSolucao.Text;
                   objOcorrencia.Ds_status = cmbStatus.Text;
                   objOcorrencia.update();
                   MessageBox.Show(objOcorrencia.ds_msg);
                   if (ckbEmail.Checked)
                   {
                       clsResponsaveis objResp = new clsResponsaveis();
                       MySqlDataReader sql_dtr = objResp.getRespByIdDept(objOcorrencia.Id_departamento);
                       clsUsuario objUsuario = new clsUsuario();
                       sql_dtr.Read();
                       try
                       {
                           objUsuario.Id_usuario = Convert.ToInt32(sql_dtr["id_usuario"].ToString());
                           objUsuario.getUserById();
                           System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                           client.Host = "SMTP";
                           client.Port = 587;
                           client.EnableSsl = false;
                           //credenciais de login
                           client.Credentials = new System.Net.NetworkCredential("SEU EMAIL", "SUA SENHA");
                           MailMessage mail = new MailMessage();
                           //mail.Sender = new System.Net.Mail.MailAddress("suporte.ti@capivari.sp.gov.br", "Departamento de TI");
                           //de quem
                           mail.From = new MailAddress("SEU EMAIL");
                           //para quem
                           mail.To.Add(new MailAddress(objUsuario.email));
                           mail.To.Add(new MailAddress("EMAIL A RECEBER 2"));
                           //assunto
                           mail.Subject = "Status da máquina " + objOcorrencia.Nm_maquina + " atualizado.";
                           //corpo do email
                           string status = cmbStatus.Text.ToLower();
                           status = char.ToUpper(status[0]) + status.Substring(1);
                           string solucao = txtSolucao.Text.ToLower();
                           solucao = char.ToUpper(solucao[0]) + solucao.Substring(1);
                           mail.Body = "Olá " + objUsuario.Nm_Usuario + " aqui é do Departamento de TI! Vimos informar que o status da ocorrência " + objOcorrencia.Nr_ocorrencia + " refente a máquina " + objOcorrencia.Nm_maquina + " é: " + status + ".\nAssentamento: " + solucao + "\n";
                           if (Equals(cmbStatus.Text, "AGUARDANDO RETIRADA"))
                           {
                               mail.Body += "\nEstamos aguardando no departamento de TI para a reirada da mesma.";
                           }
                           mail.IsBodyHtml = false;
                           mail.Priority = MailPriority.High;
                           try
                           {
                               client.Send(mail);
                           }
                           catch (System.Exception erro)
                           {
                               MessageBox.Show(erro.ToString());
                           }
                           finally
                           {
                               mail = null;
                           }
                       }
                       catch
                       {
                           MessageBox.Show("Não existe responsável pelo departamento e questão!");
                       }
                   }
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
