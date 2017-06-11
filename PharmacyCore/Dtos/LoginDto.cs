using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.Dtos
{
    public class LoginDto
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
