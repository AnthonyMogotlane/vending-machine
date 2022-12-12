namespace VendingMachineLib.PowerSources;
public abstract class PowerSource : IPowerSource
{
    public bool On { get; set; } = false;

    public PowerSource(bool on) => this.On = on;

    public bool PowerStatus() => On;

    public abstract string GetDesc();
}