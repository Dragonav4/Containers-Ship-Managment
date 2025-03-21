namespace ConsoleAppProject_3_s31722;

public abstract class Container
{
    private static int counter = 1; // 

    public string SerialNumber { get; } //TODO readonly
    public double MaxPayload { get; }
    public double TareWeight { get; } //weight of container
    public double CargoWeight { get; set; } // weight of cargo 
    
    public double Depth { get; }
    public double Height { get; }
    public double Width { get; }

    public Container(string type,double height, double width, double depth, double tareWeight, double maxPayload) // created a container(without cargo)
    {
        this.MaxPayload = maxPayload;
        this.Depth = depth;
        this.Height = height;
        this.Width = width;
        this.TareWeight = tareWeight;
        SerialNumber = $"KON-{type}-{counter++}";
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    } //virtual for override класс наследник from base class}

    public virtual void LoadCargo(double weight)
    {
        if (CargoWeight + TareWeight > MaxPayload)
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

    public override string ToString() => $"{SerialNumber}: {CargoWeight/MaxPayload}kg loaded, tare weight is {TareWeight}kg ";
}