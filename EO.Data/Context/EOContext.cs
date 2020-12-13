using EO.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO.Data.Context
{
    public class EOContext : DbContext
    {
        public EOContext(DbContextOptions<EOContext> options) : base(options)
        {
        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
    }
}
