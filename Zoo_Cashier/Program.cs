using System.IO;
using System.Text;
using System.Threading.Tasks;
using Zoo_logic;
using Zoo_Rep;
using Zoo_UI;
using System.Collections.Generic;
using System.Windows;
namespace CLASSIS
{
    public class Program 
    {
        
        static void Main(string[] args)
        {
            List<Animal> Animals = new List<Animal>();
            Repository repository = new Repository(args);
            UserInterface UI = new UserInterface();
            Kassa kassa = repository.ReadInfromOfTickets();
            kassa = repository.FullInformTickets(kassa);
            Animals = repository.ReadAnimals();
            Zoo zoo = new Zoo();
            zoo.animals = Animals;
            zoo.kassa = kassa;
            
            UI.Start(kassa);
        }
    }
}