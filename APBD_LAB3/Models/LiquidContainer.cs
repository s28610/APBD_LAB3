using APBD_LAB3.Interfaces;
using APBD_LAB3.Exeption;

namespace APBD_LAB3.Models;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double maxWeight, double emptyWeight, double height, double depth, bool isHazardous)
        : base(maxWeight, emptyWeight, height, depth)
    {
        IsHazardous = isHazardous;
        IdNumber += "-L-" + Counter;
    }
    
    public override void LoadCargo(double weight)
    {
        if (IsHazardous && weight + CurrentWeight > MaxWeight * 0.5)
        {
            NotifyDanger();
            throw new OverfillException("Cargo weight exceeds container capacity.");
        } 
        else if(!IsHazardous && weight + CurrentWeight > MaxWeight * 0.9)
        {
            NotifyDanger();
            throw new OverfillException("Cargo weight exceeds container capacity.");

        }

        CurrentWeight += weight;
    }
    
    public override void UnloadCargo()
    {
        CurrentWeight = EmptyWeight;
    }
    
    public void NotifyDanger()
    {
        Console.WriteLine($"Container {IdNumber} has hazardous cargo!");
    }

    public override string ToString()
    {
        return base.ToString() +
               $", isHazardous = {IsHazardous}";
    }
}