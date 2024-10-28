using System;



interface ICreate
{
    public void Create();
}
abstract class Figure
{
    public abstract double Area();

}

class Check
{
   static public double InputCheck(string input)
    {
        double result;
        while (true)
        {
            if (double.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Вы ввели неверное значение");
            }
        }
    }
}

class Rectangle : Figure,IPrint, ICreate
{
   public void Create()
    {
        Console.WriteLine("Введите высоту прямоугольника");
        this.height = Check.InputCheck(Console.ReadLine());
        Console.WriteLine("Введите ширину прямоугольника");
        this.width = Check.InputCheck(Console.ReadLine());
    }
    public override double Area()
    {
        return height * width;
    }
    public Rectangle()
    {
        this.height = 0;
        this.width = 0;
    }
    public Rectangle(double height, double width)
    {
        this.height = height;   
        this.width = width;
    }

    public double height { get; set; }
    public double width { get; set; }                                                                                                                                           

    public override string ToString()
    {
        return "Высота:" + this.height.ToString() + " Ширина: " + this.width.ToString() + " Площадь: " + this.Area().ToString();
    }
    public void Print()
    {
        Console.WriteLine("Прямоугольник\n"+this.ToString());
    }

}
class Square : Rectangle, IPrint
{
    
    public Square(double side): base(side,side)
    {
  
    }
    public Square() { }
    public void Create()
    {
        Console.WriteLine("Введите сторону квадрата");
        double side = Check.InputCheck(Console.ReadLine());
        this.height = side;
        this.width = side;

    }
    public override string ToString()
    {
        return "Сторона: " + this.height.ToString() + " Площадь: " + this.Area().ToString();  
    }
    public void Print()
    {
        Console.WriteLine("Квадрат\n" + this.ToString());
    }
}
class Circle : Figure,IPrint
{

    public void Create()
    {
        Console.WriteLine("Введите радиус круга");
        this.radius = Check.InputCheck(Console.ReadLine());
    }
    public Circle() { }
    public Circle(double radius)
    {
        this.radius = radius;
    }
    public double radius { get; set; }

    public override double Area() {
        return Math.PI * radius * radius;
    }
    public override string ToString()
    {
        return "Радиус: " + this.radius.ToString() + " Площадь: " + this.Area().ToString();
    }
    public void Print()
    {
        Console.WriteLine("Круг\n" + this.ToString());
    }
    
}

interface IPrint
{
    public void Print();
}

class Program
{

    static int Main()
    {
       
        Square s1 = new Square(13.65);
        Circle c1 = new Circle(6);

        while (true)
        {
            switch (Menu())
            {
                case 1:
                    Rectangle r1 = new Rectangle();
                    r1.Create();

                    r1.Print();
                    break;
                case 2:
                    Square s = new Square();
                    s.Create();
                    s.Print();
                    break;
                case 3:
                    Circle c = new Circle();
                    c.Create();
                    c.Print();
                    break;
                case 4:
                    return 0;
                default:
                    break;

            }

        }
    }

    static double Menu()
    {
        Console.WriteLine("\nКакую фигуры вы ходите создать? ");
        Console.WriteLine("1. Прямоугольник");
        Console.WriteLine("2. Квадрат");
        Console.WriteLine("3. Круг");
        Console.WriteLine("4. Выход\n");
        string input = Console.ReadLine();
        return Check.InputCheck(input);

        return 0;
    }
}