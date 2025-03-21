using System.Runtime.InteropServices;
using ConsoleAppProject_3_s31722.Interface;

namespace ConsoleAppProject_3_s31722.ContainerClasses;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; }

    public GasContainer(
        double height,
        double width,
        double depth,
        double tareWeight,
        double maxPayload,
        double pressure) : base(
        "G",
        height,
        width,
        depth,
        tareWeight,
        maxPayload)
    
    { Pressure = pressure;} // TODO 
    
    public override void UnloadCargo() => CargoWeight -= CargoWeight * 0.95;
    
    public override void LoadCargo(double weight)
    {
        if (CargoWeight + weight > MaxPayload)
        {
            displayHazardNotification(
                $"Alert overrFilled hazard cargo container. Overfilled detected in: {SerialNumber}");
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        } 
        base.LoadCargo(weight);
    }
    public void displayHazardNotification(String message)
    {
        throw new ExternalException(message);
    }
}