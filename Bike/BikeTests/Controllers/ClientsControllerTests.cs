using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bike.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAL.Models;

namespace Bike.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        [TestMethod()]
        public void ClientsControllerTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.Index() as ViewResult;
            const string expectedViewName = "";
            Assert.IsNotNull(result, "Deberia haber retornado un ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "El nombre de la vista deberia haber sido {0}", expectedViewName);
            // Verificamos que el modelo sea el que estamos esperando
        }

        [TestMethod()]
        public void IndexTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.Index() as ViewResult;
            const string expectedViewName = "";
            Assert.IsNotNull(result, "Deberia haber retornado un ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "El nombre de la vista deberia haber sido {0}", expectedViewName);
            // Verificamos que el modelo sea el que estamos esperando
            var model1 = result.ViewData.Model as List<ModelClients>;
            Assert.IsNotNull(model1, "El modelo esperado era una lista de Model Clients");
        }

        [TestMethod()]
        [HttpPost]
        public void CreateTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.Create() as ViewResult;
            const string expectedViewName = "";
            Assert.IsNotNull(result, "Deberia haber retornado un ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "El nombre de la vista deberia haber sido {0}", expectedViewName);
            // Verificamos que el modelo sea el que estamos esperando
            var model1 = result.ViewData.Model as List<ModelClients>;
            Assert.IsNull(model1, "El modelo esperado era nulo.");
        }
       

        [TestMethod()]
        public void EditTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.Edit(9) as ViewResult;
            Assert.IsNotNull(result, "Deberia haber retornado un ViewResult");
            Assert.IsNotNull(result.Model, "Deberia haber devuelto un result.Model de ModelClients");
        }
       

        [TestMethod()]
        public void DeleteTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.Delete(9) as ViewResult;
            Assert.IsNotNull(result, "Deberia haber retornado un ViewResult");
            Assert.IsNotNull(result.Model, "Deberia haber devuelto un result.Model de ModelClients");
        }

        [TestMethod()]
        public void DeleteClientTest()
        {
            ClientsController clientController = new ClientsController();
            var result = clientController.DeleteClient(10) as RedirectToRouteResult;
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Index",result.RouteValues["action"].ToString(),"Deberia haber redireccionado al Index");
        }
    }
}