using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab4_App_Reservation.Models
{
    public class Reservation
    {

        [HiddenInput]
        public DateTime Created { get; set; }
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Proszê podaæ datê!")]
        public DateTime Date { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Proszê podaæ miasto!")]
        public string City { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Proszê podaæ adres!")]
        public string Address { get; set; }

        [Display(Name = "Pokój")]
        [Required(ErrorMessage = "Proszê podaæ pokój!")]
        public string Room { get; set; }

        [Display(Name = "W³aœciciel")]
        [Required(ErrorMessage = "Proszê podaæ w³aœciciela!")]
        public string Owner { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Proszê podaæ cenê!")]
        [Range(0, double.MaxValue, ErrorMessage = "Proszê podaæ poprawn¹ cenê!")]
        public decimal Price { get; set; }
    }
}