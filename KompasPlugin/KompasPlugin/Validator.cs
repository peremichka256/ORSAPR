using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompasPlugin
{
    /// <summary>
    /// Статический класс проверки правильности значения параметра
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Метод сравнивающий значение с допустимым минимумом и максимумом
        /// </summary>
        /// <param name="min">Минимм</param>
        /// <param name="max">Максимум</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        static public bool IsValidateSize(double min, double max, double value)
        {
            return (value >= min) && (value <= max);
        }
    }
}
