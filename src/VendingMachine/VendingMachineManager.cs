using VendingMachineLib.VendingMachines;


namespace VendingMachineLib;
public class VendingMachineManager
{
    public int TotalIncome { get; set; }
    public Dictionary<string, int> AllSoldProducts { get; set; }
    public List<Azkoyen> VendingMachines {get;set;}

    public VendingMachineManager()
    {
        AllSoldProducts = new Dictionary<string, int>();
        VendingMachines = new List<Azkoyen>();
    }

 
    public void AddVendingMachines(params Azkoyen[] vms)
    {
        foreach (var vm in vms)
            VendingMachines.Add(vm);
    }

    public int CountVendingMachines() => VendingMachines.Count();
    
    // Total income of all vending machine
    public double GetTotalIncome() => 
        VendingMachines.Select(vm => vm.TotalAmount).Aggregate(0.00, (sum, ta) => sum + ta);


    public void AddSoldProducts()
    {
        foreach (var vm in VendingMachines)
        {
            foreach (var product in vm.SoldProducts)
            {
                if(!AllSoldProducts.ContainsKey(product.Key))
                    AllSoldProducts.Add(product.Key, 1);
                else
                    AllSoldProducts[product.Key]++;
            }
        }
    }

    public string GetMostPopular() => AllSoldProducts.Keys.Max();
    public string GetLeastPopular() => AllSoldProducts.Keys.Min();
}