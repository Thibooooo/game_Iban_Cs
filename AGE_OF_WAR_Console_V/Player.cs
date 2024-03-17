using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE_OF_WAR_Console_V
{
    internal class Player
    {
        int money;
        string name;
        int pre_defined_number; //1 ou 2
        int nb_pts;
        List<Entity> Mob_Spawn;
        public Player(string name, int money, int pre_defined_number)
        {
            this.name = name;
            this.money = money;
            this.pre_defined_number = pre_defined_number;
            this.nb_pts = 0;
            this.Mob_Spawn = new List<Entity>();
            
        }
        
        public void RemoveMobSpawn(Entity entity)
        {
            Mob_Spawn.Remove(entity);
        }
        


        public void AddMobSpawn(Entity entity)
        {
            Mob_Spawn.Add(entity);
        }
        public static void DisplayPlayerInfo(Player player1, Player player2)
        {
            Console.WriteLine("Name: " + player1.Name + "\t\t\t\t\t\t\t\tName: " + player2.Name);
            Console.WriteLine("Money: " + player1.money + "\t\t\t\t\t\t\t\tMoney: " + player2.money);
            Console.WriteLine("Points: " + player2.Points + "\t\t\t\t\t\t\t\tPoints: " + player2.Points);
        }
        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }

        public int Money
        {
            get
            {
                return money;
            }
            set { money = value; }
        }

        public int Number
        {
            get
            {
                return pre_defined_number;
            }
            set { pre_defined_number = value; }
        }
        public int Points
        {
            get
            {
                return nb_pts;
            }
            set { nb_pts = value; }
        }
        public List<Entity> Mob_spawn
        {
            get
            {
                return this.Mob_Spawn;
            }
            set
            {
                this.Mob_Spawn = value;
            }
        }

    }
}
