using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE_OF_WAR_Console_V
{
    internal class Map
    {
        private int size;
        Entity[] carte;
        Home Base1;
        Home Base2;
        Entity Empty;
        public Home[] list_home;
        public Map(int size)
        {
            this.size = size;
            carte = new Entity[size];
            Base1 = new Home(50,50, 1);
            
            Base2 = new Home(50, 50, 1);
            
            Empty = new Entity("Empty");
            this.list_home = new Home[2] {Base1, Base2};


        }

        public void SpawnMob(Entity entite_quelquonque, int location, Player player)
        {
            if ((location < this.Size) && (location > 0))
            {
                this.carte[location] = entite_quelquonque;
                player.AddMobSpawn(entite_quelquonque);
            }
            else
            {
                Console.WriteLine("Error Location");
            }
        }
        
        public void DispawnMob(Mob entite_quelquonque,Player joueur)
        {
            //Console.WriteLine("Current position : " + entite_quelquonque.Current_Position);
            this.carte[entite_quelquonque.Current_Position] = Empty;
            joueur.RemoveMobSpawn(entite_quelquonque);            
        }

        public void Beginning_fulfil_map()
        {
            for (int i = 0; i < size; i++)
            {
                this.carte[i] = Empty;
            }
            this.carte[0] = Base1;
            this.carte[size-1] = Base2;
        }

        public void AfficheCarte(Player[] listJoueur)
        {
            
            for (int i = 0; i < this.size; i++)
            {
                Console.Write("|" );
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i == this.Size - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (this.carte[i] is Mob mob)
                {
                    if (listJoueur[0].Mob_spawn.Contains(mob))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
                this.carte[i].Affichage_Entity();
                Console.ResetColor();
            }
            Console.WriteLine("|");
        }
        public int Size
        {
            get
            {
                return size;
            }
            set { size = value; }
        }
        public Entity[] Carte
        {
            get
            {
                return this.carte;
            }
            set { carte = value; }
        }


    }
}
