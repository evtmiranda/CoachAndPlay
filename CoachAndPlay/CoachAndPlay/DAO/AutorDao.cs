using System.Data;
using CoachAndPlay.MDL;
using System.Collections.Generic;

namespace CoachAndPlay.DAO
{
    public static class AutorDao
    {
        /// <summary>
        /// Incluir um autor
        /// </summary>
        /// <param name="Autor"></param>
        public static void Incluir(Autor Autor)
        {
            DataTable Tabela = BancoDao.Consultar("SP_INC_AUTOR", Autor.Assunto.Codigo, Autor.Profissao, Autor.Nome);

            if (Tabela.Rows.Count > 0)
                Autor.Codigo = int.Parse(Tabela.Rows[0][0].ToString());
        }

        /// <summary>
        /// Consultar um autor
        /// </summary>
        /// <returns></returns>
        public static Autor Consultar(int Codigo)
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_AUTOR", Codigo);

            if (Tabela.Rows.Count == 0)
                return null;

            Autor Autor = new Autor();
            int Assunto = int.Parse(Tabela.Rows[0]["AUTASSUNTO"].ToString());

            Autor.Codigo = int.Parse(Tabela.Rows[0]["AUTCODIGO"].ToString());
            Autor.Assunto = AssuntoDao.Consultar(Assunto);
            Autor.Profissao = Tabela.Rows[0]["AUTPROFISSAO"].ToString();
            Autor.Nome = Tabela.Rows[0]["AUTNOME"].ToString();

            return Autor;
        }

        /// <summary>
        /// Consultar todos os autores
        /// </summary>
        /// <returns></returns>
        public static List<Autor> Consultar()
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_AUTOR");
            List<Autor> Autores = new List<Autor>();

            for (int i = 0; i < Tabela.Rows.Count; i++)
            {
                Autor Autor = new Autor();
                int Assunto = int.Parse(Tabela.Rows[i]["AUTASSUNTO"].ToString());

                Autor.Codigo = int.Parse(Tabela.Rows[i]["AUTCODIGO"].ToString());
                Autor.Assunto = AssuntoDao.Consultar(Assunto);
                Autor.Profissao = Tabela.Rows[i]["AUTPROFISSAO"].ToString();
                Autor.Nome = Tabela.Rows[i]["AUTNOME"].ToString();

                Autores.Add(Autor);
            }

            return Autores;
        }

        /// <summary>
        /// Alterar um autor
        /// </summary>
        /// <param name="Autor"></param>
        public static void Alterar(Autor Autor)
        {
            BancoDao.Executar("SP_ALT_AUTOR", Autor.Codigo, Autor.Assunto.Codigo, Autor.Profissao, Autor.Nome);
        }

        /// <summary>
        /// Excluir um autor
        /// </summary>
        /// <param name="Autor"></param>
        public static void Excluir(Autor Autor)
        {
            BancoDao.Executar("SP_EXL_AUTOR", Autor.Codigo);
        }
    }
}
