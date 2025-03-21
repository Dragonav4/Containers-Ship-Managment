namespace ConsoleAppProject_3_s31722;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed{ get; }
    public int MaxContainers{ get; }
    public double MaxWeight{ get; }

    private readonly List<Container> containers = new();
    public List<Container> Containers => containers;

    
    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if(containers.Count >= MaxContainers) { throw new InvalidOperationException($"Ship {Name} cannot load more containers!");} //TODO all cons before max
        if(GetTotalWeight() +  container.TareWeight > MaxWeight * 1000) throw new InvalidOperationException($"Ship {Name} exceeds the allowed weight!");
        containers.Add(container);
    }

    public void RemoveContainer(Container container)
    {
        containers.Remove(container);
    }
    
    public double GetTotalWeight()
    {
        return containers.Sum(c => c.TareWeight + c.CargoWeight);
    }
    
    public void PrintInfo()
    {
        Console.WriteLine(
            $"Ship {Name}: Speed {MaxSpeed} knots, {Containers.Count}/{MaxContainers} containers, {Containers.Sum(c => c.TareWeight + c.CargoWeight) / 1000}/{MaxWeight} tons loaded");
        foreach (var container in Containers)
            Console.WriteLine($"  - {container}");
    }
}