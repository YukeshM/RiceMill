
using Entities.Entity;
using Entities.Model;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {

        private readonly RicemillContext _riceMillContext;

        public ProductDAL(RicemillContext riceMillContext)
        {
            this._riceMillContext = riceMillContext;
        }

        public void Create(CreateProductModel product)
        {
            try
            {
                ICollection<Image> image = new List<Image>()
                {
                    new Image{ FileName = product.FileName, OriginalFileName = product.FilePath, ImageVersion = product.ImageVersion }
                };

                Product newProduct = new Product()
                {
                    CreatedBy = product.CreatedBy,
                    CreatedOn = product.CreatedOn,
                    Description = product.Description,
                    Name = product.ProductName,
                    Price = product.Price,
                    ModifiedBy = product.ModifiedBy,
                    ModifiedOn = product.ModifiedOn,
                    Image = image
                };

                _riceMillContext.Product.Add(newProduct);
                _riceMillContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Error" + e);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                Product model = _riceMillContext.Product.Find(id);
                //have to change the code for delete product the product should be there
                //_riceMillContext.Remove(model);
                //_riceMillContext.SaveChanges();
            }
        }

#nullable enable
        public IEnumerable<uspGetProductListResult> Get(string? word, int? pageIndex, int? pageSize)
        {
            try
            {
                List<uspGetProductListResult> products = _riceMillContext.Procedures.uspGetProductListAsync(word, pageIndex, pageSize).Result;

                return products;
            }
            catch (Exception e)
            {
                throw new Exception("Exception:" + e.Message);
            }
        }

#nullable disable

        public uspGetProdcutByIdResult GetProductById(int id)
        {
            try
            {
                if (id != 0)
                {
                    uspGetProdcutByIdResult product = _riceMillContext.Procedures.uspGetProdcutByIdAsync(id).Result.ToList().FirstOrDefault();

                    return product;
                }
                else
                {
                    throw new Exception("Id cannot be 0");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
        }

        public void PlaceOrder(PlaceOrder order)
        {
            try
            {
                uspGetProdcutByIdResult product = GetProductById(order.ProductId);

                Orders orderTable = new Orders()
                {
                    UserId = order.UserId,
                    TotalPrice = order.Quantity * product.Price,
                    Date = order.OrderDate
                };

                OrderItem orderItem = new OrderItem()
                {
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    Price = product.Price,
                    Order = orderTable
                };

                _riceMillContext.OrderItem.Add(orderItem);
                _riceMillContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }

        }

        //public int OrderId(Guid userId, DateTime orderDate)
        //{
        //    List<uspGetOrderIdResult> orderIds = _riceMillContext.Procedures.uspGetOrderIdAsync(userId, orderDate).Result;

        //    for (int i = 0; i < orderIds.Count; i++)
        //    {
        //        int orderId = orderIds[0].OrderId;
        //        return orderId;
        //    }
        //    return 0;
        //}

        //public IEnumerable<uspGetImageByProductIdResult> GetImageByProductId(int id)
        //{
        //    try
        //    {

        //        List<uspGetImageByProductIdResult> image = _riceMillContext.Procedures.uspGetImageByProductIdAsync(id).Result;
        //        return image;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public void Update(Product model)
        {
            try
            {
                _riceMillContext.Product.Update(model);
                _riceMillContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<uspGetOrderItemResult> GetOrderDetails()
        {
            try
            {
                IEnumerable<uspGetOrderItemResult> orderDetails = _riceMillContext.Procedures.uspGetOrderItemAsync().Result;
                return orderDetails;
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }
    }
}
