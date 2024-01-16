using Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ReservationEntity
{
    public int ReservationEntityId { get; set; }

    public DateTime Data { get; set; }

    public Adress? Adress { get; set; }

    public decimal Cena { get; set; }

    public virtual PokojDetailsEntity PokojDetailsEntity { get; set; } = null!;

    public int ContactEntityContactId { get; set; }
    public string ContactName { get; set; }

    public virtual ContactEntity ContactEntity { get; set; }
}