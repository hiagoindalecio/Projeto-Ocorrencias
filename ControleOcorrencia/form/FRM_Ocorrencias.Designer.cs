namespace ControleOcorrencia.form
{
    partial class FRM_Ocorrencias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Ocorrencias));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.rbImpressora = new System.Windows.Forms.RadioButton();
            this.rbMaquina = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRetirada = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lstOcorrencia = new System.Windows.Forms.ListView();
            this.cNrOcorrencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cNmDepartamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cNmMaquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDtEntrada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDsStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDsCriado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblProblema = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cxGreen = new System.Windows.Forms.Label();
            this.cxAmarelo = new System.Windows.Forms.Label();
            this.cxVermelho = new System.Windows.Forms.Label();
            this.cxCinza = new System.Windows.Forms.Label();
            this.cxBisque = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(24, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controle de Ocorrências";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(10, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nova Ocorrência";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lstOcorrencia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1262, 363);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ocorrências";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cbAll);
            this.groupBox5.Controls.Add(this.rbImpressora);
            this.groupBox5.Controls.Add(this.rbMaquina);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(1134, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(118, 123);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filtros";
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(10, 76);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(72, 20);
            this.cbAll.TabIndex = 2;
            this.cbAll.Text = "Todas";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.AlterarFiltro);
            // 
            // rbImpressora
            // 
            this.rbImpressora.AutoSize = true;
            this.rbImpressora.Location = new System.Drawing.Point(7, 49);
            this.rbImpressora.Name = "rbImpressora";
            this.rbImpressora.Size = new System.Drawing.Size(112, 20);
            this.rbImpressora.TabIndex = 1;
            this.rbImpressora.Text = "Impressoras";
            this.rbImpressora.UseVisualStyleBackColor = true;
            this.rbImpressora.CheckedChanged += new System.EventHandler(this.AlterarFiltro);
            // 
            // rbMaquina
            // 
            this.rbMaquina.AutoSize = true;
            this.rbMaquina.Checked = true;
            this.rbMaquina.Location = new System.Drawing.Point(7, 22);
            this.rbMaquina.Name = "rbMaquina";
            this.rbMaquina.Size = new System.Drawing.Size(93, 20);
            this.rbMaquina.TabIndex = 0;
            this.rbMaquina.TabStop = true;
            this.rbMaquina.Text = "Máquinas";
            this.rbMaquina.UseVisualStyleBackColor = true;
            this.rbMaquina.CheckedChanged += new System.EventHandler(this.AlterarFiltro);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnRetirada);
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(1134, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 205);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ações";
            // 
            // btnRetirada
            // 
            this.btnRetirada.BackColor = System.Drawing.Color.SlateGray;
            this.btnRetirada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirada.ForeColor = System.Drawing.Color.White;
            this.btnRetirada.Location = new System.Drawing.Point(10, 171);
            this.btnRetirada.Name = "btnRetirada";
            this.btnRetirada.Size = new System.Drawing.Size(102, 28);
            this.btnRetirada.TabIndex = 9;
            this.btnRetirada.Text = "Retirar";
            this.btnRetirada.UseVisualStyleBackColor = false;
            this.btnRetirada.Click += new System.EventHandler(this.btnRetirada_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SlateGray;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(10, 127);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 38);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir QRCode";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SlateGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(10, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "Finalizar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(10, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Atualizar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // lstOcorrencia
            // 
            this.lstOcorrencia.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstOcorrencia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNrOcorrencia,
            this.cNmDepartamento,
            this.cNmMaquina,
            this.cDtEntrada,
            this.cDsStatus,
            this.cDsCriado});
            this.lstOcorrencia.Font = new System.Drawing.Font("Linux Libertine G", 12F);
            this.lstOcorrencia.FullRowSelect = true;
            this.lstOcorrencia.Location = new System.Drawing.Point(19, 46);
            this.lstOcorrencia.Name = "lstOcorrencia";
            this.lstOcorrencia.Size = new System.Drawing.Size(1109, 298);
            this.lstOcorrencia.TabIndex = 2;
            this.lstOcorrencia.UseCompatibleStateImageBehavior = false;
            this.lstOcorrencia.View = System.Windows.Forms.View.Details;
            this.lstOcorrencia.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstOcorrencias_ColumnClick);
            this.lstOcorrencia.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstOcorrencia_ItemCheck);
            this.lstOcorrencia.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstOcorrencia_ItemChecked);
            this.lstOcorrencia.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstOcorrencia_SelectedIndex);
            // 
            // cNrOcorrencia
            // 
            this.cNrOcorrencia.Text = "Ocorrência";
            this.cNrOcorrencia.Width = 95;
            // 
            // cNmDepartamento
            // 
            this.cNmDepartamento.Text = "Departamento";
            this.cNmDepartamento.Width = 154;
            // 
            // cNmMaquina
            // 
            this.cNmMaquina.Text = "Máquina";
            this.cNmMaquina.Width = 146;
            // 
            // cDtEntrada
            // 
            this.cDtEntrada.Text = "Registrada em";
            this.cDtEntrada.Width = 300;
            // 
            // cDsStatus
            // 
            this.cDsStatus.Text = "Status";
            this.cDsStatus.Width = 211;
            // 
            // cDsCriado
            // 
            this.cDsCriado.Text = "Criado Por";
            this.cDsCriado.Width = 198;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cadastre ocorrências para organizar";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.SlateGray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(1172, 21);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(102, 44);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.fecharOcorrencias);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFiltro);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1262, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pesquisar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(105, 20);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(1034, 20);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblProblema
            // 
            this.lblProblema.AutoSize = true;
            this.lblProblema.BackColor = System.Drawing.Color.Transparent;
            this.lblProblema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblema.Location = new System.Drawing.Point(6, 18);
            this.lblProblema.Name = "lblProblema";
            this.lblProblema.Size = new System.Drawing.Size(67, 16);
            this.lblProblema.TabIndex = 9;
            this.lblProblema.Text = "Problema";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lblProblema);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 514);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1262, 50);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Defeito";
            // 
            // cxGreen
            // 
            this.cxGreen.AutoSize = true;
            this.cxGreen.BackColor = System.Drawing.Color.Transparent;
            this.cxGreen.Location = new System.Drawing.Point(1026, 13);
            this.cxGreen.Name = "cxGreen";
            this.cxGreen.Size = new System.Drawing.Size(13, 13);
            this.cxGreen.TabIndex = 3;
            this.cxGreen.Text = "_";
            // 
            // cxAmarelo
            // 
            this.cxAmarelo.AutoSize = true;
            this.cxAmarelo.BackColor = System.Drawing.Color.Transparent;
            this.cxAmarelo.Location = new System.Drawing.Point(1026, 25);
            this.cxAmarelo.Name = "cxAmarelo";
            this.cxAmarelo.Size = new System.Drawing.Size(13, 13);
            this.cxAmarelo.TabIndex = 12;
            this.cxAmarelo.Text = "_";
            // 
            // cxVermelho
            // 
            this.cxVermelho.AutoSize = true;
            this.cxVermelho.BackColor = System.Drawing.Color.Transparent;
            this.cxVermelho.Location = new System.Drawing.Point(1026, 38);
            this.cxVermelho.Name = "cxVermelho";
            this.cxVermelho.Size = new System.Drawing.Size(13, 13);
            this.cxVermelho.TabIndex = 11;
            this.cxVermelho.Text = "_";
            // 
            // cxCinza
            // 
            this.cxCinza.AutoSize = true;
            this.cxCinza.BackColor = System.Drawing.Color.Transparent;
            this.cxCinza.Location = new System.Drawing.Point(1026, 51);
            this.cxCinza.Name = "cxCinza";
            this.cxCinza.Size = new System.Drawing.Size(13, 13);
            this.cxCinza.TabIndex = 13;
            this.cxCinza.Text = "_";
            // 
            // cxBisque
            // 
            this.cxBisque.AutoSize = true;
            this.cxBisque.BackColor = System.Drawing.Color.Transparent;
            this.cxBisque.Location = new System.Drawing.Point(1026, 64);
            this.cxBisque.Name = "cxBisque";
            this.cxBisque.Size = new System.Drawing.Size(13, 13);
            this.cxBisque.TabIndex = 14;
            this.cxBisque.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(1047, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Entregue ou baixa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1045, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Aguardando retirada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(1045, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Entre trêns e sete dias";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(1045, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mais que sete dias";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(1045, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Menos de três dias";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Atualizar);
            // 
            // FRM_Ocorrencias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1315, 600);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cxBisque);
            this.Controls.Add(this.cxCinza);
            this.Controls.Add(this.cxAmarelo);
            this.Controls.Add(this.cxVermelho);
            this.Controls.Add(this.cxGreen);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Ocorrencias";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ocorrências";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Ocorrencias_FormClosed);
            this.Load += new System.EventHandler(this.FRM_Ocorrencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader cNmDepartamento;
        private System.Windows.Forms.ColumnHeader cNmMaquina;
        private System.Windows.Forms.ColumnHeader cDtEntrada;
        private System.Windows.Forms.ColumnHeader cDsStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ColumnHeader cDsCriado;
        private System.Windows.Forms.ColumnHeader cNrOcorrencia;
        private System.Windows.Forms.ListView lstOcorrencia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblProblema;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRetirada;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.RadioButton rbImpressora;
        private System.Windows.Forms.RadioButton rbMaquina;
        private System.Windows.Forms.Label cxGreen;
        private System.Windows.Forms.Label cxAmarelo;
        private System.Windows.Forms.Label cxVermelho;
        private System.Windows.Forms.Label cxCinza;
        private System.Windows.Forms.Label cxBisque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer;
    }
}