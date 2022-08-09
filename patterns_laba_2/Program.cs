using patterns_laba_2.Cars;
using patterns_laba_2.Creation;
using patterns_laba_2.Pools;
using patterns_laba_2.Printers;
using System;

partial class Program
{
    static object loker = new();
    static Random random = new Random();


    static void Main(string[] args)
    {
        var reusablePool = new Pool<ICar>(new CarCreator(), 20);

        var thrd1 = new Thread(new Road(reusablePool, new Printer(ConsoleColor.Red)).Run);
        var thrd2 = new Thread(new Road(reusablePool, new Printer(ConsoleColor.Blue)).Run);

        thrd1.Start();
        Thread.Sleep(2000);
        thrd2.Start();

        Console.ReadKey();
        reusablePool.ShowPool();
    }
}