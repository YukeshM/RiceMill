

using Entities.Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal : IUserDAL
    {
        private readonly RicemillContext _ricemillContext;

        public UserDal(RicemillContext ricemillContext)
        {
            _ricemillContext = ricemillContext;
        }

        public IEnumerable<uspGetGenderResult> GetGender()
        {
            try
            {
                IEnumerable<uspGetGenderResult> gender = _ricemillContext.Procedures.uspGetGenderAsync().Result;
                return gender;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
