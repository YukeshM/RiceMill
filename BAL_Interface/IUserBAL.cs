using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace IBAL
{
    public interface IUserBAL
    {
        IEnumerable<GenderViewModel> GetGender();

    }
}
