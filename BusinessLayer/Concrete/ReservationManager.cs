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
	public class ReservationManager : IReservationService
	{
		IReservationDal _reservationDal;

		public ReservationManager(IReservationDal reservationDal)
		{
			_reservationDal = reservationDal;
		}

        public List<Reservation> TGetListWithReservationByWaitApproval(int id)
        {
		 return	_reservationDal.GetListWithReservationByWaitApproval(id);
        }

        //public List<Reservation> GetListApprovalReservation(int id)
        //{
        //    return _reservationDal.GetListByFilter(x=>x.AppUserId == id && x.Status=="Onay Bekliyor");
        //}

        public void TAdd(Reservation entity)
		{
			_reservationDal.Insert(entity);
		}

		public void TDelete(Reservation entity)
		{
			throw new NotImplementedException();
		}

		public Reservation TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Reservation> TGetList()
		{
			return _reservationDal.GetList();
		}


		public void TUpdate(Reservation entity)
		{
			throw new NotImplementedException();
		}

        public List<Reservation> TGetListWithReservationByAccepted(int id)
        {
			return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> TGetListWithReservationByPrevios(int id)
        {
			return _reservationDal.GetListWithReservationByPrevios(id);
        }

		public List<Reservation> TGetListWithAppUser(int id)
		{
			return _reservationDal.GetListWithAppUser(id);
		}
	}
}
