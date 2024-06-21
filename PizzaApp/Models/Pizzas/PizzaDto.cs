using Models.Sauces;

namespace Models.Pizzas;

public class PizzaDto
{
    public string? Name { get; set; }

    
    public int? Sauce {get; set;}

    public ICollection<int> Toppings { get; set; }

    
    public PizzaDto(ICollection<int> toppings)
    {
        Toppings = toppings;
    }
}