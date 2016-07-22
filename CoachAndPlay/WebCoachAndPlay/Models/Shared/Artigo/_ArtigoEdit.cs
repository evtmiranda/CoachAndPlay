using CoachAndPlay.DAO;
using CoachAndPlay.MDL;
using System.Collections.Generic;

namespace WebCoachAndPlay.Models.Shared.Artigo
{
    public class _ArtigoEdit
    {
        public List<Autor> Autores { get; set; }
        public List<Assunto> Assuntos { get; set; }

        public _ArtigoEdit()
        {
            Autores = new List<Autor>();
            Assuntos = new List<Assunto>();

            Autores.AddRange(AutorDao.Consultar());
            Assuntos.AddRange(AssuntoDao.Consultar());
        }
    }
}