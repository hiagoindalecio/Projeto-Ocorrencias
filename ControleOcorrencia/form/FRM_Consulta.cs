using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Consulta : Form
    {
        private static FRM_Consulta instance;

        public static FRM_Consulta Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Consulta();
            }
            return instance;
        }

        private void FRM_Consulta_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public FRM_Consulta()
        {
            InitializeComponent();
            this.Top = 60;
            this.Left = 0;
            //.Bottom = 60;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Height = 750;
            InserirUrl();
            txtPesquisa.Focus();
        }

        private void InserirUrl()
        {
            try
            {
                webRelatorio.Navigate("LINK DO SITE");
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void Pesquisar(object sender, EventArgs e)
        {
            webRelatorio.Navigate("LINK DO SITE" + txtPesquisa.Text);
            txtPesquisa.Text = "";
        }

        private void PesquisarEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                webRelatorio.Navigate("LINK DO SITE" + txtPesquisa.Text);
                txtPesquisa.Text = "";
            }
        }

    }
}
