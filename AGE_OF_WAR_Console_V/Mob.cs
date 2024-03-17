using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE_OF_WAR_Console_V
{
    internal class Mob : Entity
    {
        public int Current_Position;
        public int Current_Health;
        public int Total_Health;
        public int Damage;
        public int Speed;
        public int SpeedAttack;
        public int Cost;
        string name;
        public Entity Empty;
        Player joueur_belong;
        public Mob(string name, int Current_Position, int Current_Health, int Total_Health, int Damage, int Speed, int SpeedAttack, int Cost, Player joueur_belong) : base(name)
        {
            this.Current_Position = Current_Position;
            this.Current_Health = Current_Health;
            this.Total_Health = Total_Health;
            this.Damage = Damage;
            this.Speed = Speed;
            this.SpeedAttack = SpeedAttack;
            this.Cost = Cost;
            Empty = new Entity("Empty");
            this.joueur_belong = joueur_belong;
        }

        public void deplacement(int NewPosition, Map carte, Player joueur_implique, Player autrejoueur)
        {
            if (carte.Carte[NewPosition].Name == "Empty")
            {
                carte.Carte[this.Current_Position] = Empty;
                this.Current_Position = NewPosition;
                carte.Carte[NewPosition] = this;
            }
        }
        public void Actualize_Position(int NewPosition, Map carte, Player joueur_implique, Player autrejoueur)
        {
            Entity entity = carte.Carte[NewPosition];
            if (entity is Mob mob)
            {
                //Console.WriteLine("Degat mob, les 2 impliqués sont : " + this.Name + " ,contre :" + entity.Name);
                //Console.WriteLine("Vie de " + entity.Name + " : " + entity.Current_Health);

                if (mob.joueur_belong.Number != this.joueur_belong.Number)
                {
                    mob.Current_Health -= this.Damage;
                }

                if (mob.Current_Health <= 0)
                {
                    carte.Carte[NewPosition] = Empty;
                    autrejoueur.RemoveMobSpawn(mob);
                    //Console.WriteLine("DISPAWN MOB");
                }
            }
            else if (entity is Home home)
            {
                home.Current_Health -= this.Damage;
                if (home.Current_Health <= 0)
                {
                    carte.Carte[NewPosition] = Empty;
                    home.end_game = true;
                }
            }

            {
                Console.WriteLine("AUTRE");
            }
        }

        public void Damage_Mob(Map carte)
        {

        }

        public void DetectionMort()
        {

        }


        public void MoveMob(Map carte, Player joueur_implique, Player autrejoueur)
        {
            lock (carte)
            {
                if (joueur_implique.Number == 1)
                {
                    for (int i = 0; i < this.Speed; i++)
                    {
                        deplacement(Current_Position + 1, carte, joueur_implique, autrejoueur);

                    }
                    for (int j = 0; j < this.SpeedAttack; j++)
                    {
                        Actualize_Position(Current_Position + 1, carte, joueur_implique, autrejoueur);
                    }
                }
                else if (joueur_implique.Number == 2)
                {
                    for (int i = 0; i < this.Speed; i++)
                    {
                        deplacement(Current_Position - 1, carte, joueur_implique, autrejoueur);
                    }
                    for (int j = 0; j < this.SpeedAttack; j++)
                    {
                        Actualize_Position(Current_Position - 1, carte, joueur_implique, autrejoueur);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR of the number of the player");
                }

            }
        }



    }
}
