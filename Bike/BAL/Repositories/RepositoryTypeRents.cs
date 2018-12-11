using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;

namespace BAL.Repositories
{
    public class RepositoryTypeRents : IRepositoryTypeRents
    {
        public void AddTypeRent(ModelTypeRents model)
        {
            using (var db = new DAL.BikeEntities())
            {
                db.TypeRents.Add(MapToDB(model));
                db.SaveChanges();
            }
        }

        public void DeleteTypeRent(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aDelete = db.TypeRents.Find(id);
                db.TypeRents.Remove(aDelete);
                db.SaveChanges();
            }
        }

        public void EditTypeRent(ModelTypeRents model)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aEdit = db.TypeRents.Find(model.id);
                aEdit.name = model.name;
                aEdit.price = model.price;
                db.SaveChanges();
            }
        }

        public List<ModelTypeRents> SelectAll()
        {
            using (var db = new DAL.BikeEntities())
            {
                return db.TypeRents.Select(MapToApp).ToList();
            }
        }

        public ModelTypeRents SelectTypeRentById(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                return MapToApp(db.TypeRents.Find(id));
            }
        }

        private DAL.TypeRents MapToDB(ModelTypeRents model)
        {
            return new DAL.TypeRents()
            {
                id = model.id,
                name = model.name,
                price = model.price
            };
        }

        private ModelTypeRents MapToApp(DAL.TypeRents modeldb)
        {
            return new ModelTypeRents()
            {
                id = modeldb.id,
                name = modeldb.name,
                price = modeldb.price
            };
        }
    }
}
