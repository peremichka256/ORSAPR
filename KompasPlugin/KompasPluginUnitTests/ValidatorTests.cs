using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPluginUnitTests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test(Description = "Негативный тест со значением больше максимального")]
        public void TestIsValidateSize_More(double min, double max, double value)
        {
            
        }

        [Test(Description = "Негативный тест со значением меньше минимального")]
        public void TestIsValidateSize_Less(double min, double max, double value)
        {

        }
    }
}
