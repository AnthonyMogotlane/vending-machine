using VendingMachineLib;
using VendingMachineLib.Model;


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

    [Fact]
    public void ShouldReturnThePriceOfAColaCola()
    {
        // Given
        var vm1 = new Azkoyen(GetProducts());
        // When
        string product = "CocaCola";
        // Then
        Assert.Equal(12.99, vm1.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnThePriceOfAKitKat()
    {
        // Given
        var vm = new Azkoyen(GetProducts());
        // When
        string product = "KitKat";
        // Then
        Assert.Equal(11.99, vm.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnProductIfFundIsEnough()
    {
        // Given
        var vm = new Azkoyen(GetProducts());
        // When
        string product = "CocaCola";
        double price = 20.00;
        // Then
        Assert.Equal(product, vm.BuyProduct(product, price));
        Assert.Equal(12.99, vm.GetTotalPrice());
        Assert.Equal(7.01, vm.GetChange());
    }

    [Fact]
    public void ShouldReturnInsufficientFundsIfNotEnough()
    {
        // Given
        var vm = new Azkoyen(GetProducts());
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
        var vm1 = new Azkoyen(GetProducts());
        var vm2 = new Azkoyen(GetProducts());
        var vm3 = new Azkoyen(GetProducts());

        var vmm = new VendingMachineManager(vm1, vm2, vm3);
        // When
        vm1.BuyProduct("Simba", 19.99);
        vm2.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("CocaCola", 12.99);
        // Then



        Console.WriteLine(vm1.SoldProducts.Count());

        Assert.Equal(52.97, vmm.GetTotalIncome());
    }

    [Fact]
    public void ShouldReturnTheMostPopularProductSold()
    {
        // Given
        var vm1 = new Azkoyen(GetProducts());
        var vm2 = new Azkoyen(GetProducts());
        var vm3 = new Azkoyen(GetProducts());

        var vmm = new VendingMachineManager(vm1, vm2, vm3);
        // When
        vm1.BuyProduct("Simba", 19.99);
        vm2.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("Simba", 19.99);
        vm3.BuyProduct("CocaCola", 12.99);

        vmm.AddSoldProducts(vm1.SoldProducts);
        vmm.AddSoldProducts(vm2.SoldProducts);
        vmm.AddSoldProducts(vm3.SoldProducts);
        // Then
        Assert.Equal("Simba", vmm.GetMostPopular());
    }
}