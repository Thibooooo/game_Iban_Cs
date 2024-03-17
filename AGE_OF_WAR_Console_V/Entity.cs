using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE_OF_WAR_Console_V
{
    internal class Entity
    {
        string name;
        public int Current_Position;
        public int Current_Health;
        public int Total_Health;
        public int Damage;
        public int Speed;
        public int SpeedAttack;
        public int Cost;

        public Entity(string name)
        {
            this.name = name;
            
        }


        public void Affichage_Entity()
        {
            string to_print = " ";
            if (this.name == "Empty")
            {
                Console.Write("__");
            }

            
            

            else if (this.name == "Caveman_classic")
            {
                //Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\u25CF ");
                
            }
            else if (this.name == "Home")
            {
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.Write("\u2588");
                //Console.Write("\u2656");
                Console.Write("\u265C ");

                //Console.ResetColor();

            }
            else if (name == "Caveman_tank")
            {
                //Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\u2660 ");
                //Console.ResetColor(); 
            }
            else if (name == "Caveman_distance")
            {
                
                //Console.ForegroundColor= ConsoleColor.Gray;
                Console.Write("\u25B2 "); 
                //Console.ResetColor();
            }
            else if (name == "Healer")
            {
                Console.Write("\u25B3 ");
            }
            else
            {
                //Console.Write("ERROR");
                Console.Write("💯");
                //Console.Write("🔟");
                Console.Write("⑪");
                //https://symbl.cc/fr/246B/
            }

            //Console.ResetColor();
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set { this.name = value; }
        }


        

    }
}
