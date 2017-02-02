using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string Portion { get; set; }
        public double Price { get; set; }

        public virtual ICollection<MenuModel> MenuModel {get; set;}

    }
}
