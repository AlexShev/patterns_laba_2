namespace patterns_laba_2.Cars;

/// <summary>
/// Класс автомобиля Хот род, реализует интерфейс <see cref="ICar"/>
/// </summary>
public class HotRod : ICar
{
    /// <summary>
    /// Номер машины
    /// </summary>
    public int CarNumber { get; private set; }

    /// <summary>
    /// Количество машин данного класса
    /// </summary>
    public static int CarCounter { get; private set; } = 0;

    public HotRod()
    {
        CarNumber = ++CarCounter;
    }

    /// <summary>
    /// Метод для демонстрации программы
    /// </summary>
    public void Ride()
    {
        Console.WriteLine($"Дрын-дын-дын... проехал Хот род {CarNumber}");
    }

    public override string ToString() => $"Хот род - {CarNumber}";
}
