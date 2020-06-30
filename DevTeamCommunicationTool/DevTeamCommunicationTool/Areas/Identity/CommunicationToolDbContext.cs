using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTeamCommunicationTool.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevTeamCommunicationTool.Areas.Identity
{
    public class CommunicationToolDbContext : IdentityDbContext<User>
    {
        public CommunicationToolDbContext(DbContextOptions<CommunicationToolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.MessagesSent)
                .WithOne(m => m.SentBy)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.MessagesRecieved)
                .WithOne(m => m.SentTo)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
