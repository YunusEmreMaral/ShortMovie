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
	public class EfDirectorRepository : GenericRepository<Director>, IDirectorDal
	{
		public List<Director> Get10Director()
		{
			using (var c = new Context())
			{
				return c.Directors.Take(10).ToList();
			}
		}
	}
}
