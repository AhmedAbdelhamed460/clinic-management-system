using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using clinic_management__system.Models;
using System.ComponentModel;

namespace clinic_management__system.ViewModel
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string NamePatient { get; set; }
        [MaxLength(13)]
        public string PhonePatient { get; set; }
        [MaxLength(10)]
        public string GenderPatient { get; set; }
        [MaxLength(250)]
        public string MedicalHistory { get; set; }
        public string birthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        [Required(ErrorMessage = "Please enter a start time")]
        public TimeSpan StartAppointment { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        [DefaultValue(typeof(TimeSpan), "00:30")]

        public TimeSpan EndAppointment
        {
            get { return StartAppointment.Add(TimeSpan.FromMinutes(30)); }
            set { }
        }
        [Display(Name = "Doctor Name")]
        public int DoctorId { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public string dayofweek { get; set; }
    }
}
