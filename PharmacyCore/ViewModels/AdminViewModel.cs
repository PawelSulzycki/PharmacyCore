using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.ViewModels
{
    public class AdminViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Display(Name = "Login urzytkownika")]
        public string Login { get; set; }

        [Display(Name = "Rola")]
        public string Role { get; set; }

        [Display(Name = "Numer telefonu")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Hasło użytkownika")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

    }
}
