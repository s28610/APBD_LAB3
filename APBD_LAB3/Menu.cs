using APBD_LAB3.Exeption;
using APBD_LAB3.Models;

namespace APBD_LAB3;

public class Menu
{
    List<Ship> ships;
    List<Container> containers;

    public Menu()
    {
        ships = new List<Ship>();
        containers = new List<Container>();
    }

    public void StartMenu()
    {
        Console.WriteLine("\n\n----------------Hello! --------------\n\n");
        while (true)
        {
            Console.WriteLine("Lista kontenerowców:");
            if (ships.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var ship in ships)
                {
                    Console.WriteLine(ship.ToString());
                }
            }
            
            Console.WriteLine("Lista kontenerów:");
            if (containers.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var container in containers)
                {
                    Console.WriteLine(container.ToString());
                }
            }

            Console.WriteLine("\n\nMożliwe akcje:" +
                              "\n1. Dodaj kontenerowiec" +
                              "\n2. Usun kontenerowiec" +
                              "\n3. Dodaj kontener" +
                              "\n4. Usun kontener" +
                              "\n5. Załaduj kontener na statek" +
                              "\n6. Usun kontener ze statku" + 
                              "\n7. Zastąpij kontener na statku innym kontenerem" +
                              "\n8. Załaduj ładunek do kontenera" + 
                              "\n9. Rozładuj kontener" + 
                              "\n0. Wyjscie z programu");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateShip();
                    break;
                case "2":
                    DeleteShip();
                    break;
                case "3":
                    CreateContainer();
                    break;
                case "4":
                    DeleteContainer();
                    break;
                case "5":
                    LoadContainerToShip();
                    break;
                case "6":
                    UnLoadContainerToShip();
                    break;
                case "7":
                    ReplaceContainer();
                    break;
                case "8":
                    LoadCargo();
                    break;
                case "9":
                    UnLoadCargo();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }
        }
    }

    void CreateShip()
    {
        Console.WriteLine("Please enter the following information about ship you want to create" +
                          "\nname : ");
        string name = Console.ReadLine();
        Console.WriteLine("max weight: ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("max speed: ");
        double maxSpeed = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("number of containers: ");
        int munOfContainers = Convert.ToInt32(Console.ReadLine());
        
        ships.Add(new Ship(name, maxWeight, maxSpeed, munOfContainers));
    }

    void DeleteShip()
    {
        Console.WriteLine("Please enter the following information about ship you want to delete" +
                          "\nname : ");
        string name = Console.ReadLine();
        var ship = ships.Find(c => c.Name == name);
        ships.Remove(ship);
    }

    void CreateContainer()
    {
        Console.WriteLine("Please enter the following information about container you want to create" +
                          "\ntypes of containers : " +
                          "\n1. liquid" +
                          "\n2. gas" +
                          "\n3. refrigerated");
        string choice = Console.ReadLine();
        Console.WriteLine("max Weight: ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("empty Weight: ");
        double emptyWeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("height: ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("depth: ");                
        double depth = Convert.ToDouble(Console.ReadLine());
        switch (choice)
        {
            case "1":
                containers.Add(new LiquidContainer(maxWeight, emptyWeight, height, depth, true));
                break;
            case "2":
                Console.WriteLine("pressure: ");                
                double pressure = Convert.ToDouble(Console.ReadLine());
                containers.Add(new GasContainer(maxWeight, emptyWeight, height, depth, pressure));
                break;
            case "3":
                Console.WriteLine("type of product: ");                
                string typeOfProd = Console.ReadLine();
                Console.WriteLine("temperature: ");                
                double temperature = Convert.ToDouble(Console.ReadLine());
                containers.Add(new RefrigeratedContainer(maxWeight, emptyWeight, height, depth, typeOfProd, temperature));
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
    }

    void DeleteContainer()
    {
        Console.WriteLine("Please enter the following information about container you want to delete" +
                          "\nname : ");
        string name = Console.ReadLine();
        var container = containers.Find(c => c.IdNumber == name);
        containers.Remove(container);
    }

    void LoadContainerToShip()
    {
        Console.WriteLine("Please choose from the list above name of the ship: ");
        string nameShip = Console.ReadLine();
        Console.WriteLine("Please choose from the list above ID number of the container: ");
        string nameContainer = Console.ReadLine();

        try
        {
            ships.Find(s => s.Name == nameShip)
                .LoadContainer(containers.Find(c => c.IdNumber == nameContainer));
            containers.Remove(containers.Find(c => c.IdNumber == nameContainer));
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);

        }
        
    }
    void UnLoadContainerToShip()
    {
        Console.WriteLine("Please choose from the list above name of the ship: ");
        string nameShip = Console.ReadLine();
        Console.WriteLine("Please choose from the list above ID number of the container: ");
        string nameContainer = Console.ReadLine();
        
        ships.Find(s => s.Name == nameShip)
            .UnloadContainer(containers.Find(c => c.IdNumber == nameContainer));
        containers.Add(containers.Find(c => c.IdNumber == nameContainer));

    }

    void ReplaceContainer()
    {
        Console.WriteLine("Please choose from the list above name of the ship where you want containers be replaced: ");
        string nameShip = Console.ReadLine();
        Console.WriteLine("Please choose from the list above ID number of the container you want to be replaced: ");
        string nameOldContainer = Console.ReadLine();
        Console.WriteLine("Please choose from the list above ID number of the container you want to add: ");
        string nameNewContainer = Console.ReadLine();

        try
        {
            ships.Find(s => s.Name == nameShip)
                .ReplaceContainer(nameOldContainer, containers.Find(c => c.IdNumber == nameNewContainer));
            containers.Add(containers.Find(c => c.IdNumber == nameOldContainer));
            containers.Remove(containers.Find(c => c.IdNumber == nameNewContainer));
        } catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);

        }
    }

    void LoadCargo()
    {
        Console.WriteLine("Please enter name of the container");
        string nameContainer = Console.ReadLine();
        Console.WriteLine("Weight of cargo: ");
        double weight = Convert.ToDouble(Console.ReadLine());

        try
        {
            containers.Find(c => c.IdNumber == nameContainer).LoadCargo(weight);

        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    void UnLoadCargo()
    {
        Console.WriteLine("Please enter name of the container");
        string nameContainer = Console.ReadLine();
        containers.Find(c => c.IdNumber == nameContainer).UnloadCargo();

    }


}