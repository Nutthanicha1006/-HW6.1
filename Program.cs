using System;

namespace HW6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Numdif, Numpage, numProblem, Ans;
            double Score = 0, Score1 = 0, CR = 0, Q = 0, LVS = 0;
            long timeu, timev, time;
            Difficulty LV = Difficulty.Easy;

            Console.WriteLine("Score: {0}, Difficulty: {1}",Score, LV);
            Console.Write("");
            Numpage = int.Parse(Console.ReadLine());
            while (Numpage != 0 && Numpage != 1 && Numpage != 2)
            {
                Console.WriteLine("Please input 0-2.");
                Console.Write("");
                Numpage = int.Parse(Console.ReadLine());
            }
            while (Numpage != 2)
            {
                switch (Numpage)
                {
                    case 0:
                        timeu = DateTimeOffset.Now.ToUnixTimeSeconds();
                        if (LV == Difficulty.Easy)
                        {
                            numProblem = 3;
                            for (int i = 0; i < 3; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    CR = CR + 1;
                                }

                                Q = 3;
                                LVS = 0;
                            }
                        }
                        if (LV == Difficulty.Normal)
                        {
                            numProblem = 5;
                            for (int i = 0; i < 5; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    CR = CR + 1;
                                }

                                Q = 5;
                                LVS = 1;
                            }
                        }
                        if (LV == Difficulty.Hard)
                        {
                            numProblem = 7;
                            for (int i = 0; i < 7; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    CR = CR + 1;
                                }

                                Q = 7;
                                LVS = 2;
                            }
                        }
                        timev = DateTimeOffset.Now.ToUnixTimeSeconds();
                        time = timev - timeu;
                        Score1 += (CR / Q) * ((25.0 - Math.Pow(LVS, 2.0)) / Math.Max(time, 25.0 - Math.Pow(LVS, 2.0))) * Math.Pow(((2.0 * (LVS)) + 1.0), 2.0);
                        
                        Console.WriteLine("Score: {0}, Difficulty: {1}", Score1, LV);
                        Console.Write("");
                        Numpage = int.Parse(Console.ReadLine());
                        
                        break;
                    case 1:
                        Console.Write("");
                        Numdif = int.Parse(Console.ReadLine());
                        while (Numdif != 0 && Numdif != 1 && Numdif != 2)
                        {
                            Console.WriteLine("Please input 0-2.");
                            Console.Write("");
                            Numdif = int.Parse(Console.ReadLine());
                        }
                        if (Numdif == 0)
                        {
                            LV = Difficulty.Easy;
                        }
                        if (Numdif == 1)
                        {
                            LV = Difficulty.Normal;
                        }
                        if (Numdif == 2)
                        {
                            LV = Difficulty.Hard;
                        }
                        Console.WriteLine("Score: {0}, Difficulty: {1}", Score1, LV);
                        Console.Write("");
                        Numpage = int.Parse(Console.ReadLine());
                        break;
                        
                }
            }
            if(Numpage == 2)
            {
                Console.WriteLine("");
            }
            Console.ReadLine();
            
        }
        enum Difficulty
        {
            Easy = 3,
            Normal = 5,
            Hard = 7
        }
        struct Problem
        {
            public string Message;
            public int Answer;
            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];
            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }
            return randomProblems;
        }
    }
}
