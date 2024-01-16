using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Lab4_App_Reservation.Models.ReservationModels
{
    public class MemoryReservationService : IReservationService
    {
        private Dictionary<int, Reservation> _reservations = new Dictionary<int, Reservation>();

        private int id = 1;

        public int Add(Reservation reservation)
        {
            reservation.Id = id++;
            _reservations[reservation.Id] = reservation;
            return reservation.Id;

        }

        public void DeleteById(int id)
        {
            _reservations.Remove(id);
        }

        public List<Reservation> FindAll()
        {
            return _reservations.Values.ToList();
        }

        public Reservation? FindById(int id)
        {
            return _reservations[id];
        }

        public void Update(Reservation reservation)
        {
            if (_reservations.ContainsKey(reservation.Id))
            {
                _reservations[reservation.Id] = reservation;
            }
        }
        public PagingList<Reservation> FindPage(int page, int size)
        {
            return PagingList<Reservation>.Create(
            (p, s) => _reservations.OrderBy(c => c.Value.ContactId)
                .Skip((p - 1) * s)
                .Take(s)
                .Select(c => c.Value)
                .ToList(),
                page,
                size,
                _reservations.Count()
            );
        }

        public Task<int> AddAsync(Reservation reservation)
        {
            return Task.Run(() =>
            {
                return Add(reservation);
            });
        }

        public Task<Reservation?> FindByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                return FindById(id);
            });
        }

        public Task<List<Reservation>> FindAllAsync()
        {
            return Task.Run(() =>
            {
                return FindAll();
            });
        }

        public Task DeleteByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                 DeleteById(id);
            });
        }

        public Task UpdateAsync(Reservation reservation)
        {
            return Task.Run(() =>
            {
                Update(reservation);
            });
        }

        public Task<PagingList<Reservation>> FindPageAsync(int page, int size)
        {
            return Task.Run(() =>
            {
                return FindPage(page, size);
            });
        }

        public List<ContactEntity> FindAllContacts()
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactEntity>> FindAllContactsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
