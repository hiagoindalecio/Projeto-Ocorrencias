using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ControleOcorrencia.classes;
using MySql.Data.MySqlClient;
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_EmitirOficio : Form
    {
        string maquina, departamento, responsavel;
        public static Document documento;
        public FRM_EmitirOficio(string machine, string dept)
        {
            InitializeComponent();
            maquina = machine;
            departamento = dept;
            responsavel = EncontrarResponsavel();
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            txtMaquina.Text = maquina;
            txtDepartamento.Text = departamento;
            txtResponsavel.Text = responsavel;
        }

        private string EncontrarResponsavel()
        {
            clsDepartamento obj_dept = new clsDepartamento();
            int id_dept = 0, id_resp = 0;
            string nameResp;
            MySqlDataReader sql_dr = obj_dept.carregarDeptByName(departamento);
            if (sql_dr.Read())
            {
                id_dept = Convert.ToInt32(sql_dr["id_departamento"].ToString());
            }
            clsResponsaveis obj_resp = new clsResponsaveis();
            sql_dr = obj_resp.getRespByIdDept(id_dept);
            if(sql_dr.Read())
            {
                id_resp = Convert.ToInt32(sql_dr["id_usuario"].ToString());
            }
            clsUsuario obj_user = new clsUsuario();
            obj_user.Id_usuario = id_resp;
            obj_user.getUserById();
            nameResp = obj_user.Nm_Usuario;
            return nameResp;
        }

        private void GerarPDF()
        {
            string peca = this.txtPart.Text, modelo = txtModelo.Text;
            DateTime data = new DateTime();
            data = DateTime.Now;
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            string diretorio = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Oficio-" + responsavel + "." + departamento + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(diretorio, FileMode.Create));
            doc.Open();
            string dados = "";
            Paragraph title = new Paragraph(dados);
            title.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
            title.Alignment = Element.ALIGN_RIGHT;
            title.Add("Capivari " + data);
            doc.Add(title);
            Paragraph txtDescricao = new Paragraph(dados);
            txtDescricao.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12);
            txtDescricao.Alignment = Element.ALIGN_LEFT;
            txtDescricao.Add("Sr(a).\n" + responsavel + "\nDepartamento: " + departamento + "\nPrefeitura Municipal de Capivari\nCapivari - SP");
            doc.Add(txtDescricao);
            Paragraph txtCorpo = new Paragraph(dados);
            txtCorpo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12);
            txtCorpo.Alignment = Element.ALIGN_JUSTIFIED;
            txtCorpo.Add("\n\n    Vimos através deste, informar que o microcomputador " + maquina + " pertencente ao departamento " + departamento + " necessita da troca da peça " + peca + ", que foi constatada com defeito, para assim podermos colocá-lo novamente em atividade. Assim sendo, abaixo relacionamos as peças necessárias para compra.\n");
            doc.Add(txtCorpo);
            Paragraph txtPeca = new Paragraph(dados);
            txtPeca.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
            txtPeca.Alignment = Element.ALIGN_CENTER;
            txtPeca.Add("\nPeça: " + peca + "\nModelo: " + modelo + "\nQuantidade: " + numQuantidade.Value);
            doc.Add(txtPeca);
            txtCorpo.Clear();
            txtCorpo.Add("\n\n    Informamos que a manutenção do microcomputador acima citado somente será possível após a aquisição das mesmas. Sem mais para o momento, subscrevemo-nos.");
            doc.Add(txtCorpo);
            Paragraph finalizacao = new Paragraph(dados);
            finalizacao.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12);
            finalizacao.Alignment = Element.ALIGN_CENTER;
            finalizacao.Add("\n\n\n\n\n\n\n\n\n\nAtenciosamente\nDepartamento de T.I.\nPrefeitura Municipal de Capivari");
            doc.Add(finalizacao);
            doc.Close();
            documento = doc;
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
            this.Close();
        }
    }
}
