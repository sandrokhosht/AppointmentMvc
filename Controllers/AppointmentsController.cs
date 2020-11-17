using AppointmentMvc.Data;
using AppointmentMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMvc.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentContext _context;
        

        public AppointmentsController(AppointmentContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointment.ToListAsync();
            return View(appointments);
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            var appointments = from a in _context.Appointment select a;  
            _context.Appointment.RemoveRange(appointments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        



        public async Task<IActionResult> Create()
        {
            ViewBag.appointments = await _context.Appointment.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Description,Time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }




    }
}
