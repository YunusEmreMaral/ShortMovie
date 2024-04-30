using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DirectorManager:IDirectorService
    {
        IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public void TAdd(Director t)
        {
            _directorDal.Insert(t);
        }

        public void TDelete(Director t)
        {
            _directorDal.Delete(t);
        }

        public Director TGetByID(int id)
        {
           return _directorDal.GetByID(id);
        }

        public List<Director> TGetList()
        {
            return _directorDal.GetList();
        }

        public void TUpdate(Director t)
        {
            _directorDal.Update(t);
        }
    }
}
