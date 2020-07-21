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
using System.Data.SqlClient;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Config : Form
    {
        private static FRM_Config instance;

        public static FRM_Config Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Config();
            }
            return instance;
        }

        private void FRM_Config_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public FRM_Config()
        {
            InitializeComponent();
            lblObrig1.Visible = false;
            lblObrig2.Visible = false;
            carregarConfigs();
            carregarDepartamentos();
            carregarUsers();
            CarregarCnx();
            this.Top = 60;
            this.Left = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Height = 750;
        }

        private void CarregarCnx()
        {
            txtIp.Text = clsDados.IpCnx;
            txtDb.Text = clsDados.NameDb;
            txtLogin.Text = clsDados.LoginCnx;
            txtPort.Text = clsDados.PortCnx;
            txtSenha.Text = clsDados.SenhaCnx;
        }

        public string SalvarCnx()
        {
            string ds_msg;
            try
            {
                clsDados.IpCnx = txtIp.Text;
                clsDados.PortCnx = txtPort.Text;
                clsDados.NameDb = txtDb.Text;
                clsDados.LoginCnx = txtLogin.Text;
                clsDados.SenhaCnx = txtSenha.Text;
                ds_msg = "Conexão salva com sucesso!";
            }
            catch
            {
                ds_msg = "Não possível salvar os dados de conexão!";
            }
            return ds_msg;
        }

        public void ValidarIpPort(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        public void carregarDepartamentos()
        {
            cmbDepartamento.Items.Clear();
            int i;
            bool j;
            clsDepartamento obj_dept = new clsDepartamento();
            MySqlDataReader sql_dr = obj_dept.carregarDeptByName("");
            //jogando os departamentos no combo box
            while (sql_dr.Read())
            {
                j = false;
                for (i = 0; i < lstResponsaveis.Items.Count; i++)
                {
                    if(Equals(lstResponsaveis.Items[i].Text, sql_dr["nm_departamento"].ToString()))
                    {
                        j = true;
                    }
                }
                if (!j)
                {
                    cmbDepartamento.Items.Add(sql_dr["nm_departamento"].ToString());
                }
            }
        }

        public void carregarUsers()
        {
            cmbUsers.Items.Clear();
            clsUsuario obj_user = new clsUsuario();
            MySqlDataReader sql_dr = obj_user.getUserByFiltro("", "order by nm_usuario");
            while (sql_dr.Read())
            {
                bool v = Convert.ToBoolean(sql_dr["ds_ativo"]);
                if (v)
                {
                    cmbUsers.Items.Add(sql_dr["nm_usuario"].ToString());
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int idUser = 0, idDept = 0;
            if (Equals(cmbDepartamento.Text, "") || Equals(cmbUsers.Text, ""))
            {
                if (Equals(cmbDepartamento.Text, ""))
                    lblObrig2.Visible = true;
                else if(Equals(cmbUsers.Text, ""))
                    lblObrig1.Visible = true;
            }
            else
            {
                clsUsuario objUser = new clsUsuario();
                clsDepartamento objDept = new clsDepartamento();
                MySqlDataReader sql_dr = objUser.getUserByFiltro(cmbUsers.Text, "");
                if (sql_dr.Read())
                {
                    idUser = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                }
                sql_dr = objDept.carregarDeptByName(cmbDepartamento.Text);
                if (sql_dr.Read())
                {
                    idDept = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                }
                clsResponsaveis objResponsaveis = new clsResponsaveis();
                objResponsaveis.Id_usuario = idUser;
                objResponsaveis.Id_Departamento = idDept;
                objResponsaveis.insert();
                MessageBox.Show(objResponsaveis.ds_msg);
                lblObrig1.Visible = false;
                lblObrig2.Visible = false;
                carregarConfigs();
                carregarDepartamentos();
                carregarUsers();
            }
        }

        public void carregarConfigs()//Carregar lista com configurações atuais
        {
            lstResponsaveis.Items.Clear();//limpar lista
            clsResponsaveis objReponsavel = new clsResponsaveis();
            MySqlDataReader sql_dr;
            string order = ("ORDER BY id_usuario");
            sql_dr = objReponsavel.getList(order);
            while (sql_dr.Read())
            {
                //jogar os dados no listview
                clsUsuario objUser = new clsUsuario();
                objUser.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"]);
                objUser.getUserById();
                clsDepartamento objDept = new clsDepartamento();
                objDept.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"]);
                objDept.carregarDeptByID();
                ListViewItem instancia = new ListViewItem(objDept.Nm_departamento);
                instancia.SubItems.Add(objUser.Nm_Usuario);
                lstResponsaveis.Items.Add(instancia);
            }
            clsConexao objConexao = new clsConexao();

            txtIp.Text = objConexao.ipServer;
            txtPort.Text = objConexao.portServer;
            txtDb.Text = objConexao.nameDb;
            txtLogin.Text = objConexao.loginServer;
            txtSenha.Text = objConexao.senhaServer;
            
        }

        private void EditarResp(object sender, MouseEventArgs e)
        {
            string valor_sl = lstResponsaveis.SelectedItems[0].SubItems[1].Text;
            int id = 0;
            clsUsuario objUser = new clsUsuario();
            MySqlDataReader sql_dr = objUser.getUserByFiltro(valor_sl, " ORDER BY NM_USUARIO, DS_PERFIL");
            if (sql_dr.Read())
            {
                id = Convert.ToInt32(sql_dr["id_usuario"].ToString());
            }
            FRM_EditarResp frm_editResp = new FRM_EditarResp(this, id, lstResponsaveis);
            frm_editResp.ShowDialog();
        }

        private void btnSalvarCnx_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SalvarCnx());
        }

        private void ValidarIpPort()
        {

        }



    }
}
