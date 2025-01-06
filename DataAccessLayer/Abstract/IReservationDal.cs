﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByPrevios(int id);
		List<Reservation> GetListWithReservationByWaitAccepted(int id);
		List<Reservation> GetListWithReservationByWaitPrevious(int id);
		List<Reservation> GetListWithAppUser(int id);

		List<Reservation> GetListWithReservationByCancel(int id);

		void SetReservationStatus(int reservationId, string status);

		public List<Reservation> GetReservations();
	}
}
