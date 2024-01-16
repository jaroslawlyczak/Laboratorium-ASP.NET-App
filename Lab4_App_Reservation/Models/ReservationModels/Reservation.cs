using Lab4_App_Reservation.Models.ContactModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lab4_App_Reservation.Models.ReservationModels;

public class Reservation
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Data' jest wymagane.")]
    [Display(Name = "Data")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "Pole 'Miasto' jest wymagane.")]
    [Display(Name = "Miasto")]
    public string Miasto { get; set; }

    [Required(ErrorMessage = "Pole 'Adres' jest wymagane.")]
    [Display(Name = "Adres")]
    public string Adress { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa pokoju' jest wymagane.")]
    [Display(Name = "Nazwa pokoju")]
    public string PokojNazwa { get; set; }

    [Required(ErrorMessage = "Pole 'Numer pokoju' jest wymagane.")]
    [Display(Name = "Numer pokoju")]
    public string PokojNumer { get; set; }

    [Required(ErrorMessage = "Pole 'Rozmiar pokoju' jest wymagane.")]
    [Display(Name = "Rozmiar pokoju")]
    public int PokojRozmiar { get; set; }

    [Required(ErrorMessage = "Pole 'Pietro pokoju' jest wymagane.")]
    [Display(Name = "Pietro pokoju")]
    public int PokojPietro { get; set; }

    [Required(ErrorMessage = "Pole 'Cena' jest wymagane.")]
    [Range(0, double.MaxValue, ErrorMessage = "Cena musi być liczbą nieujemną.")]
    [Display(Name = "Cena")]
    public decimal Cena { get; set; }

    [Display(Name = "Właściciel")]
    public int ContactId { get; set; }
    public string ContactName { get; set; }


    [ValidateNever]
    public List<SelectListItem> ContactList { get; set; }
}
