using Entities.Entity;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IProductDAL
    {
        void Create(CreateProductModel product);

        IEnumerable<uspGetProductListResult> Get(string? word, int? pageIndex, int? pageSize);

        //IEnumerable<uspGetImageByProductIdResult> GetImageByProductId(int id);

        void Update(Product model);

        void Delete(int id);

        uspGetProdcutByIdResult GetProductById(int id);

        void PlaceOrder(PlaceOrder order);

        IEnumerable<uspGetOrderItemResult> GetOrderDetails();
    }
}
