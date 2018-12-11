using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Interfaces;
using BAL.Repositories;
using BAL.Models;

namespace Presentation.Areas.Rents.Controllers
{
    public class RentsController : Controller
    {

        private IRepositoryRents _repositoryrents;
        private IRepositoryClients _repositoryclients;
        private IRepositoryTypePromotions _repositorytypepromotions;
        private IRepositoryTypeRents _repositorytyperents;
        private IRepositoryBodyRents _repositorybodyrents;
        private static List<ModelBodyRents> listbodyrents;

        public RentsController()
        {
            if (_repositoryrents == null)
                _repositoryrents = new RepositoryRents();
            if (_repositoryclients == null)
                _repositoryclients = new RepositoryClients();
            if (_repositorytypepromotions == null)
                _repositorytypepromotions = new RepositoryTypePromotions();
            if (_repositorytyperents == null)
                _repositorytyperents = new RepositoryTypeRents();
            if (listbodyrents == null)
                listbodyrents = new List<ModelBodyRents>();
            if (_repositorybodyrents == null)
                _repositorybodyrents = new RepositoryBodyRents();

        }

        // GET: Rents/Rents
        public ActionResult Index()
        {
            var rent = _repositoryrents.SelectAll();
            return View(rent);
        }

        // GET: Rents/Rents/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var client = _repositorybodyrents.SelectBodyRentById(id);
                return View(client);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Rents/Rents/Create
        public ActionResult Create()
        {
            listbodyrents = new List<ModelBodyRents>();
            var clients = _repositoryclients.SelectAll();
            var typerents = _repositorytyperents.SelectAll();

            ViewBag.clients = clients;
            ViewBag.typerents = typerents;
            ViewBag.listbodyrents = listbodyrents;
            // TODO: Add insert logic here
            return View();
        }

        public ActionResult RemoveCar(int id)
        {
            ModelBodyRents obj = null;
            foreach (var element in listbodyrents)
            {
                if (element.typerents_id == id)
                {
                    obj = element;
                    break;
                }
            }
            listbodyrents.Remove(obj);

            var clients = _repositoryclients.SelectAll();
            var typerents = _repositorytyperents.SelectAll();

            ViewBag.clients = clients;
            ViewBag.typerents = typerents;
            ViewBag.listbodyrents = listbodyrents;

            return View("Create");
        }

        public ActionResult Create2()
        {
            var clients = _repositoryclients.SelectAll();
            var typerents = _repositorytyperents.SelectAll();

            ViewBag.clients = clients;
            ViewBag.typerents = typerents;
            ViewBag.listbodyrents = listbodyrents;
            return View("Create");
        }

        public ActionResult Confirm()
        {
            if (listbodyrents.Count > 0)
            {
                var promotions = _repositorytypepromotions.SelectWhereQuantity(listbodyrents.Count);
                ViewBag.promotions = promotions;
                var clients = _repositoryclients.SelectAll();
                ViewBag.clients = clients;
                return View();
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public ActionResult Confirm(ModelRents model)
        {

            if (listbodyrents.Count > 0)
            {
                if (ModelState.IsValid)
                {
                    model.date = DateTime.Now;
                    model.quantity = listbodyrents.Count;
                    double price = 0;
                    foreach (var item in listbodyrents)
                    {
                        price += item.price;
                    }


                    if (model.typepromotions_id != 0)
                    {
                        var promotion = _repositorytypepromotions.SelectTypePromotionById(model.typepromotions_id);
                        decimal disc = Convert.ToDecimal(price) * (Convert.ToDecimal(promotion.discount) / 100);
                        model.price = price - Convert.ToDouble(disc);
                    }
                    else
                    {
                        model.price = price;
                    }


                    int result = _repositoryrents.AddRent(model);

                    foreach (var item in listbodyrents)
                    {
                        item.rents_id = result;
                        item.date = model.date;
                        _repositorybodyrents.AddBodyRent(item);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Confirm");
                }
            }
            else
            {
                return RedirectToAction("Create");
            }
        }


        // POST: Rents/Rents/Create
        [HttpPost]
        public ActionResult Create2(ModelBodyRents model)
        {
            try
            {
                var rent = _repositorytyperents.SelectTypeRentById(model.typerents_id);
                model.price = rent.price;
                model.name_temp = rent.name;
                listbodyrents.Add(model);
                var clients = _repositoryclients.SelectAll();
                var typerents = _repositorytyperents.SelectAll();

                ViewBag.clients = clients;
                ViewBag.typerents = typerents;
                ViewBag.listbodyrents = listbodyrents;

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }


        // GET: Rents/Rents/Delete/5
        public ActionResult Delete(int id)
        {
            var rent = _repositoryrents.SelectRentById(id);
            return View(rent);
        }

        // POST: Rents/Rents/Delete/5
        [HttpPost]
        public ActionResult DeleteRents(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repositoryrents.DeleteRent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
