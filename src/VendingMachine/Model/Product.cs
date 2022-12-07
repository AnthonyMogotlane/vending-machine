namespace VendingMachineLib.Model;
public class Product
{
    public string? Name { get; set;}
    public string? Description { get; set;}
    public double Price { get; set;}
    public double Size { get; set;}
}

public class SoftDrink : Product
{
    public SoftDrink(string name, string description, double price, double size)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Size = size;
    }
}

public class Chocolate : Product
{
    public Chocolate(string name, string description, double price, double size)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Size = size;
    }
}

public class PotatoChips : Product 
{
    public PotatoChips(string name, string description, double price, double size)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Size = size;
    }
}
