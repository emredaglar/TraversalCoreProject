using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IReservationService : IGenericService<Reservation>
	{
		//List<Reservation> GetListApprovalReservation(int id);
		List<Reservation> TGetListWithReservationByWaitApproval(int id);
		List<Reservation> TGetListWithReservationByAccepted(int id);

		List<Reservation> TGetListWithReservationByPrevios(int id);
		List<Reservation> TGetListWithAppUser(int id);
		List<Reservation> GetListWithReservationByCancel(int id);
		void TSetReservationStatus(int reservationId, string status);
		public List<Reservation> TGetReservations();
		List<Reservation> GetListWithReservationByWaitApproval(int id);
		List<Reservation> GetListWithReservationByWaitAccepted(int id);
		List<Reservation> GetListWithReservationByWaitPrevious(int id);
	}
}
