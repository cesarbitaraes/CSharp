using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    //[ApiKey]
    public IActionResult Get(
        [FromServices] IConfiguration configuration)
    {
        var env = configuration.GetValue<string>("Env");
        return Ok(new
        {
            Environment = env
        });
    }
    
}