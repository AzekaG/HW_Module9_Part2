using System.Text.Encodings.Web;

namespace Task3
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];
         
            /*Создайте лямбда-выражение для подсчёта количе-
ства чисел в массиве, кратных семи. Напишите код для
тестирования работы лямбды.*/
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(5, 8);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Amount of values % 7 == 0   is : " + array.Where(x=>x%7==0).Count());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            /*Создайте лямбда-выражение для отображения уни-
кальных отрицательных чисел в массиве. Напишите код
для тестирования работы лямбды.*/
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-9, 9);
                Console.Write("{0,3}" ,array[i]);
            }
            Console.WriteLine();
            var Res = array.Where(x => x < 0).Distinct().ToArray();
            Console.WriteLine("Unique '-' elements : ");
            foreach(var  x in Res) 
            {
                Console.Write(x+" ");
            }

            /*Создайте лямбда-выражение для проверки есть ли в
тексте заданное слово. Напишите код для тестирования
работы лямбды.*/
            Console.WriteLine();
            Console.WriteLine();
            string text = "Текст : Создайте лямбда-выражение для проверки есть ли в тексте Текст заданное слово. Текст";
            Console.WriteLine(text);
            Console.WriteLine("Введите нужное слово для поиска : ");
            string findKey = Console.ReadLine();
            if (text.Contains(findKey)) { Console.WriteLine("We find this word : " + findKey); }
            else Console.WriteLine("We can't find this word =(");
            Console.WriteLine("Вариант 2 : ");
            Console.WriteLine("Введите нужное слово для поиска : ");
            findKey = Console.ReadLine();
            string[] text2 = text.Split(' ');
            var ResStr = text2.Where(text2 => text2.Contains(findKey));
            if (ResStr.Count()==0) Console.WriteLine("No words :(");
            foreach (var el in ResStr)
            {
                  Console.WriteLine(el);
            }



        }
    }
}