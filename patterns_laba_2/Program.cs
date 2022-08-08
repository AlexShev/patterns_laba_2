using patterns_laba_2;
using patterns_laba_2.Cars;
using patterns_laba_2.Creation;
using patterns_laba_2.Pool;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

        var reusablePool = new ObjectPool<ICar>(new CarCreator(), 10);

        var thrd1 = new Thread(Run);
        var thrd2 = new Thread(Run);

        var thisObject1 = reusablePool.GetObject();
        var thisObject2 = reusablePool.GetObject();

        thrd1.Start(reusablePool);
        thrd2.Start(reusablePool);

        ViewObject(thisObject1);
        ViewObject(thisObject2);

        Thread.Sleep(2000);
        reusablePool.Release(thisObject1);

        Thread.Sleep(2000);
        reusablePool.Release(thisObject2);

        Console.ReadKey();
    }

    private static void Run(object obj)
    {
        Console.WriteLine("\t" + System.Reflection.MethodInfo.GetCurrentMethod().Name);
        var reusablePool = (ObjectPool<ICar>)obj;
        Console.WriteLine("\tstart wait");
        var thisObject1 = reusablePool.WaitForObject();
        ViewObject(thisObject1);
        Console.WriteLine("\tend wait");
        reusablePool.Release(thisObject1);
    }

    private static void ViewObject(ICar car)
    {
        car.Ride();
        Console.WriteLine();
    }
}