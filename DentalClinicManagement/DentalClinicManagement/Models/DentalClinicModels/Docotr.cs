﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinicManagement.Models.DentalClinicModels
{
    public class Docotr
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Docotr Name")]
        public string Name { get; set; }

        public string competence { get; set; }

        public string Phone { get; set; }

        public Clinic Clinic { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int ClinicId { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
