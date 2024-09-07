using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Validations;

namespace WebApplication1.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        
        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color  { get; set; }

        [Shirt_EnsureCorrectSizingAttribute, Required]
        public int? Size { get; set; }

         [Required]
        public string? Gender { get; set; }
         
        public double? Price { get; set; }
    }
}