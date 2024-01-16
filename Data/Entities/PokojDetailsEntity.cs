using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class PokojDetailsEntity
{
    [ForeignKey("ReservationEntity")]
    public int Id { get; set; }

    public string Nazwa { get; set; }

    public string Numer { get; set; }

    public int Rozmiar { get; set; }

    public int Pietro { get; set; }

    public virtual ReservationEntity ReservationEntity { get; set; } = null!;
}