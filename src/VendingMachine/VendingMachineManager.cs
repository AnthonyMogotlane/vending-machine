
namespace VendingMachineLib;

public class VendingMachineManager
{
    public int TotalIncome { get; set; }
    public Dictionary<string, int> AllSoldProducts { get; set; }

    public Azkoyen Vm1 { get; set; }
    public Azkoyen Vm2 { get; set; }
    public Azkoyen Vm3 { get; set; }

    public VendingMachineManager(Azkoyen vm1, Azkoyen vm2, Azkoyen vm3)
    {
        this.Vm1 = vm1;
        this.Vm2 = vm2;
        this.Vm3 = vm3;
        AllSoldProducts = new Dictionary<string, int>();
    }

    public double GetTotalIncome()
    {
       return Vm1.TotalAmount + Vm2.TotalAmount + Vm3.TotalAmount;
    }

    public void AddSoldProducts(Dictionary<string, int> soldProducts)
    {
        foreach (var product in soldProducts)
        {
            if(!AllSoldProducts.ContainsKey(product.Key))
                AllSoldProducts.Add(product.Key, 1);
            else
                AllSoldProducts[product.Key]++;
        }
    }

    public string GetMostPopular()
    {
        return AllSoldProducts.Keys.Max();
    }
}