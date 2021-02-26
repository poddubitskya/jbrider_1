using Microsoft.AspNetCore.Mvc;

namespace Some.API.Controllers.Assignment
{
  public class UsersController : Controller
  {
    [HttpPost]
    public IActionResult CreateAsync()
    {
      return CreatedAtAction(nameof(CreateAsync), new { });
    }
  }
}