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
    /// Логика взаимодействия для Zak_Page3.xaml
    /// </summary>
    public partial class Zak_Page3 : Page
    {
        double Summa = 0;
        int click = 0;
        Kassa kassa;
        int numtick;
        bool checkskidka;
        public Zak_Page3(Kassa kassa, int numtick, bool checkskidka)
        {
            
            
                this.kassa = kassa;
                this.numtick =numtick;
                this.checkskidka = checkskidka;
            
            InitializeComponent();
        }
        public void InformTicket()
        {
            
            Ticket ticket = kassa.ChangeInformTicket(numtick, checkskidka);
            if (checkskidka)
            textblock.Text += ("Действует скидка на этот билет!");
            textblock.Text += (ticket.type + '\n' + ticket.vip + '\n' + "Цена " + ticket.cena + " Рублей" + '\n' + "Наличие " + kassa.ColvoOfTicket[numtick] + " штук" + '\n');
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (click==0)
            {
                click++;
                try
                {
                    int buycolvo = 0;
                    buycolvo = int.Parse(textbox.Text);
                    buycolvo = kassa.AvailabilityOfTickets(numtick, buycolvo);
                    if (buycolvo <= 0)
                    {
                        click--;         
                    }
                    else
                    {
                        kassa.ListBuyTickets = new List<Ticket>();
                        kassa.Ticket_Details(numtick, buycolvo, checkskidka);
                        textbox.Text = "";
                        Summa = kassa.Summa(numtick, buycolvo, checkskidka);
                        textblock.Text = "Итоговая сумма: " + Summa + " Р";
                        Button.Content = "Купить";
                        label.Content = "Введите номер карты";
                    }
                    
                }
                catch
                {
                    click--;
                }
            } else

            if (click > 0)
            {
                if (textbox.Text.Length > 0)
                {
                    string NumberCart = textbox.Text;
                    kassa.BuyTickets(NumberCart, Summa);
                    textbox.Visibility = Visibility.Hidden;
                    textblock.Text = "Покупка совершена!";
                    Button.Visibility = Visibility.Hidden;
                    label.Content = "";
                }
                else
                {
                    click = 0;
                }
                
            }

        }
    }
}
