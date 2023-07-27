using System.Diagnostics;
using System.Management.Automation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ButtonData.Json;

namespace MinecraftServerDashboard
{
    class Program
    {
        public static GameServerInfo ActiveServer { get; set; }
        public static bool ServerRunning { get; set; }
        public static Process ServerProcess { get; set; }
        public static StreamWriter ServerInput { get; set; }

        public static void Main(string[] args)
        {
            ServerRunning = false;
            ActiveServer = new GameServerInfo();
            ServerProcess = new Process();


            startWebClient(args);
        }

        private static void startWebClient(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}