using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DistributionFunction
{
    class Distribute
    {
        private double summ;
        private string amounts;
        private Regex regex;

        private double[] AmountsDouble { get; set; }
        private double[] Result { get; set; }


        public Distribute(double summ, string amounts, Regex regex)
        {
            this.summ = summ;
            this.amounts = amounts;
            this.regex = regex;

            AmountsToDouble(this.amounts);
         }

        public void Last()                                              //распределение в счет первых
        {
            Result = new double[AmountsDouble.Length];                  //создаем массив для вывода результата
            if (AmountsDouble != null)
            {
                for (int i = AmountsDouble.Length -1; i >= 0; i--)      //проходим по массиву с конца
                    if (summ > AmountsDouble[i])                        //проверяем что сумма не превышает елемент массива
                    {
                        Result[i] = AmountsDouble[i];                   //записываем елемент суммы в массив
                        summ -= AmountsDouble[i];                       //уменьшаем сумму
                    }
                    else
                    {                                                   //если оставшаяся сумма меньше текущего элемента,
                        Result[i] = summ;                               //записываем в элемент остаток суммы 
                        break;                                          //и выходим из цикла
                    }
            }
            else
            {
                Console.WriteLine("Входных двнных нет");
            }
        }

        public void First()                                             //распределение в счет первых
        {
            Result = new double[AmountsDouble.Length];                  //создаем массив для вывода результата
            if (AmountsDouble != null)
            {
                for (int i = 0; i < AmountsDouble.Length; i++)          //проходим по массиву с начала
                    if (summ > AmountsDouble[i])                        //проверяем что сумма не превышает елемент массива
                    {
                        Result[i] = AmountsDouble[i];                   //записываем елемент суммы в массив
                        summ -= AmountsDouble[i];                       //уменьшаем сумму
                    }
                else
                    {                                                   //если оставшаяся сумма меньше текущего элемента,
                        Result[i] = summ;                               //записываем в элемент остаток суммы 
                        break;                                          //и выходим из цикла
                    }
            }
            else
            {
                Console.WriteLine("Входных двнных нет");
            }
        }

        public void Apportionment()                                     //пропорциональное распрепределение
        {
            Result = new double[AmountsDouble.Length];                  //создаем массив для вывода результата
            if (AmountsDouble != null)
            {
                double k = summ / AmountsDouble.Sum();                  //находим коэффициент для распределения
                
                for (int i = 0; i < AmountsDouble.Length; i++)          
                {
                    Result[i] = Math.Round(AmountsDouble[i] * k, 2);    //записываем в массив результат пропорционального распределения
                }
                double remains = summ - Result.Sum();                   //находим остаток от округления
                Result[^1] += remains;                                  //добавляем его к последнему элементу
            }
            else
            {
                Console.WriteLine("Входных двнных нет");
            }
        }

        public void AmountsToDouble(string am)                          //переводим список сумм в массив
        {
            MatchCollection matches = regex.Matches(am);                //находим суммы в строке

            AmountsDouble = new double[matches.Count];                  //создаем массив для сумм

            if (matches.Count > 0)
            {
                int i = 0;
                foreach (Match match in matches)
                {
                    AmountsDouble[i] = float.Parse(match.Value);        //записываем суммы в массив
                    i++;
                }
            }
        }

        public override string ToString()
        {
            string exit = "";
            foreach (float i in Result)
            {
                exit += $"{i};";
            }
            exit = exit.Substring(0, exit.Length - 1);
            return exit;
        }
    }
}


