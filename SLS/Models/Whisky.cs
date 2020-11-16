using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public class Whisky
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int AlcoholPercentage { get; set; }
        [Required]
        public WhiskyType Type { get; set; }
        [Required]
        public decimal Price { get; set; }  

        public int Stock { get; set; }

        public string PhotoPath { get; set; }

        public bool IsDeleted { get; set; }

        
    }
}
