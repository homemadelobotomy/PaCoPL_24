using System;

class Program
{
    
    
    static void Main(string[] args)
    {
        double a, b, c;

        if (args.Length == 3)
        {
            //Проверка значений введенных через консоль
            if (!double.TryParse(args[0], out a))
            {
                Console.WriteLine($"Некорректное значение для A: {args[0]}");
                return;
            }
            if (!double.TryParse(args[1], out b))
            {
                Console.WriteLine($"Некорректное значение для B: {args[1]}");
                return;
            }
            if (!double.TryParse(args[2], out c))
            {
                Console.WriteLine($"Некорректное значение для C: {args[2]}");
                return;
            }
        }
        else
        {
            //Ввод с клавиатуры
            a = inputData("A");
            b = inputData("B");
            c = inputData("C");
        }
        double discriminant = b * b - 4 * a * c;
        // Решение биквадратного уравнения
        if (discriminant < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"У уравнения с коэффициентами A = {a}, B = {b}, C = {c} нет действительных корней");
            Console.ResetColor();
        }
        else if (discriminant == 0.0) 
        {
            double x = -b /( 2 * a);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корень уравнения x = {x}");
            Console.ResetColor();
        }
        else
        {
            double x1 = (- b  + Math.Sqrt(discriminant))/ (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корни уравнения x1 = {x1}, x2 = {x2}");
            Console.ResetColor();
        }
    }
    /// <summary>
    /// Функция ввода и проверки коэффициентов с именем "data_name" 
    /// </summary>
    /// <param name="data_name"></param>
    /// <returns></returns>
    static double inputData(string data_name)
    {
        double coeficient;
        while (true)
        {
            Console.WriteLine($"Введите коэффициент {data_name}: ");
            string? input = Console.ReadLine();
            if (double.TryParse(input, out coeficient))
            {
                if (data_name == "A" && coeficient == 0.0)
                {
                    Console.WriteLine("Коэффициент A должен быть отличен от 0");
                }
                else
                {
                    return coeficient;
                }
            }   
            else
            {
                Console.WriteLine($"Некорректный ввод коэффициента {data_name}, попробуйте еще раз.");
            }
        }
    }
}
