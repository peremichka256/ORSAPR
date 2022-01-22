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

        [Test(Description = "Позитивный тест на сеттер имени параметра")]
        public void TestParameterNameSet()
        {
            ParameterNames newName = ParameterNames.DistanceAngleToHole;
            _testParameter.Name = newName;

            Assert.AreEqual(newName, _testParameter.Name,
                "Имя параметра присвоено неверно");
        }

        [Test(Description = "Позитивный тест на геттер имени параметра")]
        public void TestParameterNameGet()
        {
            ParameterNames newName = ParameterNames.DistanceAngleToHole;
            _testParameter.Name = newName;

            Assert.IsTrue(_testParameter.Name == newName,
                "Геттер вернул неверное имя");
        }

        [TestCase(-1000, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер параметра")]
        public void TestParameterSet_ValueUncorrect(double wrongValue)
        {
            Assert.Throws<Exception>(() =>
                { _testParameter.Value = wrongValue; },
                "Возникает, если высота крепления больше 100 или меньше 0");
        }

        [Test(Description = "Позитивный тест на сеттер параметра")]
        public void TestParameterSet_ValueСorrect()
        {
            var newValue = 50;
            _testParameter.Value = newValue;

            Assert.True(_testParameter.Value == newValue,
                "Возникает, если значение не было передано в параметр");
        }

        [Test(Description = "Позитивный тест на геттер параметра")]
        public void TestParameterGet()
        {
            var testValue = 6.66;
            _testParameter.Value = testValue;

            Assert.AreEqual(_testParameter.Value, testValue,
                "Возникает, если геттер вернул не то значение");
        }

        [TestCase(-1, Description = "Значение максимума меньше минимума")]
        [Test(Description = "Негативный тест на сеттер максимума")]
        public void TestParameterMaxSet_MaxUncorrect(double wrongMax)
        {
            Assert.Throws<Exception>(() =>
                { _testParameter.Max = wrongMax; },
                "Возникает, если максимальное значение меньше минимального");
        }

        [Test(Description = "Позитивный тест на геттер максимума")]
        public void TestParameterMaxGet()
        {
            var parameterMax = 50;
            _testParameter.Max = parameterMax;

            Assert.AreEqual(parameterMax, _testParameter.Max,
                "Геттер вернул неккоректное значение максимума");
            _testParameter.Max = 100;
        }

        [Test(Description = "Позитивный тест на геттер максимума")]
        public void TestParameterMinGet()
        {
            var parameterMin = 1;
            _testParameter.Min = parameterMin;

            Assert.AreEqual(parameterMin, _testParameter.Min,
                "Геттер вернул неккоректное значение минимума");
            _testParameter.Min = 0;
        }
    }
}
