using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
namespace BAL.Interfaces
{
    public interface IRepositoryBodyRents
    {
        void AddBodyRent(ModelBodyRents model);
        List<ModelBodyDetails> SelectBodyRentById(int id);
    }
}
