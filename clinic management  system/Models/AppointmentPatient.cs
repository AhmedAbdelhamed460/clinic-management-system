using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management__system.Models
{
    public class AppointmentPatient
    {
        public int Id { get; set; }
        [MaxLength(50)]
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


        
       
        public TimeSpan StartAppointment { get; set; }
       
        public TimeSpan EndAppointment { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
      
    }
}
