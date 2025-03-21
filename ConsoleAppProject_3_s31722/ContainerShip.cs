using ConsoleAppProject_3_s31722.ContainerClasses;

namespace ConsoleAppProject_3_s31722;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }

    private readonly List<Container> _containers = new();
    public IReadOnlyCollection<Container> Containers => _containers;

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException($"Ship {Name} cannot load more containers!");
        }

        if (GetTotalWeight() + container.TotalWeight > MaxWeight * 1000)
            throw new InvalidOperationException($"Ship {Name} exceeds the allowed weight!");
        _containers.Add(container);
    }

    public void ReplaceContainer(Container container, string oldContainerId)
    {
        var containerToRemove = _containers.FirstOrDefault(c =>c.SerialNumber == oldContainerId);
        if(containerToRemove != null)
        {
            _containers.Remove(containerToRemove);
            _containers.Add(container);
        }
    }

    public void MoveToAnotherShip(Container container, ContainerShip otherShip)
    {
        RemoveContainer(container);
        otherShip.LoadContainer(container);
    }
    
    public void LoadContainers(IEnumerable<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }
    
    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public double GetTotalWeight()
    {
        return _containers.Sum(c => c.TotalWeight);
    }

    public void PrintInfo()
    {
        Console.WriteLine(
            $"Ship {Name}: Speed {MaxSpeed} knots, {Containers.Count}/{MaxContainers} containers, {Containers.Sum(c => c.TareWeight + c.CargoWeight) / 1000}/{MaxWeight} tons loaded");
        foreach (var container in Containers)
            Console.WriteLine($"  - {container}");
    }
}