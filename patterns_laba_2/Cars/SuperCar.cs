namespace patterns_laba_2.Cars;

/// <summary>
/// Класс автомобиля Хот род, реализует интерфейс <see cref="ICar"/>
/// </summary>
public class SuperCar : ICar
{
    /// <summary>
    /// Номер машины
    /// </summary>
    public int CarNumber { get; private set; }

    /// <summary>
    /// Количество машин данного класса
    /// </summary>
    public static int CarCounter { get; private set; } = 0;

    public SuperCar()
    {
        CarNumber = ++CarCounter;
    }

    /// <summary>
    /// Метод для демонстрации программы
    /// </summary>
    public void Ride()
    {
        Console.WriteLine($"вжух... пролетел Суперкар {CarNumber}");
    }

    public override string ToString() => $"Суперкар - {CarNumber}";
}
