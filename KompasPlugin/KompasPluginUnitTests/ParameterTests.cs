using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPlugin.UnitTests
{
    //Проверить геттеры
    [TestFixture]
    public class ParameterTests
    {
        /// <summary>
        /// Объект шаблонного класса для тестов
        /// </summary>
        private Parameter<double> _testParameter
            = new Parameter<double>(0, 100, 0);

        [TestCase(-1, Description = "Значение максимума меньше минимума")]
        [Test(Description = "Негативный тест на сеттер максимума")]
        public void TestParameterSet_MaxUncorrect(double wrongMax)
        {
            Assert.Throws<Exception>(() =>
                { _testParameter.Max = wrongMax; },
                "Возникает, если максимальное значение меньше минимального");
        }

        [TestCase(-1, Description = "Значение меньше допустимого")]
        [TestCase(101, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер параметра")]
        public void TestParameterSet_ValueUncorrect(double wrongValue)
        {
            Assert.Throws<Exception>(() =>
                { _testParameter.Value = wrongValue; },
                "Возникает, если высота крепления больше 100 или меньше 0");
        }

        [Test(Description = "Позитивный тест на геттер параметра")]
        public void TestParameterGet()
        {
            var testValue = 6.66;
            _testParameter.Value = testValue;

            Assert.AreEqual(_testParameter.Value, testValue,
                "Возникает, если геттер вернул не то значение");
        }
    }
}
