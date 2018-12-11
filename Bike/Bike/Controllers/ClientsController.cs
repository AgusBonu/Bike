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
    public class ClientsController : Controller
    {

        private IRepositoryClients _repositoryclients;

        public ClientsController()
        {
            if (_repositoryclients == null)
                _repositoryclients = new RepositoryClients();

        }

        // GET: Clients/Clients
        public ActionResult Index()
        {
            var listClients = _repositoryclients.SelectAll();
            return View(listClients);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ModelClients model)
        {
            if (ModelState.IsValid)
            {
                _repositoryclients.AddClient(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var client = _repositoryclients.SelectClientById(id);
            return View(client);
        }


        [HttpPost]
        public ActionResult Edit(ModelClients model)
        {
            _repositoryclients.EditClient(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var client = _repositoryclients.SelectClientById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult DeleteClient(int id)
        {
            _repositoryclients.DeleteClient(id);
            return RedirectToAction("Index");
        }


    }
}