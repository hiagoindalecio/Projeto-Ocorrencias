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
    public partial class FRM_Atendimento : Form
    {
        private static FRM_Atendimento instance;
        public int id_user;
        public static FRM_Atendimento Instance(int id_usuario)
        {
            if (instance == null)
            {
                instance = new FRM_Atendimento(id_usuario);
            }
            return instance;
        }

        private void FRM_Atendimento_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public FRM_Atendimento(int id_usuario)
        {
            InitializeComponent();
            lblObrig1.Visible = false;
            lblObrig2.Visible = false;
            lblObrig3.Visible = false;
            lblObrig4.Visible = false;
            lblObrig5.Visible = false;
            Parametros();
            carregarDepartamentos();
            this.Top = 60;
            this.Left = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Height = 750;
            id_user = id_usuario;
        }

        public void Parametros()
        {
            txtNome.MaxLength = 30;
            txtMaquina.MaxLength = 30;
            txtProblema.MaxLength = 200;
            txtSolucao.MaxLength = 200;
        }

        public void carregarDepartamentos()
        {
            cmbDepartamento.Items.Clear();
            clsDepartamento obj_dept = new clsDepartamento();
            MySqlDataReader sql_dr = obj_dept.carregarDeptByName("");
            //jogando os departamentos no combo box
            while (sql_dr.Read())
            {
                cmbDepartamento.Items.Add(sql_dr["nm_departamento"].ToString());
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            lblObrig1.Visible = false;
            lblObrig2.Visible = false;
            lblObrig3.Visible = false;
            lblObrig4.Visible = false;
            lblObrig5.Visible = false;
            if (Equals(cmbDepartamento.Text, "") || Equals(txtNome.Text, "") || Equals(txtMaquina.Text, "") || Equals(txtProblema.Text, "") || Equals(txtSolucao.Text, ""))
            {
                if (Equals(cmbDepartamento.Text, ""))
                    lblObrig2.Visible = true;
                if (Equals(txtNome.Text, ""))
                    lblObrig1.Visible = true;
                if (Equals(txtMaquina.Text, ""))
                    lblObrig3.Visible = true;
                if (Equals(txtProblema.Text, ""))
                    lblObrig4.Visible = true;
                if (Equals(txtSolucao.Text, ""))
                    lblObrig5.Visible = true;
            }
            else
            {
                clsAtendimento objAtendimento = new clsAtendimento();
                clsDepartamento objDept = new clsDepartamento();
                MySqlDataReader sql_dr = objDept.carregarDeptByName(cmbDepartamento.Text);
                if (sql_dr.Read())
                {
                    objAtendimento.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"]);
                }
                objAtendimento.Id_user = id_user;
                objAtendimento.Nm_maquina = txtMaquina.Text;
                objAtendimento.Nm_solicitante = txtNome.Text;
                objAtendimento.Problema = txtProblema.Text;
                objAtendimento.Solucao = txtSolucao.Text;
                MessageBox.Show(objAtendimento.Insert());
            }
            cmbDepartamento.SelectedIndex = -1;
            txtNome.Text = "";
            txtMaquina.Text = "";
            txtProblema.Text = "";
            txtSolucao.Text = "";
        }

        private void AbrirTeamViewer(object sender, EventArgs e)
        {
            try
            {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe");
            }
            catch
            {
                MessageBox.Show("Não foi possível localizar o TeamViewer em sua máquina!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirDameWare(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\DameWare Development\\DameWare Mini Remote Control\\DWRCC.exe");
            }
            catch
            {
                MessageBox.Show("Não foi possível localizar o DameWare na sua máquina!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
