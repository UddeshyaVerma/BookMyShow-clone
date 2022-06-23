
using System.ComponentModel.DataAnnotations;

namespace BookMyShowApi.Models
{
    public class UserModel 
    {
        public string UserName { get; set; }=String.Empty;
        public string FullName { get; set; }=String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
      
        public string Password { get; set; } = String.Empty;
    }
}
