namespace ControleOcorrencia.form
{
    partial class FRM_Relatorio_Mensal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Relatorio_Mensal));
            this.lstMaquinas = new System.Windows.Forms.ListView();
            this.clnMaquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chAtendimentos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalAtendimentos = new System.Windows.Forms.Label();
            this.lstAtendimento = new System.Windows.Forms.ListView();
            this.chMaquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolicitante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMaquinas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalMaquinas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chAtendimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMaquinas)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMaquinas
            // 
            this.lstMaquinas.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lstMaquinas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnMaquina,
            this.clnData,
            this.clnSaída});
            this.lstMaquinas.Font = new System.Drawing.Font("Linux Libertine G", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaquinas.Location = new System.Drawing.Point(19, 37);
            this.lstMaquinas.Name = "lstMaquinas";
            this.lstMaquinas.Size = new System.Drawing.Size(585, 162);
            this.lstMaquinas.TabIndex = 0;
            this.lstMaquinas.UseCompatibleStateImageBehavior = false;
            this.lstMaquinas.View = System.Windows.Forms.View.Details;
            // 
            // clnMaquina
            // 
            this.clnMaquina.Text = "Máquina";
            this.clnMaquina.Width = 258;
            // 
            // clnData
            // 
            this.clnData.Text = "Data de Entrada";
            this.clnData.Width = 155;
            // 
            // clnSaída
            // 
            this.clnSaída.Text = "Data de Saída";
            this.clnSaída.Width = 167;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chAtendimentos);
            this.groupBox1.Controls.Add(this.lblTotalAtendimentos);
            this.groupBox1.Controls.Add(this.lstAtendimento);
            this.groupBox1.Controls.Add(this.chMaquinas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTotalMaquinas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstMaquinas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(27, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1244, 443);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relatório Mensal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(632, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Atendimentos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(632, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gráfico Final Atendimentos:";
            // 
            // chAtendimentos
            // 
            this.chAtendimentos.BackColor = System.Drawing.SystemColors.MenuBar;
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Name = "ChartArea1";
            this.chAtendimentos.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chAtendimentos.Legends.Add(legend3);
            this.chAtendimentos.Location = new System.Drawing.Point(635, 243);
            this.chAtendimentos.Name = "chAtendimentos";
            this.chAtendimentos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "atendimentos";
            this.chAtendimentos.Series.Add(series3);
            this.chAtendimentos.Size = new System.Drawing.Size(585, 190);
            this.chAtendimentos.TabIndex = 7;
            this.chAtendimentos.Text = "chart2";
            title3.Name = "atendimentos";
            title3.Text = "Histórico de Atendimentos em 5 meses:";
            this.chAtendimentos.Titles.Add(title3);
            // 
            // lblTotalAtendimentos
            // 
            this.lblTotalAtendimentos.AutoSize = true;
            this.lblTotalAtendimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAtendimentos.Location = new System.Drawing.Point(631, 200);
            this.lblTotalAtendimentos.Name = "lblTotalAtendimentos";
            this.lblTotalAtendimentos.Size = new System.Drawing.Size(195, 20);
            this.lblTotalAtendimentos.TabIndex = 6;
            this.lblTotalAtendimentos.Text = "Total de Atendimentos:";
            // 
            // lstAtendimento
            // 
            this.lstAtendimento.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lstAtendimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMaquina,
            this.chData,
            this.chSolicitante});
            this.lstAtendimento.Font = new System.Drawing.Font("Linux Libertine G", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAtendimento.Location = new System.Drawing.Point(635, 37);
            this.lstAtendimento.Name = "lstAtendimento";
            this.lstAtendimento.Size = new System.Drawing.Size(585, 162);
            this.lstAtendimento.TabIndex = 5;
            this.lstAtendimento.UseCompatibleStateImageBehavior = false;
            this.lstAtendimento.View = System.Windows.Forms.View.Details;
            // 
            // chMaquina
            // 
            this.chMaquina.Text = "Máquina";
            this.chMaquina.Width = 258;
            // 
            // chData
            // 
            this.chData.Text = "Data";
            this.chData.Width = 151;
            // 
            // chSolicitante
            // 
            this.chSolicitante.Text = "Solicitante";
            this.chSolicitante.Width = 172;
            // 
            // chMaquinas
            // 
            this.chMaquinas.BackColor = System.Drawing.SystemColors.MenuBar;
            chartArea4.Area3DStyle.Enable3D = true;
            chartArea4.Name = "ChartArea1";
            this.chMaquinas.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chMaquinas.Legends.Add(legend4);
            this.chMaquinas.Location = new System.Drawing.Point(19, 243);
            this.chMaquinas.Name = "chMaquinas";
            this.chMaquinas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series4.ChartArea = "ChartArea1";
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.LegendText = "Máquinas";
            series4.Name = "meses";
            this.chMaquinas.Series.Add(series4);
            this.chMaquinas.Size = new System.Drawing.Size(585, 190);
            this.chMaquinas.TabIndex = 4;
            this.chMaquinas.Text = "Maquinas";
            title4.Name = "Title1";
            title4.Text = "Hitórico de máquinas em 5 meses:";
            this.chMaquinas.Titles.Add(title4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gráfico Final Máquinas:";
            // 
            // lblTotalMaquinas
            // 
            this.lblTotalMaquinas.AutoSize = true;
            this.lblTotalMaquinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMaquinas.Location = new System.Drawing.Point(15, 200);
            this.lblTotalMaquinas.Name = "lblTotalMaquinas";
            this.lblTotalMaquinas.Size = new System.Drawing.Size(161, 20);
            this.lblTotalMaquinas.TabIndex = 2;
            this.lblTotalMaquinas.Text = "Total de Máquinas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Máquinas:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbMes.Location = new System.Drawing.Point(84, 85);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(87, 32);
            this.cmbMes.TabIndex = 25;
            // 
            // cmbAno
            // 
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Items.AddRange(new object[] {
            "2019",
            "2020"});
            this.cmbAno.Location = new System.Drawing.Point(235, 83);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(88, 32);
            this.cmbAno.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mês:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ano:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.SlateGray;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPesquisar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisar.Location = new System.Drawing.Point(329, 78);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(113, 37);
            this.btnPesquisar.TabIndex = 28;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.Pesquisar);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.SlateGray;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportar.Location = new System.Drawing.Point(448, 78);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(113, 37);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(23, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 64);
            this.label5.TabIndex = 29;
            this.label5.Text = "Balanço Mensal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRM_Relatorio_Mensal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1300, 572);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAno);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Relatorio_Mensal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatrio Mensal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Relatorio_Mensal_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chAtendimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMaquinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstMaquinas;
        private System.Windows.Forms.ColumnHeader clnMaquina;
        private System.Windows.Forms.ColumnHeader clnData;
        private System.Windows.Forms.ColumnHeader clnSaída;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalMaquinas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chMaquinas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalAtendimentos;
        private System.Windows.Forms.ListView lstAtendimento;
        private System.Windows.Forms.ColumnHeader chMaquina;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.ColumnHeader chSolicitante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAtendimentos;
        private System.Windows.Forms.Button btnExportar;
    }
}