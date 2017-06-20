using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyCore.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Nazwa leku")]
        public string Name { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Display(Name = "Sposób dostawy")]
        public string DeliveryMethod { get; set; }

        [Display(Name = "Status zamowienia")]
        public string StatusOfOrder { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Data zamowienia")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataOfOrder { get; set; }
    }
}
