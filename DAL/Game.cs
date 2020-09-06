using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Game
    {
        int i = 0;
        int closestResult = 140;
        int resultPotentialWinner;
        Players PotentialWinner;
        private readonly int BasketWeight;
        private readonly int CountPlayers;
        private readonly string[] typePlayers = new string[] { "Normal player", "Notepad player", "Uber player", "Cheater", "Uber cheater" };
        private readonly List<int> Answers = new List<int>();
        private readonly List<Players> players = new List<Players>();

        public Game (int basketWeight, int countPlayers)
        {
            BasketWeight = basketWeight;
            CountPlayers = countPlayers;
        }

        public void Start()
        {
            _ = new Game(BasketWeight, CountPlayers);
            Random rand = new Random();

            for (int i = 0;i< CountPlayers; i++)
            {
                players.Add(new Players($"Player-{i+1}", typePlayers[rand.Next(0, 4)]));
            }

            Console.WriteLine("Count Players: " + BasketWeight);
            foreach (Players players1 in players)
            {
                Console.WriteLine($"Name: {players1.GetName} Type: {players1.GetTypePlayers}");
            }

            Console.WriteLine("----------------------------------------------------------------------------------\n");

            for (i = 0; i < 6; i++)
            {
                foreach (Players player in players)
                {
                    int rez = player.Move(Answers);
                    Answers.Add(rez);

                    Console.WriteLine($"{rez}|  Name: {player.GetName} Type: {player.GetTypePlayers}");

                    if (rez == BasketWeight)
                    {
                        Console.WriteLine($"{player.GetName} - Winner!");
                        i = 100;
                        break;
                    }
                    
                    
                    if (closestResult > Math.Abs(BasketWeight - rez))
                    {
                        closestResult = Math.Abs(BasketWeight - rez);
                        PotentialWinner = player;
                        resultPotentialWinner = rez;
                    }
                }
                Console.WriteLine();
            }
            if (i == 6)
            { 
                Console.WriteLine($"No winner(");
                Console.WriteLine($"Closest Winner: {PotentialWinner.GetName} ({PotentialWinner.GetTypePlayers}) - {resultPotentialWinner}");
            }
        }
    }
}
