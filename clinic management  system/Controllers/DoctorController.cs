using clinic_management__system.Migrations;
using clinic_management__system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinic_management__system.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var doctor =_context.Doctors.ToList();
            return View(doctor);
        }
        [HttpGet]
        public IActionResult DoctorId(int? Id, DateTime startDate, DateTime endDate)
        {


            var today = DateTime.Now;
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
           if(startDate ==default || endDate ==default)
            {

                startDate=DateTime.Today;
                endDate = DateTime.Today;

            }
           

            var Doctor = _context.Doctors.Include(n => n.AppointmentPatient.Where(a => a.Date >= startDate && a.Date <= endDate))
                .Include(n => n.schedule).SingleOrDefault(n => n.Id == Id);









            // var AppointmentPatientDate =Doctor.AppointmentPatient.Where(a=>a.Date==today).OrderBy(a=>a.Date).ToList();
            if (Doctor == null)
            {
                return NotFound();
            }
            TempData["success"] = "";
            return View(Doctor);
        }

       


    }
}
