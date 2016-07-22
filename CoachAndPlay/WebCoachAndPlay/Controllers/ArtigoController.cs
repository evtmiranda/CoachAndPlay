using System;
using System.Web;
using System.Web.Mvc;
using CoachAndPlay.DAO;
using CoachAndPlay.MDL;
using System.Collections.Generic;

namespace WebCoachAndPlay.Controllers
{
    public class ArtigoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtTitulo, int cboAutor, int cboAssunto, string txtConteudo)
        {
            try
            {
                Artigo artigo = new Artigo();
                artigo.Titulo = txtTitulo;
                artigo.Autor.Codigo = cboAutor;
                artigo.Assunto.Codigo = cboAssunto;
                artigo.Conteudo = txtConteudo;

                ArtigoDao.Incluir(artigo);

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
	}
}