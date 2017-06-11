﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}
