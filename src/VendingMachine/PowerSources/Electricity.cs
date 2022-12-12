namespace VendingMachineLib.PowerSources;
public class Electricity : PowerSource
{
    public Electricity(bool on) : base(on) { }
    public override string GetDesc()
    {
        return On ? "Powered by Electricity" : "No Power";
    }
}