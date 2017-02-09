using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clAcessoDB
    {
        //variavel para reecebe rstring de conexao
        public string vConexao = "";

        //método responsavel por abrir a conexao com o banco de dados
        public SqlConnection AbreBanco()
        {
            //abre a conexao com o banco de dados
            SqlConnection conn = new SqlConnection(vConexao);
            conn.Open();
            return conn;
        }
        //método responsavel por fechar a conexao com o banco de dados
        public void FechaBanco(SqlConnection conn)
        {
            //fecha a conexao com a base de dados
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void ExecutaComando(string strQuery)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = AbreBanco();
                SqlCommand cmdComando = new SqlCommand();
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = conn;

                //passa os valores da quer SQL, tipo do comando
                //conexao e executa o comando
                cmdComando.ExecuteNonQuery();
            }
            //tratamento de excessoes
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //em caso de erro ou não, finaliza
                FechaBanco(conn);
            }
        }


    }

}
