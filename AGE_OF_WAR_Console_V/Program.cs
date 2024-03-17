using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
namespace AGE_OF_WAR_Console_V
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Map carto = new Map(48);
            int end_game = 0;
            Player player1 = new Player("Thibault", 1000, 1);
            Player player2 = new Player("Rodolphe", 1000, 2);


            Mob Caveman_tank = new Mob("Caveman_tank", 20, 30, 40, 10, 1, 1, 10, player2);
            Mob Caveman_distance = new Mob("Caveman_distance", 30, 50, 50, 2, 3, 1, 15, player2);
            Mob Caveman_classic = new Mob("Caveman_classic", 10, 99, 99, 3, 1, 1, 12, player1);
            Mob test = new Mob("test", 10, 50, 50, 30, 1, 1, 15, player1);
            Mob Healer = new Mob("Healer", 35, 60, 60, 20, 1, 1, 15, player2);
            carto.Beginning_fulfil_map();

            carto.SpawnMob(Caveman_classic, Caveman_classic.Current_Position, player1);
            carto.SpawnMob(Caveman_tank, Caveman_tank.Current_Position, player2);
            carto.SpawnMob(Caveman_distance, Caveman_distance.Current_Position, player2);
            //carto.SpawnMob(test, test.Current_Position, player1);
            //carto.SpawnMob(Healer, Healer.Current_Position, player2);
            //carto.AfficheCarte(l);
            int i = 0;

            while (!Program.Check_End_Game(carto))
            {
                i++;
                Console.Clear();
                
                foreach (Mob mob in player1.Mob_spawn.OrderByDescending(mob => mob.Current_Position).ToList()) // Le trie ici ne fonctionne pas, enfaite il se fait sur la base du 1er spawn premier à jouer dans l'ordre de l'ordi, donc ici c'est celui qui est le plus loin dans la map donc avec la current_position la plus élevé ! Mais donc ça va se faire naturellement partout quand j'aurai mit les boutons de spawn de mobs
                {
                    mob.MoveMob(carto, player1, player2);
                    
                }
                foreach (Mob mob in player2.Mob_spawn.OrderBy(mob => mob.Current_Position).ToList())
                {
                    Console.WriteLine($"Mob - Position: {mob.Current_Position}");
                    mob.MoveMob(carto, player2, player1);
                    //Thread.Sleep(1000);
                }

                Console.WriteLine("\n");





                Player[] listeJoueurs = new Player[] { player1, player2 };

                int compteur = 0;
                
                Console.WriteLine("Liste Home " + carto.list_home);
                foreach (Player joueur in listeJoueurs)
                {
                    Console.WriteLine("Liste des Mobs Spawn pour le joueur " + joueur.Name + ":");
                    


                    foreach (Mob mob in joueur.Mob_spawn)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("- " + mob.Name + " - Health: " + mob.Current_Health);
                        Console.ResetColor();
                        Console.WriteLine(" - Damage : " + mob.Damage + " - Position : " + mob.Current_Position);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Vie du Home de " + joueur.Name + " : " + carto.list_home[compteur].Current_Health);
                    compteur++;
                    Console.ResetColor();


                    Console.WriteLine();

                }



                Affichage_Vie(carto, listeJoueurs);


                carto.AfficheCarte(listeJoueurs);
                Player.DisplayPlayerInfo(player1, player2);
                Thread.Sleep(1500);

            }

        }

        public static bool Check_End_Game(Map carte)
        {
            bool a = false;

            foreach (Home home in carte.list_home)
            {
                if (home.end_game == true)
                {
                    a = true;
                }

            }
            return a;

        }
        public static void Affichage_Vie(Map carte, Player[] listeJoueurs)
        {

            string[] liste_pdv = new string[51] {
    "⓪", "①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨",
    "🔟", "⑪", "⑫", "⑬", "⑭", "⑮", "⑯", "⑰", "⑱", "⑲",
    "⑳", "㉑", "㉒", "㉓", "㉔", "㉕", "㉖", "㉗", "㉘", "㉙",
    "㉚", "㉛", "㉜", "㉝", "㉞", "㉟", "㊱", "㊲", "㊳", "㊴",
    "㊵", "㊶", "㊷", "㊸", "㊹", "㊺", "㊻", "㊼", "㊽", "㊾",
    "㊿"};

            int compteur = 0;
            for (int i = 0; i < carte.Size; i++)
            {
                Console.Write("|");
                bool printed = false;
                
                foreach (Player joueur in listeJoueurs)
                {
                    foreach (Mob mob in joueur.Mob_spawn)
                    {
                        if (carte.Carte[i] == mob)
                        {
                            if (joueur.Number == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            //Console.Write(liste_pdv[mob.Current_Health]);
                            Console.Write(mob.Current_Health);
                            Console.ResetColor();
                            printed = true;
                            break;
                        }

                    }



                    if (printed) break;
                }

                if ((i == 0) || (i == carte.Size - 1))
                {


                    Console.ForegroundColor = ConsoleColor.Green;


                    //Console.Write(liste_pdv[carte.list_home[compteur].Current_Health]);

                    Console.Write(carte.list_home[compteur].Current_Health);
                    compteur++;
                    printed = true;
                    Console.ResetColor();
                }


                if (!printed)
                {
                    Console.Write("__");
                }




            }
            Console.WriteLine("|");
        }



    }
}