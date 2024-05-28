using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPersonalsRepository : GenericRepository<Personal>, IPersonalDal

    {
        public List<Personal> PersonalMessage(string s)
        {
            using (var c = new Context())
            {
                return c.Personals.Where(x => x.PersonalName == s).ToList();
            }
        }

      
    }
}
