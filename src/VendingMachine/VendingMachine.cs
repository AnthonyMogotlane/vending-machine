using VendingMachineLib.Model;

namespace VendingMachineLib;
public class VendingMachine : IVendingMachine
{
    public double TotalPrice { get;}
    public double Change { get; }
    // List of Products
    List<Product> Products = new List<Product>()
    {
        new Product("chocolate", 10.50),
        new Product("chips", 15.00),
        new Product("soda", 18.00)
    };

    public double CheckPrice(string productName)
    {
        var product = Products.Find(o => o.ProductName == productName);
        return product.Price;
    }

    public string BuyProduct(string productName, double price)
    {
        var product = Products.Find(o => o.ProductName == productName);

        if(product == null) return "Product not available";
        if(product != null && price >= product.Price) 
        {
            TotalPrice += product.Price;
            Change = price - product.Price;
            return product.ProductName;
        }
        return "Insufficient funds";
    }

    public double GetTotalPrice() => TotalPrice;
    public double GetChange() => Change;
}