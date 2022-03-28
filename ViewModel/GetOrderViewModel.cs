using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetOrderViewModel
    {
        public int OrderId
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }
        public DateTime OrderDate
        {
            get; set;
        }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName
        {
            get; set;
        }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity
        {
            get; set;
        }


        public decimal? Price
        {
            get; set;
        }
        public decimal? TotalPrice
        {
            get; set;
        }
    }
}
