using VendingMachineLib;
using VendingMachineLib.VendingMachines;
using VendingMachineLib.Model;
using VendingMachineLib.PowerSources;



namespace VendingMachineLib.Tests;
public class VendingMachineTest
{
    public List<Product> GetProducts()
    {
        return new List<Product>()
        {
            new SoftDrink("CocaCola", "No Sugar Soft Drink Bottle", 12.99, 500),
            new Chocolate("KitKat", "KitKat 4 Finger Milk Chocolate Bar", 11.99, 41.5),
            new PotatoChips("Simba", "Cheese & Onion Flavoured Potato Chips", 19.99, 120)
        };
    }

    Electricity powerSource = new Electricity(true); // Power source for the whole building

    [Fact]
    public void ShouldReturnThePriceOfAColaCola()
    {
        // Given
        var vm1 = new Azkoyen(GetProducts(), powerSource);
        // When
        string product = "CocaCola";
        // Then
        Assert.Equal("R12.99", vm1.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnThePriceOfAKitKat()
    {
        // Given                
        var vm = new Azkoyen(GetProducts(), powerSource);
        // When
        string product = "KitKat";
        // Then

        // en-ZA
        Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);



        Assert.Equal("R11.99", vm.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnProductIfFundIsEnough()
    {
        // Given
        var vm = new Azkoyen(GetProducts(), powerSource);
        // When
        string product = "CocaCola";
        double price = 20.00;
        // Then
        Assert.Equal(product, vm.BuyProduct(product, price));
        Assert.Equal("R12.99", vm.GetTotalPrice());
        Assert.Equal("R7.01", vm.GetChange());
    }

    [Fact]
    public void ShouldReturnInsufficientFundsIfNotEnough()
    {
        // Given
        var vm = new Azkoyen(GetProducts(), powerSource);
        // When
        string product = "Simba";
        double price = 10.00;
        string message = "Insufficient funds";
        // Then
        Assert.Equal(message, vm.BuyProduct(product, price));
    }

    [Fact]
    public void ShouldReturnTotalOfTheProductsBought()
    {
        // Given
        var vmm = new VendingMachineManager(); // Manager Instance

        var vm1 = new Azkoyen(GetProducts(), powerSource);
        var vm2 = new Azkoyen(GetProducts(), powerSource);
        var vm3 = new Azkoyen(GetProducts(), powerSource);

        // When
        vm1.BuyProduct("Simba", 19.99);
        vm2.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("CocaCola", 12.99);

        vmm.AddVendingMachines(vm1, vm2, vm3);
        // Then
        Assert.Equal(52.97, vmm.GetTotalIncome());
    }

    [Fact]
    public void ShouldReturnTheMostPopularProductSold()
    {
        // Given
        var vm1 = new Azkoyen(GetProducts(), powerSource);
        var vm2 = new Azkoyen(GetProducts(), powerSource);
        var vm3 = new Azkoyen(GetProducts(), powerSource);

        var vmm = new VendingMachineManager();
        // When
        vm1.BuyProduct("Simba", 19.99);
        vm2.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("CocaCola", 12.99);

        vmm.AddVendingMachines(vm1, vm2, vm3);
        vmm.AddSoldProducts();
        // Then
        Assert.Equal("Simba", vmm.GetMostPopular());
    }

    [Fact]
    public void ShouldReturnTheLeastPopularProductSold()
    {
        // Given
        var vmm = new VendingMachineManager(); // Manager instance
        var vm1 = new Azkoyen(GetProducts(), powerSource);
        var vm2 = new Azkoyen(GetProducts(), powerSource);
        var vm3 = new Azkoyen(GetProducts(), powerSource);
        // When -> Items bought in vending machines in the building
        vm1.BuyProduct("Simba", 19.99);
        vm2.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("CocaCola", 12.99);

        vmm.AddVendingMachines(vm1, vm2, vm3);
        vmm.AddSoldProducts();
        // Then
        Assert.Equal("CocaCola", vmm.GetLeastPopular());
    }

    [Fact]
    public void ShouldReturnNumberOfVendingMachinesInTheBuilding()
    {
        // Given
        var vmm = new VendingMachineManager(); // Manager instance
        var vm1 = new Azkoyen(GetProducts(), powerSource);
        var vm2 = new Azkoyen(GetProducts(), powerSource);
        var vm4 = new Azkoyen(GetProducts(), powerSource);
        var vm5 = new Azkoyen(GetProducts(), powerSource);
        var vm6 = new Azkoyen(GetProducts(), powerSource);
        var vm7 = new Azkoyen(GetProducts(), powerSource);
        // When
        vmm.AddVendingMachines(vm1, vm2, vm4, vm5, vm6, vm7); // 6 machines in the building
        // Then
        Assert.Equal(6, vmm.CountVendingMachines());
    }

    [Fact]
    public void ShouldReturnFalseIfPowerSourceIsInvalid()
    {
        var ps = new Electricity(false);
        Assert.False(ps.PowerStatus());
    }

    [Fact]
    public void ShouldReturnTrueIfPowerSourceIsValid()
    {
        var ps = new Solar(true);
        Assert.True(ps.PowerStatus());
    }

    [Fact]
    public void ShouldReturnThePowerSourceSuppliedToTheVendingMachine()
    {
        Electricity electricity = new Electricity(false);
        var vm1 = new Azkoyen(GetProducts(), electricity);

        Assert.Equal("No Power", vm1.PowerSupplyStatus());
    }

    [Fact]
    public void ShouldReturnNoPowerIfTheIsNoPowerSource()
    {
        Electricity electricity = new Electricity(true);
        var vm1 = new Azkoyen(GetProducts(), electricity);

        Assert.Equal("Powered by Electricity", vm1.PowerSupplyStatus());
    }
}