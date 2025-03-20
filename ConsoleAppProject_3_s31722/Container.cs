namespace ConsoleAppProject_3_s31722;

public abstract class Container
{
    private static int counter = 1; // 

    public string SerialNumber { get; } //TODO readonly
    public double maxPayload { get; }
    public double tareWeight { get; } //weight of container
    public double CargoWeight { get; set; } // weight of cargo 
    
    public double depth { get; }
    public double height { get; }
    public double width { get; }

    public Container(string type,double height, double width, double depth, double tareWeight, double maxPayload) // created a container(without cargo)
    {
        this.maxPayload = maxPayload;
        this.depth = depth;
        this.height = height;
        this.width = width;
        this.tareWeight = tareWeight;
        SerialNumber = $"KON-{type}-{counter++}";
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    } //virtual for override класс наследник from base class}

    public virtual void LoadCargo(double weight)
    {
        if (CargoWeight + tareWeight > maxPayload)
        {
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        }
        CargoWeight += weight;
    }
    
    public class CargoOverloadException : Exception
    {
        public CargoOverloadException(string message) : base(message)
        {
        }
    }

    public override string ToString() => $"{SerialNumber}: {CargoWeight/maxPayload}kg loaded, tare weight is {tareWeight}kg ";
}