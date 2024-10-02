using System;

abstract class Figure
{
    public abstract double Area();

}

class Rectangle : Figure,IPrint
{
    public override double Area()
    {
        return height * width;
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
        Rectangle r1 = new Rectangle(12,4);
        Square s1 = new Square(13.65);
        Circle c1 = new Circle(6);

        r1.Print();
        s1.Print();
        c1.Print(); 

        return 0;
    }
}