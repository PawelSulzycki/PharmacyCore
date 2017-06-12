using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.ViewModels
{
    public class AdminViewModel
    {
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
    }
}
