using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Models;
using BAL.Repositories;
using BAL.Interfaces;

namespace Bike.Controllers
{
    public class PromotionsController : Controller
    {
        private IRepositoryTypePromotions _repositorytypepromotions;
        // GET: Promotions

        public PromotionsController()
        {
            if (_repositorytypepromotions == null)
                _repositorytypepromotions = new RepositoryTypePromotions();

        }
        public ActionResult Index()
        {
            var list = _repositorytypepromotions.SelectAll();
            return View(list);
        }


        // GET: Promotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        [HttpPost]
        public ActionResult Create(ModelTypePromotions model)
        {
            if (ModelState.IsValid)
            {
                _repositorytypepromotions.AddTypePromotion(model);
            }
            return RedirectToAction("Index");

        }


        public ActionResult Edit(int id)
        {
            var obj = _repositorytypepromotions.SelectTypePromotionById(id);
            return View(obj);
        }


        [HttpPost]
        public ActionResult Edit(ModelTypePromotions model)
        {
            _repositorytypepromotions.EditTypePromotion(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var obj = _repositorytypepromotions.SelectTypePromotionById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult DeletePromotion(int id)
        {
            _repositorytypepromotions.DeleteTypePromotion(id);
            return RedirectToAction("Index");
        }
    }
}
