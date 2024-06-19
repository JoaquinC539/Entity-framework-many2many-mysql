using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Topping;

[Table("toppings")]
public class Topping
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public Topping()
    {}
    public Topping(int id, string name)
    {
        Id = id;
        Name = name;
    }
}