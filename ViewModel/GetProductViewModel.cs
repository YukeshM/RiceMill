using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class GetProductViewModel
    {
        public int ProductId
        {
            get; set;
        }

        [Required(ErrorMessage = "Product name is required")]

        public string ProductName
        {
            get; set;
        }

        [Required(ErrorMessage = "Description is required")]

        public string Description
        {
            get; set;
        }

        [Required(ErrorMessage = "Price is required")]

        public decimal Price
        {
            get; set;
        }


        [Required(ErrorMessage = "Total count is required")]

        public int? TotalCount
        {
            get; set;
        }


    }
}
