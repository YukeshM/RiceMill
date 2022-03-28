using Entities.Entity;
using IBAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BAL
{
    public class UserBAL : IUserBAL
    {
        private readonly IUserDAL _userDAL;

        public UserBAL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IEnumerable<GenderViewModel> GetGender()
        {
            List<uspGetGenderResult> genderFromDAL = _userDAL.GetGender().ToList();

            List<GenderViewModel> list = new List<GenderViewModel>();

            for (int i = 0; i < genderFromDAL.Count; i++)
            {
                GenderViewModel genderForBAL = new GenderViewModel()
                {
                    GenderId = genderFromDAL[i].GenderId,
                    GenderName = genderFromDAL[i].GenderName
                };
                list.Add(genderForBAL);
            }
            return list;
        }
    }
}
