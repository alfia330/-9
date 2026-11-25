using System;
using System.Collections.Generic;
interface IGame
{
    void Play(string team);
}

abstract class Game : IGame
{
    public string Name { get; set; }
    protected abstract void Run(string team);
    public void Play(string team)
    {
        Console.WriteLine(team + " играет в игру \"" + Name + "\"");
        Run(team);
    }
}
class Beach : Game { public Beach() { Name = "Пляж"; } protected override void Run(string t) { Console.WriteLine(t + ": перетягивание каната на песке!"); } }
class Mousetrap : Game { public Mousetrap() { Name = "Мышеловка"; } protected override void Run(string t) { Console.WriteLine(t + ": прыжки через ловушки!"); } }
class Sea : Game { public Sea() { Name = "Море"; } protected override void Run(string t) { Console.WriteLine(t + ": бешеная ванна с водой!"); } }
class Fishing : Game { public Fishing() { Name = "Рыбалка"; } protected override void Run(string t) { Console.WriteLine(t + ": ловля рыбок в бассейне!"); } }
class Postman : Game { public Postman() { Name = "Почтальоны"; } protected override void Run(string t) { Console.WriteLine(t + ": доставка посылок на бегу!"); } }
class Slide : Game { public Slide() { Name = "Горка"; } protected override void Run(string t) { Console.WriteLine(t + ": спуск с огромной горки!"); } }

class ExtraGame : IGame
{
    private IGame inner;
    public ExtraGame(IGame inner) { this.inner = inner; }
    public void Play(string team)
    {
        inner.Play(team);
        Console.WriteLine(team + " играет в новую игру \"Батут\" (декоратор добавил её к передаче)");
    }
}

class BigRaces
{
    private List<IGame> games = new List<IGame>();

    public void AddGame(IGame g) { games.Add(g); }

    public void RunAll(string team)
    {
        Console.WriteLine("=== Команда: " + team + " ===");
        foreach (IGame g in games) g.Play(team);
    }
}

class Program
{
    static void Main()
    {
        BigRaces show = new BigRaces();
        show.AddGame(new Beach());
        show.AddGame(new Mousetrap());
        show.AddGame(new Sea());
        show.AddGame(new Fishing());
        show.AddGame(new Postman());
        show.AddGame(new Slide());
        show.AddGame(new ExtraGame(new Slide()));

        string[] teams = { "Россия", "Франция", "Китай", "Казахстан" };
        foreach (string t in teams) show.RunAll(t);
    }
}