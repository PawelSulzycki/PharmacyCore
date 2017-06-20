using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.Dtos
{
    public class CreateMedicineDto
    {

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Producent")]
        public string Manufacturer { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data ważności")]
        public DateTime DataExpiration { get; set; }

        [Display(Name = "Rodzaj przechowywania")]
        public string StorageMethod { get; set; }

        [Display(Name = "Zastosowanie")]
        public string Use { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Refundowane")]
        public bool Refunded { get; set; }

        [Display(Name = "Recepta")]
        public bool Perscription { get; set; }

        [Display(Name = "Ilosc sztuk")]
        public int Quantity { get; set; }
    }

}
