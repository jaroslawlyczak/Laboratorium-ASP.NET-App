using Data.Entities;

namespace Lab4_App_Reservation.Models.ReservationModels
{
    public interface IReservationService
    {
        int Add(Reservation reservation);
        Reservation? FindById(int id);
        List<Reservation> FindAll();
        void DeleteById(int id);
        void Update(Reservation reservation);
        PagingList<Reservation> FindPage(int page, int size);
        List<ContactEntity> FindAllContacts();


        Task<int> AddAsync(Reservation reservation);
        Task<Reservation?> FindByIdAsync(int id);
        Task<List<Reservation>> FindAllAsync();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(Reservation reservation);
        Task<PagingList<Reservation>> FindPageAsync(int page, int size);
        Task<List<ContactEntity>> FindAllContactsAsync();

    }
}
