using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SaveThem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string fName { get; set; }
        public string lName { get; set; }
    }
}
