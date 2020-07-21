using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using ControleOcorrencia.classes;
using MySql.Data.MySqlClient;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Procedimentos : Form
    {
        int nr_ocorrenciaLocal;
        FRM_Ocorrencias frm_osLocal;
        public FRM_Procedimentos(string nr_ocorrencia, FRM_Ocorrencias frm_os)
        {
            InitializeComponent();
            frm_osLocal = frm_os;
            nr_ocorrenciaLocal = Convert.ToInt32(nr_ocorrencia);
            CarregarOS();
            txtSolucao.CharacterCasing = CharacterCasing.Upper;
            txtMaquina.CharacterCasing = CharacterCasing.Upper;
            txtDefeito.CharacterCasing = CharacterCasing.Upper;
            cmbStatus.SelectedIndex = 0;
        }
        private void CarregarOS()
        {
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            objOcorrencia.Nr_ocorrencia = nr_ocorrenciaLocal;
            MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();

            if(sql_dr.Read())
            {
                objOcorrencia.Ds_Defeito = sql_dr["ds_defeito"].ToString();
                objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                objOcorrencia.Nm_maquina = sql_dr["nm_maquina"].ToString();
                objOcorrencia.Patrimonio_os = sql_dr["patrimonio_os"].ToString();
            }
            txtDefeito.Text = objOcorrencia.Ds_Defeito;
            txtMaquina.Text = objOcorrencia.Nm_maquina;
            txtPatrimonio.Text = objOcorrencia.Patrimonio_os;
            clsDepartamento objDept = new clsDepartamento();
            objDept.Id_departamento = objOcorrencia.Id_departamento;
            objDept.carregarDeptByID();
            cmbDepartamento.Text = objDept.Nm_departamento;
            carregarDepartamentos();
        }

        public void carregarDepartamentos()
        {
            clsDepartamento obj_dept = new clsDepartamento();

            MySqlDataReader sql_dr = obj_dept.carregarDeptByName("");
            //jogando os departamentos no combo box
            while (sql_dr.Read())
            {
                cmbDepartamento.Items.Add(sql_dr["nm_departamento"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Equals(txtSolucao.Text, "") || Equals(txtMaquina.Text, "") || Equals(txtDefeito.Text, "") || Equals(txtPatrimonio, "") || Equals(cmbDepartamento.Text, ""))
            {
                if (Equals(txtMaquina.Text, ""))
                {
                    lblOMaquina.Visible = true;
                }
                else
                {
                    lblOMaquina.Visible = false;
                }
                if (Equals(cmbDepartamento.Text, ""))
                {
                    lblODept.Visible = true;
                }
                else
                {
                    lblODept.Visible = false;
                }
                if (Equals(txtPatrimonio, ""))
                {
                    lblOPatr.Visible = true;
                }
                else
                {
                    lblOPatr.Visible = false;
                }
                if (Equals(txtSolucao.Text, ""))
                {
                    txtMsg.Visible = true;
                }
                else
                {
                    txtMsg.Visible = false;
                }
            }
            else if (!Equals(txtSolucao.Text, ""))
            {
                clsProcedimento objProcedimento = new clsProcedimento();
                objProcedimento.Nr_ocorrencia = nr_ocorrenciaLocal;
                objProcedimento.Ds_Procedimento = txtSolucao.Text;
                objProcedimento.Status_atual = cmbStatus.Text;
                objProcedimento.insert();
                MessageBox.Show(objProcedimento.ds_msg);
                clsOcorrencias objOcorrencia = new clsOcorrencias();
                objOcorrencia.Nr_ocorrencia = nr_ocorrenciaLocal;
                MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();
                if(sql_dr.Read())
                {
                    objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                    objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                    objOcorrencia.Nm_maquina = txtMaquina.Text;
                    objOcorrencia.Ds_Defeito = txtDefeito.Text;
                    if (!Equals(txtPatrimonio.Text, ""))
                        objOcorrencia.Patrimonio_os = txtPatrimonio.Text;
                    else
                        objOcorrencia.Patrimonio_os = null;
                    objOcorrencia.Ds_solucao = sql_dr["Ds_solucao"].ToString();
                    try
                    {
                        objOcorrencia.Dt_saida = Convert.ToDateTime(sql_dr["dt_saida"].ToString());
                    }
                    catch
                    {
 
                    }
                    //objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                    clsDepartamento objDept = new clsDepartamento();
                    sql_dr = objDept.carregarDeptByName(cmbDepartamento.Text);
                    if (sql_dr.Read())
                    {
                        objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                    }
                    objOcorrencia.Ds_status = cmbStatus.Text;
                    objOcorrencia.update();
                    objOcorrencia.MandarHistorico();
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
                            if (Equals(cmbStatus.Text, "AGUARDANDO PEÇA"))
                            {
                                mail.Body += "\nEntre em contato com nossa equipe para mais informações sobre novas peças.";
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
                }
                if (Equals(cmbStatus.Text, "AGUARDANDO PEÇA"))
                {
                    FRM_EmitirOficio frm_oficio = new FRM_EmitirOficio(txtMaquina.Text, cmbDepartamento.Text);
                    frm_oficio.ShowDialog();
                }
                this.Close();
                
            }
            else
            {
                txtMsg.Visible = true;
            }
            
        }

        private void txtSolucao_Enter(object sender, EventArgs e)
        {
            txtMsg.Visible = false;
        }

        private void FRM_Procedimentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_osLocal.carregarOcorrencias();
            frm_osLocal.txtFiltro.Text = "";
        }

        private void Bloquear(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
