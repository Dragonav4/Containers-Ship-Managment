using System.Runtime.InteropServices;

namespace ConsoleAppProject_3_s31722.ContainerClasses;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public RefrigeratedProductType TypeOfProductType { get; private set; }
    public double Temperature { get; private set; }
    public enum RefrigeratedProductType
    {
        Bananas,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Sausages,
        Butter,
        Eggs
    }
    
    private static readonly Dictionary<RefrigeratedProductType, double> _productTemperature = new()
    {
        { RefrigeratedProductType.Bananas, 13.3 },
        { RefrigeratedProductType.Chocolate, 18 },
        { RefrigeratedProductType.Fish, 2 },
        { RefrigeratedProductType.Meat, -15 },
        { RefrigeratedProductType.IceCream, -18 },
        { RefrigeratedProductType.FrozenPizza, -30 },
        { RefrigeratedProductType.Cheese, 7.2 },
        { RefrigeratedProductType.Sausages, 5 },
        { RefrigeratedProductType.Butter, 20.5 },
        { RefrigeratedProductType.Eggs, 19 }
    };

    public RefrigeratedContainer(
        RefrigeratedProductType typeOfProductType,
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
            if (!_productTemperature.ContainsKey(typeOfProductType))
            {
                throw new KeyNotFoundException($"Product '{typeOfProductType}' not found.");
            }

            if (temperature > _productTemperature[typeOfProductType])
            {
                throw new ArgumentException
                ($"Product '{typeOfProductType}' must be kept at its proper temperature " +
                 $"{_productTemperature[typeOfProductType]}°C or lower.");
            }
        }
        TypeOfProductType = typeOfProductType;
        Temperature = temperature;
    }

    public void DisplayHazardNotification()
    {
        Console.WriteLine($"[ALERT IN CONTAINER:] {SerialNumber}");
    }
}