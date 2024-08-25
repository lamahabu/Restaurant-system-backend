using Serilog;
using System.Net;
using Serilog.Events;
using Domain.Shared.Layer;
using MailKit.Security;

namespace AutoMapper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File(Paths.LogFile, rollingInterval: RollingInterval.Day)
           .WriteTo.Email(
            from: Paths.SenderEmail,
            to: Paths.ReciverEmail,
            host: "smtp.gmail.com",
            port: 587,
            connectionSecurity: SecureSocketOptions.StartTls,
            credentials: new NetworkCredential("username", "password"),
            subject: ErrorsConstant.ErrorMessage,
            body: "An error has been logged.",
            formatProvider: null,
            restrictedToMinimumLevel: LogEventLevel.Error)
           .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}