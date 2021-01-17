using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using AspNetMvc.App_Start;
using MongoDB.Driver;
using AspNetMvc.Models;

namespace AspNetMvc.Controllers
{
    public class ClienteController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<ClienteModels> cliente;

        public ClienteController()
        {
            dBContext = new MongoDBContext();
            cliente = dBContext.database.GetCollection<ClienteModels>("cliente");
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<ClienteModels> clientes = cliente.AsQueryable<ClienteModels>().ToList();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(string id)
        {
            var clientId = new ObjectId(id);
            var client = cliente.AsQueryable<ClienteModels>().SingleOrDefault(x => x.Id == clientId);

            return View(client);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteModels clienteModels)
        {
            try
            {
                cliente.InsertOne(clienteModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            var clientId = new ObjectId(id);
            var client = cliente.AsQueryable<ClienteModels>().SingleOrDefault(x => x.Id == clientId);

            return View(client);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ClienteModels clienteModels)
        {
            try
            {
                var filter = Builders<ClienteModels>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<ClienteModels>.Update
                    .Set("nome", clienteModels.Nome)
                    .Set("email", clienteModels.Email)
                    .Set("cpf", clienteModels.Cpf);

                var result = cliente.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(string id)
        {
            var clientId = new ObjectId(id);
            var client = cliente.AsQueryable<ClienteModels>().SingleOrDefault(x => x.Id == clientId);

            return View(client);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ClienteModels clienteModels)
        {
            try
            {
                cliente.DeleteOne(Builders<ClienteModels>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
