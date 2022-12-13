using VendingMachineLib.Model;
using VendingMachineLib.PowerSources;


namespace VendingMachineLib.VendingMachines;
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

    public string CheckPrice(string name)
    {
        if (SwitchIsOff()) return PowerSupplyStatus(); // Check if the power is ON or OF

        var product = Products.Find(o => o.Name == name);
        return $"R{product.Price}".Replace(',', '.');
    }

    public string BuyProduct(string name, double price)
    {
        if (SwitchIsOff()) return PowerSupplyStatus(); // Check if the power is ON or OFF

        // Execute if the is power
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

    public string GetTotalPrice() => SwitchIsOff() ? PowerSupplyStatus() : $"R{TotalAmount}".Replace(',', '.');
    public string GetChange() => SwitchIsOff() ? PowerSupplyStatus() : $"R{Change}".Replace(',', '.');

    // Get power source if the is power e.g "Electricity", "No Power" if the supply is off
    public string PowerSupplyStatus() => Power.GetDesc();
    // Returning false if the power source is off
    public bool SwitchIsOff() => !Power.PowerStatus();
}