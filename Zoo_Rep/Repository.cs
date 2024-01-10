using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zoo_logic;

namespace Zoo_Rep
{
    public class Repository 
    {
        public string[] Args { get; }
        public Repository(string[] args)
        {
            Args = args;
        }

        public List<Animal> ReadAnimals()
        {
            List<Animal> animals = new List<Animal>();
            List<string> Animals = File.ReadAllLines(Args[1]).ToList();
            for (int i=0; i<Animals.Count; i+=2)
            {
                Animal animal = new Animal();
                animal.Name = Animals[i];
                animal.About = Animals[i+1];
                animals.Add(animal);
            }
            return animals;
            throw new System.NotImplementedException();
        }

        public List<Ticket> ReadTickets()
        {
            
            List<Ticket> tickets = new List<Ticket>();
            List<string> Tickets = File.ReadAllLines(Args[2]).ToList();
            for (int i = 0; i < Tickets.Count; i+=4)
            {
                Ticket ticket = new Ticket(Tickets[i], int.Parse(Tickets[i + 1]), Tickets[i + 2]);
                tickets.Add(ticket);

            }
            return tickets;
            throw new System.NotImplementedException();
        }

        public Kassa ReadInfromOfTickets()
        {
            Kassa kassa = new Kassa();
            List<string> Tickets = File.ReadAllLines(Args[2]).ToList();
            for (int i = 1; i <= Tickets.Count / 4; i++)
            {
                kassa.ColvoOfTicket.Add(Tickets[i * 4 - 1]);
            }
            kassa.SaveColvoOfTicket=kassa.ColvoOfTicket.ToList();
            return kassa;
            throw new System.NotImplementedException();
        }
        public Kassa FullInformTickets(Kassa kassa)
        {
            List<Ticket> tickets = new List<Ticket>();
            tickets = ReadTickets();
            kassa.tickets=tickets.ToList();
            return kassa;
        }
    }
}