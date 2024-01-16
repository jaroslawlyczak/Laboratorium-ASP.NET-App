using Data;
using Data.Entities;

namespace Lab4_App_Reservation.Models.ReservationModels
{
    public class EFReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public EFReservationService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(Reservation reservation)
        {
            var reservationEntity = ReservationMapper.ToEntity(reservation);

            var addedReservation = _context.Reservations.Add(reservationEntity);
            _context.SaveChanges();

            var pokojDetailsEntity = ReservationMapper.ToP(reservation);
            pokojDetailsEntity.Id = addedReservation.Entity.ReservationEntityId;

            _context.PokojDetails.Add(pokojDetailsEntity);
            _context.SaveChanges();

            return addedReservation.Entity.ReservationEntityId;
        }

        public Reservation? FindById(int id)
        {
            var entityr = _context.Reservations.Find(id);
            var entityd = _context.PokojDetails.Find(id);
            if (entityr != null)
            {
                return ReservationMapper.FromEntity(entityr, entityd);
            }
            return null;
        }

        public List<Reservation> FindAll()
        {
            return _context.Reservations.Select(e => ReservationMapper.FromEntity(e)).ToList();
        }

        public void DeleteById(int id)
        {
            ReservationEntity? find = _context.Reservations.Find(id);
            if (find != null)
            {
                _context.Reservations.Remove(find);
                _context.SaveChanges();
            }
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(ReservationMapper.ToEntity(reservation));
            _context.PokojDetails.Update(ReservationMapper.ToP(reservation));

            _context.SaveChanges();

        }

        public PagingList<Reservation> FindPage(int page, int size)
        {
            return PagingList<Reservation>.Create(
            (p, s) => _context.Reservations.OrderBy(c => c.ContactEntityContactId)
                .Skip((p - 1) * s)
                .Take(s)
                .Select(ReservationMapper.FromEntity)
                .ToList(),
                page,
                size,
                _context.Reservations.Count()
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
            return _context.Contacts.ToList();
        }

        public Task<List<ContactEntity>> FindAllContactsAsync()
        {
            return Task.Run(() =>
            {
                return FindAllContacts();
            });
        }
    }
}
