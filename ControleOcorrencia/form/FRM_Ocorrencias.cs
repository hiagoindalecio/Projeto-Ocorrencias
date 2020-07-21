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
///DESENVOLVIDO POR HIAGO INDALÉCIO
namespace ControleOcorrencia.form
{
    public partial class FRM_Ocorrencias : Form
    {
        clsUsuario objUsuarioLogado = new clsUsuario();
        string nr_OcorrenciaSelecionada = "0"; 
        string orderBy = " ";
        string where = " ";
        public string IpServer, PortServer, NameDb, LoginServer, SenhaServer;

        private static FRM_Ocorrencias instance;

        public static FRM_Ocorrencias Instance(int id_Usuario)
        {
             if (instance == null)
             {
                 instance = new FRM_Ocorrencias(id_Usuario);
             }
             return instance; 
        }

        public FRM_Ocorrencias(int id_Usuario)
        {
            InitializeComponent();
            lblProblema.Visible = false;
            this.Top = 60;
            this.Left = 0;
            //.Bottom = 60;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Height = 750;
            cxGreen.BackColor = Color.FromArgb(60, 179, 113);
            cxAmarelo.BackColor = Color.FromArgb(240, 230, 140);
            cxVermelho.BackColor = Color.FromArgb(178, 34, 34);
            cxCinza.BackColor = Color.Gray;
            cxBisque.BackColor = Color.Bisque;
            objUsuarioLogado.Id_usuario = id_Usuario;
            objUsuarioLogado.getUserById();
            orderBy = " ORDER BY O.NR_OCORRENCIA, D.NM_DEPARTAMENTO, O.NM_MAQUINA, O.DT_ENTRADA, O.DS_STATUS";
            where = " (O.DS_STATUS LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NR_OCORRENCIA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " D.NM_DEPARTAMENTO LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NM_MAQUINA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.DT_ENTRADA LIKE '%" + txtFiltro.Text + "%') ";
            carregarOcorrencias();
            Timer();
            //lstOcorrencia.CheckBoxes = true;
        }

        private void Timer()
        {
            timer.Interval = 60000;
            timer.Start();
        }

        public void Atualizar(object sender, EventArgs e)
        {
            carregarOcorrencias();
            Timer();
        }

