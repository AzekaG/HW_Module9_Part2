using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;


/*Создайте класс рюкзак. Характеристики рюкзака:
■ Цвет рюкзака;
■ Фирма производитель;
■ Ткань рюкзака;
■ Вес рюкзака;
■ Объём рюкзака;
■ Содержимое рюкзака (список объектов, у каждого
объекта кроме названия нужно учитывать занимаемый объём).
Создайте методы для заполнения характеристик.
Создайте событие для добавления объекта в рюкзак.
Реализуйте анонимный метод в качестве обработчика
события добавления объекта. Если при попытке добавления может быть превышен объём рюкзака, нужно
генерировать исключение. */

namespace Task2
{

   
    class Bag
    {
        public EventHandler<AddEvent>? Notify;
        protected double OccupedCapacity { get; set; }
        public string? BagColor { get; set; }
        public string? BagBrandName { get; set; }
        public string? BagTextile { get; set; }
       

        public double BagCapacity { get;set; }
        public Dictionary<string, double>? BagContent;
        
        public Bag()
        {
            BagContent = new Dictionary<string, double>() { };
        }
      double AddToBags(double weight)
        {
            if (OccupedCapacity + weight <= BagCapacity)
            {
                
                Notify?.Invoke(this, new AddEvent("This object added into the Bag"));
                OccupedCapacity += weight;
                return weight;
            }
            Notify?.Invoke(this, new AddEvent("OwerWeight!"));
            return 0;
            
        }
        public void AddThingsIntoBag(string name,double weight)
        {
            if (AddToBags(weight) > 0)
            {
                BagContent.Add(name, weight);
                return ;
            }
           
        }
        public void SetInfo()
        {
            WriteLine("Enter info about Bag : ");
            WriteLine("Color : ");
            BagColor = ReadLine();
            WriteLine("Brand Name : ");
            BagBrandName = ReadLine();
            WriteLine("Textile : ");
            BagTextile= ReadLine();
          
            WriteLine("Bag  Capacity : ");
            BagCapacity = double.Parse(ReadLine());
        }
        public void SetInfo(string textile, string brand , string color, double capacity)
        {
            this.BagBrandName = brand;
            this.BagColor = color;
            this.BagCapacity = capacity;
            this.BagTextile = textile;
        }
        public void OutputInfo()
        {
            Console.WriteLine("Bag Info : ");
            Console.WriteLine("Color : " + BagColor + "\nBrand : " + BagBrandName +
                "\nTextile : " + BagTextile  + "\nCapacity" + BagCapacity +
                "\nOccuped Capacity : " + OccupedCapacity);

            Console.WriteLine();
            OutputBagContent();

        }
       public void OutputBagContent()
        {

            if (BagContent.Count()>0)
            {
                Console.WriteLine("Things in bag : ");
                foreach (var item in BagContent)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }
            else Console.WriteLine("Bag is Empty\n");
        }
    }
    class AddEvent
    {

        public string Message { get; set; }
        public AddEvent(string message)
        {
            this.Message = message;
        }
    }


    class InterFaceClient
    {
        Bag Bag;
       public InterFaceClient(Bag bag)
        {
            Bag = bag;
        }
        public InterFaceClient()
        {
            Bag = new Bag();
            Bag.SetInfo();
        }
        public void InterFaceMenu()
        {
          
            int choice;
            do
            {
                Console.WriteLine("Choose an action : ");
                Console.WriteLine("1.Add things into Bag\n" +
                    "2.show info about Bag\n" +
                    
                    "0.Exit ");
               
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter name of Thing :   \"book\"");
                            string thing = Console.ReadLine();
                            Console.WriteLine("Enter a Weight of " + thing + "   \"1,25\"");
                            double weight = double.Parse(Console.ReadLine());
                            Bag.AddThingsIntoBag(thing, weight);
                            Bag.OutputBagContent();
                        }
                        break;
                    case 2: 
                        {
                            Bag.OutputInfo();
                        } break;
                   
                    default: { } return;

                }
            } while (choice!=0);
        }

    }

    internal class Program
    {
        static void Message(object? sender, AddEvent obj)
        {
            Console.WriteLine(obj.Message);
        }


        static void Main(string[] args)
        {
            Bag bag = new Bag();
            bag.Notify = Message;
            Console.WriteLine("Choose an action : "+
               "\n1-Add a new bag" +
               "\n2-Working with standart bag\n");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 2)
                  { bag.SetInfo("Jeans", "Gucci", "Indigo", 5.0); }
            else bag.SetInfo();
        InterFaceClient faceClient = new InterFaceClient(bag);
            faceClient.InterFaceMenu();
        }
    }
}