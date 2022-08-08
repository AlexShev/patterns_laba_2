namespace patterns_laba_2.Cars;

/// <summary>
/// Интерфейс для обобщения видов автомобилей
/// <list type="bullet">
/// <item><see cref="HotRod"/></item>
/// <item><see cref="SuperCar"/></item>
/// </list>
/// </summary>
public interface ICar
{
    /// <summary>
    /// Метод для запуска
    /// </summary>
    public void Ride();
}
