using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Sauces;
using Models.Toppings;

namespace Models.Pizzas;

[Table("pizzas")]
public class Pizza
{

    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Column("sauce")]
    [JsonIgnore]    
    public int? SauceId { get; set; }

    [ForeignKey("SauceId")]
    public Sauce? Sauce{ get; set; }

    public ICollection<Topping>? Toppings { get; set; }

    // public ICollection<Topping>? Toppings { get; set; }

    

    public Pizza()
    {}   
}