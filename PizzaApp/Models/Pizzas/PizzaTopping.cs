using System.ComponentModel.DataAnnotations.Schema;
using Models.Toppings;

namespace Models.Pizzas;

[Table("PizzaTopping")]
public class PizzaTopping
{
    // [Column("id")]
    // public int Id { get; set; }

    [Column("pizza_id")]
    public int PizzaId { get; set; }

    [Column("topping_id")]
    public int ToppingId { get; set; }
    
    [ForeignKey("PizzaId")]
    public Pizza? Pizza { get; set; } =null;

    [ForeignKey("ToppingId")]
    public Topping? Topping { get; set; } = null;
}