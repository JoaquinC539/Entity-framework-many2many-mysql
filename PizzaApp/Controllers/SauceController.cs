using Abstracts.BaseApiController;
using Interfaces.IApiController;
using Microsoft.AspNetCore.Mvc;
using Models.Sauce;
using Services.SauceService;

namespace Controllers.SauceController;

[ApiController]
[Route("api/[controller]")]
public class SauceController: BaseApiController<SauceService, Sauce,SauceDto>
{
    

    public SauceController(SauceService sauceService):base(sauceService)
    {
        
    }

    [HttpGet]
    public ActionResult<IEnumerable<Sauce>> Index( [FromQuery] string? name  )
    {
        Dictionary<string,object> args=new Dictionary<string,object>();
        if(name!=null)
        {
            args.Add("name",name);
        }
        List<Sauce> sauces=Service.Index(args).ToList(); 
        return Ok(sauces);  
        
    }

    
}