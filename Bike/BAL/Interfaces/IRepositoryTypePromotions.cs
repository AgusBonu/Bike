using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
namespace BAL.Interfaces
{
    public interface IRepositoryTypePromotions
    {
        void AddTypePromotion(ModelTypePromotions model);
        void DeleteTypePromotion(int id);
        void EditTypePromotion(ModelTypePromotions model);
        List<ModelTypePromotions> SelectAll();
        ModelTypePromotions SelectTypePromotionById(int id);
        List<ModelTypePromotions> SelectWhereQuantity(int cant);
    }
}