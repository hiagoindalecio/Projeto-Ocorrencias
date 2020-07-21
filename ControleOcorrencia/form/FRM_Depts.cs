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
    public partial class FRM_Depts : Form
    {

        private static FRM_Depts instance;

        public static FRM_Depts Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Depts();
            }
            return instance;
        }

        private void FRM_Depts_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public FRM_Depts()
        {
            InitializeComponent();
            this.Top = 60;
            this.Left = 0;
            //.Bottom = 60;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Height = 620;
            carregarDepartamentos();
            txtFiltro.CharacterCasing = CharacterCasing.Upper;
            txtFiltro.Focus();
        }
        public void carregarDepartamentos()
        {
            lstDept.Items.Clear();
            clsDepartamento objDepartamento = new clsDepartamento();
            MySqlDataReader sql_dr = objDepartamento.carregarDeptByName(txtFiltro.Text);

            while (sql_dr.Read())
            {
                //colocando os dados do list view
                ListViewItem instancia_lista = new ListViewItem(sql_dr["nm_departamento"].ToString());
                lstDept.Items.Add(instancia_lista);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CadDept form_cad = new FRM_CadDept(0,0, this);
            form_cad.ShowDialog();
        }

        private void visualizarDept(object sender, EventArgs e)
        {
            string vl_select = lstDept.SelectedItems[0].SubItems[0].Text;
            int id = 0;
            clsDepartamento objDept = new clsDepartamento();
            MySqlDataReader sql_dr = objDept.carregarDeptByName(vl_select);

            if(sql_dr.Read())
            {
                id = Convert.ToInt32(sql_dr["id_departamento"].ToString());
            }

            if (vl_select == "")
            {
                MessageBox.Show("Por favor, selecione um campo válido!");
            }
            else
            {
                FRM_CadDept formCadDept = new FRM_CadDept(1, id, this);
                formCadDept.ShowDialog();

            }
        }

        private void Filtrar(object sender, EventArgs e)
        {
            carregarDepartamentos();
        }

        private void fecharDeps(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
