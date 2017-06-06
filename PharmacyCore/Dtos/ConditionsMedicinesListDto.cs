using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class ConditionsMedicinesListDto
    {
        public bool Refunded { get; set; }

        public bool Perscription { get; set; }

        public string StorageMethod { get; set; }
    }
}
