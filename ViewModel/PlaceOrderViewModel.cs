using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PlaceOrderViewModel
    {


        public int ProductId
        {
            get; set;
        }

        public int OrderId
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }

        [Required(ErrorMessage = "Quantity is required")]

        public int Quantity
        {
            get; set;
        }

        public Guid UserId
        {
            get; set;
        }

        public decimal TotalPrice
        {
            get; set;
        }

        public DateTime OrderDate
        {
            get; set;
        }
    }
}
