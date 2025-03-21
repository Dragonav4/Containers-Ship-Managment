using System.Runtime.InteropServices;

namespace ConsoleAppProject_3_s31722.ContainerClasses;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

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

    {
        Pressure = pressure;
    } 

    public override void UnloadCargo() => CargoWeight -= CargoWeight * 0.95;

    public void DisplayHazardNotification()
    {
        throw new ExternalException($"ALARM in container: {SerialNumber}");
    }
}