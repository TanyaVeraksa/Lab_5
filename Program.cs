using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{  public interface ISomeInterface
    { 
        void Print();
        void Die();
    }
    public interface ISomeInterface2
    {
        void PrintGrow();
        void Die();
    }
    class Plant : ISomeInterface
    {
       
        public int GrowYears;
        public Plant(int day)
        {
            GrowYears = day;
        }  
        public void Print()
        {
            Console.WriteLine("Растение вырастет через " + GrowYears + " дней");
        }
         void ISomeInterface.Die() { Console.Write("Статус цветка - Жив. "); }
         public override string ToString()
         {
             return "Plant:" + GrowYears + " " + base.ToString(); //переопределение метода ToString(), 

        }
       
    }
    
    class Kust :  ISomeInterface, ISomeInterface2
    {
        public float dlina;
        public int GrowYears;
        public Kust(int day, float d)
        {
            GrowYears = day;
            dlina = d;
        }
        public void Print()
        {
            Console.WriteLine("Растение вырастет через " + GrowYears + " дней");
        }
        public void PrintGrow()
        {
            Console.WriteLine("Длина растения: " + dlina);
        }
        void ISomeInterface2.Die()
        { Console.WriteLine("Растение погибло"); }
        void ISomeInterface.Die()
        { Console.WriteLine("Растение живо"); }

        public override string ToString()
        {
            return "Kust:"+ GrowYears + " " + dlina + " " + base.ToString(); //переопределение метода ToString(), 

        }
    }
    //Абстрактный класс похож на обычный класс, но мы не можем использовать конструктор абстрактного класса для создания его объекта
    abstract class Byket
    {
        public string Name { get; set; }
        public Byket(string name)
        {
            Name = name;
        }
        public void Draw()
        {
            Console.Write("Букет " + Name);
        }
        //Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual.
        //Такие методы и свойства называют виртуальными
        public virtual void Numm() { } 
    }
    
    class Rose : Byket
    {
        public int Kol { get; set; } // количество цветов в букете
        public Rose(string name, int Koll) : base(name)
        {
            Kol = Koll;
        }
       // А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override.
        public override void Numm()
        {
            Console.Write(" содержит " + Kol + " цветов");
        }
        public override string ToString()
        {
            return "Rose:" + base.Name + " " + Kol + " " + base.ToString(); //переопределение метода ToString(), 

        }
    }
   
    class Gladiolus : Byket
    {
        public int Kol { get; set; } // количество цветов в букете
        public Gladiolus(string name, int Koll) : base(name)
        {
            Kol = Koll;
        }
        public override void Numm()
        {
            Console.Write(" содержит " + Kol + " цветов");
        }
        public override string ToString()
        {
            return "Gladiolus:" + base.Name + " " + Kol + " " + base.ToString(); //переопределение метода ToString(), 

        }
        
    }
    sealed class Paper:Cactus // Запечатанный класс. Класс, от которого запрещается наследовать.
    { }
    class Cactus
    { }

    class Printer
    {
        public virtual void IAmPrinting(ISomeInterface its2, Byket its)
        {
            Console.WriteLine("Тип объекта: " + its.GetType() + " Содержимое объекта: " +its);
            Console.WriteLine("Тип объекта: " + its2.GetType() + " Содержимое объекта: " + its2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISomeInterface Rose = new Plant(35);
            Rose.Print();
            Kust kust = new Kust(257, 62.5f);
            kust.PrintGrow();
            kust.Print();
            //обращение к интерфейсу
            ((ISomeInterface)kust).Die();
            ((ISomeInterface2)kust).Die();
            //использование этих классов
            Rose myByket = new Rose("Роза", 9); 
            Gladiolus myGlad = new Gladiolus("Гладиолус", 17); 
            myByket.Draw();
            myByket.Numm();
            Console.WriteLine();
            myGlad.Draw();
            myGlad.Numm();
            Console.WriteLine();

            Plant test = new Plant(100);
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            // Создадим ссылку на интерфейс
            ISomeInterface obj;
            //Используем ссылку на объект test
            obj = test;
            obj.Die();
            obj.Print();
            //Определить, поддерживает ли данный тип тот или иной интерфейс, можно с использованием ключевого слова as. 
            //Если объект удается интерпретировать как указанный интерфейс, то возвращается ссылка на интересующий интерфейс, а если нет, то ссылка null. 
            //Следовательно, перед продолжением в коде необходимо предусмотреть проверку на null.
            obj = test as ISomeInterface;
            if (obj != null)
                Console.WriteLine("Тип Plant поддерживает интерфейс ISomeInterface :)");
            else
                Console.WriteLine("Не поддерживает :( ");
            //Проверить, был ли реализован нужный интерфейс, можно также с помощью ключевого слова is. 
            //Если запрашиваемый объект не совместим с указанным интерфейсом, возвращается значение false, а если совместим, то можно спокойно вызывать члены этого интерфейса
            if (test is ISomeInterface)
                Console.WriteLine("Тип Plant поддерживает интерфейс ISomeInterface :)");
            else
                Console.WriteLine("Не поддерживает :(");
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Rose test2 = new Rose("Роза", 13);
            // Создадим ссылку на абстрактный класс
            Byket obj2;
            //Используем ссылку на объект test2
            obj2 = test2;
            obj2.Draw();
            obj2.Numm();
            Console.WriteLine();

            obj2 = test2 as Byket;
            if (obj2 != null)
                Console.WriteLine("Тип Pose поддержвает абстрактный класс Byket");
            else
                Console.WriteLine("Не поддерживает :(");
            if(test2 is Byket)
                Console.WriteLine("Тип Pose поддержвает абстрактный класс Byket");
            else
                Console.WriteLine("Не поддерживает :(");
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            //возвращается не только имя класса, но и специфические данные для конкретного экземпляра класса
            Plant ob = new Plant(75);
            Console.WriteLine(ob);

            Kust ob2 = new Kust(197, 15.6f);
            Console.WriteLine(ob2);

            Rose ob3 = new Rose("Белая роза", 15);
            Console.WriteLine(ob3);

            Gladiolus ob4 = new Gladiolus("Гладиолус", 21);
            Console.WriteLine(ob4);
            Console.WriteLine("////////////////////////////////////////////////////////////////////");

            Plant thisPlant = new Plant(205);
            Gladiolus UR = new Gladiolus("Гладиолус", 5);
            ISomeInterface obj7;
            obj7 = thisPlant;
            Byket ttt;
            ttt = UR;
            Printer mmm = new Printer();
            mmm.IAmPrinting(obj7, ttt);
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Plant fff = new Plant(456);
            Kust sss = new Kust(57, 45f);

            // Ссылки на разнотипные объекты классов
            ISomeInterface2 inter;
            ISomeInterface inter2;

            inter = sss;
            inter2 = fff;

            Byket ttt2;
            ttt2 = UR;

            // Объявляем и инициализируем массив объектов
            object[,] arrByObject = { {sss, ttt}, {fff, ttt2 } };
            // Выведем в консоль каждый член массива
            foreach (object i in arrByObject)
                Console.WriteLine($"{i} ");
            Console.WriteLine();
        }
    }
}

