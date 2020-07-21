namespace ControleOcorrencia.form
{
    partial class FRM_Principal
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
            System.Windows.Forms.MenuStrip menuStrip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Principal));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUserLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtLogado = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.Label();
            this.mOcorrencia = new System.Windows.Forms.ToolStripMenuItem();
            this.mAtendimento = new System.Windows.Forms.ToolStripMenuItem();
            this.mDept = new System.Windows.Forms.ToolStripMenuItem();
            this.mUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.mOFF = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuStrip1.SuspendLayout();
            this.txtLogado.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AllowMerge = false;
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = System.Drawing.Color.LightGray;
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOcorrencia,
            this.mAtendimento,
            this.mDept,
            this.mUser,
            this.mConsulta,
            this.mConfig,
            this.mRelatorio,
            this.mOFF});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1284, 61);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(102, 56);
            this.toolStripStatusLabel1.Text = "Bem-vindo, ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 56);
            // 
            // txtUserLogado
            // 
            this.txtUserLogado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLogado.Name = "txtUserLogado";
            this.txtUserLogado.Size = new System.Drawing.Size(56, 56);
            this.txtUserLogado.Text = "Name";
            // 
            // txtLogado
            // 
            this.txtLogado.AutoSize = false;
            this.txtLogado.BackColor = System.Drawing.Color.Gray;
            this.txtLogado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.txtUserLogado});
            this.txtLogado.Location = new System.Drawing.Point(0, 640);
            this.txtLogado.Name = "txtLogado";
            this.txtLogado.ShowItemToolTips = true;
            this.txtLogado.Size = new System.Drawing.Size(1284, 61);
            this.txtLogado.TabIndex = 2;
            this.txtLogado.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblVersion.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.lblVersion.Location = new System.Drawing.Point(1135, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(50, 18);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // mOcorrencia
            // 
            this.mOcorrencia.BackColor = System.Drawing.Color.Transparent;
            this.mOcorrencia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mOcorrencia.ForeColor = System.Drawing.Color.Black;
            this.mOcorrencia.Image = global::ControleOcorrencia.Properties.Resources.fix;
            this.mOcorrencia.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mOcorrencia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mOcorrencia.Name = "mOcorrencia";
            this.mOcorrencia.Size = new System.Drawing.Size(91, 57);
            this.mOcorrencia.Text = "Ocorrências";
            this.mOcorrencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mOcorrencia.Click += new System.EventHandler(this.mOcorrencia_Click);
            // 
            // mAtendimento
            // 
            this.mAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.mAtendimento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAtendimento.ForeColor = System.Drawing.Color.Black;
            this.mAtendimento.Image = global::ControleOcorrencia.Properties.Resources.support;
            this.mAtendimento.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mAtendimento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mAtendimento.Name = "mAtendimento";
            this.mAtendimento.Size = new System.Drawing.Size(100, 57);
            this.mAtendimento.Text = "Atendimento";
            this.mAtendimento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mAtendimento.Click += new System.EventHandler(this.mAtendimento_Click);
            // 
            // mDept
            // 
            this.mDept.BackColor = System.Drawing.Color.Transparent;
            this.mDept.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mDept.ForeColor = System.Drawing.Color.Black;
            this.mDept.Image = global::ControleOcorrencia.Properties.Resources.department;
            this.mDept.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mDept.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mDept.Name = "mDept";
            this.mDept.Size = new System.Drawing.Size(114, 57);
            this.mDept.Text = "Departamentos";
            this.mDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mDept.Click += new System.EventHandler(this.mDept_Click);
            // 
            // mUser
            // 
            this.mUser.BackColor = System.Drawing.Color.Transparent;
            this.mUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mUser.ForeColor = System.Drawing.Color.Black;
            this.mUser.Image = global::ControleOcorrencia.Properties.Resources.team;
            this.mUser.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mUser.Name = "mUser";
            this.mUser.Size = new System.Drawing.Size(72, 57);
            this.mUser.Text = "Usuários";
            this.mUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mUser.Click += new System.EventHandler(this.mUser_Click);
            // 
            // mConsulta
            // 
            this.mConsulta.BackColor = System.Drawing.Color.Transparent;
            this.mConsulta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mConsulta.ForeColor = System.Drawing.Color.Black;
            this.mConsulta.Image = global::ControleOcorrencia.Properties.Resources.search;
            this.mConsulta.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mConsulta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mConsulta.Name = "mConsulta";
            this.mConsulta.Size = new System.Drawing.Size(73, 57);
            this.mConsulta.Text = "Consulta";
            this.mConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mConsulta.Click += new System.EventHandler(this.mConsulta_Click_1);
            // 
            // mConfig
            // 
            this.mConfig.BackColor = System.Drawing.Color.Transparent;
            this.mConfig.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mConfig.ForeColor = System.Drawing.Color.Black;
            this.mConfig.Image = global::ControleOcorrencia.Properties.Resources.configuration_5164;
            this.mConfig.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mConfig.Name = "mConfig";
            this.mConfig.Size = new System.Drawing.Size(84, 57);
            this.mConfig.Text = "Configurar";
            this.mConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mConfig.Click += new System.EventHandler(this.mConfig_Click);
            // 
            // mRelatorio
            // 
            this.mRelatorio.BackColor = System.Drawing.Color.Transparent;
            this.mRelatorio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mRelatorio.ForeColor = System.Drawing.Color.Black;
            this.mRelatorio.Image = global::ControleOcorrencia.Properties.Resources.graph;
            this.mRelatorio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mRelatorio.Name = "mRelatorio";
            this.mRelatorio.Size = new System.Drawing.Size(114, 57);
            this.mRelatorio.Text = "Balanço Mensal";
            this.mRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mRelatorio.Click += new System.EventHandler(this.mRelatorio_Click);
            // 
            // mOFF
            // 
            this.mOFF.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mOFF.ForeColor = System.Drawing.Color.Black;
            this.mOFF.Image = ((System.Drawing.Image)(resources.GetObject("mOFF.Image")));
            this.mOFF.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mOFF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mOFF.Name = "mOFF";
            this.mOFF.Size = new System.Drawing.Size(58, 57);
            this.mOFF.Text = "Logoff";
            this.mOFF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mOFF.Click += new System.EventHandler(this.ocorrênciasToolStripMenuItem_Click);
            // 
            // FRM_Principal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtLogado);
            this.Controls.Add(menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 740);
            this.MinimumSize = new System.Drawing.Size(1300, 740);
            this.Name = "FRM_Principal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Principal_FormClosed);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.txtLogado.ResumeLayout(false);
            this.txtLogado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mOFF;
        private System.Windows.Forms.ToolStripMenuItem mOcorrencia;
        private System.Windows.Forms.ToolStripMenuItem mDept;
        private System.Windows.Forms.ToolStripMenuItem mUser;
        private System.Windows.Forms.ToolStripMenuItem mConsulta;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel txtUserLogado;
        private System.Windows.Forms.StatusStrip txtLogado;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem mConfig;
        private System.Windows.Forms.ToolStripMenuItem mRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mAtendimento;
    }
}