using System.Runtime.InteropServices;

namespace ConsoleAppProject_3_s31722.ContainerClasses;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(
        double height,
        double width,
        double depth,
        double tareWeight,
        double maxPayload,
        bool isHazardous) :
        base(
            "L",
            height,
            width,
            depth,
            tareWeight,
            maxPayload)
    {
        IsHazardous = IsHazardous;
    }

    public override void LoadCargo(double weight)
    {
        var limit = (IsHazardous) ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (CargoWeight + weight > limit)
        {
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        }
        CargoWeight+=weight;
    }
    public void DisplayHazardNotification()
    {
        throw new ExternalException($"Alert hazard cargo container: {SerialNumber}");
    }
}