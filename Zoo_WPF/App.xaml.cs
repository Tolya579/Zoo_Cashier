using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zoo_logic;
using Zoo_Rep;
using Zoo_UI;


namespace Zoo_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void Main_Start (object sender, StartupEventArgs e)
        {
            List<Animal> Animals = new List<Animal>();
            Repository repository = new Repository(e.Args);
            Kassa kassa = repository.ReadInfromOfTickets();
            kassa = repository.FullInformTickets(kassa);
            Animals = repository.ReadAnimals();
            Zoo zoo = new Zoo();
            zoo.animals = Animals;
            zoo.kassa = kassa;
            MainWindow mainWindow = new MainWindow(kassa, zoo);
            mainWindow.Show();
        }

    }
}
