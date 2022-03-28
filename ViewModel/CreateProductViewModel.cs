
using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CreateProductViewModel
    {
        public string ProductId
        {
            get; set;
        }

        [Required(ErrorMessage ="Product name required")]
        [StringLength(100, ErrorMessage = "Product name should be less than 100")]
        public string ProductName
        {
            get; set;
        }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description should be less than 250")]
        public string Description
        {
            get; set;
        }

        [Required(ErrorMessage = "Price is required")]
        [StringLength(1000000, ErrorMessage = "Price should be less than 1000000")]
        public decimal Price
        {
            get; set;
        }
        public Guid CreatedBy
        {
            get; set;
        }

        
        public DateTime CreatedOn
        {
            get; set;
        }
        public Guid? ModifiedBy
        {
            get; set;
        }
        public DateTime? ModifiedOn
        {
            get; set;
        }


        public string FileName
        {
            get; set;
        }
        public string OriginalFileName
        {
            get; set;
        }
        public int? ImageVersion
        {
            get; set;
        }
    }
}
