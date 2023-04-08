using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace clinic_management__system.Models
{
    public class schedule
    {

        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan StartWork { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan EndWork { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string dayofWeek { get; set; } 
        

    }
}
