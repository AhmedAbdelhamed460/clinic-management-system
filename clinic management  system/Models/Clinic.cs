using System.ComponentModel.DataAnnotations;

namespace clinic_management__system.Models
{
    public class Clinic
    {
        public int Id { get; set; }
       [ MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Addres { get; set; }
        [MaxLength(13)]
        public string Phone { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}
