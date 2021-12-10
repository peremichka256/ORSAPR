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
        /// <param name="min">Минимум</param>
        /// <param name="max">Максимум</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public static bool IsValidateSize(double min, double max, double value)
        {
            return (value >= min) && (value <= max);
        }
    }
}
