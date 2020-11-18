using AppointmentMvc.CustomValidations;
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
        
        [MinLength(3), MaxLength(50), Required(ErrorMessage = "Something went wrong")]
        public string Description { get; set; }

        [Range(0,24,ErrorMessage = "Input is not valid")]
        [TimeAvailability(ErrorMessage = "This time is not available")]
        public int Time { get; set; }

        
    }
    
}
