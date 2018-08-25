using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SoftUniClone.Web.Areas.Identity.IdentityHostingStartup))]
namespace SoftUniClone.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}