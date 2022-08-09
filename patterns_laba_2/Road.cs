using patterns_laba_2.Cars;
using patterns_laba_2.Pools;
using patterns_laba_2.Printers;

partial class Program
{
    private class Road
    {
        private Pool<ICar> _cars;
        private Printer _printer;
        private int _number;

        public Road(Pool<ICar> cars, Printer printer)
        {
            _cars = cars;
            _printer = printer;

            _number = ++Number;
        }

        public static int Number { get; private set; } = 0;
        public static readonly int MAX_CAR_NAMBER = 10;

        public void Run()
        {
            _printer.Print($"Встречная полоса № {_number}");

            Queue<ICar?> cars = new Queue<ICar?>(MAX_CAR_NAMBER);
            Queue<ICar> usedCars = new Queue<ICar>(MAX_CAR_NAMBER);

            for (int i = 0; i < 5; i++)
            {
                int neededCarNum = random.Next(1, MAX_CAR_NAMBER);

                for (int j = 0; j < neededCarNum; j++)
                {
                    cars.Enqueue(_cars.GetObject());
                }

                for (int j = 0; j < neededCarNum; j++)
                {
                    ICar? car = cars.Dequeue();

                    if (car != null)
                    {
                        Thread.Sleep(500);
                        ViewObject(car);
                        usedCars.Enqueue(car);
                    }
                }

                while(usedCars.Count > 0)
                {
                    _cars.Release(usedCars.Dequeue());
                    Thread.Sleep(random.Next(900, 1500));
                }
            }
        }

        private void ViewObject(ICar car)
        {
            lock (loker)
            {
                car.Printer = _printer;
                car.Ride();
                Console.WriteLine();
            }
        }
    }
}