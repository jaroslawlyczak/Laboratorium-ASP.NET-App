using Data.Entities;
using Data.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Lab4_App_Reservation.Models.ReservationModels;

public class ReservationMapper
{
    public static Reservation FromEntity(ReservationEntity entityr, PokojDetailsEntity entityp)
    {
        if (entityr == null)
        {
            return null;
        }

        return new Reservation()
        {
            Id = entityr.ReservationEntityId,
            Data = entityr.Data,
            Miasto = entityr.Adress?.City,
            Adress = entityr.Adress != null ? $"{entityr.Adress.Street} {entityr.Adress.PostalCode}" : string.Empty,
            PokojNazwa = entityp.Nazwa,
            PokojNumer = entityp.Numer,
            PokojPietro = entityp.Pietro,
            PokojRozmiar = entityp.Rozmiar,
            Cena = entityr.Cena,
            ContactId = entityr.ContactEntityContactId,
            ContactName = entityr.ContactName
        };
    }
    public static Reservation FromEntity(ReservationEntity entityr)
    {
        if (entityr == null)
        {
            return null;
        }

        return new Reservation()
        {
            Id = entityr.ReservationEntityId,
            Data = entityr.Data,
            Miasto = entityr.Adress?.City,
            Adress = entityr.Adress != null ? $"{entityr.Adress.Street} {entityr.Adress.PostalCode}" : string.Empty,
            Cena = entityr.Cena,
            ContactName = entityr.ContactName

        };
    }

    public static PokojDetailsEntity ToP(Reservation model)
    {
        if (model == null)
        {
            return null;
        }

        return new PokojDetailsEntity()
        {
            Id = model.Id,
            Nazwa = model.PokojNazwa,
            Numer = model.PokojNumer,
            Pietro = model.PokojPietro,
            Rozmiar = model.PokojRozmiar,
        };
    }

    public static ReservationEntity ToEntity(Reservation model)
    {
        if (model == null)
        {
            return null;
        }

        return new ReservationEntity()
        {
            ReservationEntityId = model.Id,
            Data = model.Data,
            Adress = new Adress()
            {
                City = model.Miasto,
                Street = model.Adress?.Split(' ').FirstOrDefault() ?? string.Empty,
                PostalCode = model.Adress?.Split(' ').Skip(1).FirstOrDefault() ?? "NULL",
            },          
            Cena = model.Cena,
            ContactEntityContactId = model.ContactId,
            ContactName = model.ContactName,
        };
    }
}
