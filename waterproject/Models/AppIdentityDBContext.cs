using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        { 
        }
    }
}
