using System;
using System.Collections.Generic;

namespace Zoo_logic
{
    public class Kassa
    {
        public List <string> DetailsForCheck;
        public List <Ticket> ListBuyTickets;
        public List <string> SaveColvoOfTicket = new List <string>();
        public List <string> ColvoOfTicket = new List<string>();
        public List <Ticket> tickets = new List<Ticket>(); 
        public double FullSumma;
        public void Ticket_Details (int NumTick, int Colvo, bool CheckSkidka)
        {
            Ticket ticket = ChangeInformTicket(NumTick, CheckSkidka);
            ColvoOfTicket[NumTick] = (int.Parse(ColvoOfTicket[NumTick]) - Colvo).ToString();
            Korzina(ticket, Colvo);
        }
        public void Korzina (Ticket ticket, int Colvo)
        {
            for (int i = 0; i < Colvo; i++)
            {
                ListBuyTickets.Add(ticket);
            }
        }
        public Ticket ChangeInformTicket (int numtick, bool CheckSkidka)
        {
            Ticket ticket;
            ticket = new Ticket(tickets[numtick].type, tickets[numtick].cena, tickets[numtick].vip);
            if (CheckSkidka)
            {
                ticket.cena -= 100;
            }
            return ticket;
        }

        public void BuyTickets(string NumberCart, double Summa)
        {
            DetailsForCheck = new List<string>();
            DetailsForCheck.Add(NumberCart);
            DetailsForCheck.Add(Summa.ToString());
            Check check = new Check();
            check.MakeCheck(ListBuyTickets, DetailsForCheck);

        }
        public int AvailabilityOfTickets(int i, int colvo)
        {
            if (int.Parse(ColvoOfTicket[i]) < colvo)
                return 0;
            else
                return colvo;

        }
        public double Summa(int NumTick, int buycolvo, bool CheckSkidka)
        {
            int cena = tickets[NumTick].cena; 
            if (CheckSkidka == true)
            cena -= 100;
            FullSumma = cena * buycolvo;
            return FullSumma;
        }

    }
}

