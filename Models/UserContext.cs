using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_12_1.Models
{
    public class UserContext:IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext>options):base(options)
        {

        }
    }
}
