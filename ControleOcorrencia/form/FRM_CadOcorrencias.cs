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
    public partial class FRM_CadOcorrencias : Form
    {

        FRM_Ocorrencias form_lstOcorrenciasLocal;

        clsUsuario objUsuarioLogado = new clsUsuario();

        public FRM_CadOcorrencias(FRM_Ocorrencias form_lstOcorrencias, int id_Usuario)
        {
            InitializeComponent();
            form_lstOcorrenciasLocal = form_lstOcorrencias;
            //exibe os departamentos no cmb
            carregarDepartamentos();
            //carrega as informações do usuario logado
            objUsuarioLogado.Id_usuario = id_Usuario;
            objUsuarioLogado.getUserById();
            cmbDepartamento.SelectedIndex = 0;
            

            if (Equals(objUsuarioLogado.Ds_perfil, "VISUALIZADOR"))
            {
                cmbDepartamento.Enabled = false;
                txtMaquina.Enabled = false;
                txtDefeito.Enabled = false;
                txtEntrada.Enabled = false;
                btnSalvar.Visible = false;
            }
            else
            {
                cmbDepartamento.Enabled = true;
                txtMaquina.Enabled = true;
                txtDefeito.Enabled = true;
                txtEntrada.Enabled = true;
                 btnSalvar.Visible = true;
            }
           
            parametros();
            
        }
        public void parametros()//deixando as informações digitadas em maiusculo
        {
            txtMaquina.CharacterCasing = CharacterCasing.Upper;
            txtDefeito.CharacterCasing = CharacterCasing.Upper;
            txtDefeito.MaxLength = 200;
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
            if (Equals(txtDefeito.Text, "") || Equals(txtMaquina.Text, ""))
            {
                if (Equals(txtDefeito.Text, ""))
                {
                    lblODefeito.Visible = true;
                }
                else
                {
                    lblODefeito.Visible = false;
                }
                if (Equals(txtMaquina.Text, ""))
                {
                    lblOMaq.Visible = true;
                }
                else
                {
                    lblOMaq.Visible = false;
                }
            }
            else
            {
                clsDepartamento objDepartamento = new clsDepartamento();
                //obtendo informações do departamento
                MySqlDataReader sql_dr = objDepartamento.carregarDeptByName(cmbDepartamento.Text);            
                if (sql_dr.Read())
                {
                    objDepartamento.Id_departamento = Convert.ToInt32(sql_dr["ID_DEPARTAMENTO"].ToString());
                }
                //obtendo informações da ocorrencia do form
                clsOcorrencias objOcorrencia = new clsOcorrencias();
                if (!Equals(txtPatrimonio.Text, ""))
                    objOcorrencia.Patrimonio_os = txtPatrimonio.Text;
                else
                    objOcorrencia.Patrimonio_os = null;
                objOcorrencia.Id_departamento = objDepartamento.Id_departamento;
                objOcorrencia.Ds_Defeito = txtDefeito.Text;
                try
                {
                    objOcorrencia.Dt_entrada = Convert.ToDateTime(txtEntrada.Text);
                }
                catch {
                    objOcorrencia.Dt_entrada = Convert.ToDateTime(txtEntrada.Text);
                }
                objOcorrencia.Nm_maquina = txtMaquina.Text;
                objOcorrencia.Ds_status = "ABERTA";
                //caso esteja salvando uma nova ocorrencia pego registra do id de que está logado
                objOcorrencia.Id_usuario = objUsuarioLogado.Id_usuario;
                objOcorrencia.Ds_status = "ABERTA";
                objOcorrencia.insert();
                MessageBox.Show(objOcorrencia.ds_msg);

                ImprimirQRCode();
            }
        }
        private void ImprimirQRCode()
        {
            DialogResult result = MessageBox.Show("IMPRIMIR QRCODE DA ORDEM DE SERVIÇO?", "ALERTA",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //code for Yes
                FRM_EmitirQRCode qrcode = new FRM_EmitirQRCode(0);
                qrcode.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                //code for No
            } 
            this.Close();
        }

        private void FRM_CadOcorrencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_lstOcorrenciasLocal.carregarOcorrencias();
            form_lstOcorrenciasLocal.txtFiltro.Text = "";
        }

    }
}
