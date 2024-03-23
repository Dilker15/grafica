using televisorFinal;

internal class Program

{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Television tv = new Television();
        Console.WriteLine(tv.getIndices());
        Console.WriteLine(tv.getFirst(5));
        using (Game game = new Game())
        {
            game.Run();
        };

    }
}