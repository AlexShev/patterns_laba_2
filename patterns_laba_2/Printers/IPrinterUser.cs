using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_laba_2.Printers;

/// <summary>
/// Интерфейс предназначен для пометки классов,
/// которым необходимо выводить информацию на консоль
/// </summary>
public interface IPrinterUser
{
    /// <summary>
    /// Объект класса <see cref="Printer"/> предназначен для вывода информации на консоль
    /// </summary>
    public Printer? Printer { set; get; }
}
