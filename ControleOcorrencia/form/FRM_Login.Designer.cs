namespace ControleOcorrencia.form
{
    partial class FRM_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOlho = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogar = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.grbConfig = new System.Windows.Forms.GroupBox();
            this.txtServerPwd = new System.Windows.Forms.TextBox();
            this.txtServerLogin = new System.Windows.Forms.TextBox();
            this.txtDb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.btnSalvarCnx = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbnInterno = new System.Windows.Forms.RadioButton();
            this.rbnExterno = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.grbConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblOlho);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.lblLogin);
            this.groupBox1.Controls.Add(this.lblSenha);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acesso ao sistema";
            // 
            // lblOlho
            // 
            this.lblOlho.BackColor = System.Drawing.Color.White;
            this.lblOlho.Image = ((System.Drawing.Image)(resources.GetObject("lblOlho.Image")));
            this.lblOlho.Location = new System.Drawing.Point(326, 117);
            this.lblOlho.Name = "lblOlho";
            this.lblOlho.Size = new System.Drawing.Size(25, 24);
            this.lblOlho.TabIndex = 3;
            this.lblOlho.Click += new System.EventHandler(this.lblOlho_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(70, 56);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(289, 35);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Logar);
            // 
            // lblLogin
            // 
            this.lblLogin.Image = ((System.Drawing.Image)(resources.GetObject("lblLogin.Image")));
            this.lblLogin.Location = new System.Drawing.Point(20, 52);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(39, 39);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "         ";
            // 
            // lblSenha
            // 
            this.lblSenha.Image = ((System.Drawing.Image)(resources.GetObject("lblSenha.Image")));
            this.lblSenha.Location = new System.Drawing.Point(14, 104);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(50, 42);
            this.lblSenha.TabIndex = 1;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(70, 111);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(289, 35);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Logar);
            // 
            // btnLogar
            // 
            this.btnLogar.BackColor = System.Drawing.Color.SlateGray;
            this.btnLogar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogar.ForeColor = System.Drawing.Color.White;
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogar.Location = new System.Drawing.Point(259, 390);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(116, 41);
            this.btnLogar.TabIndex = 6;
            this.btnLogar.Text = "Login";
            this.btnLogar.UseVisualStyleBackColor = false;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // picBox
            // 
            this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
            this.picBox.Location = new System.Drawing.Point(39, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(334, 193);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 6;
            this.picBox.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(11, 426);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(13, 18);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = ".";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Trebuchet MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(330, 448);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(10, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = ".";
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfig.BackgroundImage")));
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfig.Location = new System.Drawing.Point(393, 1);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(20, 20);
            this.btnConfig.TabIndex = 8;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            this.btnConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterBtnConfig);
            // 
            // grbConfig
            // 
            this.grbConfig.BackColor = System.Drawing.Color.Transparent;
            this.grbConfig.Controls.Add(this.txtServerPwd);
            this.grbConfig.Controls.Add(this.txtServerLogin);
            this.grbConfig.Controls.Add(this.txtDb);
            this.grbConfig.Controls.Add(this.label8);
            this.grbConfig.Controls.Add(this.label7);
            this.grbConfig.Controls.Add(this.label6);
            this.grbConfig.Controls.Add(this.txtPort);
            this.grbConfig.Controls.Add(this.txtIp);
            this.grbConfig.Controls.Add(this.btnSalvarCnx);
            this.grbConfig.Controls.Add(this.label10);
            this.grbConfig.Controls.Add(this.label11);
            this.grbConfig.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConfig.ForeColor = System.Drawing.Color.Black;
            this.grbConfig.Location = new System.Drawing.Point(12, 32);
            this.grbConfig.Name = "grbConfig";
            this.grbConfig.Size = new System.Drawing.Size(387, 138);
            this.grbConfig.TabIndex = 9;
            this.grbConfig.TabStop = false;
            this.grbConfig.Text = "Configurção de Conexão";
            // 
            // txtServerPwd
            // 
            this.txtServerPwd.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerPwd.Location = new System.Drawing.Point(247, 57);
            this.txtServerPwd.Name = "txtServerPwd";
            this.txtServerPwd.Size = new System.Drawing.Size(134, 23);
            this.txtServerPwd.TabIndex = 47;
            // 
            // txtServerLogin
            // 
            this.txtServerLogin.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerLogin.Location = new System.Drawing.Point(247, 31);
            this.txtServerLogin.Name = "txtServerLogin";
            this.txtServerLogin.Size = new System.Drawing.Size(134, 23);
            this.txtServerLogin.TabIndex = 46;
            // 
            // txtDb
            // 
            this.txtDb.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDb.Location = new System.Drawing.Point(61, 83);
            this.txtDb.Name = "txtDb";
            this.txtDb.Size = new System.Drawing.Size(136, 23);
            this.txtDb.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-1, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 44;
            this.label8.Text = "DataBase:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(204, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 43;
            this.label7.Text = "Senha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 42;
            this.label6.Text = " Login:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(61, 57);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(136, 23);
            this.txtPort.TabIndex = 41;
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(61, 31);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(136, 23);
            this.txtIp.TabIndex = 40;
            // 
            // btnSalvarCnx
            // 
            this.btnSalvarCnx.BackColor = System.Drawing.Color.SlateGray;
            this.btnSalvarCnx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarCnx.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarCnx.ForeColor = System.Drawing.Color.White;
            this.btnSalvarCnx.Location = new System.Drawing.Point(273, 86);
            this.btnSalvarCnx.Name = "btnSalvarCnx";
            this.btnSalvarCnx.Size = new System.Drawing.Size(108, 37);
            this.btnSalvarCnx.TabIndex = 39;
            this.btnSalvarCnx.Text = "Salvar";
            this.btnSalvarCnx.UseVisualStyleBackColor = false;
            this.btnSalvarCnx.Click += new System.EventHandler(this.btnSalvarCnx_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 18);
            this.label10.TabIndex = 38;
            this.label10.Text = "Port:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 18);
            this.label11.TabIndex = 37;
            this.label11.Text = "TCP/IP:";
            // 
            // rbnInterno
            // 
            this.rbnInterno.AutoSize = true;
            this.rbnInterno.Location = new System.Drawing.Point(14, 390);
            this.rbnInterno.Name = "rbnInterno";
            this.rbnInterno.Size = new System.Drawing.Size(58, 17);
            this.rbnInterno.TabIndex = 10;
            this.rbnInterno.Text = "Interno";
            this.rbnInterno.UseVisualStyleBackColor = true;
            this.rbnInterno.Visible = false;
            this.rbnInterno.CheckedChanged += new System.EventHandler(this.AlternarServer);
            // 
            // rbnExterno
            // 
            this.rbnExterno.AutoSize = true;
            this.rbnExterno.Checked = true;
            this.rbnExterno.Location = new System.Drawing.Point(84, 390);
            this.rbnExterno.Name = "rbnExterno";
            this.rbnExterno.Size = new System.Drawing.Size(61, 17);
            this.rbnExterno.TabIndex = 11;
            this.rbnExterno.TabStop = true;
            this.rbnExterno.Text = "Externo";
            this.rbnExterno.UseVisualStyleBackColor = true;
            this.rbnExterno.Visible = false;
            this.rbnExterno.CheckedChanged += new System.EventHandler(this.AlternarServer);
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(413, 472);
            this.Controls.Add(this.rbnExterno);
            this.Controls.Add(this.rbnInterno);
            this.Controls.Add(this.grbConfig);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(429, 511);
            this.MinimumSize = new System.Drawing.Size(429, 511);
            this.Name = "FRM_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acesso ao Sistema";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.grbConfig.ResumeLayout(false);
            this.grbConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOlho;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnLogar;
        public System.Windows.Forms.TextBox txtLogin;
        public System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.GroupBox grbConfig;
        private System.Windows.Forms.TextBox txtServerPwd;
        private System.Windows.Forms.TextBox txtServerLogin;
        private System.Windows.Forms.TextBox txtDb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button btnSalvarCnx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbnInterno;
        private System.Windows.Forms.RadioButton rbnExterno;

    }
}