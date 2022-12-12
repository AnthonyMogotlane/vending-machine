namespace VendingMachineLib.PowerSources;
public class Solar : PowerSource
{
    public Solar(bool on) : base(on) { }
    public override string GetDesc()
    {
        return On ? "Powered by Solar" : "No Power";
    }
}