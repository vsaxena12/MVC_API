using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_Consume_API.Models
{
    public class Employees
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [ForeignKey("Departments")]
        public int Department_ID { get; set; }
    }
}
