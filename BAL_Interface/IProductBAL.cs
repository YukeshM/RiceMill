using System.Collections.Generic;
using ViewModel;

namespace IBAL
{
    public interface IProductBAL
    {
        void Create(CreateProductViewModel product);

        IEnumerable<GetProductViewModel> Get(string? word, int? pageIndex, int? pageSize);

        //IEnumerable<ProductViewModel> GetImageByProductId(int id);

        void Update(UpdateProductViewModel model);

        void Delete(int id);

        GetProductViewModel GetProductById(int id);

        void PlaceOrder(PlaceOrderViewModel order);

        IEnumerable<GetOrderViewModel> GetOrderDetails();

    }
}
