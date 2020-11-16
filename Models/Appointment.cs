using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMvc.Models
{
    public class Appointment
    {

        public int Id { get; set; }
        public string Description { get; set; }

        [Range(0,24)]
        public int Time { get; set; }

        
    }
    
}
