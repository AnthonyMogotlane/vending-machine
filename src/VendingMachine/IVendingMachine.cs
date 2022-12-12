namespace VendingMachineLib;
public interface IVendingMachine
{
    public string CheckPrice(string productName);
    
    public string BuyProduct(string productName, double price);

    public string GetTotalPrice();
    public string GetChange();
}

