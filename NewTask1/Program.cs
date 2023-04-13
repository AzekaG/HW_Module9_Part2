using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

/*Создайте анонимный метод для получения RGB значения для цвета радуги. Цвет радуги передаётся в качестве
параметра. Напишите код для тестирования работы метода.*/
namespace Task1
{

    internal class Program
    {
        public delegate string GiveRgb(string key);
        class Color
        {

            public GiveRgb giveRgb;
            public Dictionary<string, int[]> ColorRgb = new Dictionary<string, int[]>();
            public Color()
            {
                ColorRgb.Add("Red", new[] { 255, 0, 0 });
                ColorRgb.Add("Orange", new[] { 255, 127, 0 });
                ColorRgb.Add("Yellow", new[] { 255, 255, 0 });
                ColorRgb.Add("Green", new[] { 0, 255, 0 });
                ColorRgb.Add("Blue", new[] { 0, 0, 255 });
                ColorRgb.Add("Indigo", new[] { 46, 43, 95 });
                ColorRgb.Add("Violet", new[] { 139, 0, 255 });

            }
            public string AGiveRgb(string key)
            {
                return giveRgb(key);
            }

        }

        static void Main(string[] args)
        {
            WriteLine("Enter a color : Red , Orange , Yellow , green , Blue , Indigo , Violet : ");
            string keyColor = ReadLine();
            Color color = new Color();
            color.giveRgb += delegate (string key)
            {
                string res = "";
                if (color.ColorRgb.ContainsKey(key))
                {
                    foreach (var item in color.ColorRgb[key])
                        res += item + " ";
                    return res;
                }
                return "No color in Data Base";
            };
            WriteLine(color.giveRgb(keyColor));
        }
    }
}
