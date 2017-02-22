using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaveThem.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string SciName { get; set; }
        public string ComName { get; set; }
       /* public string Status { get; set; }
        public string StatusTxt { get; set; }
        public int Country { get; set; }
        public DateTime ListingDate { get; set; }
        public string EntityId { get; set; }
        public string SpeciesCode { get; set; }
        public int VipCode { get; set; }
        public string PopAbbreviation { get; set; }
        public string PopDesc { get; set; }
        public decimal DonationValue { get; set; }
        public bool IsActive { get; set; } */

        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
