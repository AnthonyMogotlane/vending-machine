using VendingMachineLib.Model;

namespace VendingMachineLib;
public class Azkoyen : IVendingMachine
{
    public double TotalAmount { get; set; }
    public double Change { get; set; }
    public List<Product> Products { get; set; }
    public Dictionary<string, int> SoldProducts { get; set; }
    public PowerSource Power { get; set; }

    public Azkoyen(List<Product> products, PowerSource power)
    {
        this.Products = products;
        this.SoldProducts = new Dictionary<string, int>();
        this.Power = power;
    }

    public double CheckPrice(string name)
    {
        if(Power.PowerStatus())
        {
            var product = Products.Find(o => o.Name == name);
            return product.Price;
        }
        return 0.00;
    }

    public string BuyProduct(string name, double price)
    {
        if (Power.PowerStatus())
        {
            var product = Products.Find(o => o.Name == name);

            if (product == null) return "Product not available";
            if (product != null && price >= product.Price)
            {
                TotalAmount += product.Price;
                Change = price - product.Price;

                if (!SoldProducts.ContainsKey(product.Name))
                    SoldProducts.Add(product.Name, 1);
                else
                    SoldProducts[product.Name]++;


                Products.Remove(product);
                return product.Name;
            }
            return "Insufficient funds";
        }
        return "";
    }

    public double GetTotalPrice() => Power.PowerStatus() ? TotalAmount : 0.00;
    public double GetChange() => Power.PowerStatus() ? Change : 0.00;
}