namespace APBD_LAB3.Models;

public abstract class Container
{
        public string IdNumber { get; set; }
        protected double MaxWeight { get; private set; }
        public double CurrentWeight { get; set; }
        protected double EmptyWeight { get; private set; }
        protected double Height { get; private set; }
        protected double Depth { get; private set; }
        protected static int Counter = 0;
        
        public Container(double maxWeight, double emptyWeight, double height, double depth)
        {
                MaxWeight = maxWeight;
                EmptyWeight = emptyWeight;
                Height = height;
                Depth = depth;
                CurrentWeight = EmptyWeight;
                Counter++;
                IdNumber = "KON";
        }

        public abstract void LoadCargo(double weight);
        public abstract void UnloadCargo();
        public override string ToString()
        {
                return $"Container: " +
                       $"IdNumber =  {IdNumber}" +
                       $", maxWeight = {MaxWeight}" +
                       $", currentWeight = {CurrentWeight}" +
                       $", emptyWeight = {EmptyWeight}" +
                       $", height = {Height}" +
                       $", depth = {Depth}";
        }
}

