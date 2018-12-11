using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Models;
using BAL.Repositories;
using BAL.Interfaces;

namespace Presentation.Controllers
{
    public class TypeRentsController : Controller
    {
        private IRepositoryTypeRents _repositorytyperents;
        // GET: Promotions

        public TypeRentsController()
        {
            if (_repositorytyperents == null)
                _repositorytyperents = new RepositoryTypeRents();

        }
        public ActionResult Index()
        {
            var list = _repositorytyperents.SelectAll();
            return View(list);
        }


        // GET: Promotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        [HttpPost]
        public ActionResult Create(ModelTypeRents model)
        {
            if (ModelState.IsValid)
            {
                _repositorytyperents.AddTypeRent(model);
            }
            return RedirectToAction("Index");

        }

        // GET: TypeRents/Edit/5
        public ActionResult Edit(int id)
        {
            var obj = _repositorytyperents.SelectTypeRentById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(ModelTypeRents model)
        {
            _repositorytyperents.EditTypeRent(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var obj = _repositorytyperents.SelectTypeRentById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult DeleteTypeRent(int id)
        {
            _repositorytyperents.DeleteTypeRent(id);
            return RedirectToAction("Index");
        }

    }
}
