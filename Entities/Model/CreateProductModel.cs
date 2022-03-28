using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class CreateProductModel
    {
        public int ProductId
        {
            get; set;
        }
        public string ProductName
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
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
        public string FilePath
        {
            get; set;
        }
        public int? ImageVersion
        {
            get; set;
        }
    }
}
