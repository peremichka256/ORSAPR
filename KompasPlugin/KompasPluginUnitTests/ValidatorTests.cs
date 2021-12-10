using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPluginUnitTests
{
    [TestFixture]
    public class ValidatorTests
    {
        private const double TEST_MIN = 0.0;

        private const double TEST_MAX = 10.0;

        [Test(Description = "Негативный тест со значением больше максимального")]
        public void TestIsValidateSize_More()
        {
            var valueMoreMax = 11.0;

            if (!Validator.IsValidateSize(TEST_MIN, TEST_MAX, valueMoreMax))
            {
                Assert.Pass("Значение больше допустимого диапазаона");
            }
        }

        [Test(Description = "Негативный тест со значением меньше минимального")]
        public void TestIsValidateSize_Less(double min, double max, double value)
        {
            var valueLessMin = -1.0;

            if (!Validator.IsValidateSize(TEST_MIN, TEST_MAX, valueLessMin))
            {
                Assert.Pass("Значение меньше допустимого диапазаона");
            }
        }
    }
}
