using Entities.Entity;
using Entities.Model;
using IBAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace BAL
{
    public class ProductBAL : IProductBAL
    {

        private readonly IProductDAL _productDAL;

        public ProductBAL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void Create(CreateProductViewModel product)
        {
            try
            {
                CreateProductModel productForDAL = new CreateProductModel()
                {
                    CreatedBy = Guid.Parse(product.ProductId),
                    CreatedOn = DateTime.Now,
                    Description = product.Description,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    FilePath = product.OriginalFileName,
                    FileName = product.FileName

                };
                _productDAL.Create(productForDAL);
            }
            catch (Exception e)
            {

                throw new Exception("Error:" + e);
            }

        }

        public void Delete(int id)
        {
            try
            {
                _productDAL.Delete(id);

            }
            catch (Exception e)
            {

                throw new Exception("Error" + e);
            }
        }
      

        public IEnumerable<GetProductViewModel> Get(string word, int? pageIndex, int? pageSize)
        {
            try
            {
                List<uspGetProductListResult> productListFromDAL = _productDAL.Get(word, pageIndex, pageSize).ToList();

                List<GetProductViewModel> list = new List<GetProductViewModel>();

                for (int i = 0; i < productListFromDAL.Count; i++)
                {
                    GetProductViewModel productViewModel = new GetProductViewModel()
                    {
                        ProductName = productListFromDAL[i].ProductName,
                        Price = productListFromDAL[i].Price,
                        Description = productListFromDAL[i].Description,
                        ProductId = productListFromDAL[i].ProductId,
                        TotalCount = productListFromDAL[i].TotalCount
                    };
                    list.Add(productViewModel);
                }
                return list;
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }

        public IEnumerable<GetOrderViewModel> GetOrderDetails()
        {
            try
            {
                List<uspGetOrderItemResult> orderList = _productDAL.GetOrderDetails().ToList();

                List<GetOrderViewModel> list = new List<GetOrderViewModel>();

                for (int i = 0; i < orderList.Count; i++)
                {
                    GetOrderViewModel newModel = new GetOrderViewModel()
                    {
                        OrderId = orderList[i].OrderId,
                        FirstName = orderList[i].FirstName,
                        OrderDate = orderList[i].OrderDate,
                        ProductName = orderList[i].ProductName,
                        Price = orderList[i].Price,
                        Quantity = orderList[i].Quantity,
                        TotalPrice = orderList[i].TotalPrice
                    };
                    list.Add(newModel);
                }
                return list;
            }
            catch (Exception e)
            {

                throw new Exception("Error: "+ e);
            }
        }

        public GetProductViewModel GetProductById(int id)
        {
            try
            {
                uspGetProdcutByIdResult products = _productDAL.GetProductById(id);


                    GetProductViewModel newProduct = new GetProductViewModel()
                    {
                        ProductId = products.ProductId,
                        Description = products.Description,
                        ProductName = products.ProductName,
                        Price = products.Price
                    };
                return newProduct;
            }
            catch (Exception e)
            {

                throw new Exception("Error: "+ e);
            }
        }

        public void PlaceOrder(PlaceOrderViewModel order)
        {
            try
            {
                PlaceOrder newOrder = new PlaceOrder()
                {
                    OrderDate = order.OrderDate,
                    Price = order.Price,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    TotalPrice = order.TotalPrice,
                    UserId = order.UserId
                };

                _productDAL.PlaceOrder(newOrder);

            }
            catch (Exception e)
            {

                throw new Exception("Error: "+ e);
            }
        }



        //public IEnumerable<ProductViewModel> GetImageByProductId(int id)
        //{
        //    try
        //    {
        //        List<uspGetImageByProductIdResult> imageByProductId = _productDAL.GetImageByProductId(id).ToList();

        //        List<ProductViewModel> list = new List<ProductViewModel>();

        //        for (int i = 0; i < imageByProductId.Count; i++)
        //        {
        //            ProductViewModel productViewModel = new ProductViewModel()
        //            {
        //                FileName = imageByProductId[i].FileName,
        //                FilePath = imageByProductId[i].FilePath
        //            };
        //            list.Add(productViewModel);
        //        }
        //        return list;

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception("Error: "+ e);
        //    }
        //}

        public void Update(UpdateProductViewModel model)
        {
            try
            {

                ICollection<Image> image = new List<Image>()
                {
                    new Image{ FileName = model.FileName, OriginalFileName = model.FileName, ImageVersion = model.ProductId + 1}
                };

                Product newModel = new Product()
                {
                    Description = model.Description,
                    Price = model.Price,
                    Name = model.ProductName,
                    Image = image

                };
                _productDAL.Update(newModel);
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }
    }
}
