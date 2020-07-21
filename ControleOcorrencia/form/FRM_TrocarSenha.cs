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
    public partial class FRM_TrocarSenha : Form
    {
        int id_userLogado;
        public FRM_TrocarSenha(int id_user)
        {
            InitializeComponent();
            id_userLogado = id_user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (Equals(txtSenha.Text, "") || Equals(txtConfirmar.Text, ""))
            {
                if (Equals(txtSenha.Text, ""))
                {
                    lblOSenha.Visible = true;
                }
                else
                {
                    lblOSenha.Visible = false;
                }
                if (Equals(txtConfirmar.Text, ""))
                {
                    lblOConfirmar.Visible = true;
                }
                else
                {
                    lblOConfirmar.Visible = false;
                }
            }
            else
            {
                lblOSenha.Visible = false;
                lblOConfirmar.Visible = false;
                if (Equals(txtSenha.Text, txtConfirmar.Text))
                {
                    clsUsuario objUser = new clsUsuario();
                    objUser.Id_usuario = id_userLogado;
                    objUser.getUserById();
                    objUser.Ds_senha = criptografarSenha(txtSenha.Text);
                    objUser.update();
                    MessageBox.Show(objUser.ds_msg);
                    lblSenhasIgual.Visible = false;
                    this.Close();
                }
                else
                {
                    lblSenhasIgual.Visible = true;
                }
            }
        }
    }
}
