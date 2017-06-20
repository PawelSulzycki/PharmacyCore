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
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Producent")]
        public string Manufacturer { get; set; }

        [Display(Name = "Data ważności")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataExpiration { get; set; }

        [Display(Name = "Refundowane")]
        public bool Refunded { get; set; }

        [Display(Name = "Recepta")]
        public bool Perscription { get; set; }

        [Display(Name = "Rodzaj przechowywania")]
        public string StorageMethod { get; set; }

        [Display(Name = "Ilość dostepnych sztuk")]
        public int Quantity { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Zastosowanie")]
        public string Use { get; set; }

    }
}
