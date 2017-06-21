using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.ViewModels
{
    public class InformationSellerViewModel
    {
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Numer telefonu")]
        public int PhoneNumber { get; set; }
    }
}
