using clinic_management__system.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management__system.ViewModel
{
    public class DoctorViewmodel
    {
        public int Id { get; set; }
        public DayOfWeek dayofWeek { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan StartWork { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan EndWork { get; set; }
        public string NamePatient { get; set; }
        [MaxLength(13)]
        public string PhonePatient { get; set; }
        [MaxLength(10)]
        public string GenderPatient { get; set; }
        [MaxLength(250)]
        public string MedicalHistory { get; set; }

        public string birthDate { get; set; }


        [Column(TypeName = "date")]

        public DateTime Date { get; set; }
        public List<AppointmentPatient> Appointments { get; set; }

    }
}
