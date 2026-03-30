using System;

// Interface
interface ICalculation
{
    double Calculate(double a, double b, string operation);
}

// Class
class Calculation : ICalculation
{
    public double Calculate(double a, double b, string operation)
    {
        switch (operation)
        {
            case "+":
                return a + b;

            case "-":
                return a - b;

            case "*":
                return a * b;

            case "/":
                if (b != 0)
                    return a / b;
                else
                {
                    Console.WriteLine("0-a bölmək olmaz!");
                    return 0;
                }

            default:
                Console.WriteLine("Yanlış əməliyyat!");
                return 0;
        }
    }
}

// Program
class Program
{
    static void Main()
    {
        Calculation calc = new Calculation();

        Console.Write("Birinci ədədi daxil et: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Əməliyyatı daxil et (+, -, *, /): ");
        string op = Console.ReadLine();

        Console.Write("İkinci ədədi daxil et: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double result = calc.Calculate(a, b, op);

        Console.WriteLine("Nəticə: " + result);
    }
}
