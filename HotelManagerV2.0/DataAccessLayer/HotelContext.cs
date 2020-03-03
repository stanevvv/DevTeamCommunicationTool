﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataAccessLayer
{
    public class HotelContext : IdentityDbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) 
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
