using System.ComponentModel.DataAnnotations;

namespace clinic_management__system.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Specialization { get; set; }
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public schedule schedule { get; set; }
        public virtual List<AppointmentPatient> AppointmentPatient { get; set; }


    }
}
