using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrinjaCarYard.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; } //PRIMARY KEY

        public string Name { get; set; }
        public ICollection<Serie> serie { get; set; }// NAVIGATE SERIE MODE
    }
}
