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
            try
            {
                using (var db = new DAL.BikeEntities())
                {
                    db.Clients.Add(MapToDB(model));
                    db.SaveChanges();
                }
            }
            catch( Exception ex)
            {

            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                using (var db = new DAL.BikeEntities())
                {
                    var aDelete = db.Clients.Find(id);
                    db.Clients.Remove(aDelete);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void EditClient(ModelClients model)
        {
            try
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
            catch (Exception ex)
            {

            }
        }

        public List<ModelClients> SelectAll()
        {
            try
            {
                using (var db = new DAL.BikeEntities())
                {
                    return db.Clients.Select(MapToApp).ToList();
                }
            }
            catch ( Exception ex)
            {
                return null;
            }
            
        }

        public ModelClients SelectClientById(int id)
        {
            try
            {
                using (var db = new DAL.BikeEntities())
                {
                    return MapToApp(db.Clients.Find(id));
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        private DAL.Clients MapToDB(ModelClients model)
        {
            try
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
            catch ( Exception ex)
            {
                return null;
            }
        }

        private ModelClients MapToApp(DAL.Clients modeldb)
        {
            try
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
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
