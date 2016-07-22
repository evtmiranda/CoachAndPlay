using System;
using System.Collections.Generic;

namespace CoachAndPlay.MDL
{
    public class Artigo
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public Autor Autor { get; set; }
        public Assunto Assunto { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public Artigo()
        {
            Autor = new Autor();
            Assunto = new Assunto();
            Comentarios = new List<Comentario>();
        }
    }
}
