using System.Data;
using CoachAndPlay.MDL;
using System.Collections.Generic;

namespace CoachAndPlay.DAO
{
    public static class AssuntoDao
    {
        /// <summary>
        /// Incluir um novo assunto
        /// </summary>
        /// <param name="Assunto"></param>
        public static void Incluir(Assunto Assunto)
        {
            DataTable Tabela = BancoDao.Consultar("SP_INC_ASSUNTO", Assunto.Nome);

            if (Tabela.Rows.Count > 0)
                Assunto.Codigo = int.Parse(Tabela.Rows[0][0].ToString());
        }

        /// <summary>
        /// Consultar um assunto
        /// </summary>
        /// <returns></returns>
        public static Assunto Consultar(int Codigo)
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_ASSUNTO", Codigo);

            if (Tabela.Rows.Count == 0)
                return null;

            Assunto Assunto = new Assunto();
            Assunto.Codigo = int.Parse(Tabela.Rows[0]["ASSCODIGO"].ToString());
            Assunto.Nome = Tabela.Rows[0]["ASSNOME"].ToString();

            return Assunto;
        }

        /// <summary>
        /// Consultar todos os assuntos
        /// </summary>
        /// <returns></returns>
        public static List<Assunto> Consultar()
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_ASSUNTO");
            List<Assunto> Assuntos = new List<Assunto>();

            for (int i = 0; i < Tabela.Rows.Count; i++)
            {
                Assunto Assunto = new Assunto();
                Assunto.Codigo = int.Parse(Tabela.Rows[i]["ASSCODIGO"].ToString());
                Assunto.Nome = Tabela.Rows[i]["ASSNOME"].ToString();

                Assuntos.Add(Assunto);
            }

            return Assuntos;
        }

        /// <summary>
        /// Alterar um assunto
        /// </summary>
        /// <param name="Assunto"></param>
        public static void Alterar(Assunto Assunto)
        {
            BancoDao.Executar("SP_ALT_ASSUNTO", Assunto.Codigo, Assunto.Nome);
        }

        /// <summary>
        /// Excluir um assunto
        /// </summary>
        /// <param name="Assunto"></param>
        public static void Excluir(Assunto Assunto)
        {
            BancoDao.Executar("SP_EXL_ASSUNTO", Assunto.Codigo);
            Assunto = null;
        }
    }
}
