using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;

namespace BAL.Repositories
{
    public class RepositoryTypePromotions : IRepositoryTypePromotions
    {
        public void AddTypePromotion(ModelTypePromotions model)
        {
            using (var db = new DAL.BikeEntities())
            {
                db.TypePromotions.Add(MapToDB(model));
                db.SaveChanges();
            }
        }

        public void DeleteTypePromotion(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aDelete = db.TypePromotions.Find(id);
                db.TypePromotions.Remove(aDelete);
                db.SaveChanges();
            }
        }

        public void EditTypePromotion(ModelTypePromotions model)
        {
            using (var db = new DAL.BikeEntities())
            {
                var aEdit = db.TypePromotions.Find(model.id);
                aEdit.name = model.name;
                aEdit.discount = model.discount;
                aEdit.quantity_min = model.quantity_min;
                aEdit.quantity_max = model.quantity_max;
                db.SaveChanges();
            }
        }

        public List<ModelTypePromotions> SelectAll()
        {
            using (var db = new DAL.BikeEntities())
            {
                return db.TypePromotions.Select(MapToApp).ToList();
            }
        }

        public List<ModelTypePromotions> SelectWhereQuantity(int cant)
        {
            using (var db = new DAL.BikeEntities())
            {
                var result = from promotion in db.TypePromotions
                             where promotion.quantity_min <= cant && promotion.quantity_max >= cant
                             select promotion;
                return result.Select(MapToApp).ToList();
            }
        }

        public ModelTypePromotions SelectTypePromotionById(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                return MapToApp(db.TypePromotions.Find(id));
            }
        }

        private DAL.TypePromotions MapToDB(ModelTypePromotions model)
        {
            return new DAL.TypePromotions()
            {
                id = model.id,
                name = model.name,
                discount = model.discount,
                quantity_max = model.quantity_max,
                quantity_min = model.quantity_min
            };
        }

        private ModelTypePromotions MapToApp(DAL.TypePromotions modeldb)
        {
            return new ModelTypePromotions()
            {
                id = modeldb.id,
                name = modeldb.name,
                discount = modeldb.discount,
                quantity_max = modeldb.quantity_max,
                quantity_min = modeldb.quantity_min
            };
        }
    }
}
