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
using System.Windows.Shapes;
using Zoo_logic;

namespace Zoo_WPF
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
        public Kassa kassa;
        int click = 0;
        int numberticket = 0;
        public Zakaz()
        {
            InitializeComponent();
        }

        private void Button_Vzr_Click(object sender, RoutedEventArgs e)
        {
            click++;
            if (click == 1)
            {
                MyFrame.Content = new Zak_Page2();
                
            }

            else
            {
                
                Button_Det.Visibility = Visibility.Hidden;
                Button_Vzr.Visibility = Visibility.Hidden;
                Skidka skidka = new Skidka();
                bool CheckSkidka = false;
                CheckSkidka = skidka.CheckSale(numberticket, DateTime.Now.Minute % 10);
                Zak_Page3 zak_Page3 = new Zak_Page3(kassa, numberticket, CheckSkidka);
                zak_Page3.InformTicket();
                MyFrame.Content = zak_Page3;
            }

        }

        private void Button_Det_Click(object sender, RoutedEventArgs e)
        {
            click++;
            if (click == 1)
            {
                MyFrame.Content = new Zak_Page2();
                numberticket += 2;
            }
                
            else
            {
                numberticket++;
                Button_Det.Visibility = Visibility.Hidden;
                Button_Vzr.Visibility = Visibility.Hidden;
                Skidka skidka = new Skidka();
                bool CheckSkidka = false;
                CheckSkidka = skidka.CheckSale(numberticket, DateTime.Now.Minute % 10);
                Zak_Page3 zak_Page3 = new Zak_Page3(kassa, numberticket, CheckSkidka);
                zak_Page3.InformTicket();
                MyFrame.Content = zak_Page3;
            }
                
        }
    }
}
