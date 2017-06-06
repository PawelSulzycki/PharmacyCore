using PharmacyCore.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.ViewModels
{
    public class MedicineViewModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Producent")]
        public string Manufacturer { get; set; }

        [Display(Name = "Data ważności")]
        public DateTime DataExpiration { get; set; }

        public MedicineViewModel(string name, string manufacurer, DateTime dataExpiration)
        {
            Name = name;
            Manufacturer = manufacurer;
            DataExpiration = dataExpiration;
        }

    }
}
