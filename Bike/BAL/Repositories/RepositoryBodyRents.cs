using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;


namespace BAL.Repositories
{
    public class RepositoryBodyRents : IRepositoryBodyRents
    {
        public void AddBodyRent(ModelBodyRents model)
        {
            using (var db = new DAL.BikeEntities())
            {
                db.BodyRents.Add(MapToDB(model));
                db.SaveChanges();
            }
        }

        public List<ModelBodyDetails> SelectBodyRentById(int id)
        {
            using (var db = new DAL.BikeEntities())
            {
                var result = from b in db.BodyRents
                             join t in db.TypeRents
                         on b.typerents_id equals t.id
                             where b.rents_id == id
                             select new ModelBodyDetails
                             {
                                 price = b.price,
                                 date = b.date,
                                 typerent = t.name

                             };
                return result.ToList();
            }
        }

        private DAL.BodyRents MapToDB(ModelBodyRents model)
        {
            return new DAL.BodyRents()
            {
                rents_id = model.rents_id,
                price = model.price,
                typerents_id = model.typerents_id,
                date = model.date,
                id = model.id
            };
        }

        private ModelBodyRents MapToApp(DAL.BodyRents modeldb)
        {
            return new ModelBodyRents()
            {
                rents_id = modeldb.rents_id,
                price = modeldb.price,
                typerents_id = modeldb.typerents_id,
                date = modeldb.date,
                id = modeldb.id
            };
        }
    }
}
