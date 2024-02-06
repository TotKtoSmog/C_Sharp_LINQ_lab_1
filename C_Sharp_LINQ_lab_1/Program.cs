using System;
using System.Linq;
using System.Xml.Serialization;

namespace C_Sharp_LINQ_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1(new int[] { -1, 2, -13, 4, 5, 6, -17, 8, });
            //Task2(3, new int[] { 10, 20, 32, 30, 40 });
            //Task3(2, new string[] { "aa", "212", "a2", "a21", "123a" });
            //Task4('C', new string[] { "cc", "cC", "aC" });
            //Task5('C', new string[] { "cc", "cC", "aC", "CC" });
            //Task6(new int[] { 11, 10, 31, -4, 0 });
            //Task7(2, new string[] { "CC", "AA1", "AA", "AB" });
            //Task8(new string[] { "CC", "AA1", "AA", "AB" });
            //Task9(3, new int[] { 2, 1, 3, 2, 2, 1, 2, 5, -7 });
            //Task10(2, new string[] { "CC", "AA1", "AAA","cFA", "AA", "ABA" });
            //Task11(4, 3, new int[] { 2, 1, 3, 2, 2, 1, 2, 5, -7 });
            //Task12(3, new int[] { 4, 6, 3, 9, 2, 3, 2, 10, -7 });
            //Task13(2, new string[] { "AA", "AA1", "AAA", "cF2", "AA", "ABA" });
            Task14(new string[] { "AA", "", "AAA", "CF", "AA", "ABA" });
        }

        /// <summary>
        /// Дана целочисленная последовательность, содержащая как положительные,
        /// так и отрицательные числа.Вывести ее первый положительный элемент и последний
        /// отрицательный элемент.
        /// </summary>
        private static void Task1(int[] A)
        {
            int firstPositive = A.Where(n => n > 0).First();
            int lastNegative = A.Where(n => n < 0).Last();

            string res = "";
            foreach (int item in A)
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
        /// <summary>
        /// Даны целое число L (> 0) и строковая последовательность A. Вывести
        /// последнюю строку из A, начинающуюся с цифры и имеющую длину L.Если требуемых
        /// строк в последовательности A нет, то вывести строку «Not found».
        /// </summary>
        /// <param name="L">Целое число для фильтрации строк.</param>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task3(int L, string[] A)
            => Console.WriteLine(A.Where(n => Char.IsDigit(n.First()) && n.Length == L).LastOrDefault("Not found"));
        /// <summary>
        /// Даны символ С и строковая последовательность A. Если A содержит
        /// единственный элемент, оканчивающийся символом C, то вывести этот элемент; если
        /// требуемых строк в A нет, то вывести пустую строку; если требуемых строк 
        /// больше одной, то вывести строку «Error»
        /// </summary>
        /// <param name="C">Символ для фильтрации.</param>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task4(char C, string[] A)
            => Console.WriteLine(A.Where(n => n.Last() == C).Count() > 1 ? "Error":
                 A.Where(n => n.Last() == C).FirstOrDefault(""));
        /// <summary>
        /// Даны символ С и строковая последовательность A. Найти количество элементов
        /// A, которые содержат более одного символа и при этом начинаются и оканчиваются
        /// символом C.
        /// </summary>
        /// <param name="C">Символ для фильтрации.</param>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task5(char C, string[] A)
            => Console.WriteLine(A.Where(n => n.Length > 1 && n.First() == C && n.Last() == C).Count());
        /// <summary>
        /// Дана целочисленная последовательность. Найти количество ее 
        /// положительных двузначных элементов, а также их среднее арифметическое(как
        /// вещественное число). Если требуемые элементы отсутствуют, то дважды вывести 0 
        /// (первый раз как целое, второй – как вещественное).
        /// </summary>
        /// <param name="A">Целочисленная последовательность</param>
        private static void Task6(int[] A)
        {
            Console.WriteLine(A.Where(n => n > 9 && n < 99).Count());
            Console.WriteLine(Math.Round(A.Where(n => n > 9 && n < 99).DefaultIfEmpty(0).Average(),3));
        }
        /// <summary>
        /// Даны целое число L (> 0) и строковая последовательность A. Строки 
        /// последовательности A содержат только заглавные буквы латинского алфавита.Среди всех
        /// строк из A, имеющих длину L, найти наибольшую (в смысле лексикографического
        /// порядка). Вывести эту строку или пустую строку, если последовательность не содержит
        /// строк длины L.
        /// </summary>
        /// <param name="L">Целое число L (> 0).</param>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task7(int L, string[] A)
            => Console.WriteLine(A.Where(n => n.Length == L).OrderBy(n => n).LastOrDefault());
        /// <summary>
        ///  Дана строковая последовательность. Найти сумму длин всех строк, входящих в 
        ///  данную последовательность.
        /// </summary>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task8(string[] A)
            => Console.WriteLine(A.Sum(n => n.Length));
        /// <summary>
        ///  Даны целое число D и целочисленная последовательность A. Начиная с первого 
        ///  элемента A, большего D, извлечь из A все нечетные положительные числа, поменяв
        ///  порядок извлеченных чисел на обратный.
        /// </summary>
        /// <param name="D">Целое число.</param>
        /// <param name="A">Целочисленная последовательность.</param>
        private static void Task9(int D, int[] A)
        {
            int []result = A.SkipWhile(n => n < D).Where(n => n > 0 && n % 2 == 1).Reverse().ToArray();
            foreach(int item in result)
                Console.WriteLine(item);
        }
        /// <summary>
        ///  Дано целое число K (> 0) и строковая последовательность A. Из элементов A,
        ///  предшествующих элементу с порядковым номером K, извлечь те строки, которые имеют
        ///  нечетную длину и начинаются с заглавной латинской буквы, изменив порядок следования
        ///  извлеченных строк на обратный.
        /// </summary>
        /// <param name="K">Целое число (> 0).</param>
        /// <param name="A">Строковая последовательность.</param>
        private static void Task10(int K, string[] A)
        {
            string[] result = A.Skip(K).Where(n => n.Length % 2 == 1 && Char.IsUpper(n.First())).Reverse().ToArray();
            foreach (string item in result)
                Console.WriteLine(item);
        }
        /// <summary>
        ///  Даны целые числа D и K (K > 0) и целочисленная последовательность A. Найти 
        ///  теоретико-множественное объединение двух фрагментов A: первый содержит все
        ///  элементы до первого элемента, большего D(не включая его), а второй – все элементы,
        ///  начиная с элемента с порядковым номером K.Полученную последовательность (не
        ///  содержащую одинаковых элементов) отсортировать по убыванию.
        /// </summary>
        /// <param name="K">Целые числа.</param>
        /// <param name="D">Целые числа.</param>
        /// <param name="A">Целочисленная последовательность.</param>
        private static void Task11(int K, int D, int[] A)
        {
            int[] result = A.TakeWhile(n => n < D).Union(A.Skip(K).ToArray()).OrderByDescending(n => n).ToArray();
            foreach (int item in result)
                Console.WriteLine(item);
        }
        /// <summary>
        ///  Дано целое число K (> 0) и целочисленная последовательность A. Найти 
        ///  теоретико-множественную разность двух фрагментов A: первый содержит все четные
        ///  числа, а второй – все числа с порядковыми номерами, большими K.В полученной
        ///  последовательности (не содержащей одинаковых элементов) поменять порядок элементов
        ///  на обратный.
        /// </summary>
        /// <param name="K">Целое число (> 0).</param>
        /// <param name="A">Целочисленная последовательность.</param>
        private static void Task12(int K, int[] A)
        {
            int[] result = A.Where(n => n % 2 == 0).Except(A.Skip(K).ToArray()).Reverse().ToArray();
            foreach (int item in result)
                Console.WriteLine(item);
        }
        /// <summary>
        ///  Даны целое число K (> 0) и последовательность непустых строк A. Строки 
        ///  последовательности содержат только цифры и заглавные буквы латинского алфавита.
        ///  Найти теоретико-множественное пересечение двух фрагментов A: первый содержит 3K
        ///  начальных элементов, а второй – все элементы, расположенные после последнего
        ///  элемента, оканчивающегося цифрой.Полученную последовательность (не содержащую
        ///  одинаковых элементов) отсортировать по возрастанию длин строк, а строки одинаковой
        ///  длины – в лексикографическом порядке по возрастанию.
        /// </summary>
        /// <param name="K"></param>
        /// <param name="A"></param>
        private static void Task13(int K, string[] A)
        {
            string[] result = A.Take(K).Intersect(A.Reverse().TakeWhile(n => !Char.IsDigit(n.Last())).ToArray()).ToArray();
            foreach (string item in result)
                Console.WriteLine(item);
        }
        /// <summary>
        ///  Дана строковая последовательность A. Строки последовательности содержат 
        ///  только заглавные буквы латинского алфавита.Получить новую последовательность строк,
        ///  элементы которой определяются по соответствующим элементам A следующим образом: 
        ///  пустые строки в новую последовательность не включаются, а к непустым приписывается
        ///  порядковый номер данной строки в исходной последовательности(например, если пятый
        ///  элемент A имеет вид «ABC», то в полученной последовательности он будет иметь вид 
        ///  «ABC5»). При нумерации должны учитываться и пустые строки последовательности A.
        ///  Отсортировать полученную последовательность в лексикографическом порядке по
        ///  возрастанию
        /// </summary>
        /// <param name="A">Cтроковая последовательность.</param>
        private static void Task14(string[] A)
        {
            int index = 0;
            string[] result = A.Select(n => $"{n}{++index}").Where(n => !(char.IsNumber(n.First()) || char.IsWhiteSpace(n.First()))).ToArray();
            foreach (string item in result)
                Console.WriteLine(item);
        }
    }
}