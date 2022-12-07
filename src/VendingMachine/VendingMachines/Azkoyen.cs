using VendingMachineLib.Model;

namespace VendingMachineLib;
public class Azkoyen : IVendingMachine
{
    public double TotalAmount { get; set; }
    public double Change { get; set; }
    public List<Product> Products { get; set; }
    public Dictionary<string, int> SoldProducts { get; set; }

    public Azkoyen(List<Product> products)
    {
        this.Products = products;
        this.SoldProducts = new Dictionary<string, int>();
    }

    public double CheckPrice(string name)
    {
        var product = Products.Find(o => o.Name == name);
        return product.Price;
    }

    public string BuyProduct(string name, double price)
    {
        var product = Products.Find(o => o.Name == name);

        if (product == null) return "Product not available";
        if (product != null && price >= product.Price)
        {
            TotalAmount += product.Price;
            Change = price - product.Price;

            if(!SoldProducts.ContainsKey(product.Name))
                SoldProducts.Add(product.Name, 1);
            else
                SoldProducts[product.Name]++;


            Products.Remove(product);
            return product.Name;
        }
        return "Insufficient funds";
    }

    public double GetTotalPrice() => TotalAmount;
    public double GetChange() => Change;
}