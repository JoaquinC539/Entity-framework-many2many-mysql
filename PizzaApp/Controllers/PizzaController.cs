using Abstracts.BaseApiController;
using Models.Pizzas;
using Services.PizzaService;

namespace Controllers.PizzaController;

public class PizzaController : BaseApiController<PizzaService,Pizza,PizzaDto>
{
    public PizzaController(PizzaService pizzaService):base(pizzaService)
    {}
}