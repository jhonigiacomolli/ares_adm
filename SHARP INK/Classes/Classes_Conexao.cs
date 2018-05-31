﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

namespace SHARP_INK.Classes
{
    public class Classes_Conexao
    {
        private static string Password_DB = "++060188jhoni.fg";
        public static string strConnDatabase = @"Data Source=D:\Projeto Auto Sharp\SHARP INK\SHARP INK\Database\Database.sdf;Password=" + Password_DB + "";
        public static string CaminhoLogo = @"D:\Projeto Auto Sharp\SHARP INK\SHARP INK\Logo\Logo.png";
        public static string Tipo_BancoHoras;
        public static DataTable Preenche_DataTable(string SQL)
        {
            DataTable Data_Table;

            try
            {
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                Data_Table = DS.Tables[0];

                return Data_Table;
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
                return null;
            }
        }

        public void Get_Cores(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Cor FROM Cores ORDER BY Cor ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Cor"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_Tamanho(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Tamanho FROM Tamanho ORDER BY id ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Tamanho"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_Grupos(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT * FROM Produtos_Grupos";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                CBO.Items.Add("Selecione o grupo");

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Grupo"].ToString().TrimEnd());
                }
                CBO.SelectedIndex = 0;
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
        public void Get_Proprietario(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Nome FROM Proprietario ORDER BY Nome ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Nome"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
        public void Get_FiltroApontamento(ComboBox CBO, string Filtro)
        {
            CBO.Items.Clear();
            try
            {
                if (Filtro.Equals("Funcionário"))
                {
                    string SQL = "SELECT Nome FROM Funcionarios ORDER BY Nome ASC";
                    SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                    DataSet DS = new DataSet();
                    SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                    DA.Fill(DS);
                    DataTable Data_Table = DS.Tables[0];

                    CBO.Items.Add("Selecione o funcionário");

                    for (int i = 0; i < Data_Table.Rows.Count; i++)
                    {
                        DataRow DR = Data_Table.Rows[i];
                        CBO.Items.Add(DR["Nome"].ToString().TrimEnd());
                    }
                }
                if (Filtro.Equals("Função"))
                {
                    string SQL = "SELECT * FROM Funcionarios_Funcao ORDER BY Funcao ASC";
                    SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                    DataSet DS = new DataSet();
                    SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                    DA.Fill(DS);
                    DataTable Data_Table = DS.Tables[0];

                    CBO.Items.Add("Selecione a função");

                    for (int i = 0; i < Data_Table.Rows.Count; i++)
                    {
                        DataRow DR = Data_Table.Rows[i];
                        CBO.Items.Add(DR["Funcao"].ToString().TrimEnd());
                    }
                }
                CBO.SelectedIndex = 0;
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_Funcao(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT * FROM Funcionarios_Funcao ORDER BY Funcao ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                CBO.Items.Add("Selecione a função");

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Funcao"].ToString().TrimEnd());
                }
                CBO.SelectedIndex = 0;
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
        public void Get_Funcionario(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Nome FROM Funcionarios ORDER BY Nome ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                CBO.Items.Add("Selecione o campo de filtro");

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Funcao"].ToString().TrimEnd());
                }

                CBO.SelectedIndex = 0;
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_TipoBanco()
        {
            try
            {
                string SQL = "SELECT TipoBancoHoras FROM Configuracoes";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    Tipo_BancoHoras = DR["TipoBancoHoras"].ToString().TrimEnd();
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_PecaAplicacao(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Aplicacao FROM Pecas_Aplicacao ORDER BY Aplicacao ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Aplicacao"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
        public void Get_TipoPeca(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Tipo FROM Pecas_Tipo ORDER BY Tipo ASC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Tipo"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Get_DanoPeca(ComboBox CBO)
        {
            try
            {
                string SQL = "SELECT Dano FROM Pecas_Dano ORDER BY id DESC";
                SqlCeConnection CONN = new SqlCeConnection(strConnDatabase);
                DataSet DS = new DataSet();
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, CONN);

                DA.Fill(DS);
                DataTable Data_Table = DS.Tables[0];

                for (int i = 0; i < Data_Table.Rows.Count; i++)
                {
                    DataRow DR = Data_Table.Rows[i];
                    CBO.Items.Add(DR["Dano"].ToString().TrimEnd());
                }
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
    }
}
