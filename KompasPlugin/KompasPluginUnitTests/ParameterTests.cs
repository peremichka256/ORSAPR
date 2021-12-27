using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPlugin.UnitTests
{
    [TestFixture]
    public class ParameterTests
    {
        /// <summary>
        /// Объект шаблонного класса для тестов
        /// </summary>
        private Parameter<double> _testParameter
            = new Parameter<double>("Test parameter", 100, 0);

        [TestCase("", Description = "Пустое значение имени")]
        [TestCase(" ", Description = "Имя состоящие из разделителя")]
        [Test(Description = "Негативный тест на сеттер имени")]
        public void TestParameterSet_NameUncorrect(string wrongName)
        {
            Assert.Throws<Exception>(() =>
                { _testParameter.Name = wrongName; },
                "Возникает, если имя пустое или состоит из пробела");
        }

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
    }
}
