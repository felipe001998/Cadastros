using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clProduto
    {
        //propriedades

        public string banco { get; set; }
        public string proCodigo { get; set; }
        public string proNome { get; set; }
        public string proDescricao { get; set; }
        public string proMarca { get; set; }
        public string proPreco { get; set; }
        public string proData { get; set; }
        public void Gravar()
        {
            //variavel utilizada para "concatenar" textos de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do insert
            strQuery.Append(" INSERT INTO tbProduto");

            strQuery.Append(" ( ");

            strQuery.Append(" proCodigo ");
            strQuery.Append(", proNome ");
            strQuery.Append(", proDescricao ");
            strQuery.Append(", proMarca ");
            strQuery.Append(", proPreco ");
            strQuery.Append(", proData ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append(" '" + proCodigo + "'");
            strQuery.Append(", '" + proNome + "'");
            strQuery.Append(", '" + proDescricao + "'");
            strQuery.Append(", '" + proMarca + "'");
            strQuery.Append(", '" + proPreco + "'");
            strQuery.Append(", '" + proData + "'");

            strQuery.Append(" ) ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
    }

}
