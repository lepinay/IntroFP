using System;
using System.Collections.Generic;
using System.Linq;

public class Polymorphism
{

    abstract class Shape
    {
        public abstract void Draw();
    }

    class Circle : Shape
    {
        public Circle(float radius)
        {
            Radius = radius;
        }
        public override void Draw()
        {
            Console.WriteLine("The circle has a radius of {0}", Radius);
        }

        public float Radius { get; set; }
    }

    class Rectangle : Shape
    {
        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine("The rectangle is {0} high by {1} wide", Width, Height);
        }

        public float Height { get; set; }
        public float Width { get; set; }
    }

    class Point : Shape
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public override void Draw()
        {
            Console.WriteLine("The point of coordinates ({0},{1})", X, Y);
        }

        public float X { get; set; }
        public float Y { get; set; }
    }

    class Polygon : Shape
    {
        public IEnumerable<Point> Points { get; set; }

        public Polygon(IEnumerable<Point> points)
        {
            Points = points;
        }

        public override void Draw()
        {
            Console.WriteLine("The polygon is made of these points:");
            foreach (var point in Points)
            {
                point.Draw();
            }
        }
    }


    public static void Main()
    {
        var circle = new Circle(10);
        var rect = new Rectangle(4, 5);
        var polygon = new Polygon(new List<Point> { new Point(1, 1), 
            new Point(2, 2), new Point(3, 3) });
        var point = new Point(2, 3);
        var shapes = new List<Shape> { circle, rect, polygon, point };

        foreach (var shape in shapes) shape.Draw();
    }


}