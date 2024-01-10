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
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public Zoo Zoo;
        public SecondWindow()
        {
            InitializeComponent();   
        }
        public void Clear()
        {
            textblock.Text = "";
        }
        public void InformAnimal()
        {
            
            foreach (Animal animal in Zoo.animals)
            {

                textblock.Text += ("Животное - " + animal.Name + '\n' + "Информация - " + animal.About + '\n' + '\n');
            }
        }

        public void InformTicket(Kassa kassa, int numtick, bool checkskidka)
        {
            
            Ticket ticket = kassa.ChangeInformTicket(numtick, checkskidka);
            if (checkskidka)
                textblock.Text += ("Действует скидка на этот билет!");
            textblock.Text += (ticket.type + '\n' + ticket.vip + '\n' + "Цена " + ticket.cena + " Рублей" + '\n' + "Наличие " + kassa.ColvoOfTicket[numtick] + " штук" + '\n');
        }

    }
}
