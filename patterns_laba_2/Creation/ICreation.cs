using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_laba_2.Creation;

/// <summary>
/// Интерфейс для использования шаблона "Object Pool" <see cref="ObjectPool"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ICreator<T>
{
    /// <summary>
    /// Возвращает вновь созданный объект
    /// </summary>
    T Create();
}