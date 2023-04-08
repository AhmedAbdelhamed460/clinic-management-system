using clinic_management__system.Models;
using clinic_management__system.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace clinic_management__system.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public IActionResult Index()
        {
            var Appointment = _context.Appointments.Include(n=>n.Doctor).ToList();
            return View(Appointment);
        }

        public IActionResult create()
        {
            var viewModel = new AppointmentViewModel()
            {
                Doctors = _context.Doctors.ToList()
            };
           
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(AppointmentViewModel model)
        {

            TimeSpan startTime = TimeSpan.Parse("09:00:00"); 
            TimeSpan endTime = TimeSpan.Parse("17:00:00");   

            if (model.Date.DayOfWeek ==DayOfWeek.Friday)
            {
                ModelState.AddModelError("Date", "This doctor is on vacation ");
                 model.Doctors =  _context.Doctors.ToList();
                return View(model);
            }
            if (!(model.StartAppointment >= startTime && model.StartAppointment <= endTime))
            {

                ModelState.AddModelError("StartAppointment", "This doctor is outside working hours  ");
              

                model.Doctors = _context.Doctors.ToList();
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.Doctors =  _context.Doctors.ToList();
                return View( model);
                
            }
         
                var Appointment = new AppointmentPatient()
                {
                    birthDate = model.birthDate,
                    StartAppointment = model.StartAppointment,
                    Date = model.Date,
                    DoctorId = model.DoctorId,
                    EndAppointment = model.EndAppointment,
                    MedicalHistory = model.MedicalHistory,
                    NamePatient = model.NamePatient,
                    PhonePatient = model.PhonePatient,
                    GenderPatient = model.GenderPatient,

                    

                };
           
                _context.Appointments.Add(Appointment);
                _context.SaveChanges();
            TempData["success"] = "Appointment create";
            return RedirectToAction("Index");
            
           
        }

      public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _context.Appointments.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            var viewModel = new AppointmentViewModel()
            {
                Id = model.Id,
                birthDate = model.birthDate,
                StartAppointment = model.StartAppointment,
              //  Date = model.Date,
                DoctorId = model.DoctorId,
                EndAppointment = model.EndAppointment,
                MedicalHistory = model.MedicalHistory,
                NamePatient = model.NamePatient,
                PhonePatient = model.PhonePatient,
                GenderPatient = model.GenderPatient,


                Doctors = _context.Doctors.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Doctors = _context.Doctors.ToList();
                return View(model);
            }
            var Appointment = _context.Appointments.Find(model.Id);
            if (Appointment == null)
            {
                return NotFound();
            }
            Appointment.StartAppointment = model.StartAppointment;
        //    Appointment.Date = model.Date;
                Appointment.EndAppointment = model.EndAppointment;
            Appointment.GenderPatient = model.GenderPatient;
            Appointment.NamePatient = model.NamePatient;
            Appointment.PhonePatient = model.PhonePatient;
            Appointment.birthDate= model.birthDate;
            Appointment.MedicalHistory  = model.MedicalHistory;
            Appointment.DoctorId = model.DoctorId;
            _context.SaveChanges();
            TempData["success"] = "Appointment Edit";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _context.Appointments.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            var viewModel = new AppointmentViewModel()
            {
                Id = model.Id,
                birthDate = model.birthDate,
                StartAppointment = model.StartAppointment,
            //    Date = model.Date,
                DoctorId = model.DoctorId,
                EndAppointment = model.EndAppointment,
                MedicalHistory = model.MedicalHistory,
                NamePatient = model.NamePatient,
                PhonePatient = model.PhonePatient,
                GenderPatient = model.GenderPatient,


                Doctors = _context.Doctors.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Doctors = _context.Doctors.ToList();
                return View(model);
            }
            var Appointment = _context.Appointments.Find(model.Id);
            if (Appointment == null)
            {
                return NotFound();
            }
            Appointment.StartAppointment = model.StartAppointment;
          //  Appointment.Date = model.Date;
            Appointment.EndAppointment = model.EndAppointment;
            Appointment.GenderPatient = model.GenderPatient;
            Appointment.NamePatient = model.NamePatient;
            Appointment.PhonePatient = model.PhonePatient;
            Appointment.birthDate = model.birthDate;
            Appointment.MedicalHistory = model.MedicalHistory;
            Appointment.DoctorId = model.DoctorId;
            _context.Remove(Appointment);
            _context.SaveChanges();
            TempData["success"] = "Appointment Delete";

            return RedirectToAction("Index");
        }

    }
}
