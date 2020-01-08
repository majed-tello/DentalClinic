using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Patient Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string CommunicableDiseases { get; set; }

        public bool Smoker { get; set; }

    }
}
