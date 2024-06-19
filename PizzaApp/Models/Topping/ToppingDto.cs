namespace Models.Topping;

public partial class ToppingDto
{
     public int? Id { get; set; }

    
    public string? Name { get; set; }

    public ToppingDto()
    {}

    public ToppingDto(string name)
    {
        Name = name;
    }
    public ToppingDto(int? id, string name)
    {
        Id = id;
        Name = name;
    }
}