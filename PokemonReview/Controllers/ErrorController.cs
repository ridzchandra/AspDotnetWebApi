using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PokemonReview.Controllers;

[Route("/[controller]")]
[ApiController]
public class ErrorController : ControllerBase
{
  [HttpGet]
  public IActionResult Error()
  {
    // Retrieve the exception details from the HttpContext.Features property
    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
    if (context != null)
    {
      var stackTrace = context.Error.StackTrace;
      var message = context.Error.Message;

      // Log the exception details to a file or a logging service
      // For this example we're just using Console.WriteLine
      Console.WriteLine($"Message: {message}");
      Console.WriteLine($"StackTrace: {stackTrace}");
    }

    // Return a Problem response to the client 
    return Problem();
  }
}
