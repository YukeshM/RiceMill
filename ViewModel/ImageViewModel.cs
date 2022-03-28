using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ImageViewModel
    {
        public int Id
        {
            get; set;
        }
        public int? ProductId
        {
            get; set;
        }

        [Required(ErrorMessage = "File name is required")]

        public string FileName
        {
            get; set;
        }

        [Required(ErrorMessage = "original file name is required")]

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
