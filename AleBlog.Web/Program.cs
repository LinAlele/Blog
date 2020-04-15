using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AleBlog.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder =>
            {
                builder.ConfigureKestrel(options => { options.AddServerHeader = false; })
                       .UseUrls("http://*:5003")
                       .UseStartup<Program>();
            }).Build().RunAsync();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSignalR() ;
            services.AddSingleton(HtmlEncoder.Create(new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs }));
            services.AddMvc().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsApp");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ConnectionHub>("/connection");
            });
        }
    }
    public class ConnectionHub : Hub
    {
        /// <summary>
        /// ä¯ÀÀÆ÷ Notification
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task Notification(string title, string message, string data)
        {
            await Clients.All.SendAsync("ReceiveNotification", title, message, data);
        }
    }
}
