using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo_logic;

namespace Zoo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Kassa kassa;
        public Zoo Zoo;
        public MainWindow(Kassa kassa, Zoo zoo)
        {
            this.kassa = kassa;
            this.Zoo = zoo;
            InitializeComponent();
        }

        private void Button_Info_Ani_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow SecWindow = new SecondWindow();
            SecWindow.Clear();
            SecWindow.Zoo = Zoo;
            SecWindow.InformAnimal();
            SecWindow.Show();
        }

        private void Button_Info_Tick_Click(object sender, RoutedEventArgs e)
        {

            SecondWindow SecWindow = new SecondWindow();
            SecWindow.Clear();
            Skidka skidka = new Skidka();
            bool CheckSkidka = false;
            for (int i = 0; i < kassa.tickets.Count; i++)
            {
                CheckSkidka = skidka.CheckSale(i, DateTime.Now.Minute % 10);
                SecWindow.InformTicket(kassa, i, CheckSkidka);
            }
            SecWindow.Show();  
        }
        private void Button_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            Zakaz WinZak = new Zakaz();
            WinZak.kassa = kassa;
            WinZak.Show();
        }
    }
}
