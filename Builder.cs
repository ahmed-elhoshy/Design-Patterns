public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }

    public void DisplaySpecs()
    {
        Console.WriteLine($"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {GPU}");
    }
}


public interface IComputerBuilder
{
    void SetCPU(string cpu);
    void SetRAM(string ram);
    void SetStorage(string storage);
    void SetGPU(string gpu);
    Computer Build();
}



public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void SetCPU(string cpu) => _computer.CPU = cpu;
    public void SetRAM(string ram) => _computer.RAM = ram;
    public void SetStorage(string storage) => _computer.Storage = storage;
    public void SetGPU(string gpu) => _computer.GPU = gpu;

    public Computer Build() => _computer;
}


public class ComputerDirector
{
    private readonly IComputerBuilder _builder;

    public ComputerDirector(IComputerBuilder builder)
    {
        _builder = builder;
    }

    public void BuildHighEndGamingPC()
    {
        _builder.SetCPU("Intel i9-13900K");
        _builder.SetRAM("32GB DDR5");
        _builder.SetStorage("2TB NVMe SSD");
        _builder.SetGPU("RTX 4090");
    }

    public void BuildBudgetPC()
    {
        _builder.SetCPU("AMD Ryzen 5");
        _builder.SetRAM("16GB DDR4");
        _builder.SetStorage("512GB SSD");
        _builder.SetGPU("Integrated");
    }
}


// Create a builder
var gamingBuilder = new GamingComputerBuilder();

// Create a director and pass the builder
var director = new ComputerDirector(gamingBuilder);

// Build a high-end gaming PC
director.BuildHighEndGamingPC();

// Get the final product
Computer gamingPC = gamingBuilder.Build();

// Display specs
gamingPC.DisplaySpecs();
// Output: CPU: Intel i9-13900K, RAM: 32GB DDR5, Storage: 2TB NVMe SSD, GPU: RTX 4090
