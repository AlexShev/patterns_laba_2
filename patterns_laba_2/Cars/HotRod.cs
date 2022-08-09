using patterns_laba_2.Printers;

namespace patterns_laba_2.Cars;

/// <summary>
/// Класс автомобиля Хот род, реализует интерфейс <see cref="ICar"/>
/// </summary>
public class HotRod : ICar, IPrinterUser
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

    public HotRod()
    {
        CarNumber = ++CarCounter;
    }

    /// <summary>
    /// Метод для демонстрации программы
    /// </summary>
    public void Ride()
    {
        Printer?.PrintLn($"Дрын-дын-дын... проехал Хот род {CarNumber}");
    }

    public override string ToString() => $"Хот род - {CarNumber}";
}
