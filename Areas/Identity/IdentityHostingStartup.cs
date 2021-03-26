using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrinjaCarYard.Areas.Identity.Data;
using PrinjaCarYard.Data;

[assembly: HostingStartup(typeof(PrinjaCarYard.Areas.Identity.IdentityHostingStartup))]
namespace PrinjaCarYard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PrinjaCarYardContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PrinjaCarYardContextConnection")));

                services.AddDefaultIdentity<PrinjaCarYardUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PrinjaCarYardContext>();
            });
        }
    }
}