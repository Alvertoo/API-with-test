using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersWebAPI.Models;

namespace UsersWebAPI.Data
{
    public class UsersWebAPIContext : DbContext
    {
        public UsersWebAPIContext (DbContextOptions<UsersWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UsersWebAPI.Models.User> User { get; set; }
    }
}
