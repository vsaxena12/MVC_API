using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_Consume_API.Models
{
    public class Departments
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
