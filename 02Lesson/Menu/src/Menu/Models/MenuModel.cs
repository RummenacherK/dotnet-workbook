using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuModel
    {
        public string Name { get; set; }
        
        public virtual Size Sizes { get; set; }
    }
}
