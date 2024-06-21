using Abstracts.BaseApiController;
using Models.Toppings;
using Services.ToppingService;

namespace Controllers.ToppingController;

public class ToppingController : BaseApiController<ToppingService,Topping,ToppingDto>
{
    public ToppingController(ToppingService toppingService):base(toppingService)
    {}
}