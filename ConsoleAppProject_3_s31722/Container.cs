namespace ConsoleAppProject_3_s31722;

public class Container
{
    private int counter = 1; // 

    public string serialNumber { get; }
    public double maxPayload { get; }
    public double tareWeight { get; } //weight of container
    public double cargoWeight { get; private set; } // weight of cargo

    protected Container(double maxPayload, double tareWeight, string type) // created a container(without cargo)
    {
        this.maxPayload = maxPayload;
        this.tareWeight = tareWeight;
        serialNumber = $"{type}-{counter++}";
    }

    public virtual void UnloadCargo() => cargoWeight = 0; //virtual for override класс наследник from base class

    public virtual void LoadCargo(double weight)
    {
        if (cargoWeight + tareWeight > maxPayload)
        {
            throw new CargoOverloadException($"Cannot load cargo. Overfilled detected in: {serialNumber}!.");
        }
        cargoWeight += weight;
    }

    
    
    

    private class CargoOverloadException : Exception
    {
        public CargoOverloadException(string message) : base(message)
        {
        }
    }
}