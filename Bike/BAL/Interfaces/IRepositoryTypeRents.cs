using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
namespace BAL.Interfaces
{
    public interface IRepositoryTypeRents
    {
        void AddTypeRent(ModelTypeRents model);
        void DeleteTypeRent(int id);
        void EditTypeRent(ModelTypeRents model);
        List<ModelTypeRents> SelectAll();
        ModelTypeRents SelectTypeRentById(int id);
    }
}