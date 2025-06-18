using System;
using System.Collections.Generic;

// Абстрактный класс
abstract class Shape
{
    public string Name { get; set; }
    // Инкапсуляция
    public Shape(string name)
    {
        Name = name;
    }
    public abstract void Draw();
}
// Круг, наследование
class Circle : Shape
{
    public double Radius { get; set; }
    // Инкапсуляция
    public Circle(double radius) : base("Круг")
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"[{Name}]");

        double rIn = Radius - 0.4;
        double rOut = Radius + 0.4;

        for(double y = Radius; y >= -Radius; --y)
        {
            for(double x = -Radius; x <= Radius; ++x)
            {
                double value = x * x + y * y;
                if(value >= rIn * rIn && value <= rOut * rOut) Console.Write("*");
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    // Полиморфный метод
    public double Area()
    {
        double value = Math.PI * Radius * Radius;
        Console.Write("Площадь фигуры: " + $"{Name}" + "\nравна: ");
        Console.WriteLine(value + "\n");
        return value;
    }
}
// Квадрат, наследование
class Square : Shape
{
    public double Side { get; set; }
    // Инкапсуляция
    public Square(double side) : base("Квадрат")
    {
        Side = side;
    }
    public override void Draw()
    {
        Console.WriteLine($"[{Name}]");

        for (int i = 0; i < Side; i++)
        {
            for (int j = 0; j < Side; j++) Console.Write("* ");
            Console.WriteLine();
        }
    }
    // Полиморфный метод
    public double Area()
    {
        double value = Side * Side;
        Console.Write("Площадь фигуры: " + $"{Name}" + "\nравна: ");
        Console.WriteLine(value + "\n");
        return value;
    }
}
// Равнобедренный прямоугольный треугольник, наследование
class Triangle : Shape
{
    public int Height { get; set; }
    // Инкапсуляция
    public Triangle(int height) : base("Треугольник")
    {
        Height = height;
    }
    public override void Draw()
    {
        Console.WriteLine($"[{Name}]");

        for(int i = 1; i <= Height; i++)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine("*");
        }
    }
    // Полиморфный метод
    public double Area()
    {
        double value = Height * Height * 0.5;
        Console.Write("Площадь фигуры: " + $"{Name}" + "\nравна: ");
        Console.WriteLine(value + "\n");
        return value;
    }
}
class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square(4),
            new Triangle(5)
        };
        Console.WriteLine("Введите количество кругов для вывода: ");
        string value = Console.ReadLine();
        if (int.TryParse(value, out int count) && count > 0)
        {
            for(int i = 0; i < count; i++) shapes.Add(new Circle(5));
        }
        else Console.WriteLine("Некорректные данные");

        foreach (var shape in shapes) shape.Draw();
        // foreach (var shape in shapes) shape.Area();
        Circle obj1 = new Circle(5);
        Square obj2 = new Square(4);
        obj1.Area();
        obj2.Area();
    }
}