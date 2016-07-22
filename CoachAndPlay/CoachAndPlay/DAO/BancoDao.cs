using System;
using System.Data;
using System.Data.SqlClient;

namespace CoachAndPlay.DAO
{
    public class BancoDao
    {
        public static string Conexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CoachAndPlay‏;Data Source=gerson";

        /// <summary>
        /// Prepara os objetos de consulta no banco a cada requisição
        /// </summary>
        /// <param name="Procedure">Nome da procedure a ser executada</param>
        /// <param name="Parametros">Parametros que a procedure recebe</param>
        /// <returns></returns>
        private static SqlCommand PrepararObjetos(string Procedure, object[] Parametros)
        {
            if (Conexao == null)
                throw new Exception("Conexão não encontrada");

            if (Procedure == null)
                return null;

            string Comando = "EXEC " + Procedure;

            for (int i = 0; i < Parametros.Length; i++)
                Comando = string.Concat(Comando, " ", Parametros[i], ",");

            if (Parametros.Length > 0)
                Comando = Comando.Substring(0, Comando.Length - 1);

            SqlConnection cnn = new SqlConnection(Conexao);
            SqlCommand cmd = cnn.CreateCommand();

            cmd.CommandText = Comando;

            return cmd;
        }

        /// <summary>
        /// Consultar dados do banco
        /// </summary>
        /// <param name="Procedure">Nome da procedure a ser executada</param>
        /// <param name="Parametros">Parametros que a procedure recebe</param>
        /// <returns></returns>
        public static DataTable Consultar(string Procedure, params object[] Parametros)
        {
            SqlCommand cmd = PrepararObjetos(Procedure, Parametros);
            DataTable Tabela = new DataTable();

            cmd.Connection.Open();
            Tabela.Load(cmd.ExecuteReader());
            cmd.Connection.Close();

            return Tabela;
        }

        /// <summary>
        /// Executar algum procedimento sem retorno de dados
        /// </summary>
        /// <param name="Procedure">Nome da procedure a ser executada</param>
        /// <param name="Parametros">Parametros que a procedure recebe</param>
        public static void Executar(string Procedure, params object[] Parametros)
        {
            SqlCommand cmd = PrepararObjetos(Procedure, Parametros);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
