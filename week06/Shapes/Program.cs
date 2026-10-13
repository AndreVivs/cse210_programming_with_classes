using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Circle("Blue", 3));
        shapes.Add(new Rectangle(4, 6, "Green"));

        // Display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetType().Name);
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}