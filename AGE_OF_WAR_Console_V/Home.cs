using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE_OF_WAR_Console_V
{
    internal class Home : Entity
    {
        public int Current_Health;
        public int Total_Health;
        public int SpeedAttack;
        public bool end_game;
        
        public Home(int Current_Health, int Total_Health, int SpeedAttack) : base("Home")
        {
            this.Current_Health = Current_Health;
            this.Total_Health = Total_Health;
            this.SpeedAttack = SpeedAttack;
            this.end_game = false;
            
        }


    }
}
