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
    public class WaveguideParametersTests
    {
        public WaveguideParameters InitTestWaveguideParameters()
        {
            var testWaveguideParameters = new WaveguideParameters(65.0, 10.0,
                80.0, 15.0,
                5.0, 30.0,
                20.0, 3.5,
                1.0, 300.0);
            return testWaveguideParameters;
        }

        [TestCase(64.9, Description = "Высота меньше допустимой")]
        [TestCase(100.1, Description = "Высота больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageHeightSet_HeightUncorrect(double wrongAnchorageHeight)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AchorageHeight = wrongAnchorageHeight; },
                "Возникает, если высота крепления больше 100 или меньше 65");
        }

        [TestCase(9.9, Description = "Толщина меньше допустимой")]
        [TestCase(20.1, Description = "Толщина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageWidthSet_ThicknessUncorrect(double wrongAnchorageThickness)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AnchorageThickness = wrongAnchorageThickness; },
                "Возникает, если толщина крепления больше 20 или меньше 10");
        }

        [TestCase(79.9, Description = "Ширина меньше допустимой")]
        [TestCase(150.1, Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageWidthSet_WidthUncorrect(double wrongAnchorageWidth)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AnchorageWidth = wrongAnchorageWidth; },
                "Возникает, если ширина крепления больше 150 или меньше 80");
        }

        [TestCase(14.9, Description = "Ширина меньше допустимой")]
        [TestCase(50.1, Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestCrossSectionHeightSet_HeightUncorrect(double wrongCrossSectionHeight)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.CrossSectionHeight = wrongCrossSectionHeight; },
                "Возникает, если высота сечения больше 50 или меньше 15");
        }
    }
}
