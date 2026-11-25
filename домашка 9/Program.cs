using System;

interface IMovable
{
    void MoveHorizontally(int dx);
    void MoveVertically(int dy);
}

abstract class Figure : IMovable
{
    protected string color;
    protected bool visible;

    public Figure(string color, bool visible)
    {
        this.color = color;
        this.visible = visible;
    }

    public virtual void MoveHorizontally(int dx) { }
    public virtual void MoveVertically(int dy) { }

    public void SetColor(string c) { color = c; }
    public bool IsVisible() { return visible; }

    public virtual void Print()
    {
        Console.WriteLine("Цвет: " + color + ", видимость: " + (visible ? "видимая" : "невидимая"));
    }
}

class Point : Figure
{
    protected int x, y;

    public Point(int x, int y, string color, bool visible) : base(color, visible)
    {
        this.x = x; this.y = y;
    }

    public override void MoveHorizontally(int dx) { x += dx; }
    public override void MoveVertically(int dy) { y += dy; }

    public override void Print()
    {
        Console.WriteLine("Точка: координаты (" + x + ", " + y + "), " + color + ", " + (visible ? "видимая" : "невидимая"));
    }
}

class Circle : Point
{
    protected int radius;

    public Circle(int x, int y, int r, string color, bool visible) : base(x, y, color, visible)
    {
        radius = r;
    }

    public double Area() { return Math.PI * radius * radius; }

    public override void Print()
    {
        Console.WriteLine("Окружность: центр (" + x + ", " + y + "), радиус " + radius + ", " + color + ", " + (visible ? "видимая" : "невидимая"));
    }
}

class Rectangle : Point
{
    protected int width, height;

    public Rectangle(int x, int y, int w, int h, string color, bool visible) : base(x, y, color, visible)
    {
        width = w; height = h;
    }

    public double Area() { return width * height; }

    public override void Print()
    {
        Console.WriteLine("Прямоугольник: (" + x + ", " + y + "), " + width + "x" + height + ", " + color + ", " + (visible ? "видимая" : "невидимая"));
    }
}

class Program
{
    static void Main()
    {
        Point p = new Point(1, 2, "красный", true);
        Circle c = new Circle(3, 4, 5, "синий", true);
        Rectangle r = new Rectangle(0, 0, 4, 6, "зелёный", false);

        p.Print();
        c.Print();
        Console.WriteLine("Площадь круга: " + c.Area().ToString("F2"));
        r.Print();
        Console.WriteLine("Площадь прямоугольника: " + r.Area());

        c.MoveHorizontally(10);
        c.SetColor("жёлтый");
        c.Print();
        Console.WriteLine("Окружность видима? " + c.IsVisible());
    }
}
