using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Cadastro
{
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        public void tstSalvar_Click(object sender, EventArgs e)
        {
            Salvar();

        }

        private void tstLimpar_Click(object sender, EventArgs e)
        {
            ClearForm.ClearForms(this);
        }

        private void tstCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public void Salvar()
        {
            {
                if (txtNome.Text == "")
                    erNome.SetError(lblNome, "Insira um nome para o cliente");
            }            // instancia a classe de negocio
            clProduto clProduto = new clProduto();
            if (txtNome.Text == "")
            {
                lblMenssagem.Text = "Insina um nome para o cliente";
                return;
            }



            DialogResult resposta;
            resposta = MessageBox.Show("Confirma o Cadastro do produto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }


            //carrega as propriedades
            clProduto.proDescricao = txtDescricao.Text;
            clProduto.proMarca = txtMarca.Text;
            clProduto.proPreco = txtPreco.Text;
            clProduto.proData = dtmData.Text;
            clProduto.proNome = txtNome.Text;

            //variavel com a sstring de conexao com o banco
            clProduto.banco = Properties.Settings.Default.conexaoDB;
            //chama metodo para gravar
            clProduto.Gravar();
            //mensagem de cofiguração
            MessageBox.Show("Cliente incluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ClearForm.ClearForms(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDescricao_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            {
                if (txtNome.Text == "")
                    erNome.SetError(lblNome, "Insira um nome para o cliente");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
