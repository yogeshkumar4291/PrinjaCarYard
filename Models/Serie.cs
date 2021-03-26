using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrinjaCarYard.Models
{
    public class Serie
    {
        [Key]
        public int ID { get; set; } //PRIMARY KEY
        public int BrandID { get; set; }
        public Brand Brand { get; set; } //BRAND NAME CONNECTED WITH BRAND MODEL
        public string name { get; set; }
        public int price { get; set; }
        public string Colours { get; set; }
        // public StaffNames StaffName { get; set; }
    }
}
