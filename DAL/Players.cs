using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Players
    {
        private readonly string Name;
        private readonly string Type;
        int counter = 0;
        private readonly List<int> options = new List<int>();

        public Players(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string GetName
        {
            get
            {
                return Name;
            }
        }
        public string GetTypePlayers
        {
            get
            {
                return Type;
            }
        }

        public int Move(List<int> Answers)
        {
            counter++;
            Random rand = new Random();

            switch (Type)
            {
                case "Normal player":
                    return rand.Next(40, 140);
                case "Notepad player":
                    {
                        int rez;
                        do
                        {
                            rez = rand.Next(40, 140);
                            foreach (int item in options)
                            {
                                if (item == rez)
                                {
                                    rez = 0;
                                    break;
                                }
                            }

                        }
                        while (rez == 0);

                        options.Add(rez);
                        return rez;
                    }

                case "Uber player":
                    return counter + 39;
                case "Cheater":
                    {
                        int rez;
                        do
                        {
                            rez = rand.Next(40, 140);

                            foreach (int item in Answers)
                            {
                                if (item == rez)
                                {
                                    rez = 0;
                                    break;
                                }
                            }
                        }
                        while (rez == 0);
                        return rez;
                    }

                case "Uber cheater":
                    {
                        int rez = 1;
                        int cheaterCounter = 0;

                        while (rez != 0)
                        {
                            rez = counter + 39;

                            foreach (int item in Answers)
                            {
                                if (item == rez + cheaterCounter)
                                {
                                    rez = 0;
                                    cheaterCounter++;
                                    break;
                                }
                            }
                        }
                        return rez;
                    }

                default:
                    return 0;
            }
        }
    }
}
