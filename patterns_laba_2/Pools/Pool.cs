using patterns_laba_2.Creation;
using patterns_laba_2.Printers;

namespace patterns_laba_2.Pools;

/// <summary>
/// Реализация пула объектов
/// </summary>
/// <typeparam name="T"></typeparam>
public class Pool<T> : IPrinterUser where T : class
{
    /// <summary>
    /// Коллекция содержит управляемые объекты
    /// </summary>
    private List<T> _pool;

    /// <summary>
    /// Ссылка на объект, которому делегируется ответственность 
    /// за создание объектов пула
    /// </summary>
    private ICreator<T> _creator;

    /// <summary>
    /// Количество объектов, существующих в данный момент
    /// </summary>
    private int _instanceCount;

    /// <summary>
    /// Максимальное количество управляемых пулом объектов
    /// </summary>
    private int _maxInstances;

    /// <summary>
    /// Объект класса <see cref="Printer"/> предназначен для вывода информации на консоль
    /// </summary>
    public Printer? Printer { set; get; }

    /// <summary>
    /// Создание пула объектов
    /// </summary>
    /// <param name="creator">Объект, которому пул делегирует ответственность
    /// за создание управляемых им объектов</param>
    public Pool(ICreator<T> creator) : this(creator, int.MaxValue) { }

    /// <summary>
    /// Создание пула объектов
    /// </summary>
    /// <param name="creator">Объект, которому пул делегирует ответственность
    /// за создание управляемых им объектов</param>
    /// <param name="maxInstances">Максимальное количество экземпляров классов,
    /// которым пул разрешает существовать одновременно
    /// </param>
    public Pool(ICreator<T> creator, int maxInstances)
    {
        _creator = creator;
        _instanceCount = 0;
        _maxInstances = maxInstances;
        _pool = new List<T>();
        Printer = new Printer(ConsoleColor.White);
    }

    /// <summary>
    /// Возвращает количество объектов в пуле, ожидающих повторного
    /// использования.
    /// </summary>
    public int Size
    {
        get
        {
            lock (_pool)
            {
                return _pool.Count;
            }
        }
    }

    /// <summary>
    /// Возвращает количество управляемых пулом объектов,
    /// существующих в данный момент
    /// </summary>
    public int InstanceCount => _instanceCount;

    /// <summary>
    /// Получить или задать максимальное количество управляемых пулом
    /// объектов, которым пул разрешает существовать одновременно.
    /// </summary>
    public int MaxInstances
    {
        get => _maxInstances;
        set
        {
            if (_instanceCount <= value)
            {
                _maxInstances = value;
            }
        }
    }

    /// <summary>
    /// Возвращает из пула объект. При пустом пуле будет создан
    /// объект, если количество управляемых пулом объектов не 
    /// больше или равно значению, возвращаемому методом 
    /// <see cref="ObjectPool{T}.MaxInstances"/>. Если количество управляемых пулом 
    /// объектов превышает это значение, то данный метод возварщает null 
    /// </summary>
    /// <returns></returns>
    public T? GetObject()
    {
        lock (_pool)
        {
            // пытаемся получить объект из пула
            T? thisObject = RemoveObject();
            if (thisObject != null)
                return thisObject;

            // если возможно, то создаём объект
            if (InstanceCount < MaxInstances)
                return CreateObject();

            // в противном случае
            return null;
        }
    }

    /// <summary>
    /// Удаляет объект из коллекции пула и возвращает его 
    /// </summary>
    private T? RemoveObject()
    {
        while (_pool.Count > 0)
        {
            // берём последний с конца объект
            T thisObject = _pool[^1];
            _pool.RemoveAt(_pool.Count - 1);

            // уменьшаем количство доступных объектов
            _instanceCount--;

            // возвращаем если это объект
            if (thisObject != null)
                return thisObject;
        } // до тех пор пока не найдём объект или не закончиться пул

        return null;
    }

    /// <summary>
    /// Создать объект, управляемый этим пулом
    /// </summary>
    private T CreateObject()
    {
        T newObject = _creator.Create();

        Printer?.Print($"создан объект {newObject}");
        _instanceCount++;

        return newObject;
    }

    /// <summary>
    /// Освобождает объект, помещая его в пул для
    /// повторного использования
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="NullReferenceException"></exception>
    public void Release(T obj)
    {
        if (obj == null)
            throw new NullReferenceException();
        lock (_pool)
        {
            // увеличиваем счётчик объектов
            _instanceCount++;

            Printer?.Print($"объект {obj} вернулся в пул");

            // возвращаем объект в пул
            _pool.Add(obj);
        }
    }

    /// <summary>
    /// Вывод всего содержимого пула на данный момент
    /// </summary>
    public void ShowPool()
    {
        Printer?.PrintLn("");

        foreach (var obj in _pool)
        {
            Printer?.Print($"объект {obj} в пуле");
        }
    }
}
