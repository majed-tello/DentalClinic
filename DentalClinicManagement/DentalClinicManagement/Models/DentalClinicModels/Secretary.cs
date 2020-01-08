using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Secretary
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Secretary Name")]
        public string Name { get; set; }

        public string Phone { get; set; }

        public Clinic Clinic { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int ClinicId { get; set; }
    }
}
