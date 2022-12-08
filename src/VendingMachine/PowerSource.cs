namespace VendingMachineLib;
public class PowerSource
{
    public string InputPower { get; set; }

    public PowerSource(string inputPower)
    {
        this.InputPower = inputPower;
    }

    public bool GetPower()
    {
        if(new List<string>(){"Solar", "Battery", "Electricity"}.Contains(InputPower))
            return true;
        else
            return false;
    } 
}