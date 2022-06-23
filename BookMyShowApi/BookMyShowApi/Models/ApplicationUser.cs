using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowApi.Models
{
    [Table("AspNetUsers")]

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public string City { get; set; }
    }
}
