using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndangeredSpeciesApp.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string fName { get; set; }
        [Display(Name = "Last Name")]
        public string lName { get; set; }
        [Display(Name = "Species Protected")]
        public int SpeciesId { get; set; }

        public virtual Species Species { get; set; }
    }
}
