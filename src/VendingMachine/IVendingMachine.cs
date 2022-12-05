using VendingMachineLib.Model;

namespace VendingMachineLib;
public interface IVendingMachine
{
    public double CheckPrice(string productName);

    public string BuyProduct(string productName, double price);

    public double GetTotalPrice();
    public double GetChange();
}