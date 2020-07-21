namespace ControleOcorrencia.form
{
    partial class FRM_Atendimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Atendimento));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDameWare = new System.Windows.Forms.Button();
            this.lblObrig5 = new System.Windows.Forms.Label();
            this.lblObrig4 = new System.Windows.Forms.Label();
            this.txtMaquina = new System.Windows.Forms.TextBox();
            this.lblObrig3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSolucao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProblema = new System.Windows.Forms.TextBox();
            this.lblObrig2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblObrig1 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnDameWare);
            this.groupBox2.Controls.Add(this.lblObrig5);
            this.groupBox2.Controls.Add(this.lblObrig4);
            this.groupBox2.Controls.Add(this.txtMaquina);
            this.groupBox2.Controls.Add(this.lblObrig3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSolucao);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProblema);
            this.groupBox2.Controls.Add(this.lblObrig2);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.lblObrig1);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbDepartamento);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1262, 258);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(264, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 37);
            this.button1.TabIndex = 45;
            this.button1.Text = "TeamViewer";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AbrirTeamViewer);
            // 
            // btnDameWare
            // 
            this.btnDameWare.BackColor = System.Drawing.Color.SlateGray;
            this.btnDameWare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDameWare.ForeColor = System.Drawing.Color.White;
            this.btnDameWare.Image = ((System.Drawing.Image)(resources.GetObject("btnDameWare.Image")));
            this.btnDameWare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDameWare.Location = new System.Drawing.Point(130, 201);
            this.btnDameWare.Name = "btnDameWare";
            this.btnDameWare.Size = new System.Drawing.Size(128, 37);
            this.btnDameWare.TabIndex = 44;
            this.btnDameWare.Text = "DameWare";
            this.btnDameWare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDameWare.UseVisualStyleBackColor = false;
            this.btnDameWare.Click += new System.EventHandler(this.AbrirDameWare);
            // 
            // lblObrig5
            // 
            this.lblObrig5.AutoSize = true;
            this.lblObrig5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrig5.ForeColor = System.Drawing.Color.Red;
            this.lblObrig5.Location = new System.Drawing.Point(1169, 27);
            this.lblObrig5.Name = "lblObrig5";
            this.lblObrig5.Size = new System.Drawing.Size(73, 15);
            this.lblObrig5.TabIndex = 43;
            this.lblObrig5.Text = "*Obrigatório";
            // 
            // lblObrig4
            // 
            this.lblObrig4.AutoSize = true;
            this.lblObrig4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrig4.ForeColor = System.Drawing.Color.Red;
            this.lblObrig4.Location = new System.Drawing.Point(761, 28);
            this.lblObrig4.Name = "lblObrig4";
            this.lblObrig4.Size = new System.Drawing.Size(73, 15);
            this.lblObrig4.TabIndex = 42;
            this.lblObrig4.Text = "*Obrigatório";
            // 
            // txtMaquina
            // 
            this.txtMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtMaquina.Location = new System.Drawing.Point(21, 156);
            this.txtMaquina.Name = "txtMaquina";
            this.txtMaquina.Size = new System.Drawing.Size(391, 29);
            this.txtMaquina.TabIndex = 41;
            // 
            // lblObrig3
            // 
            this.lblObrig3.AutoSize = true;
            this.lblObrig3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrig3.ForeColor = System.Drawing.Color.Red;
            this.lblObrig3.Location = new System.Drawing.Point(339, 135);
            this.lblObrig3.Name = "lblObrig3";
            this.lblObrig3.Size = new System.Drawing.Size(73, 15);
            this.lblObrig3.TabIndex = 40;
            this.lblObrig3.Text = "*Obrigatório";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "Nome da Máquina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(848, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Solução:";
            // 
            // txtSolucao
            // 
            this.txtSolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtSolucao.Location = new System.Drawing.Point(851, 46);
            this.txtSolucao.Multiline = true;
            this.txtSolucao.Name = "txtSolucao";
            this.txtSolucao.Size = new System.Drawing.Size(391, 149);
            this.txtSolucao.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Problema:";
            // 
            // txtProblema
            // 
            this.txtProblema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtProblema.Location = new System.Drawing.Point(443, 46);
            this.txtProblema.Multiline = true;
            this.txtProblema.Name = "txtProblema";
            this.txtProblema.Size = new System.Drawing.Size(391, 149);
            this.txtProblema.TabIndex = 35;
            // 
            // lblObrig2
            // 
            this.lblObrig2.AutoSize = true;
            this.lblObrig2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrig2.ForeColor = System.Drawing.Color.Red;
            this.lblObrig2.Location = new System.Drawing.Point(339, 27);
            this.lblObrig2.Name = "lblObrig2";
            this.lblObrig2.Size = new System.Drawing.Size(73, 15);
            this.lblObrig2.TabIndex = 34;
            this.lblObrig2.Text = "*Obrigatório";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtNome.Location = new System.Drawing.Point(21, 102);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(391, 29);
            this.txtNome.TabIndex = 33;
            // 
            // lblObrig1
            // 
            this.lblObrig1.AutoSize = true;
            this.lblObrig1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrig1.ForeColor = System.Drawing.Color.Red;
            this.lblObrig1.Location = new System.Drawing.Point(339, 81);
            this.lblObrig1.Name = "lblObrig1";
            this.lblObrig1.Size = new System.Drawing.Size(73, 15);
            this.lblObrig1.TabIndex = 30;
            this.lblObrig1.Text = "*Obrigatório";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.SlateGray;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(21, 201);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(103, 37);
            this.btnSalvar.TabIndex = 28;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nome do Solicitante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Departamento:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(21, 46);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(391, 32);
            this.cmbDepartamento.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(28, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 72);
            this.label5.TabIndex = 13;
            this.label5.Text = "Atendimento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRM_Atendimento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 533);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Atendimento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Config";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Atendimento_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblObrig1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblObrig2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSolucao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProblema;
        private System.Windows.Forms.TextBox txtMaquina;
        private System.Windows.Forms.Label lblObrig3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblObrig5;
        private System.Windows.Forms.Label lblObrig4;
        private System.Windows.Forms.Button btnDameWare;
        private System.Windows.Forms.Button button1;

    }
}