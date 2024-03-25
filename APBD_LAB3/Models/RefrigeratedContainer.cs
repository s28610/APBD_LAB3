using APBD_LAB3.Exeption;

namespace APBD_LAB3.Models;

public class RefrigeratedContainer : Container
{
    protected string TypeOfProduct { get; private set; }
    protected double Temperature { get; private set; }   
    
    public RefrigeratedContainer(double maxWeight, double emptyWeight, double height, double depth, string typeOfProduct, double temperature)
        : base(maxWeight, emptyWeight, height, depth)
    {
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
        IdNumber += "-C-" + Counter;
    }
    
    public override void LoadCargo(double weight)
    {
        if (weight + CurrentWeight > MaxWeight)
        {
            throw new OverfillException("Cargo weight exceeds container capacity.");
        }
        else
        {
            CurrentWeight += weight;
        }    
    }
    
    public override void UnloadCargo()
    {
        CurrentWeight = EmptyWeight;
    }

    public override string ToString()
    {
        return base.ToString() +
               $", typeofProduct = {TypeOfProduct}" +
               $", temperature = {Temperature}";
    }
}