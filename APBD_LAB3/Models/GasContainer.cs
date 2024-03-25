using APBD_LAB3.Interfaces;
using APBD_LAB3.Exeption;

namespace APBD_LAB3.Models;

public class GasContainer : Container, IHazardNotifier
{
    protected double Pressure { get; private set; }
    
    public GasContainer(double maxWeight, double emptyWeight, double height, double depth, double pressure)
        : base(maxWeight, emptyWeight, height, depth)
    {
        Pressure = pressure;
        IdNumber += "-G-" + Counter;
    }

    public override void LoadCargo(double weight)
    {
        if (weight + CurrentWeight > MaxWeight)
        {
            NotifyDanger();
            throw new OverfillException("Cargo weight exceeds container capacity.");
        }
        else
        {
            CurrentWeight += weight;
        }    
    }

    public override void UnloadCargo()
    {
        CurrentWeight = CurrentWeight * 0.05 + EmptyWeight;
    }

    public void NotifyDanger()
    {
        Console.WriteLine($"Container {IdNumber} has hazardous cargo!");
    }

    public override string ToString()
    {
        return base.ToString() +
               $", pressure = {Pressure}";
}
}