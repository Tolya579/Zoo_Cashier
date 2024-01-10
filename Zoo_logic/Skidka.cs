using System;

namespace Zoo_logic
{
    public class Skidka
    {
        public bool CheckSale(int NumberTicket, int minute)
        {
            int i=-1;
            switch (minute)
            {
                    case 2:
                    i = 0;
                    break;
                    case 4:
                    i = 1;
                    break;
                    case 6:
                    i = 2;
                    break;
                    case 8:
                    i = 3;
                    break;
            }
            if (i==NumberTicket)
                return true;
            else
                return false;
        }  
            
    }
}

