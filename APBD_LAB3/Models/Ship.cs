using APBD_LAB3.Exeption;

namespace APBD_LAB3.Models;

public class Ship
{
    public string Name { get; private set; }
    protected double MaxWeight { get; private set; }
    protected double CurrentOverallWeight { get; private set; }

    protected double MaxSpeed { get; private set; }
    protected int MaxNumOfContainers { get; private set; }

    private List<Container> Containers = new List<Container>();

    public Ship(string name, double maxWeight, double maxSpeed, int maxNumOfContainers)
    {
        Name = name;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        MaxNumOfContainers = maxNumOfContainers;
        CurrentOverallWeight = 0;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count + 1 > MaxNumOfContainers)
            throw new OverfillException("Cannot load more containers. Maximum capacity reached.");
        if (CurrentOverallWeight + container.CurrentWeight > MaxWeight)
            throw new OverfillException("Cannot load more containers. Maximum weight reached.");
        Containers.Add(container);
        CurrentOverallWeight += container.CurrentWeight;
    }

    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
        CurrentOverallWeight -= container.CurrentWeight;
    }

    public void ReplaceContainer(string oldContainerNumber, Container newContainer)
    {
        var oldContainer = Containers.Find(c => c.IdNumber == oldContainerNumber);
        if (oldContainer != null)
        {
            UnloadContainer(oldContainer);
            LoadContainer(newContainer);
        }
    }

    public string printContainers()
    {
        string containersInfo = "";
        Containers.ForEach(c => containersInfo += "\n\t" + c.ToString());
        return containersInfo;
    }

    public override string ToString()
    {
        return "Ship: " +
               $"name = {Name}" +
               $", maxWeight = {MaxWeight}" +
               $", currentWeight = {CurrentOverallWeight}" +
               $", maxSpeed = {MaxSpeed}" +
               $", maxNumOfContainers = {MaxNumOfContainers}" +
               ", containers : {" + printContainers() +
               "\n}";
}
}