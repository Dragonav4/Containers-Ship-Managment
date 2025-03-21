using ConsoleAppProject_3_s31722;
using ConsoleAppProject_3_s31722.ContainerClasses;

class Program
{
    public static void Main()
    {
        List<Container> containers = new List<Container>();
        List<ContainerShip> ships = new List<ContainerShip>();


        while (true)
        {
            Console.WriteLine("\n--- Container & Ship Management ---");
            Console.WriteLine("1. Add a container");
            Console.WriteLine("2. Add a ship");
            Console.WriteLine("3. Load a container onto a ship");
            Console.WriteLine("4. Display ship information");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var container = CreateContainer();
                    if (container != null) containers.Add(container);
                    break;
                case "2":
                    var ship = CreateShip();
                    if (ship != null) ships.Add(ship);
                    break;
                case "3":
                    LoadContainerOnShip(containers, ships);
                    break;
                case "4":
                    return;
                case "5":
                    PrintShipInfo(ships);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static Container CreateContainer()
    {
        Console.WriteLine("\nSelect container type:");
        Console.WriteLine("1. Liquid Container");
        Console.WriteLine("2. Gas Container");
        Console.WriteLine("3. Refrigerated Container");
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Max payload (kg): ");
        double maxPayload = double.Parse(Console.ReadLine());
        Console.Write("Tare weight (kg): ");
        double tareWeight = double.Parse(Console.ReadLine());
        Console.Write("Depth (cm): ");
        double depth = double.Parse(Console.ReadLine());
        Console.Write("Width (cm): ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Height (cm): ");
        double height = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                Console.Write("Hazardous cargo (true/false): ");
                bool isHazardous = bool.Parse(Console.ReadLine());
                return new LiquidContainer(height, width, depth, tareWeight, maxPayload, isHazardous);

            case "2":
                Console.Write("Pressure (atm): ");
                double pressure = double.Parse(Console.ReadLine());
                return new GasContainer(height, width, depth, tareWeight, maxPayload, pressure);
            case "3":
                Console.Write("Product type (Bananas, Meat, etc.): ");
                string product = Console.ReadLine();
                Console.Write("Storage temperature (°C): ");
                double temp = double.Parse(Console.ReadLine());
                return new RefrigeratedContainer(product, temp, height, width, depth, tareWeight, maxPayload);
            default:
                Console.WriteLine("Invalid selection :(");
                return null;
        }
    }

    static ContainerShip CreateShip()
    {
        Console.WriteLine("\nEnter ship name:");
        string shipName = Console.ReadLine();
        Console.Write("Maximum speed (knots): ");
        double maxSpeed = double.Parse(Console.ReadLine());
        Console.Write("Max number of containers: ");
        int maxContainers = int.Parse(Console.ReadLine());
        Console.Write("Maximum weight (tons): ");
        double maxWeight = double.Parse(Console.ReadLine());

        return new ContainerShip(shipName, maxSpeed, maxContainers, maxWeight);
    }

    static void LoadContainerOnShip(List<Container> containers, List<ContainerShip> ships)
    {
        if (ships.Count == 0)
        {
            Console.WriteLine("\nNo available ships ");
            return;
        }

        if (containers.Count == 0)
        {
            Console.WriteLine("\nNo available containers ");
            return;
        }

        Console.Write("Choose your ship: ");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {ships[i].Name} ({ships[i].Containers.Count}/{ships[i].MaxContainers} containers)");
        }
        
        if (!int.TryParse(Console.ReadLine(), out int shipIndex) || shipIndex < 1 || shipIndex > ships.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        
        Console.WriteLine("\nAvailable containers:");
        for (int i = 0; i < containers.Count; i++)
            Console.WriteLine($"{i + 1}. {containers[i].SerialNumber} ({containers[i].CargoWeight + containers[i].TareWeight} kg)");
        
        Console.Write("Select a container: ");
        if (!int.TryParse(Console.ReadLine(), out int containerIndex) || containerIndex < 1 || containerIndex > containers.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        ContainerShip selectedShip = ships[shipIndex - 1];
        Container selectedContainer = containers[containerIndex - 1];
        Console.Write($"Enter cargo weight for {selectedContainer.SerialNumber} (max {selectedContainer.MaxPayload} kg): ");
        if (!double.TryParse(Console.ReadLine(), out double cargoWeight))
        {
            Console.WriteLine("Invalid weight input.");
            return;
        }

        
        selectedContainer.LoadCargo(cargoWeight);
        
        try
        {
            selectedContainer.LoadCargo(cargoWeight);
            selectedShip.LoadContainer(selectedContainer);
            Console.WriteLine($"Container {selectedContainer.SerialNumber} loaded onto {selectedShip.Name}.");
            containers.RemoveAt(containerIndex - 1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
    }
    static void PrintShipInfo(List<ContainerShip> ships)
    {
        if (ships.Count == 0)
        {
            Console.WriteLine("No ships available.");
            return;
        }

        Console.WriteLine("\nShip Information:");
        foreach (var ship in ships)
        {
            ship.PrintInfo(); // Вызываем PrintInfo() у каждого корабля
        }
    }
    
}