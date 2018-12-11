using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;

namespace BAL.Interfaces
{
    public interface IRepositoryClients
    {
        void AddClient(ModelClients model);
        void DeleteClient(int id);
        List<ModelClients> SelectAll();
        ModelClients SelectClientById(int id);
        void EditClient(ModelClients model);

    }
}
