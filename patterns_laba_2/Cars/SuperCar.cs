using patterns_laba_2.Printers;

namespace patterns_laba_2.Cars;

/// <summary>
/// Класс автомобиля Хот род, реализует интерфейс <see cref="ICar"/>
/// </summary>
public class SuperCar : ICar, IPrinterUser
{
    /// <summary>
    /// Номер машины
    /// </summary>
    public int CarNumber { get; private set; }

    /// <summary>
    /// Количество машин данного класса
    /// </summary>
    public static int CarCounter { get; private set; } = 0;

    /// <summary>
    /// Объект класса <see cref="Printer"/> предназначен для вывода информации на консоль
    /// </summary>
    public Printer? Printer { get; set; }

    public SuperCar()
    {
        CarNumber = ++CarCounter;
    }

    /// <summary>
    /// Метод для демонстрации программы
    /// </summary>
    public void Ride()
    {
        Printer?.PrintLn($"вжух... пролетел Суперкар {CarNumber}");
    }

    public override string ToString() => $"Суперкар - {CarNumber}";
}
