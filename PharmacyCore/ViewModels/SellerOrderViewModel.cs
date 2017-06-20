using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.ViewModels
{
    public class SellerOrderViewModel
    {
        [Display(Name = "Nazwa leku")]
        public string Name { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Display(Name = "Sposób dostawy")]
        public string DeliveryMethod { get; set; }

        [Display(Name = "Data zamowienia")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataOfOrder { get; set; }

        public int Id { get; set; }

    }
}
