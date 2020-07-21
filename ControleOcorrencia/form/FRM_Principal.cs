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
    public partial class FRM_Principal : Form
    {
        FRM_Login form_loginLocal;
        int id_userLogado;
        public FRM_Principal(int id_usuario, FRM_Login form_login)
        {
            InitializeComponent();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var titleAttribute = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false).FirstOrDefault() as System.Reflection.AssemblyTitleAttribute;
            var title = titleAttribute.Title;
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVersion.Text = "by Hiago Indalécio";
            string version = GetVersion();
            lblVersion.Text = (string.Format(title + "\nVersion: {0}", version));
            id_userLogado = id_usuario;
            form_loginLocal = form_login;
            ExibirMenu(id_usuario);
            VerificarSenhaPadrao();
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

        public String criptografarSenha(string senha)
        {
            var stringHash = "";
            try
            {
                UnicodeEncoding objUE = new UnicodeEncoding();
                byte[] hashBytes, messageBytes = objUE.GetBytes(senha);

                SHA512Managed objSM = new SHA512Managed();


                hashBytes = objSM.ComputeHash(messageBytes);

                foreach (byte b in hashBytes)
                {
                    stringHash += String.Format("{0:x2}", b);
                }
            }
            catch (Exception e)
            {
                stringHash = e.Message;
            }
            return stringHash;

        }
        private void VerificarSenhaPadrao()
        {
            clsUsuario objUser = new clsUsuario();
            objUser.Id_usuario = id_userLogado;
            objUser.getUserById();

            if(Equals(objUser.Ds_senha, criptografarSenha("10203040")))
            {
                FRM_TrocarSenha formTS = new FRM_TrocarSenha(id_userLogado);
                formTS.MdiParent = this;
                formTS.Show();
            }
        }
        private void ExibirMenu(int id_user)
        {
            clsUsuario objUser = new clsUsuario();
            objUser.Id_usuario = id_user;
            objUser.getUserById();
            if (Equals(objUser.Ds_perfil, "OPERADOR"))
            {
                mOcorrencia.Visible = true;
                mDept.Visible = false;
                mUser.Visible = false;
                mConsulta.Visible = true;
                mConfig.Visible = false;
                mOFF.Visible = true;
                mRelatorio.Visible = false;
            }
            if (Equals(objUser.Ds_perfil, "VISUALIZADOR"))
            {
                mOcorrencia.Visible = true;
                mDept.Visible = false;
                mUser.Visible = false;
                mConsulta.Visible = true;
                mConfig.Visible = false;
                mOFF.Visible = true;
                mRelatorio.Visible = false;
            }
            if (Equals(objUser.Ds_perfil, "TÉCNICO"))
            {
                mOcorrencia.Visible = true;
                mDept.Visible = false;
                mUser.Visible = false;
                mConsulta.Visible = true;
                mConfig.Visible = false;
                mOFF.Visible = true;
                mRelatorio.Visible = true;
            }
            if (Equals(objUser.Ds_perfil, "ADMINISTRADOR"))
            {
                mOcorrencia.Visible = true;
                mDept.Visible = true;
                mUser.Visible = true;
                mConsulta.Visible = true;
                mConfig.Visible = true;
                mOFF.Visible = true;
                mRelatorio.Visible = true;
            }
            txtUserLogado.Text = objUser.Nm_Usuario;
        }
        private void ocorrênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            form_loginLocal.txtLogin.Text = "";
            form_loginLocal.txtSenha.Text = "";
            form_loginLocal.Show();
        }

        private void FRM_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_loginLocal.txtLogin.Text = "";
            form_loginLocal.txtSenha.Text = "";
            form_loginLocal.Show();

        }
            
        public void mOcorrencia_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Ocorrencias form_Ocorrencia = FRM_Ocorrencias.Instance(id_userLogado);
            form_Ocorrencia.MdiParent = this;
            form_Ocorrencia.Show();

        }

        public void mDept_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Depts form_Dept = FRM_Depts.Instance();
            form_Dept.MdiParent = this;
            form_Dept.Show();
        }

        public void mUser_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Users form_user = FRM_Users.Instance();
            form_user.MdiParent = this;
            form_user.Show();
        }

        public bool form_Ocorrecia { get; set; }

        public void mConfig_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Config form_config = FRM_Config.Instance();
            form_config.MdiParent = this;
            form_config.Show();
        }

        private void mRelatorio_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Relatorio_Mensal frm_rel = FRM_Relatorio_Mensal.Instance();
            frm_rel.MdiParent = this;
            frm_rel.Show();
        }

        private void mConsulta_Click_1(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Consulta form_consulta = FRM_Consulta.Instance();
            form_consulta.MdiParent = this;
            form_consulta.Show();
        }

        private void mAtendimento_Click(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Atendimento form_atendimento = FRM_Atendimento.Instance(id_userLogado);
            form_atendimento.MdiParent = this;
            form_atendimento.Show();
        }

    }
}
