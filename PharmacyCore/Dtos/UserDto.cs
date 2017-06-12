using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Login użytkownika")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Hasło użytkownika")]
        public string Password { get; set; }

        [Display(Name = "Rola użytkownika")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Numer telefonu")]
        public int PhoneNumber { get; set; }
    }
}
