using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLS.Models
{
    public class Item
    {

        [Key]
        public int Id { get; set; }
        public Whisky Whisky { get; set; }

        public Customer Customer { get; set; }
        public int Quantity { get; set; }

    }
}
