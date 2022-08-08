using patterns_laba_2.Cars;

namespace patterns_laba_2.Creation;

/// <summary>
/// Класс предназначенный для создания объектов, реализующих интерфейс <see cref="ICar"/>
/// </summary>
public class CarCreator : ICreator<ICar>
{
    /// <summary>
    /// Возвращает объект, реализующих интерфейс <see cref="ICar"/>
    /// </summary>
    public ICar Create()
    {
        if (HotRod.CarCounter < SuperCar.CarCounter)
        {
            return new HotRod();
        }
        else
        {
            return new SuperCar();
        }
    }
}
