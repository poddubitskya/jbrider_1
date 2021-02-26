using System;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Some.API
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      CreateWebHostBuilder(args, environmentName).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args, string environmentName)
    {
      var builder = WebHost.CreateDefaultBuilder(args);

      switch (environmentName)
      {
        case "Development":
          builder = builder
            .UseKestrel(options => options.AddServerHeader = false)
            .UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));
          break;
        default:
          builder = builder.UseIISIntegration();
          break;
      }

      builder = builder.UseStartup(typeof(Startup).GetTypeInfo().Assembly.FullName);

      return builder;
    }
  }
}