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
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_EmitirQRCode : Form
    {
        int nr_os = 0;
        public FRM_EmitirQRCode(int nrOcorrencia)
        {
            InitializeComponent();
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            if (nrOcorrencia == 0)
            {
                //pegar a ultima ocorrencia cadastrada
                clsOcorrencias objOcorrencia = new clsOcorrencias();
                objOcorrencia.getLastOcorrencia();
                if (!Equals(objOcorrencia.ds_msg, ""))
                {
                    MessageBox.Show(objOcorrencia.ds_msg);
                }
                else
                {
                    nr_os = objOcorrencia.Nr_ocorrencia;
                }
                clsDepartamento objDept = new clsDepartamento();
                objDept.Id_departamento = objOcorrencia.Id_departamento;
                objDept.carregarDeptByID();
                //conseguir colocar mais info junto com o link
                pictureBox1.Image = qrcode.Draw("LINK DO SITE" + objOcorrencia.Nr_ocorrencia, 50);
            }
            else
            {
                //pegar a ocorencia pelo id(nrOcorrencia)
                clsOcorrencias objOcorrencia = new clsOcorrencias();
                objOcorrencia.Nr_ocorrencia = nrOcorrencia;
                objOcorrencia.getOcorrenciasByID();
                if (!Equals(objOcorrencia.ds_msg, ""))
                {
                    MessageBox.Show(objOcorrencia.ds_msg);
                }
                else
                {
                    nr_os = nrOcorrencia;
                }
                clsDepartamento objDept = new clsDepartamento();
                objDept.Id_departamento = objOcorrencia.Id_departamento;
                objDept.carregarDeptByID();
                pictureBox1.Image = qrcode.Draw("LINK DO SITE" + objOcorrencia.Nr_ocorrencia, 50);
            }
            CarregarImpressoras();
        }

        public void CarregarImpressoras()
        {
            cmbImpressoras.Items.Clear();
            foreach (var impressora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbImpressoras.Items.Add(impressora);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var pd = new System.Drawing.Printing.PrintDocument())
            {
                pd.PrinterSettings.PrinterName = cmbImpressoras.Text;
                pd.PrintPage += pd_PrintPage;
                pd.Print();
            }
        }
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Create coordinates for upper-left corner of image.
            float x = (e.PageBounds.Width - pictureBox1.Width) / 2;
            float y = 10F;

            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(0.0F, 0.0F, 1000.0F, 1000.0F);
            GraphicsUnit units = GraphicsUnit.Millimeter;

            // Draw image to screen.
            e.Graphics.DrawImage(pictureBox1.Image , x, y, srcRect, units);

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            string msg = "OS: "+ nr_os.ToString();
            x = (e.PageBounds.Width / 2) ;
            x -= (msg.Length * 4);
            y = pictureBox1.Height + 20F;
            e.Graphics.DrawString(msg, drawFont, drawBrush, x, y, drawFormat);
        }
    }
}
