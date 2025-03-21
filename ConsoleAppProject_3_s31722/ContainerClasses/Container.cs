namespace ConsoleAppProject_3_s31722.ContainerClasses;

public abstract class Container
{
    private static int _counter = 1; 

    public string SerialNumber { get; } 
    public double MaxPayload { get; }
    public double TareWeight { get; } //weight of container
    public double CargoWeight { get; protected set; } // weight of cargo 
    
    public double TotalWeight => TareWeight + CargoWeight;
    public double Depth { get; }
    public double Height { get; }
    public double Width { get; }

    public Container(string type,double height, double width, double depth, double tareWeight, double maxPayload) // created a container(without cargo)
    {
        MaxPayload = maxPayload;
        Depth = depth;
        Height = height;
        Width = width;
        TareWeight = tareWeight;
        SerialNumber = $"KON-{type}-{_counter++}";
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    } //virtual for override класс наследник from base class}

    public virtual void LoadCargo(double weight)
    {
        if (CargoWeight + weight > MaxPayload)
        {
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {SerialNumber}!.");
        }
        CargoWeight += weight;
    }

    protected class CargoOverloadException : Exception
    {
        public CargoOverloadException(string message) : base(message)
        {
        }
    }

    public override string ToString() => $"{SerialNumber}: {CargoWeight/MaxPayload}kg loaded, tare weight is {TareWeight}kg ";
}