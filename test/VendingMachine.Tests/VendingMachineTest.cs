using VendingMachineLib;


namespace VendingMachineLib.Tests;
public class VendingMachineTest
{
    [Fact]
    public void ShouldReturnThePriceOfAChocolate()
    {
        // Given
        var vm = new VendingMachine();
        // When
        string product = "chocolate";
        // Then
        Assert.Equal(10.5, vm.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnThePriceOfASoda()
    {
        // Given
        var vm = new VendingMachine();
        // When
        string product = "soda";
        // Then
        Assert.Equal(18, vm.CheckPrice(product));
    }

    [Fact]
    public void ShouldReturnProductIfFundIsEnough()
    {
        // Given
        var vm = new VendingMachine();
        // When
        string product = "soda";
        double price = 20.00;
        // Then
        Assert.Equal(product, vm.BuyProduct(product, price));
        Assert.Equal(18.00, vm.GetTotalPrice());
        Assert.Equal(2.00, vm.GetChange());
    }

    [Fact]
    public void ShouldReturnInsufficientFundsIfNotEnough()
    {
        // Given
        var vm = new VendingMachine();
        // When
        string product = "soda";
        double price = 10.00;
        string message = "Insufficient funds";
        // Then
        Assert.Equal(message, vm.BuyProduct(product, price));
    }
}