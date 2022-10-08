using Microsoft.AspNetCore.Identity;

namespace Assignment_12_1.Models
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
