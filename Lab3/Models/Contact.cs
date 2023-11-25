using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "Imie jest za długie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj adres e-mail")]
        [EmailAddress(ErrorMessage = "Adres e-mail nie poprawny")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Telefon niepoprawny")]
        public string Phone { get; set; }

        public DateTime Birth { get; set; }
    }
}
