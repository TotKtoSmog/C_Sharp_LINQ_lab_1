using System;

namespace C_Sharp_LINQ_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            Task2(3, new int[] { 10, 20, 32, 30, 40 });
        }

        /// <summary>
        /// Дана целочисленная последовательность, содержащая как положительные,
        /// так и отрицательные числа.Вывести ее первый положительный элемент и последний
        /// отрицательный элемент.
        /// </summary>
        private static void Task1()
        {
            int[] array = { -1, 2, -13, 4, 5, 6, -17, 8, };

            int firstPositive = array.Where(n => n > 0).First();
            int lastNegative = array.Where(n => n < 0).Last();

            string res = "";
            foreach (int item in array)
                res += $"{item}, ";
            res = res.Remove(res.Length-2);

            Console.WriteLine("Дана последовательность:");
            Console.WriteLine($"({res})");
            Console.WriteLine($"Первый положительный: {firstPositive}");
            Console.WriteLine($"Последний негативный: {lastNegative}");
        }

        /// <summary>
        /// Даны цифра D (однозначное целое число) и целочисленная последовательность
        /// A.Вывести первый положительный элемент последовательности A, оканчивающийся
        /// цифрой D.Если требуемых элементов в последовательности A нет, то вывести 0
        /// </summary>
        private static void Task2(int D, int[]A)
        {
            
            int Result = A.Where(n => n % 10 == D).FirstOrDefault(0);

            string sRes = "";
            foreach (int item in A)
                sRes += $"{item}, ";
            sRes = sRes.Remove(sRes.Length - 2);

            Console.WriteLine($"Число D : {D}");
            Console.WriteLine($"Последовательность: {sRes}");
            Console.WriteLine($"Результат: {Result}");
        }
    }
}