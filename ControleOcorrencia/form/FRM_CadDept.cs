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
    public partial class FRM_CadDept : Form
    {
        int op;
        int id_departamento;
        FRM_Depts form_deptsLocal;
        public FRM_CadDept(int operacao, int id_dept, FRM_Depts form_depts)
        {
            InitializeComponent();
            id_departamento = id_dept;
            op = operacao;
            form_deptsLocal = form_depts;
            txtDept.CharacterCasing = CharacterCasing.Upper;
            if(id_dept != 0)
            {
                VisualizarDept();
            }
        }
        private void VisualizarDept()
        {
            clsDepartamento objDepartamento = new clsDepartamento();
            objDepartamento.Id_departamento = id_departamento;
            objDepartamento.carregarDeptByID();
            txtDept.Text = objDepartamento.Nm_departamento;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Equals(txtDept.Text, ""))
            {
                lblOMaq.Visible = true;
            }
            else
            {
                clsDepartamento objDept = new clsDepartamento();
                objDept.Nm_departamento = txtDept.Text;
                if (op == 0)//insert
                {
                    objDept.insert();
                }
                else//update
                {
                    objDept.Id_departamento = id_departamento;
                    objDept.update();
                }
                MessageBox.Show(objDept.ds_msg);
                this.Close();
            }
        }

        private void FRM_CadDept_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_deptsLocal.carregarDepartamentos();
            form_deptsLocal.txtFiltro.Text = "";
        }
    }
}
