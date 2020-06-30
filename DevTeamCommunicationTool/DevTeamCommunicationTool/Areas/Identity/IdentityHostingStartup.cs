﻿using System;
using DevTeamCommunicationTool.Areas.Identity.Data;
using DevTeamCommunicationTool.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DevTeamCommunicationTool.Areas.Identity.IdentityHostingStartup))]
namespace DevTeamCommunicationTool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CommunicationToolDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CommunicationToolContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CommunicationToolDbContext>();
            });
        }
    }
}