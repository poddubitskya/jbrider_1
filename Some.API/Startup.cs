using Microsoft.AspNetCore.Builder;

namespace Some.API
{
  public class Startup
  {
    public void Configure(IApplicationBuilder app)
    {
      app.UseRouting();

      app.UseCors("CorsPolicy");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          "default",
          "{controller}/{action=Index}/{id?}");
      });
    }
  }
}