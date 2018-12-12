using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;

namespace BAL.Interfaces
{
    public interface IRepositoryRents
    {
        int AddRent(ModelRents model);
        void DeleteRent(int id);
        List<ModelDetailRents> SelectAll();
        ModelRents SelectRentById(int id);

    }
}
