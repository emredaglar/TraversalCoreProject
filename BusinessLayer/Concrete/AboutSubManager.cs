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
	public class AboutSubManager : IAboutSubService
	{
		IAboutSubDal _aboutSubDal;

        public AboutSubManager(IAboutSubDal aboutSubDal)
        {
            _aboutSubDal = aboutSubDal;
        }

        public void TAdd(AboutSub entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AboutSub entity)
        {
            throw new NotImplementedException();
        }

        public AboutSub TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AboutSub> TGetList()
        {
           return _aboutSubDal.GetList();   
        }

        public void TUpdate(AboutSub entity)
        {
            throw new NotImplementedException();
        }
    }
}
