namespace SimpleCrudApi.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // public ProductModel() { }
    public ProductModel(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

}
