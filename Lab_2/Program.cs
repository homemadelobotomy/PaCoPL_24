using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearRegression;


interface ICreate
{
    public void Create();
}
abstract class Figure : IComparable<Figure>,IPrint
{
    public abstract double Area();
    
    public int CompareTo(Figure other)
    {
        if (other == null)
        {
            return 1;
        }
        return this.Area().CompareTo(other.Area());
    }
    public abstract void Print();
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

class Rectangle : Figure, ICreate
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
    override public void Print()
    {
        Console.WriteLine("Прямоугольник\n"+this.ToString());
    }

}
class Square : Rectangle, ICreate
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
    override public void Print()
    {
        Console.WriteLine("Квадрат\n" + this.ToString());
    }
}
class Circle : Figure, ICreate
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
    public override void Print()
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

        Figure r1 = new Rectangle(5, 10);
        Figure s1 = new Square(2);
        Figure s2 = new Square(9);
        Figure c1 = new Circle(3);
        Figure r2 = new Rectangle(7, 2);

        List<Figure> figures = new List<Figure>(){ r1, s1, r2, s2, c1 };
        ArrayList list = new ArrayList() {r1,s1,r2,s2,c1};
      

        list.Sort(new FigureComparer());

        figures.Sort();
        foreach(Figure item in list)
        {
            item.Print();
        }

        Cube cube = new Cube(6);
        cube.PrintMatrix();

        SparseMatrix sparseMatrix = new SparseMatrix();
        sparseMatrix.SetValue(2, 4, 1, 1);
        sparseMatrix.SetValue(2, 1, 1, 1);

        Console.WriteLine("Разреженная матрица:");
        Console.WriteLine(sparseMatrix.ToString());

        SimpleStack<Figure> stack = new SimpleStack<Figure>();
        stack.Push(r1);
        stack.Push(s1);
        stack.Push(c1);
        stack.Pop();

        return 0;
       
    }

    static void interactive()
    {
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
                    return ;
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

public class FigureComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Figure figure1 = x as Figure;
        Figure figure2 = y as Figure;

        if (figure1 == null || figure2 == null)
            throw new ArgumentException();

        return figure1.Area().CompareTo(figure2.Area());
    }
}

class SparseMatrix
{
    private Dictionary<(int x, int y, int z), double> matrix;

    public SparseMatrix()
    {
        matrix = new Dictionary<(int, int, int), double>();
    }

    public void SetValue(int x, int y, int z, double value)
    {
        if (value != 0)
        {
            matrix[(x, y, z)] = value;
        }
        else
        {
            matrix.Remove((x, y, z));
        }
    }

    public double GetValue(int x, int y, int z)
    {
        matrix.TryGetValue((x, y, z), out double value);
        return value;
    }
    public override string ToString()
    {
        if (matrix.Count == 0)
            return "Разреженная матрица пуста.";

        var result = "\n";
        foreach (var item in matrix)
        {
            result += $"Координаты: ({item.Key.x}, {item.Key.y}, {item.Key.z}), Значение: {item.Value}\n";
        }
        return result;
    }
}

public class Cube
{
    public int Size { get; set; }
    private SparseMatrix matrix;

    public Cube(int size)
    {
        Size = size;
        matrix = new SparseMatrix();
        InitMatrix();
    }


    private void InitMatrix()
    {
        matrix.SetValue(0, 0, 0, 1.0);
        matrix.SetValue(Size, 0, 0, 1.0);
        matrix.SetValue(Size, Size, 0, 1.0);
        matrix.SetValue(0, Size, 0, 1.0);
        matrix.SetValue(0, 0, Size, 1.0);
        matrix.SetValue(Size, 0, Size, 1.0);
        matrix.SetValue(Size, Size, Size, 1.0);
        matrix.SetValue(0, Size, Size, 1.0);
    }


    public void PrintMatrix()
    {
        Console.WriteLine("\nВершины куба:");
        Console.WriteLine(matrix.ToString());
    }
}

class SimpleStack<T> 
{
    private LinkedList<T> list = new LinkedList<T>();

    public T Pop()
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("пустой стек"); //проверка на пустой стек
        }

        T element = list.First.Value;
        list.RemoveFirst();
        return element;
    }

    public void Push(T element)
    {
        list.AddFirst(element);
    }
};