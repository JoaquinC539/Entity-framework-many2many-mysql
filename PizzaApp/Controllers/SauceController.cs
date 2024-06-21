using Abstracts.BaseApiController;
using Models.Sauces;
using Services.SauceService;

namespace Controllers.SauceController;


public class SauceController: BaseApiController<SauceService, Sauce,SauceDto>
{
    

    public SauceController(SauceService sauceService):base(sauceService)
    {}

    

    
}