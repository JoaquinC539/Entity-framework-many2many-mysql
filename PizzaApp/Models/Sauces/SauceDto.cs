namespace Models.Sauces;

public class SauceDto
{
    public int? Id { get; set; }

    
    public string? Name { get; set; }

    public SauceDto()
    {}

    public SauceDto (string name)
    {
        Name = name;
    }

    public SauceDto(int id, string name) 
    {
        Id = id;
        Name = name;
    }
}