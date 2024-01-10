using System;
using System.Collections.Generic;
using Zoo_logic;
namespace Zoo_UI
{
    public class UserInterface 
    {
        public Zoo Zoo;
        public void Start(Kassa kassa)
        {
            string UserChoice = "";
            while (UserChoice != "3")
            {
                Skidka skidka = new Skidka();
                bool CheckSkidka = false;
                string Back = "";
                ShowMenu();
                UserChoice = ChooseMode();
                switch (UserChoice)
                {
                    case "0":
                        while (Back != "1")
                        {
                            ClearMode();

                            ShowAnimals(Zoo.animals);
                            Back = ChooseMode();
                        }
                        break;
                    case "1":
                        while (Back != "1")
                        {
                            ClearMode();
                            for (int i = 0; i < kassa.tickets.Count; i++)
                            {
                                CheckSkidka = skidka.CheckSale(i, DateTime.Now.Minute % 10);
                                ShowTickets(kassa, i, CheckSkidka);
                            }
                            Back = ChooseMode();
                        }
                        break;
                    case "2":
                        kassa.ListBuyTickets = new List<Ticket>();  // Запись данных о каждом рассматриваемом к пакупке билете 
                        double FullSumma = 0;
                        bool CheckBuy = false;


                        for (; ; )  // Симуляция корзины билетов рассматриваемых к пакупке 
                        {

                            int colvo = 0;
                            int i = 0, NumTick = 0;
                            string choice = "";
                            while ((choice != "1") && (choice != "2") && (choice != "3"))
                            {
                                choice = GetСhoiceVzrOrDet(out i);
                            }
                            if (choice == "3") break; choice = "";
                            NumTick += i;
                            while ((choice != "1") && (choice != "2") && (choice != "3"))
                            {
                                choice = GetСhoiceVipOrNo(out i);
                            }
                            if (choice == "3") break;
                            NumTick += i;
                            while (colvo <= 0)
                            {
                                Console.Clear();
                                CheckSkidka = skidka.CheckSale(NumTick, DateTime.Now.Minute % 10);
                                ShowTickets(kassa, NumTick, CheckSkidka);
                                colvo = GetTicketsAmount();
                                colvo = kassa.AvailabilityOfTickets(NumTick, colvo);
                            }
                            CheckSkidka = skidka.CheckSale(NumTick, DateTime.Now.Minute % 10);
                            FullSumma += kassa.Summa(NumTick, colvo, CheckSkidka);
                            string ChoiceBuy = GetChoiceBuyOrNo(FullSumma);
                            if (ChoiceBuy == "1")
                            {
                                CheckBuy = true;
                                string NumberCart = GetCardType();
                                kassa.Ticket_Details(NumTick, colvo, CheckSkidka);
                                kassa.BuyTickets(NumberCart, FullSumma);
                                break;
                            }
                            else
                            if (ChoiceBuy == "2")
                            {
                                kassa.Ticket_Details(NumTick, colvo, CheckSkidka);
                            }
                            else

                            if (ChoiceBuy == "3")
                            {
                                break;
                            }
                        }
                        if (CheckBuy == false)
                            kassa.ColvoOfTicket = kassa.SaveColvoOfTicket;
                        else
                            kassa.SaveColvoOfTicket = kassa.ColvoOfTicket;
                        break;
                }
            }
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "ИНФОРМАЦИЯ О ЖИВОТНЫХ - 0"+"\n"+
                "ИНФОРМАЦИЯ О БИЛЕТАХ - 1" + "\n" +
                "ЗАКАЗАТЬ БИЛЕТЫ - 2" + "\n" +
                "ВЫХОД ИЗ ПРОГРАММЫ - 3" + "\n"
                            );
        }
        public void ShowAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                Console.WriteLine(@"Животное - {0}, Информация: {1} {2}",animal.Name, '\n', animal.About);
            }
        }

        public void ShowTickets(Kassa kassa, int numtick, bool checkskidka)
        {
                Ticket ticket = kassa.ChangeInformTicket(numtick, checkskidka);
            if (checkskidka)
                Console.WriteLine("Действует скидка на этот билет!");
                Console.WriteLine(ticket.type + '\n' + ticket.vip + '\n' + "Цена " + ticket.cena + " Рублей" + '\n' + "Наличие " + kassa.ColvoOfTicket[numtick] + " штук" + '\n');
        }

        public void ClearMode()
        {
            Console.Clear();
            Console.WriteLine("Вернуться назад - 1" + '\n');
        }

        public string ChooseMode()
        {
            return Console.ReadLine();
            throw new NotImplementedException();
        }

        public string GetCardType()
        {
            Console.WriteLine("Введите номер карты");
            return Console.ReadLine();
            throw new NotImplementedException();
        }

        public int GetTicketsAmount()
        {

            Console.WriteLine("Сколько билетов вам нужно?");
            bool flag = true;
            int buycolvo = 0; try { buycolvo = int.Parse(Console.ReadLine()); } catch { flag = false; }
            if ((flag == true) && (buycolvo > 0))
            {
                return buycolvo;
            }
            else
                return 0;
            throw new NotImplementedException();
        }

        public string GetСhoiceVzrOrDet(out int NumTic)
        {
            NumTic = 0;
            Console.Clear();
            Console.WriteLine("Какой билет вам нужен?");
            Console.WriteLine("Взрослый - 1");
            Console.WriteLine("Детский - 2");
            Console.WriteLine("Вернуться в меню - 3");
            string choice = Console.ReadLine();
            if (choice == "2")
                NumTic += 2;
            return choice;
        }
        public string GetСhoiceVipOrNo(out int NumTick)
        {
            NumTick = 0;
            Console.Clear();
            Console.WriteLine("Нужен ли проход без очередей?");
            Console.WriteLine("Да - 1");
            Console.WriteLine("Нет - 2");
            Console.WriteLine("Вернуться в меню - 3");
            string choice = Console.ReadLine();
            if (choice == "2")
                NumTick += 1;
            return choice;
        }
        public string GetChoiceBuyOrNo (double FullSumma)
        {
            Console.Clear();
            Console.WriteLine("Итоговая сумма - " + FullSumma);
            Console.WriteLine("");
            Console.WriteLine("Готовы сделать заказ?");
            Console.WriteLine("Да - 1");
            Console.WriteLine("Нет, добавлю еще - 2");
            Console.WriteLine("Выход в меню - 3");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}

