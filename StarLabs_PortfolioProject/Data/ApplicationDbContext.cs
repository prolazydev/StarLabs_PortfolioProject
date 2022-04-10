using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarLabs_PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLabs_PortfolioProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Chord> Chords { get; set; }
    }
}
