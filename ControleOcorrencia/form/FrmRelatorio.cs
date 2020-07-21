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
    public partial class FRM_Relatorio : Form
    {
        public FRM_Relatorio()
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
                webRelatorio.Navigate("LINK");//Aqui fica o link do relatório(site de relatórios ainda não desenvolvido)
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void Pesquisar(object sender, EventArgs e)
        {
            webRelatorio.Navigate("www.capivari.sp.gov.br/os/index.php?parametro=" + txtPesquisa.Text);//Aqui fica o link do relatório + a pesquisa(site de relatórios ainda não desenvolvido)
            txtPesquisa.Text = "";
        }

        private void PesquisarEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                webRelatorio.Navigate("www.capivari.sp.gov.br/os/index.php?parametro=" + txtPesquisa.Text);//Aqui fica o link do relatório + a pesquisa(site de relatórios ainda não desenvolvido)
                txtPesquisa.Text = "";
            }
        }

    }
}
