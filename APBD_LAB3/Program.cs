using APBD_LAB3;
using APBD_LAB3.Exeption;
using APBD_LAB3.Models;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.StartMenu();
        
        Console.WriteLine("---------Ships and containers before load cargo: ------");
        Ship ship = new Ship("1", 50000, 10, 20);
        LiquidContainer liquidContainer = new LiquidContainer(20000, 1000, 1000, 5, true);
        GasContainer gasContainer = new GasContainer( 8000, 1000, 1000, 10, 3);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer( 12000, 700, 1200, 4, "Banana", 13.3);
        
        
        try
        {
            gasContainer.LoadCargo(7000);
            Console.WriteLine(gasContainer.ToString());
            gasContainer.UnloadCargo();
            Console.WriteLine(gasContainer.ToString());
            
            
            
            liquidContainer.LoadCargo(11000);
            Console.WriteLine(liquidContainer.ToString());
            
            liquidContainer.UnloadCargo();
            Console.WriteLine(liquidContainer.ToString());
            
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(refrigeratedContainer);
        Console.WriteLine(ship.ToString());
        
        ship.UnloadContainer(liquidContainer);
        Console.WriteLine(ship.ToString());

        ship.ReplaceContainer("KON-L-1", gasContainer);
        Console.WriteLine(ship.ToString());
    }
}
