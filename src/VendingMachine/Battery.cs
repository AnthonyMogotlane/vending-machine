
namespace VendingMachineLib;
public class Battery : IPowerSource
{
    public bool On { get; set; } = false;

    public PowerSource(bool on) => this.On = on;
    
    public bool PowerStatus() => On;
}