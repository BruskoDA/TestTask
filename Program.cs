using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }
    public Shape(string name)
    {
        Name = name;
    }
    public abstract void Draw();
    public abstract double Area();
}

// Круг
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius) : base("Круг") // ?
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
                if(value >= rIn * rIn && value <= rOut * rOut) Console.WriteLine("*");
                else Console.WriteLine(" ");
            }
        }
    }
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}
// Квадрат
class Square : Shape
{
    public double Side { get; set; }

    public Square(double side) : base("Квадрат")
    {
        Side = side;
    }
    public override void Draw()
    {
        
    }
}