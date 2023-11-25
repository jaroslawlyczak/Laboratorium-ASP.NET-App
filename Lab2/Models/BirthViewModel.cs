using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Lab2.Models
{
    public class BirthViewModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsValid()
        {
            return DateTime.Now.CompareTo(BirthDate) > 0;
        }

        public int Birth()
        {
            var today = DateTime.Today;

            var age = today.Year - BirthDate.Year;

            if (BirthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
