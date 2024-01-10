using System;
using System.Collections.Generic;

namespace Zoo_logic
{
    public class Check
    {
        public void MakeCheck(List<Ticket> ListBuyTicket, List<string> ListDetails)
        {
            
            WritingCheckToFile(ListBuyTicket, ListDetails);
        }
        public List<object> EditingListInform(List<object> ListInform)
        {
            for (int i = 0; i < ListInform.Count - 2; i += 3)
            {
                for (int j = i + 3; j < ListInform.Count - 2; j += 3)
                {
                    Ticket ticket1= (Ticket) ListInform[i + 1];
                    Ticket ticket2= (Ticket) ListInform[j + 1];
                    if (((int)ListInform[i] == (int)ListInform[j]) && (ticket1.cena==ticket2.cena))
                    {
                        ListInform.RemoveAt(j);
                        ListInform[i + 2] = (int)ListInform[i + 2] + (int)ListInform[j + 1];
                        ListInform.RemoveAt(j);
                        ListInform.RemoveAt(j);
                    }

                }
            } // Очищает несколько заказов одиннаковых билетов
            return ListInform;
        }
        public void WritingCheckToFile(List<Ticket> ListInform, List<string> ListDetails)
        {
            Skidka skidka = new Skidka();
            System.IO.File.WriteAllText(@"CHECK.txt", "         ЗООПАРК" + Environment.NewLine);
            for (int i=0; i < ListInform.Count; i++)
            {
                int colvo = 1;
                for (int j = i+1; j < ListInform.Count; j++)
                {
                    if ((ListInform[i].type==ListInform[j].type)&&(ListInform[i].cena == ListInform[j].cena))
                    {
                        ListInform.RemoveAt(j);
                        j--;
                        colvo++;
                    }
                }
                System.IO.File.AppendAllText(@"CHECK.txt", (ListInform[i].type + "......" + ListInform[i].vip + "......" + ListInform[i].cena + "Р" + "......"));
                System.IO.File.AppendAllText(@"CHECK.txt", "X" + colvo + '\n');
            }
            System.IO.File.AppendAllText(@"CHECK.txt", "Номер банковской карты: " + ListDetails[0] + Environment.NewLine);
            System.IO.File.AppendAllText(@"CHECK.txt", "Итоговая сумма: " + ListDetails[1] + "Р");
           
        }
    }
}

