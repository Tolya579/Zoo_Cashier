using System;
using Xunit;
using Zoo_logic;
using System.Collections.Generic;
namespace Zoo_Tests
{
    public class ZooTests
    {
        
        public static IEnumerable<object[]> AgeHeightWeightData()
        {
            yield return new object[] { 0, 2, true };
            yield return new object[] { 1, 4, true };
            yield return new object[] { 2, 6, true };
            yield return new object[] { 3, 8, true };
        }

        [Theory]
        [MemberData("AgeHeightWeightData")]
        public void CheckSkidka (int num, int minute, bool expected)
        {
            Skidka skidka = new Skidka();
            bool actual = skidka.CheckSale(num, minute);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Num_CheckSkidka_False()
        {
            // arange
            int num = 1;
            int minute = 3;
            bool expected = false;
            //act
            Skidka skidka = new Skidka();
            bool actual = skidka.CheckSale(num, minute);
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HaveTicket()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ColvoOfTicket.Add("7");
            int NumTick = 0;
            int Colvo = 5;
            int expected = 5;
            //act

            int actual = kassa.AvailabilityOfTickets(NumTick, Colvo);
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NoTickets()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ColvoOfTicket.Add("7");
            int NumTick = 0;
            int Colvo = 8;
            int expected = 0;
            //act
            int actual = kassa.AvailabilityOfTickets(NumTick, Colvo);
            //assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void EditingList()
        {
            Ticket ticket1 = new Ticket("", 200, "");
            Ticket ticket2 = new Ticket("", 100, "");
            // arange
            List<object> List = new List<object>() { 0, ticket1, 3, 0, ticket1, 7, 0, ticket2, 3, 1, ticket2, 3, 1, ticket2, 4, "numbercart", "summa" };
            List<object> expected = new List<object>() { 0, ticket1, 10, 0, ticket2, 3, 1, ticket2, 7, "numbercart", "summa" };
            //act
            Check check = new Check();
            List<object> actual = check.EditingListInform(List);
            //assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void AddListInform()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ListBuyTickets = new List<Ticket>();
            string numbercart = "523325235";
            double summa = 2000;
            List<string> expected = new List<string>() { "523325235", "2000" };
            //act
            kassa.BuyTickets(numbercart, summa);
            //assert
            Assert.Equal(expected, kassa.DetailsForCheck);
        }
        
        [Fact]
        public void AddListMainInform()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ListBuyTickets = new List<Ticket>();
            kassa.ColvoOfTicket = new List<string>() {"8"};
            kassa.ColvoOfTicket.Add ("8");
            Ticket ticket1 = new Ticket("", 200, "");
            Ticket ticket2 = new Ticket("", 100, "");
            kassa.tickets.Add(ticket1);
            int numtick = 0;
            int colvo = 5;
            List<object> expected = new List<object>() { 0, ticket2, 5 };
            //act
            kassa.Ticket_Details(numtick, colvo, true);
            //assert
            expected.Equals(kassa.ListBuyTickets);
        }
        
        [Fact]
        public void ChangeColvoTicket()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ListBuyTickets = new List<Ticket>();
            kassa.ColvoOfTicket = new List<string>();
            kassa.ColvoOfTicket.Add("8");
            Ticket ticket1 = new Ticket("", 200, "");
            kassa.tickets.Add(ticket1);
            int numtick = 0;
            int colvo = 5;
            string expected = "3";
            //act
            kassa.Ticket_Details(numtick, colvo, true);
            //assert
            Assert.Equal(expected, kassa.ColvoOfTicket[0]);
        }
        
        [Fact]
        public void CheckFullSumma()
        {
            // arange
            Ticket ticket = new Ticket("",200,"");
            Kassa kassa = new Kassa();
            int numtick = 0;
            kassa.tickets = new List<Ticket>();
            kassa.tickets.Add(ticket);
            bool CheckSkidka = true;
            int Colvo = 10;
            double expected = 1000;
            //act
            double actual=kassa.Summa(numtick, Colvo, CheckSkidka);
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ChangeInformTicket()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ListBuyTickets = new List<Ticket>();
            Ticket ticket1 = new Ticket("", 200, "");
            Ticket expected = new Ticket("", 100, "");
            kassa.tickets.Add(ticket1);
            int numtick = 0;
            //act
            Ticket ticket_actual=kassa.ChangeInformTicket(numtick, true);
            //assert
            expected.Equals(ticket_actual);
        }
        [Fact]
        public void FillingKorzina()
        {
            // arange
            Kassa kassa = new Kassa();
            kassa.ListBuyTickets = new List<Ticket>();
            Ticket ticket1 = new Ticket("", 200, "");
            int colvo = 3;
            List<object> expected = new List<object> () { ticket1, ticket1, ticket1 };
            //act
            kassa.Korzina(ticket1, colvo);
            //assert
            expected.Equals(kassa.ListBuyTickets);
        }

        
    }
}
