﻿using Asp.net_Core_Web_App_MVC_E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions) 
        {

        }

        public DbSet<Category> Category { get; set; }


    }
}