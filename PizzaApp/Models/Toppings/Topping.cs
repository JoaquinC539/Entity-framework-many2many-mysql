using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Models.Pizzas;

namespace Models.Toppings;

[Table("toppings")]
public class Topping
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<Pizza>? Pizzas{ get; set; }

    // [JsonIgnore]
    // public ICollection<Topping>? Pizzas { get; set; }

    

    public Topping()
    {}
    
}