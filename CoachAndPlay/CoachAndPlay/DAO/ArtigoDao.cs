using System.Data;
using CoachAndPlay.MDL;
using System.Collections.Generic;
using System;

namespace CoachAndPlay.DAO
{
    public static class ArtigoDao
    {
        /// <summary>
        /// Incluir um artigo
        /// </summary>
        /// <param name="Artigo"></param>
        public static void Incluir(Artigo Artigo)
        {
            DataTable Tabela = BancoDao.Consultar("SP_INC_ARTIGO",  Artigo.Titulo, 
                                                                    Artigo.Autor.Codigo, 
                                                                    Artigo.Assunto.Codigo, 
                                                                    Artigo.Conteudo);

            if(Tabela.Rows.Count > 0)
                Artigo.Codigo = int.Parse(Tabela.Rows[0][0].ToString());
        }

        /// <summary>
        /// Consulta artigos
        /// </summary>
        /// <param name="Index">Index da pesquisa</param>
        /// <param name="QtdArtigos">Quantidade de artigos retornados</param>
        /// <returns>Lista contendo os artigos</returns>
        public static List<Artigo> Consultar(int Index, int QtdArtigos)
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_ARTIGO", Index, QtdArtigos);
            
            List<Artigo> Artigos = new List<Artigo>();

            for (int i = 0; i < Tabela.Rows.Count; i++)
            {
                Artigo Artigo = new Artigo();
                int CodAutor = int.Parse(Tabela.Rows[i]["ARTAUTOR"].ToString());
                int CodAssunto = int.Parse(Tabela.Rows[i]["ARTASSUNTO"].ToString());

                Artigo.Codigo = int.Parse(Tabela.Rows[i]["ARTCODIGO"].ToString());
                Artigo.Titulo = Tabela.Rows[i]["ARTTITULO"].ToString();
                Artigo.Autor = AutorDao.Consultar(CodAutor);
                Artigo.Assunto = AssuntoDao.Consultar(CodAssunto);
                Artigo.Conteudo = Tabela.Rows[i]["ARTCONTEUDO"].ToString();
                Artigo.DataCriacao = DateTime.Parse(Tabela.Rows[i]["ARTDATACRIACAO"].ToString());
                Artigo.Comentarios = ComentarioDao.Consultar(Artigo.Codigo, 1, 5);

                Artigos.Add(Artigo);
            }

            return Artigos;
        }

        /// <summary>
        /// Alterar um artigo
        /// </summary>
        /// <param name="Artigo"></param>
        public static void Alterar(Artigo Artigo)
        {
            BancoDao.Executar("SP_ALT_ARTIGO", Artigo.Codigo, Artigo.Titulo, Artigo.Autor.Codigo, Artigo.Assunto.Codigo, Artigo.Conteudo);
        }

        /// <summary>
        /// Excluir um artigo
        /// </summary>
        /// <param name="Artigo"></param>
        public static void Excluir(Artigo Artigo)
        {
            BancoDao.Executar("SP_EXL_ARTIGO", Artigo.Codigo);
        }
    }
}
