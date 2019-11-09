using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Department
    {
        [Key]
        [Required]
        public int Department_ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
