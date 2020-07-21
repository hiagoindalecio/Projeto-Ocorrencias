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
    public partial class FRM_EditarResp : Form
    {
        FRM_Config form_config;
        int idUsuario;
        ListView lstResponsavel;
        public FRM_EditarResp(FRM_Config frm_config, int idUser, ListView lstResponsaveis)
        {
            InitializeComponent();
            form_config = frm_config;
            idUsuario = idUser;
            lstResponsavel = lstResponsaveis;
            txtNome.Enabled = false;
            carregarUser(idUsuario);
            carregarDepartamento();
        }

        private void carregar(object sender, FormClosedEventArgs e)
        {
            form_config.carregarConfigs();
            form_config.carregarDepartamentos();
            form_config.carregarUsers();
        }

        private void carregarUser(int idUsuario)
        {
            clsUsuario objUser = new clsUsuario();
            objUser.Id_usuario = idUsuario;
            objUser.getUserById();
            txtNome.Text = objUser.Nm_Usuario;
        }

        private void carregarDepartamento()
        {
            cmbDepartamento.Items.Clear();
            int i, idDept;
            bool j;
            clsDepartamento obj_dept = new clsDepartamento();
            MySqlDataReader sql_dr = obj_dept.carregarDeptByName("");
            //jogando os departamentos no combo box
            while (sql_dr.Read())
            {
                j = false;
                for (i = 0; i < lstResponsavel.Items.Count; i++)
                {
                    if (Equals(lstResponsavel.Items[i].Text, sql_dr["nm_departamento"].ToString()))
                    {
                        j = true;
                    }
                }
                if (!j)
                {
                    cmbDepartamento.Items.Add(sql_dr["nm_departamento"].ToString());
                }
            }
            clsResponsaveis objResp = new clsResponsaveis();
            sql_dr = objResp.getRespByIdUser(idUsuario);
            if (sql_dr.Read())
            {
                idDept = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                obj_dept.Id_departamento = idDept;
                obj_dept.carregarDeptByID();
                cmbDepartamento.Items.Add(obj_dept.Nm_departamento);
            }
            cmbDepartamento.SelectedItem = cmbDepartamento.Items[cmbDepartamento.Items.Count - 1];
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clsResponsaveis objResp = new clsResponsaveis();
            objResp.Id_usuario = idUsuario;
            clsDepartamento objDept = new clsDepartamento();
            MySqlDataReader sql_dr = objDept.carregarDeptByName(cmbDepartamento.Text);
            if (sql_dr.Read())
            {
                objResp.Id_Departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
            }
            objResp.update();
            MessageBox.Show(objResp.ds_msg);
            if (Equals(objResp.ds_msg, "Responsável atualizado com sucesso!"))
            {
                this.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            clsResponsaveis objResp = new clsResponsaveis();
            objResp.Id_usuario = idUsuario;
            clsDepartamento objDept = new clsDepartamento();
            MySqlDataReader sql_dr = objDept.carregarDeptByName(cmbDepartamento.Text);
            if (sql_dr.Read())
            {
                objResp.Id_Departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
            }
            objResp.delete();
            MessageBox.Show(objResp.ds_msg);
            if (Equals(objResp.ds_msg, "Responsável deletado com sucesso!"))
            {
                this.Close();
            }
        }
    }
}
