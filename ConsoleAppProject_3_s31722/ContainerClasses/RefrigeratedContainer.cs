using System.Runtime.InteropServices;
using ConsoleAppProject_3_s31722.Interface;

namespace ConsoleAppProject_3_s31722.ContainerClasses;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public string TypeOfProduct { get; set; }
    public double Temperature { get; set; }

    public static readonly Dictionary<string, double> productTemperature = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice Cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(
        string typeOfProduct,
        double temperature,
        double height,
        double width,
        double depth,
        double tareWeight,
        double maxPayload) :
        base(
            "R",
            height,
            width,
            depth,
            tareWeight,
            maxPayload)
    {
        {
            if (!productTemperature.ContainsKey(typeOfProduct))
            {
                throw new KeyNotFoundException($"Product '{typeOfProduct}' not found.");
            }

            if (temperature > productTemperature[typeOfProduct])
            {
                throw new ArgumentException
                ($"Product '{typeOfProduct}' must be kept at its proper temperature " +
                 $"{productTemperature[typeOfProduct]}°C or lower.");
            }
        }
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
    }

    public void displayHazardNotification(String message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }
    
    public override void LoadCargo(double weight)
    {
        if (CargoWeight + weight > maxPayload)
        {
            displayHazardNotification(
                $"Alert overrFilled hazard cargo container. Overfilled detected in: {SerialNumber}");
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        }

        base.LoadCargo(weight);
    }
}