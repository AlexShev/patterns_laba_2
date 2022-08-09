namespace patterns_laba_2.Printers;

/// <summary>
/// Объекты данного класса предназначены для цветного вывода информации в консоль
/// </summary>
public class Printer
{
    /// <summary>
    /// Цвет которым будет печататься информация
    /// </summary>
    public ConsoleColor ConsoleColor { get; set; }

    /// <summary>
    /// переменная заглушка для захвата контроля потока
    /// </summary>
    private static readonly object loker = new object();

    /// <summary>
    /// Создание обекта принтера
    /// </summary>
    /// <param name="consoleColor">Цвет которым будет печататься информация</param>
    public Printer(ConsoleColor consoleColor)
    {
        ConsoleColor = consoleColor;
    }

    /// <summary>
    /// Печать строки в консоль установленным в переменную <see cref="ConsoleColor"/> цветом
    /// </summary>
    /// <param name="str">строка для вывода на консоль</param>
    public void Print(string str)
    {
        lock (loker)
        {
            Console.ForegroundColor = ConsoleColor;
            Console.WriteLine(str);
        }
    }

    /// <summary>
    /// Печать строки в консоль установленным в переменную <see cref="ConsoleColor"/> 
    /// цветом и постановка пустой строки после
    /// </summary>
    /// <param name="str">строка для вывода на консоль</param>
    public void PrintLn(string str)
    {
        lock (loker)
        {
            Console.ForegroundColor = ConsoleColor;
            Console.WriteLine(str);
            Console.WriteLine();
        }
    }
}
