using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenderViewModel
    {
        [Required(ErrorMessage = "Gender id is required")]
        public int GenderId
        {
            get; set;
        }

        [Required(ErrorMessage = "Gender is required")]
        public string GenderName
        {
            get; set;
        }
    }
}
