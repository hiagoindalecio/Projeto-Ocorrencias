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
    public partial class FRM_Users : Form
    {
        private static FRM_Users instance;

        public static FRM_Users Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Users();
            }
            return instance;
        }

        private void FRM_Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
        
        public string orderBy = "";

        public FRM_Users()
        {
            InitializeComponent();
            rbtAtivos.Checked = true;
            //this.WindowState = FormWindowState.Maximized;
            this.Top = 60;
            this.Left = 0;
            //.Bottom = 60;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Height = 620;
            txtFiltro.CharacterCasing = CharacterCasing.Upper;
            txtFiltro.Focus();
            orderBy = "ORDER BY NM_USUARIO, DS_PERFIL";
            carregarUser();
        }

        public void carregarUser()
        {
            lstUsers.Items.Clear();
            clsUsuario objUser = new clsUsuario();
            MySqlDataReader sql_dr = objUser.getUserByFiltro(txtFiltro.Text, orderBy);

            while (sql_dr.Read())
            {
                //colocando os dados do list view
                ListViewItem instancia_lista = new ListViewItem(sql_dr["nm_usuario"].ToString());
                instancia_lista.SubItems.Add(sql_dr["ds_perfil"].ToString());
                if (rbtAtivos.Checked)
                {
                    if (Convert.ToInt32(sql_dr["ds_ativo"]) == 1)
                        lstUsers.Items.Add(instancia_lista);
                }
                else
                {
                    if (Convert.ToInt32(sql_dr["ds_ativo"]) == 0)
                        lstUsers.Items.Add(instancia_lista);
                }
                //lstUsers.Items.Add(instancia_lista);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CadUser form_user = new FRM_CadUser(this, 0);
            form_user.ShowDialog();
        }

        private void lstUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (Equals(e.Column.ToString(), "0"))
            {
                orderBy = " ORDER BY NM_USUARIO, DS_PERFIL";
            }
            if (Equals(e.Column.ToString(), "1"))
            {
                orderBy = " ORDER BY DS_PERFIL, NM_USUARIO";
            }
            carregarUser();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            carregarUser();
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            string vl_select = lstUsers.SelectedItems[0].SubItems[0].Text;
            int id = 0;
            clsUsuario objUser = new clsUsuario();
            MySqlDataReader sql_dr = objUser.getUserByFiltro(vl_select, orderBy);

            if (sql_dr.Read())
            {
                id = Convert.ToInt32(sql_dr["id_usuario"].ToString());
            }

            if (vl_select == "")
            {
                MessageBox.Show("Por favor, selecione um campo válido!");
            }
            else
            {
                FRM_CadUser formCadUser = new FRM_CadUser(this, id);
                formCadUser.ShowDialog();
            }
        }

        private void fecharUsers(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_UsuariosClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Filtrar(object sender, EventArgs e)
        {
            carregarUser();
        }

    }
}
