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

        /// <summary>
        /// Метод проверяющий соответствие разницы двух величин необходимой
        /// </summary>
        /// <param name="minuend">Уменьшаемое</param>
        /// <param name="subtrahend">Вычитаемое</param>
        /// <param name="difference">Разность</param>
        /// <returns></returns>
        static public bool IsStrictlyGreater(double minuend, double subtrahend, double difference)
        {
            return (minuend - subtrahend) == difference;
        }

        static public bool IsRatioCorrect(double multiplicand, double product, int multiplier)
        {
            return (multiplicand * multiplier) == product;
        }
    }
}
