using System.Data;
using CoachAndPlay.MDL;
using System.Collections.Generic;
using System;

namespace CoachAndPlay.DAO
{
    public static class ComentarioDao
    {
        /// <summary>
        /// Incluir um comentario em um artigo
        /// </summary>
        /// <param name="Artigo"></param>
        /// <param name="Comentario"></param>
        public static void Incluir(int CodigoArtigo, Comentario Comentario)
        {
            DataTable Tabela = BancoDao.Consultar("SP_INC_COMENTARIO", CodigoArtigo, Comentario.Nome, Comentario.Email, Comentario.Texto);

            if(Tabela.Rows.Count > 0)
                Comentario.Codigo = int.Parse(Tabela.Rows[0][0].ToString());
        }

        /// <summary>
        /// Recupera os comentarios de um artigo
        /// </summary>
        /// <param name="CodigoArtigo"></param>
        /// <returns></returns>
        public static List<Comentario> Consultar(int CodigoArtigo, int Index, int QtdComentarios)
        {
            DataTable Tabela = BancoDao.Consultar("SP_CON_COMENTARIO", CodigoArtigo, Index, QtdComentarios);
            List<Comentario> Comentarios = new List<Comentario>();

            for (int i = 0; i < Tabela.Rows.Count; i++)
            {
                Comentario Comentario = new Comentario();

                Comentario.Codigo = int.Parse(Tabela.Rows[i]["COMCODIGO"].ToString());
                Comentario.Nome = Tabela.Rows[i]["COMNOME"].ToString();
                Comentario.Email = Tabela.Rows[i]["COMEMAIL"].ToString();
                Comentario.Texto = Tabela.Rows[i]["COMCOMENTARIO"].ToString();
                Comentario.DataCriacao = DateTime.Parse(Tabela.Rows[i]["COMDATA"].ToString());

                Comentarios.Add(Comentario);
            }

            return Comentarios;
        }
    }
}
