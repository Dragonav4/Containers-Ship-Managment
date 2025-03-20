using System.Runtime.InteropServices;
using ConsoleAppProject_3_s31722.Interface;

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
        double limit = (IsHazardous) ? maxPayload * 0.5 : maxPayload * 0.9;
        if (weight > limit)
        {
            displayHazardNotification(
                $"Alert overrfilled hazard cargo container. Overfilled detected in: {SerialNumber}");
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        }

        base.LoadCargo(weight);
    }
    public void displayHazardNotification(String message)
    {
        throw new ExternalException(message);
    }
}