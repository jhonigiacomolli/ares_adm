﻿using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace ARES_ADM.Classes
{
    class Classe_Configuracoes
    {
        public static string NomeProjeto = "ARES Management Solutions";
        public static string NomeModulos = "ARES ADM";
        public static string RazaoSocial;
        public static string CNPJ;
        public static string Endereco;
        public static string Email;
        public static string Telefone;
        public static string TipoBancoHoras;
        public static string Infotec;
        public static string Datasheet;
        public static string CatalisesOriginais;
        public static string ValorCatalises;
        public static string HoraFunilaria;
        public static string HoraPintura;
        public static string HoraMecanica;
        public static string HoraEletrica;
        public static string HoraTapecaria;
        public static string HoraTerceiros;
        public static string HoraRecuperacao;

        public void Carrega_Configuracoes(frmConfiguracoes Form)
        {
            try
            {
                DataTable DT = Classes_Conexao.Preenche_DataTable("SELECT * FROM Configuracoes");

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    DataRow DR = DT.Rows[i];
                    if (DR.RowState != DataRowState.Deleted)
                    {
                        Form.txtRazaoSocial.Text = RazaoSocial;
                        Form.txtCNPJ_CPF.Text = CNPJ;
                        Form.txtEndereco.Text = Endereco;
                        Form.txtEmail.Text = Email;
                        Form.txtTelefone.Text = Telefone;
                        Form.cboTipoBancoHoras.Text = TipoBancoHoras;

                        if (Infotec.Equals("TRUE")) { Form.cboInfoTec.Text = "SIM"; } else { Form.cboInfoTec.Text = "NÃO"; } 
                        
                        if (Datasheet.Equals("TRUE")) { Form.cboDatasheet.Text = "SIM"; } else { Form.cboDatasheet.Text = "NÃO"; }

                        if (CatalisesOriginais.Equals("TRUE")) { Form.cboCatalisesOriginais.Text = "SIM"; } else { Form.cboCatalisesOriginais.Text = "NÃO"; }

                        if (ValorCatalises.Equals("TRUE")) { Form.cboValorCatalises.Text = "SIM"; } else { Form.cboValorCatalises.Text = "NÃO"; }
                    }
                }
                DT.Dispose();
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex);
                Messagebox.Show();
            }
        }

        public void Leitura_Configuracoes()
        {
            try
            {
                DataTable DT = Classes_Conexao.Preenche_DataTable("SELECT * FROM Configuracoes");

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    DataRow DR = DT.Rows[i];
                    if (DR.RowState != DataRowState.Deleted)
                    {
                        RazaoSocial = DR["Empresa_RazaoSocial"].ToString().TrimEnd().ToUpper();
                        CNPJ = DR["Empresa_CNPJ"].ToString().TrimEnd().ToUpper();
                        Endereco = DR["Empresa_Endereco"].ToString().TrimEnd().ToUpper();
                        Email = DR["Empresa_Email"].ToString().TrimEnd().ToUpper();
                        Telefone = DR["Empresa_Telefone"].ToString().TrimEnd().ToUpper();
                        TipoBancoHoras = DR["TipoBancoHoras"].ToString().TrimEnd().ToUpper();
                        Infotec = DR["Exibir_Catalise_InfoTec"].ToString().TrimEnd().ToUpper();    
                        Datasheet = DR["Exibir_Catalise_Datasheet"].ToString().TrimEnd().ToUpper();
                        CatalisesOriginais = DR["Exibir_CatalisesOriginais"].ToString().TrimEnd().ToUpper();
                        ValorCatalises = DR["Exibir_Catalise_Valores"].ToString().TrimEnd().ToUpper();
                    }
                }
                DT.Dispose();
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }

        public void Salvar_Configuracoes(frmConfiguracoes Form)
        {
            string Razao = Form.txtRazaoSocial.Text;
            string CNPJ = Form.txtCNPJ_CPF.Text;
            string Endereco = Form.txtEndereco.Text;
            string Email = Form.txtEmail.Text;
            string Telefone = Form.txtTelefone.Text;
            string BancoHoras = Form.cboTipoBancoHoras.Text;
            string InfoTec= string.Empty;
            string Datasheet=string.Empty;

            if (Form.cboInfoTec.Text.Equals("SIM")) { InfoTec = "TRUE"; }
            if (Form.cboInfoTec.Text.Equals("NÃO")) { InfoTec = "FALSE"; }

            if (Form.cboDatasheet.Text.Equals("SIM")) { Datasheet = "TRUE"; }
            if (Form.cboDatasheet.Text.Equals("NÃO")) { Datasheet = "FALSE"; }

            if (Form.cboCatalisesOriginais.Text.Equals("SIM")) { CatalisesOriginais = "TRUE"; }
            if (Form.cboCatalisesOriginais.Text.Equals("NÃO")) { CatalisesOriginais = "FALSE"; }

            if (Form.cboValorCatalises.Text.Equals("SIM")) { ValorCatalises = "TRUE"; }
            if (Form.cboValorCatalises.Text.Equals("NÃO")) { ValorCatalises = "FALSE"; }

            try
            {
                SqlCeConnection CONN = new SqlCeConnection(Classes_Conexao.strConnDatabase);

                string comandoSQL = "UPDATE Configuracoes SET Empresa_RazaoSocial='" + Razao.Replace("'", "''") + "', Empresa_CNPJ='" + CNPJ + "', Empresa_Endereco='" + Endereco + "', Empresa_Email='" + Email + "', Empresa_Telefone='" + Telefone + "', TipoBancoHoras='" + BancoHoras + "', Exibir_Catalise_InfoTec='" + InfoTec + "', Exibir_Catalise_Datasheet='" + Datasheet + "', Exibir_CatalisesOriginais='" + CatalisesOriginais + "', Exibir_Catalise_Valores='" + ValorCatalises + "' WHERE id='1'";

                SqlCeCommand CMD = new SqlCeCommand(comandoSQL, CONN);

                CONN.Open();
                CMD.ExecuteNonQuery();
                CONN.Close();

                Form messagebox = new frmMensagemBox(Classe_Mensagem.ALERTA, "Alteração de Configurações", "Suas alterações foram salvas com sucesso!");
                messagebox.ShowDialog();
            }
            catch (SqlCeException ex)
            {
                Form Messagebox = new frmMensagemBox(Classe_Mensagem.CRITICO, "Erro", "Ocorreu o seguinte erro:/n" + ex.Message);
                Messagebox.Show();
            }
        }
    }
}
