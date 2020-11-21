using AppointmentMvc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMvc.CustomValidations
{
    public class TimeAvailability : ValidationAttribute
    {

        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value==null)
            {
                return new ValidationResult("Time field is required");
            }

            // getting AppointmentContext via ValidationContext
            AppointmentContext dbcontext = (AppointmentContext)validationContext.GetService(typeof(AppointmentContext));
            var times = from a in dbcontext.Appointment select a.Time;

            bool containsValue = times.Any(a => a == (int)value);

            if (containsValue)
            {
                return new ValidationResult("Unfortunately, this time is not available");
            }
            else return ValidationResult.Success;
        }
    }
}
