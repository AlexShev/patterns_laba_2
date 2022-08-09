using patterns_laba_2.Printers;

namespace patterns_laba_2.Cars;

/// <summary>
/// Интерфейс для обобщения видов автомобилей
/// <list type="bullet">
/// <item><see cref="HotRod"/></item>
/// <item><see cref="SuperCar"/></item>
/// </list>
/// </summary>
public interface ICar : IPrinterUser
{
    /// <summary>
    /// Метод для запуска
    /// </summary>
    public void Ride();
}
