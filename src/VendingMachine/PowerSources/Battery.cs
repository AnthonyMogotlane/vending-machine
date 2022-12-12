namespace VendingMachineLib.PowerSources;
public class Battery : PowerSource
{
    public Battery(bool on) : base(on) { }
    public override string GetDesc()
    {
        return On ? "Powered by Battery" : "No Power";
    }
}