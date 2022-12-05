namespace VendingMachineLib.Model;
class Product
{
    public string? ProductName { get;}
    public double Price { get;}

    public Product(string productName, double price)
    {
        ProductName = productName;
        Price = price;
    }
}