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
    public class NewsletterManager:INewsletterService
    {
        INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void TAdd(NewsLetter t)
        {
            _newsletterDal.Insert(t);
        }

        public void TDelete(NewsLetter t)
        {
            _newsletterDal.Delete(t);
        }

        public NewsLetter TGetByID(int id)
        {
            return _newsletterDal.GetByID(id);
        }

        public List<NewsLetter> TGetList()
        {
            return _newsletterDal.GetList();
        }

        public void TUpdate(NewsLetter t)
        {
            _newsletterDal.Update(t);
        }
    }
}
