using System;
using System.Text.RegularExpressions;

namespace DistributionFunction
{
    class Program
    {
        static double summ = 10000;
        static public string amounts = "1000;2000;3000;5000;8000;5000";
        static public Regex regex = new Regex(@"\d+");
        static void Main(string[] args)
        {
            
            Distribute dist = new Distribute(summ, amounts, regex);
            while (true)
            {
                
                Console.Clear();

                Console.WriteLine("Способы распределения распределения");
                Console.WriteLine("1 - ПРОП \n2 - ПЕРВ \n3 - ПОСЛ");
                Console.WriteLine("Введите номер пункта меню");

                int numberMenu = int.Parse(Console.ReadLine());

                if (numberMenu <= 3)
                {
                    switch (numberMenu)
                    {
                        case (1):

                            dist.Apportionment();
                            Console.WriteLine(dist);
                            Console.WriteLine("Нажмите Enter");
                            Console.ReadKey();
                            break;
                        case (2):

                            dist.First();
                            Console.WriteLine(dist);
                            Console.WriteLine("Нажмите Enter");
                            Console.ReadKey();
                            break;
                        case (3):
                            dist.Last();
                            Console.WriteLine(dist);
                            Console.WriteLine("Нажмите Enter");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите от 1 до 3");
                    Console.ReadKey();
                }
            }
        }
    }
}
    


