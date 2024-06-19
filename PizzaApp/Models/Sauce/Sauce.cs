using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Sauce;

[Table("sauces")]
public class Sauce{
    
    [Column("id")]
    public int? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public Sauce()
    {}

    public Sauce (string name)
    {
        Name = name;
    }

    public Sauce(int id, string name) 
    {
        Id = id;
        Name = name;
    }

}