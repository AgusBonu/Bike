using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;

namespace BAL.Repositories
{
    public class RepositoryClients : IRepositoryClients
    {
        public void AddClient(ModelClients model)
        {
            using (var db = new DAL.BikeEntities())
            {
                db.Clients.Add(MapToDB(model));
                db.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aDelete = db.Clients.Find(id);
                db.Clients.Remove(aDelete);
                db.SaveChanges();
            }
        }

        public void EditClient(ModelClients model)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aEdit = db.Clients.Find(model.id);
                aEdit.name = model.name;
                aEdit.surname = model.surname;
                aEdit.email = model.email;
                aEdit.telephone = model.telephone;
                db.SaveChanges();
            }
        }

        public List<ModelClients> SelectAll()
        {
            using (var db = new DAL.BikeEntities())
            {
                return db.Clients.Select(MapToApp).ToList();
            }
        }

        public ModelClients SelectClientById(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                return MapToApp(db.Clients.Find(id));
            }
        }


        private DAL.Clients MapToDB(ModelClients model)
        {
            return new DAL.Clients()
            {
                id = model.id,
                name = model.name,
                surname = model.surname,
                email = model.email,
                telephone = model.telephone
            };
        }

        private ModelClients MapToApp(DAL.Clients modeldb)
        {
            return new ModelClients()
            {
                id = modeldb.id,
                name = modeldb.name,
                surname = modeldb.surname,
                email = modeldb.email,
                telephone = modeldb.telephone
            };
        }
    }
}
