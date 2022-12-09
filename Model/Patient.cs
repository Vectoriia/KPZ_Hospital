using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patient: BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Disease> MedicalHistory { get; set; }
    }
}
