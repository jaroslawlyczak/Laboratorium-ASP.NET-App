
namespace Lab4_App_Reservation.Models
{
        public interface IReservationService
        {
            int Add(Reservation reservation);
            void Edit(Reservation reservation);
            void Delete(int id);
            List<Reservation> FindAll();
            Reservation FindById(int id);
        }
       
}