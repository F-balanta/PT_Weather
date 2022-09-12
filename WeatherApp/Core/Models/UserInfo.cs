using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserInfo
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
