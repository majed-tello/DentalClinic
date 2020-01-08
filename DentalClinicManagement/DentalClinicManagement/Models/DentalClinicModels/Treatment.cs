using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string TreatmentType { get; set; }

        public double Cost { get; set; }

        public string Notes { get; set; }

        public Appointment Appointment { get; set; }
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
    }
}
