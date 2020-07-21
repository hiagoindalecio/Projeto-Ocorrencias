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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Relatorio_Mensal : Form
    {
        private static FRM_Relatorio_Mensal instance;
        public static Document documento;
        public static FRM_Relatorio_Mensal Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Relatorio_Mensal();
            }
            return instance;
        }

        private void GerarPDF()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            string diretorio = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Relatorio-" + cmbMes.Text + "." + cmbAno.Text + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(diretorio, FileMode.Create));
            doc.Open();
            string dados = "";
            Paragraph title = new Paragraph(dados);
            title.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
            title.Alignment = Element.ALIGN_CENTER;
            Paragraph finalizacao = new Paragraph(dados);
            finalizacao.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, (int)System.Drawing.FontStyle.Italic);
            finalizacao.Alignment = Element.ALIGN_JUSTIFIED;
            title.Add("Relatório Mensal - " + cmbMes.Text + "/" + cmbAno.Text);
            doc.Add(title);
            Paragraph txtMaquinas = new Paragraph(dados);
            txtMaquinas.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10);
            txtMaquinas.Alignment = Element.ALIGN_JUSTIFIED;
            title.Clear();
            title.Add("\n\nMáquinas\n");
            doc.Add(title);
            for (int i = 0; i < lstMaquinas.Items.Count; i++)
            {
                txtMaquinas.Add("Nome Máquina: " + lstMaquinas.Items[i].Text + " | ");
                txtMaquinas.Add("Data entrada: " + lstMaquinas.Items[i].SubItems[1].Text + " | ");
                txtMaquinas.Add("Data Saída: " + lstMaquinas.Items[i].SubItems[2].Text + "\n");
            }
            doc.Add(txtMaquinas);
            finalizacao.Add(lblTotalMaquinas.Text);
            doc.Add(finalizacao);
            Paragraph txtAtendimento = new Paragraph(dados);
            txtAtendimento.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10);
            txtAtendimento.Alignment = Element.ALIGN_JUSTIFIED;
            title.Clear();
            title.Add("\n\nAtendimentos\n");
            doc.Add(title);
            for (int i = 0; i < lstAtendimento.Items.Count; i++)
            {
                txtAtendimento.Add("Nome Máquina: " + lstAtendimento.Items[i].Text + " | ");
                txtAtendimento.Add("Data: " + lstAtendimento.Items[i].SubItems[1].Text + " | ");
                txtAtendimento.Add("Solicitante: " + lstAtendimento.Items[i].SubItems[2].Text + "\n");
            }
            doc.Add(txtAtendimento);
            finalizacao.Clear();
            finalizacao.Add(lblTotalAtendimentos.Text);
            doc.Add(finalizacao);
            doc.Close();
            documento = doc;
        }

        private void FRM_Relatorio_Mensal_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public FRM_Relatorio_Mensal()
        {
            InitializeComponent();
            Parametros();
        }

        private void Parametros()
        {
            this.Top = 60;
            this.Left = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Height = 750;
            btnExportar.Visible = false;
        }

        public void CarregarMaquinas()
        {
            int quantasTotal = 0;
            string[] dt_entrada, dt_saida;
            lstMaquinas.Items.Clear();
            clsOcorrencias objOcorrencias = new clsOcorrencias();
            MySqlDataReader sql_dr;
            sql_dr = objOcorrencias.getOcorenciasByDate(cmbMes.Text, cmbAno.Text);
            while (sql_dr.Read())
            {
                ListViewItem instancia_lista = new ListViewItem(sql_dr["nm_maquina"].ToString());
                dt_entrada = sql_dr["dt_entrada"].ToString().Split(' ');
                instancia_lista.SubItems.Add(dt_entrada[0]);
                dt_saida = sql_dr["dt_saida"].ToString().Split(' ');
                instancia_lista.SubItems.Add(dt_saida[0]);
                lstMaquinas.Items.Add(instancia_lista);
                quantasTotal++;
            }
            lblTotalMaquinas.Text = "Total: " + quantasTotal + " máquinas foram registradas este mês.";
            int mes = Convert.ToInt32(cmbMes.Text), ano = Convert.ToInt32(cmbAno.Text);
            CarregarGraficoMaquinas(mes, ano, quantasTotal);
        }

        private void CarregarGraficoMaquinas(int mesSelecionado, int anoSelecionado, int quantasAtual)
        {
            this.chMaquinas.Series["meses"].Points.Clear();
            int quantasDois = 0, quantasTres = 0, quantasQuatro = 0, quantasCinco = 0;
            string mesBuscar = "";
            clsOcorrencias objOcorrencias = new clsOcorrencias();
            MySqlDataReader sql_dr;
            sql_dr = objOcorrencias.getOcorenciasByDate(cmbMes.Text, cmbAno.Text);
            int mes = mesSelecionado, ano = anoSelecionado;
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objOcorrencias.getOcorenciasByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasDois++;//Um mes atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objOcorrencias.getOcorenciasByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasTres++;//Dois meses atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objOcorrencias.getOcorenciasByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasQuatro++;//Três meses atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objOcorrencias.getOcorenciasByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasCinco++;//Quatro meses atrás
            }
            try
            {
                int i = 4;
                while (i >= 0)
                {
                    string nome;
                    nome = "Mês " + mesSelecionado;
                    if (mesSelecionado == 1)
                        mesSelecionado = 12;
                    else
                        mesSelecionado--;
                    int quantasMaquinas;
                    if (i == 4)
                        quantasMaquinas = quantasAtual;
                    else if (i == 3)
                        quantasMaquinas = quantasDois;
                    else if (i == 2)
                        quantasMaquinas = quantasTres;
                    else if (i == 1)
                        quantasMaquinas = quantasQuatro;
                    else
                        quantasMaquinas = quantasCinco;
                    this.chMaquinas.Series["meses"].Points.AddXY(nome, quantasMaquinas);
                    i--;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível encontrar os dados! \n" + e);
            }
        }

        public void CarregarAtendimentos()
        {
            int quantasTotal = 0;
            lstAtendimento.Items.Clear();
            clsAtendimento objAtendimento = new clsAtendimento();
            MySqlDataReader sql_dr;
            sql_dr = objAtendimento.getAtendimentoByDate(cmbMes.Text, cmbAno.Text);
            while (sql_dr.Read())
            {
                ListViewItem instancia_lista = new ListViewItem(sql_dr["nm_maquina"].ToString());
                instancia_lista.SubItems.Add(sql_dr["dt_atendimento"].ToString());
                instancia_lista.SubItems.Add(sql_dr["nm_solicitante"].ToString());
                lstAtendimento.Items.Add(instancia_lista);
                quantasTotal++;
            }
            lblTotalAtendimentos.Text = "Total: " + quantasTotal + " atendimentos foram registrados este mês.";
            int mes = Convert.ToInt32(cmbMes.Text), ano = Convert.ToInt32(cmbAno.Text);
            CarregarGraficoAtendimentos(mes, ano, quantasTotal);
        }

        private void CarregarGraficoAtendimentos(int mesSelecionado, int anoSelecionado, int quantasAtual)
        {
            this.chAtendimentos.Series["atendimentos"].Points.Clear();
            int quantasDois = 0, quantasTres = 0, quantasQuatro = 0, quantasCinco = 0;
            string mesBuscar = "";
            clsAtendimento objAtendimento = new clsAtendimento();
            MySqlDataReader sql_dr;
            sql_dr = objAtendimento.getAtendimentoByDate(cmbMes.Text, cmbAno.Text);
            int mes = mesSelecionado, ano = anoSelecionado;
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objAtendimento.getAtendimentoByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasDois++;//Um mes atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objAtendimento.getAtendimentoByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasTres++;//Dois meses atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objAtendimento.getAtendimentoByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasQuatro++;//Três meses atrás
            }
            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            mes--;
            if (mes < 10)
            {
                mesBuscar = "0" + mes.ToString();
            }
            else
            {
                mesBuscar = mes.ToString();
            }
            sql_dr = objAtendimento.getAtendimentoByDate(mesBuscar, ano.ToString());
            while (sql_dr.Read())
            {
                quantasCinco++;//Quatro meses atrás
            }
            try
            {
                int i = 4;
                while (i >= 0)
                {
                    string nome;
                    nome = "Mês " + mesSelecionado;
                    if (mesSelecionado == 1)
                        mesSelecionado = 12;
                    else
                        mesSelecionado--;
                    int quantosAtendimentos;
                    if (i == 4)
                        quantosAtendimentos = quantasAtual;
                    else if (i == 3)
                        quantosAtendimentos = quantasDois;
                    else if (i == 2)
                        quantosAtendimentos = quantasTres;
                    else if (i == 1)
                        quantosAtendimentos = quantasQuatro;
                    else
                        quantosAtendimentos = quantasCinco;
                    this.chAtendimentos.Series["atendimentos"].Points.AddXY(nome, quantosAtendimentos);
                    i--;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível encontrar os dados! \n" + e);
            }
        }

        private void Pesquisar(object sender, EventArgs e)
        {
            CarregarMaquinas();
            CarregarAtendimentos();
            btnExportar.Visible = true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                GerarPDF();
                MessageBox.Show("O documento foi salvo em sua pasta 'Documentos'.", "Êxito");
            }
            catch
            {
                MessageBox.Show("Não foi possível exportar!", "ERRO");
            }
        }

    }
}
