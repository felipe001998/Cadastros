using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class clCliente
    {
        //propriedade
        public string banco      { get; set; }
        public int    cliCodigo  { get; set; }
        public string cliNome    { get; set; }
        public string cliEndereco  { get; set; }
        public string cliNumero  { get; set; }
        public string cliBairro  { get; set; }
        public string cliCidade  { get; set; }
        public string cliEstado  { get; set; }
        public string cliCEP     { get; set; }
        public string cliCelular { get; set; }
        public void Gravar()
        {
            //variavel utilizada para "concatenar" textos de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do insert
            strQuery.Append(" INSERT INTO tbCliente");

            strQuery.Append(" ( ");

            strQuery.Append(" cliNome ");
            strQuery.Append(", cliEndereco ");
            strQuery.Append(", cliNumero ");
            strQuery.Append(", cliBairro ");
            strQuery.Append(", cliCidade ");
            strQuery.Append(", cliEstado ");
            strQuery.Append(", cliCEP ");
            strQuery.Append(", cliCelular ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append(" '" + cliNome + "'");
            strQuery.Append(", '" + cliEndereco + "'");
            strQuery.Append(", '" + cliNumero + "'");
            strQuery.Append(", '" + cliBairro + "'");
            strQuery.Append(", '" + cliCidade + "'");
            strQuery.Append(", '" + cliEstado + "'");
            strQuery.Append(", '" + cliCEP + "'");
            strQuery.Append(", '" + cliCelular + "'");

            strQuery.Append(" ) ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
    }
}
