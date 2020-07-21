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
using System.Security.Cryptography;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_CadUser : Form
    {
        FRM_Users frm_lstUserLocal;
        int id_usuarioLocal;
        public FRM_CadUser(FRM_Users frm_lstUser, int id_usuario)
        {
            InitializeComponent();
            frm_lstUserLocal = frm_lstUser;
            id_usuarioLocal = id_usuario;
            rdbPadrao.Checked = true;
            txtNome.CharacterCasing = CharacterCasing.Upper;
            cmbPerfil.SelectedIndex = 0;
            CarregarDept();
            if(id_usuarioLocal != 0)
            {
                VisualizarUser();
            }
           
        }
        private void CarregarDept()
        {
            clsDepartamento clsDept = new clsDepartamento();
            MySqlDataReader sql_dr = clsDept.carregarDeptByName("");

            while (sql_dr.Read())
            {
                cmbDept.Items.Add(sql_dr["nm_departamento"].ToString());
            }
            cmbDept.SelectedIndex = 0;
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
        public void VisualizarUser()
        {
            clsUsuario objUser = new clsUsuario();
            objUser.Id_usuario = id_usuarioLocal;
            objUser.getUserById();
            txtNome.Text = objUser.Nm_Usuario;
            txtLogin.Text = objUser.Ds_login;
            cmbPerfil.Text = objUser.Ds_perfil;
            txtEmail.Text = objUser.email;
            clsDepartamento clsDept = new clsDepartamento();
            clsDept.Id_departamento = objUser.Id_Departamento;
            clsDept.carregarDeptByID();
            cmbDept.SelectedItem = clsDept.Nm_departamento;
            if (objUser.Ds_ativo == 1)
                cbxAtivo.Checked = true;
            rdbNP.Checked = true;
            txtSenha.Text = "**";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbNP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNP.Checked == true)
            {
                txtSenha.Enabled = true;
            }
            else
            {
                txtSenha.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temArroba = txtEmail.Text.Contains("@"), temPonto = txtEmail.Text.Contains(".");
            if (Equals(txtNome.Text, "") || Equals(txtLogin.Text, "") || (rdbNP.Checked == true && Equals(txtSenha.Text, "")) || Equals(txtEmail.Text, ""))
            {
                //caso algo esteja faltando
                if (Equals(txtNome.Text, ""))
                {
                    lblONome.Visible = true;
                }
                else
                {
                    lblONome.Visible = false;
                }
                if (Equals(txtLogin.Text, ""))
                {
                    lblOLogin.Visible = true;
                }
                else
                {
                    lblOLogin.Visible = false;
                }
                if (rdbNP.Checked == true && Equals(txtSenha.Text, ""))
                {
                    lblOSenha.Visible = true;
                }
                else
                {
                    lblOSenha.Visible = false;
                }
                if (Equals(txtEmail.Text, ""))
                {
                    lblOEmail.Visible = true;
                }
                else
                {
                    lblOEmail.Visible = false;
                }
            }
            else if(!temArroba || !temPonto)
            {
                MessageBox.Show("O campo email está inválido! Favor revisar a informação.", "ERRO");
            }
            else
            {
                clsDepartamento clsDept = new clsDepartamento();
                MySqlDataReader sql_dr = clsDept.carregarDeptByName(cmbDept.Text);

                if (sql_dr.Read())
                {
                    clsDept.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                }
                
                clsUsuario objUsuario = new clsUsuario();
                
                objUsuario.Id_usuario = id_usuarioLocal;
                if (id_usuarioLocal != 0)//salva
                {
                    objUsuario.getUserById();                    
                }
                objUsuario.Id_Departamento = clsDept.Id_departamento;
                objUsuario.Nm_Usuario = txtNome.Text;
                objUsuario.Ds_login = txtLogin.Text;
                objUsuario.Ds_perfil = cmbPerfil.Text;
                objUsuario.email = txtEmail.Text;
                if (cbxAtivo.Checked)
                {
                    objUsuario.Ds_ativo = 1;
                }
                else
                {
                    objUsuario.Ds_ativo = 0;
                }

                if(rdbPadrao.Checked == true)
                {
                    objUsuario.Ds_senha = criptografarSenha("10203040");
                }
                else
                {
                    if(!Equals(txtSenha.Text, "**"))
                    {
                        objUsuario.Ds_senha = criptografarSenha(txtSenha.Text);
                    }    
                }
                
                //tudo certo
                if (id_usuarioLocal == 0)//salva
                {
                    objUsuario.insert();
                }
                else//atualiza
                {
                    objUsuario.update();
                }
                MessageBox.Show(objUsuario.ds_msg);
                this.Close();
            }
        }

        private void FRM_CadUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_lstUserLocal.carregarUser();
            frm_lstUserLocal.txtFiltro.Text = "";
        }
    }
}
