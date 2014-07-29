using mvc_crud_repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_crud_repository.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepositorio _livroRepositorio;

        public LivroController()
        {
            this._livroRepositorio = new LivroRepostiorio(new DBContext());
        }
        
        //
        // GET: /Livro/
        public ActionResult Index()
        {
            var livros = from livro in _livroRepositorio.GetLivros()
                         select livro;
            return View(livros);
        }

        //
        // GET: /Livro/Details/5
        public ActionResult Details(int id)
        {
            Livro livro = _livroRepositorio.GetLivroPorID(id);
            return View(livro);
        }

        //
        // GET: /Livro/Create
        public ActionResult Create()
        {
            return View(new Livro());
        }

        //
        // POST: /Livro/Create
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.InserirLivro(livro);
                    _livroRepositorio.Salvar();
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente....");
                
            }
            return View();
        }

        //
        // GET: /Livro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                // TODO: Add update logic here

                _livroRepositorio.AtualizarLivro(livro);
                _livroRepositorio.Salvar();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente.....");
            }
            return View();
        }

        //
        // GET: /Livro/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente novamente......";
            }
            Livro livro = _livroRepositorio.GetLivroPorID(id);
            return View(livro);
        }

        //
        // POST: /Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Livro livro = _livroRepositorio.GetLivroPorID(id);
                _livroRepositorio.DeletarLivro(id);
                _livroRepositorio.Salvar();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                  new System.Web.Routing.RouteValueDictionary {
               { "id", id },
               { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
