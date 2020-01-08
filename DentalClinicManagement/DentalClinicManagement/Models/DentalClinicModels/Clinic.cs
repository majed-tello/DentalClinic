using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Clinic Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Docotr> Docotrs { get; set; }
        public ICollection<Secretary> Secretaries { get; set; }
    }
}
