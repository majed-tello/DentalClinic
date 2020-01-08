using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Start Appointment Time"),DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Appointment Time"), DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required, Range(1, 2), Display(Name = "State")]
        public decimal State { get; set; }

        public Docotr Docotr { get; set; }
        [ForeignKey(nameof(Docotr)), Display(Name = "Docotr")]
        public int DoctotId { get; set; }

        public ApplicationUser CreatedUser { get; set; }
        [ForeignKey(nameof(CreatedUser)), Display(Name = "Appointment Owner")]
        public string CreatedUserId { get; set; }

        public ICollection<Treatment> Treatments { get; set; }
    }
}
