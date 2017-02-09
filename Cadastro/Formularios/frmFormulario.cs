using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
namespace Cadastro
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PesquisarCEP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        void Cadastrar()
        {
            
        }
        private void Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //enviar Tab quando fro pressionado enter
            if ((e.KeyChar.CompareTo((char)Keys.Return)) ==0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void Cadastro_DragDrop(object sender, DragEventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
          //  OpenForm();
        }
        
        void PesquisarCEP()
        {
            DataSet ds = new DataSet();

            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCep.Text);
            ds.ReadXml(xml);
            if (ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep completo" || ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep único")
            {
                txtEndereco.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString() + " " + ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                cboEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                txtNumero.Focus();
            }
            else
            {
                MessageBox.Show("CEP não Encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void OpenForm(Type frmType)
        {
            bool bolCtl = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Equals(frmType))
                {
                    form.Show();
                    bolCtl = true;
                    break;
                }
            }

            if (!bolCtl)
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.Show();
            }
        }

        private void tstSalvar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    /*    public static void CleaarForm(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control ctrControl in parent.Controls)
            {
                //Loop through all controls 
                if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.TextBox)))
                {
                    //Check to see if it's a textbox 
                    ((System.Windows.Forms.TextBox)ctrControl).Text = string.Empty;
                    //If it is then set the text to String.Empty (empty textbox) 
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RichTextBox)))
                {
                    //If its a RichTextBox clear the text
                    ((System.Windows.Forms.RichTextBox)ctrControl).Text = string.Empty;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.ComboBox)))
                {
                    //Next check if it's a dropdown list 
                    ((System.Windows.Forms.ComboBox)ctrControl).SelectedIndex = -1;
                    //If it is then set its SelectedIndex to 0 
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.CheckBox)))
                {
                    //Next uncheck all checkboxes
                    ((System.Windows.Forms.CheckBox)ctrControl).Checked = false;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RadioButton)))
                {
                    //Unselect all RadioButtons
                    ((System.Windows.Forms.RadioButton)ctrControl).Checked = false;
                }
                if (ctrControl.Controls.Count > 0)
                {
                    //Call itself to get all other controls in other containers 
                    CleaarForm(ctrControl);
                }
            }
        }
        */
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {

        }

        private void Cadastro_Load_1(object sender, EventArgs e)
        {
         
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tstSalva_Click(object sender, EventArgs e)
        {
            Salvar();
            /* instancia a classe de negocio
            clCliente clClientes = new clCliente();
            if (txtNome.Text == "")
            {
                lblMensagem.Text = "Insina um nome para o cliente";
                return;
            }

            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(resposta.Equals(DialogResult.No))
            {
                return;
            }

            //carrega as propriedades
            clClientes.cliNome = txtNome.Text;
            clClientes.cliEndereco = txtEndereco.Text;
            clClientes.cliNumero = txtNumero.Text;
            clClientes.cliBairro = txtBairro.Text;
            clClientes.cliCidade = txtCidade.Text;
            clClientes.cliEstado = cboEstado.Text;
            clClientes.cliCEP = mskCep.Text;
            clClientes.cliCelular = mtbCelular.Text;

            //variavel com a sstring de conexao com o banco
            clClientes.banco = Properties.Settings.Default.conexaoDB;
            //chama metodo para gravar
            clClientes.Gravar();
            //mensagem de cofiguração
            MessageBox.Show("Cliente incluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ClearForm.ClearForms(this);
            */
        }
        public void Salvar()
        {
            if (txtNome.Text == "")
            {
                erNome.SetError(lblNome, "Insira um nome para o cliente");
            }
            // instancia a classe de negocio
            clCliente clClientes = new clCliente();
            if (txtNome.Text == "")
            {
                lblMensagem.Text = "Insina um nome para o cliente";
                return;
            }

            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //carrega as propriedades
            clClientes.cliNome = txtNome.Text;
            clClientes.cliEndereco = txtEndereco.Text;
            clClientes.cliNumero = txtNumero.Text;
            clClientes.cliBairro = txtBairro.Text;
            clClientes.cliCidade = txtCidade.Text;
            clClientes.cliEstado = cboEstado.Text;
            clClientes.cliCEP = mskCep.Text;
            clClientes.cliCelular = mtbCelular.Text;

            //variavel com a sstring de conexao com o banco
            clClientes.banco = Properties.Settings.Default.conexaoDB;
            //chama metodo para gravar
            clClientes.Gravar();
            //mensagem de cofiguração
            MessageBox.Show("Cliente incluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ClearForm.ClearForms(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ClearForm.ClearForms(this);
        }
    }
}