        public void carregarOcorrencias()
        {
            lstOcorrencia.Items.Clear();
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            MySqlDataReader sql_dr;
            if (Equals(objUsuarioLogado.Ds_perfil, "OPERADOR"))//se for funcionário ele só pode ver as ocorrencias abertas por ele
            {
                if (cbAll.Checked)//mostra tudo
                {
                    //sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " " + orderBy);
                    if (rbImpressora.Checked)//só impressoras
                    {
                        sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " AND D.NM_DEPARTAMENTO = 'IMPRESSORAS' " + orderBy);
                    }
                    else//só máquinas
                    {
                        sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " AND D.NM_DEPARTAMENTO != 'IMPRESSORAS' " + orderBy);
                    }
                }
                else//mostra tudo menos entregue ou baixa
                {
                    //sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE') " + orderBy);
                    if (rbImpressora.Checked)//só impressoras
                    {
                        sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO = 'IMPRESSORAS' " + orderBy);
                    }
                    else//só máquinas
                    {
                        sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_USUARIO = " + objUsuarioLogado.Id_usuario + " AND " + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO != 'IMPRESSORAS' " + orderBy);
                    }
                }
            }
            else// caso o usuario for adm ele pode visualizar todas as ocorrencias
            {
                if(objUsuarioLogado.Id_Departamento != 3)//só do mesmo departamento se não for TI
                {
                    if (cbAll.Checked)//mostra tudo
                    {
                        if (rbImpressora.Checked)
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_DEPARTAMENTO = " + objUsuarioLogado.Id_Departamento + " AND " + where + " AND D.NM_DEPARTAMENTO = 'IMPRESSORAS' " + orderBy);
                        }
                        else
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_DEPARTAMENTO = " + objUsuarioLogado.Id_Departamento + " AND " + where + " AND D.NM_DEPARTAMENTO != 'IMPRESSORAS' " + orderBy);
                        }
                    }
                    else//mostra tudo menos entregue ou baixa
                    {
                        if (rbImpressora.Checked)
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_DEPARTAMENTO =" + objUsuarioLogado.Id_Departamento + " AND " + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO = 'IMPRESSORAS' " + orderBy);
                        }
                        else
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE O.ID_DEPARTAMENTO =" + objUsuarioLogado.Id_Departamento + " AND " + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO != 'IMPRESSORAS' " + orderBy);
                        }
                    }
                }
                else// caso o usuario for adm ou do setor de TI ele pode visualizar todas as ocorrencias
                {
                    if (cbAll.Checked)//mostra tudo
                    {
                        //sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " " + orderBy);
                        if (rbImpressora.Checked)
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " AND D.NM_DEPARTAMENTO = 'IMPRESSORAS'" + orderBy);
                        }
                        else
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " AND D.NM_DEPARTAMENTO != 'IMPRESSORAS'" + orderBy);
                        }
                    }
                    else//mostra tudo menos entregue, baixa ou vhamado aberto
                    {
                        //sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE') " + orderBy);
                        if (rbImpressora.Checked)
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO = 'IMPRESSORAS'" + orderBy);
                        }
                        else
                        {
                            sql_dr = objOcorrencia.getOcorrenciasByFiltro("WHERE" + where + " AND (O.DS_STATUS != 'BAIXA' AND O.DS_STATUS != 'ENTREGUE' AND O.DS_STATUS != 'CHAMADO ABERTO') AND D.NM_DEPARTAMENTO != 'IMPRESSORAS'" + orderBy);
                        }
                    }
                }
                
            }
            
            while (sql_dr.Read())
            {
                //colocando os dados do list view
                ListViewItem instancia_lista = new ListViewItem(sql_dr["nr_ocorrencia"].ToString());
                instancia_lista.SubItems.Add(sql_dr["nm_departamento"].ToString());
                instancia_lista.SubItems.Add(sql_dr["nm_maquina"].ToString());
                TimeSpan dias = DateTime.Now.Subtract(Convert.ToDateTime(sql_dr["dt_entrada"].ToString()));
                instancia_lista.SubItems.Add(sql_dr["dt_entrada"].ToString().Substring(0, 10) + " - HÁ " +dias.Days+ " DIA(S) ATRÁS");
                instancia_lista.SubItems.Add(sql_dr["ds_status"].ToString());
                instancia_lista.SubItems.Add(sql_dr["nm_usuario"].ToString());

                lstOcorrencia.Items.Add(instancia_lista);

                int i = lstOcorrencia.Items.Count-1;

                int dif = Convert.ToInt32(dias.Days.ToString());
                if (dif < 3)
                {
                    lstOcorrencia.Items[i].BackColor = Color.FromArgb(60, 179, 113);
                }
                else if (dif >= 3 && dif <=7)
                {
                    lstOcorrencia.Items[i].BackColor = Color.FromArgb(240, 230, 140);
                }
                else if (dif > 7)
                {
                    lstOcorrencia.Items[i].BackColor = Color.FromArgb(178, 34, 34);
                }
                if (Equals(sql_dr["ds_status"].ToString(), "AGUARDANDO RETIRADA"))
                {
                    lstOcorrencia.Items[i].BackColor = Color.Gray;
                }
                if (Equals(sql_dr["ds_status"].ToString(), "ENTREGUE") || Equals(sql_dr["ds_status"].ToString(), "BAIXA"))
                {
                    lstOcorrencia.Items[i].BackColor = Color.Transparent;
                }
                if (Equals(sql_dr["ds_status"].ToString(), "CHAMADO ABERTO"))
                {
                    lstOcorrencia.Items[i].BackColor = Color.Green;
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CadOcorrencias fr_ocorrencia = new FRM_CadOcorrencias(this, objUsuarioLogado.Id_usuario);
            fr_ocorrencia.ShowDialog();
        }

        private void FRM_Ocorrencias_Load(object sender, EventArgs e)
        {

            //lstOcorrencia.Items[0].Selected = true;
        }

        private void lstOcorrencias_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(Equals(e.Column.ToString(), "0"))
            {
               orderBy =  " ORDER BY O.NR_OCORRENCIA, D.NM_DEPARTAMENTO, O.NM_MAQUINA, O.DT_ENTRADA, O.DS_STATUS";
            }
            if (Equals(e.Column.ToString(), "1"))
            {
                orderBy = " ORDER BY D.NM_DEPARTAMENTO, O.NR_OCORRENCIA, O.NM_MAQUINA, O.DT_ENTRADA, O.DS_STATUS";
            }
            if (Equals(e.Column.ToString(), "2"))
            {
                orderBy = " ORDER BY O.NM_MAQUINA, O.NR_OCORRENCIA, D.NM_DEPARTAMENTO, O.DT_ENTRADA, O.DS_STATUS";
            }
            if (Equals(e.Column.ToString(), "3"))
            {
                orderBy = " ORDER BY O.DT_ENTRADA, O.NR_OCORRENCIA,  D.NM_DEPARTAMENTO, O.NM_MAQUINA, O.DS_STATUS";
            }
            if (Equals(e.Column.ToString(), "4"))
            {
                orderBy = " ORDER BY O.DS_STATUS, O.NR_OCORRENCIA, D.NM_DEPARTAMENTO , O.NM_MAQUINA, O.DT_ENTRADA ";
            }
            carregarOcorrencias();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where = " (O.DS_STATUS LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NR_OCORRENCIA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " D.NM_DEPARTAMENTO LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NM_MAQUINA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.DT_ENTRADA LIKE '%" + txtFiltro.Text + "%') ";
            carregarOcorrencias();
        }

        private void FRM_Ocorrencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void lstOcorrencia_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked && this.lstOcorrencia.CheckedItems.Count == 1)
            {
                // Don't allow the only checked item to be unchecked.
                e.NewValue = e.CurrentValue;
            }
        }

        private void lstOcorrencia_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            for (int i = 0; i < this.lstOcorrencia.CheckedItems.Count; i++)
            {
                if (this.lstOcorrencia.CheckedItems[i] != e.Item)
                {
                    this.lstOcorrencia.CheckedItems[i].Checked = false;
                    break;
                }
            }
            try
            {
                string vl_select = lstOcorrencia.CheckedItems[0].Text;

                if (vl_select == "")
                {
                    MessageBox.Show("Por favor, selecione um campo válido!");
                }
                else
                {
                    nr_OcorrenciaSelecionada = vl_select;
                }
            }
            catch
            {
                nr_OcorrenciaSelecionada = "0";
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Equals(nr_OcorrenciaSelecionada, "0"))
            {
                MessageBox.Show("Selecione uma linha válida");
            }
            else
            {
                FRM_Procedimentos frm_editar = new FRM_Procedimentos(nr_OcorrenciaSelecionada, this);
                frm_editar.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Equals(nr_OcorrenciaSelecionada, "0"))
            {
                MessageBox.Show("Selecione uma linha válida");
            }
            else
            {
                FRM_Finalizar_Ocorrencia frm_saida = new FRM_Finalizar_Ocorrencia(Convert.ToInt32(nr_OcorrenciaSelecionada), this);
                frm_saida.ShowDialog();
            }
        }

        private void fecharOcorrencias(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sair(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Equals(nr_OcorrenciaSelecionada, "0"))
            {
                MessageBox.Show("Selecione uma linha válida");
            }
            else
            {
                FRM_EmitirQRCode frm_qrcode = new FRM_EmitirQRCode(Convert.ToInt32(nr_OcorrenciaSelecionada));
                frm_qrcode.ShowDialog();
            }
        }

        private void lstOcorrencia_SelectedIndex(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                string vl_select = lstOcorrencia.SelectedItems[0].Text;
                nr_OcorrenciaSelecionada = vl_select;
            }
            catch
            {
                nr_OcorrenciaSelecionada = "0";
            }
            lblProblema.Visible = true;
            clsOcorrencias objOcorrencia = new clsOcorrencias();
            objOcorrencia.Nr_ocorrencia = Convert.ToInt32(nr_OcorrenciaSelecionada);
            MySqlDataReader sql_dr = objOcorrencia.getOcorrenciasByID();
            if (sql_dr.Read())
            {
                objOcorrencia.Ds_Defeito = sql_dr["ds_defeito"].ToString();
                objOcorrencia.Dt_entrada = Convert.ToDateTime(sql_dr["dt_entrada"].ToString());
                objOcorrencia.Id_departamento = Convert.ToInt32(sql_dr["id_departamento"].ToString());
                objOcorrencia.Id_usuario = Convert.ToInt32(sql_dr["id_usuario"].ToString());
                objOcorrencia.Nm_maquina = sql_dr["nm_maquina"].ToString();
            }
            lblProblema.Text = objOcorrencia.Ds_Defeito;
        }

        private void btnRetirada_Click(object sender, EventArgs e)
        {
            if (Equals(nr_OcorrenciaSelecionada, "0"))
            {
                MessageBox.Show("Selecione uma linha válida");
            }
            else if (!Equals(lstOcorrencia.SelectedItems[0].SubItems[4].Text, "AGUARDANDO RETIRADA"))
            {
                MessageBox.Show("Você não pode retirar uma máquina que não está aguardando retirada!", "ERRO");
            }
            else
            {
                FRM_Saida form_saida = new FRM_Saida(Convert.ToInt32(nr_OcorrenciaSelecionada), this);
                form_saida.ShowDialog();
            }
        }

        private void AlterarFiltro(object sender, EventArgs e)
        {
            where = " (O.DS_STATUS LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NR_OCORRENCIA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " D.NM_DEPARTAMENTO LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.NM_MAQUINA LIKE '%" + txtFiltro.Text + "%' OR" +
                    " O.DT_ENTRADA LIKE '%" + txtFiltro.Text + "%') ";
            carregarOcorrencias();
        }

        private void Atualizar()
        {

        }

    }
}
