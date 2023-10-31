//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InventoryManagement.Service.Interface
//{
//    internal class IProductService
//    {
//    }
//}

using InventoryManagement.Common.DTOs.Master;

namespace InventoryManagement.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductId(string product);

        IQueryable<ProductDTO> GetAll();
    }
}
