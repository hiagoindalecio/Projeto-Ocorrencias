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
using System.Security.Cryptography;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
            Parametros();
            if (rbnExterno.Checked)
            {
                clsDados.PegarDiretorioExterno();
            }
            else
            {
                clsDados.PegarDiretorioInterno();
            }
            string result = clsDados.BuscarDados();
            if (Equals(result, "Os dados de conexão não foram encontrados!"))
            {
                MessageBox.Show(result + "\nUtilize o botão de configuração para preencher os dados.");
                btnConfig.Visible = true;
            }
        }

        public string GetVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver;
                ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            else
                return "Not Published";
        }

        private void Parametros()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var titleAttribute = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false).FirstOrDefault() as System.Reflection.AssemblyTitleAttribute;
            var title = titleAttribute.Title;
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            lblName.Text = "by Hiago Indalécio";
            string version = GetVersion();
            lblVersion.Text = (string.Format(title + "\nVersion: {0}", version));
            txtLogin.CharacterCasing = CharacterCasing.Lower;
            txtSenha.UseSystemPasswordChar = true;
            txtServerLogin.Clear();
            btnConfig.Visible = false;
            grbConfig.Visible = false;
            txtLogin.Focus();
            /*txtIp.Text = "187.51.2.4";
            txtDb.Text = "db_ocorrencia";
            txtPort.Text = "3306";
            txtServerLogin.Text = "ocorrencia";
            txtServerPwd.Text = "ocorrencia2020";*/
        }

        private void lblOlho_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == false)
            {
                txtSenha.UseSystemPasswordChar = true;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = false;
            } 
        }
        public String criptografarSenha(string senha)
        {
            var stringHash = "";
            try
            {
                UnicodeEncoding objUE = new UnicodeEncoding();
                byte[] hashBytes, messageBytes = objUE.GetBytes(senha);

                SHA512Managed objSM = new SHA512Managed();
                

                hashBytes = objSM.ComputeHash(messageBytes);

                foreach(byte b in hashBytes)
                {
                    stringHash += String.Format("{0:x2}", b);
                }
            }
            catch(Exception e)
            {
                stringHash = e.Message;
            }
            return stringHash;

        }

        private void Logar()
        {
            try
            {
                clsUsuario obj_usuario = new clsUsuario();
                obj_usuario.Ds_login = txtLogin.Text;
                obj_usuario.Ds_senha = criptografarSenha(txtSenha.Text);
                obj_usuario.AutenticarUser();

                if (Equals(obj_usuario.ds_msg, ""))
                {
                    FRM_Principal formP = new FRM_Principal(obj_usuario.Id_usuario, this);
                    formP.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(obj_usuario.ds_msg);
                    txtLogin.Clear();
                    txtSenha.Clear();
                    txtLogin.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível se conectar ao banco!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void Logar(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Logar();
            }
        }

        public void btnConfig_Click(object sender, EventArgs e)
        {
            if (grbConfig.Visible)
            {
                picBox.Visible = true;
                grbConfig.Visible = false;
            }
            else
            {
                picBox.Visible = false;
                grbConfig.Visible = true;
            }
        }

        public string SalvarCnx()
        {
            string ds_msg;
            try
            {
                clsDados.IpCnx = txtIp.Text;
                clsDados.PortCnx = txtPort.Text;
                clsDados.NameDb = txtDb.Text;
                clsDados.LoginCnx = txtServerLogin.Text;
                clsDados.SenhaCnx = txtServerPwd.Text;
                ds_msg = "Conexão salva com sucesso!";
            }
            catch
            {
                ds_msg = "Não possível salvar os dados de conexão!";
            }
            picBox.Visible = true;
            grbConfig.Visible = false;
            return ds_msg;
        }

        private void btnSalvarCnx_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SalvarCnx());
        }

        private void EnterBtnConfig(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                picBox.Visible = true;
            }
        }

        private void AlternarServer(object sender, EventArgs e)
        {
            if (rbnExterno.Checked)
            {
                clsDados.PegarDiretorioExterno();
            }
            else
            {
                clsDados.PegarDiretorioInterno();
            }
            string result = clsDados.BuscarDados();
            if (Equals(result, "Os dados de conexão não foram encontrados!"))
            {
                MessageBox.Show(result + "\nUtilize o botão de configuração para preencher os dados.");
                btnConfig.Visible = true;
            }
        }

    }
}
