﻿using System;
using ConfArch.Web;
using ConfArch.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ConfArch.Web.Areas.Identity.IdentityHostingStartup))]
namespace ConfArch.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup   // it works like the startup class of the project. It is triggered when the application starts
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ConfArchWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ConfArchWebContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = true;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredLength = 3;
                    }
                    )
                    .AddEntityFrameworkStores<ConfArchWebContext>();
            });
        }
    }
}