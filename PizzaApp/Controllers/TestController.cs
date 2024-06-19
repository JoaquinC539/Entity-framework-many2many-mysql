using Microsoft.AspNetCore.Mvc;


namespace Controllers.TestController;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    
    private readonly IConfiguration _environment;
    public TestController(IConfiguration environment)
    {
        _environment= environment;
    }

    [HttpGet]
    public IActionResult Index()
    {
        
        
        Dictionary<string,string> data = new Dictionary<string,string> { { "test", "test" } };
        return Ok(data);
    }
}
