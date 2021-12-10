using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPluginUnitTests
{
    [TestFixture]
    public class WaveguideParametersTests
    {
        public WaveguideParameters InitTestWaveguideParameters()
        {
            return new WaveguideParameters();
        }

        [TestCase(64.9, Description = "Высота меньше допустимой")]
        [TestCase(100.1, Description = "Высота больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageHeightSet_HeightUncorrect(double wrongAnchorageHeight)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AnchorageHeight = wrongAnchorageHeight; },
                "Возникает, если высота крепления больше 100 или меньше 65");
        }

        [TestCase(9.9, Description = "Толщина меньше допустимой")]
        [TestCase(20.1, Description = "Толщина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageWidthSet_ThicknessUncorrect(double wrongAnchorageThickness)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AnchorageThickness = 
                    wrongAnchorageThickness; },
                "Возникает, если толщина крепления больше 20 или меньше 10");
        }

        [TestCase(79.9, Description = "Ширина меньше допустимой")]
        [TestCase(150.1, Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestAnchorageWidthSet_WidthUncorrect(double wrongAnchorageWidth)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.AnchorageWidth =
                    wrongAnchorageWidth; },
                "Возникает, если ширина крепления больше 150 или меньше 80");
        }

        [TestCase(14.9, Description = "Высота меньше допустимой")]
        [TestCase(50.1, Description = "Высота больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestCrossSectionHeightSet_HeightUncorrect(double wrongCrossSectionHeight)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.CrossSectionHeight = 
                    wrongCrossSectionHeight; },
                "Возникает, если высота сечения больше 50 или меньше 15");
        }

        [TestCase(4.9, Description = "Толщина меньше допустимой")]
        [TestCase(10.1, Description = "Толщина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestCrossSectionThicknessSet_ThicknessUncorrect(double wrongCrossSectionThickness)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.CrossSectionThickness = 
                    wrongCrossSectionThickness; },
                "Возникает, если Толщина сечения больше 10 или меньше 5");
        }

        [TestCase(29.9, Description = "Ширина меньше допустимой")]
        [TestCase(100.1, Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestCrossSectionWidthSet_WidthUncorrect(double wrongCrossSectionWidth)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.CrossSectionWidth = 
                    wrongCrossSectionWidth; },
                "Возникает, если ширина сечения больше 100 или меньше 30");
        }

        [TestCase(19.9, Description = "Расстояние меньше допустимого")]
        [TestCase(50.1, Description = "Расстояние больше допустимого")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestDistanceAngleToHoleSet_DistanceUncorrect(double wrongDistanceAngleToHole)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.DistanceAngleToHole = 
                    wrongDistanceAngleToHole; },
                "Возникает, если расстояние от угла сечения до отверстия больше 50 или меньше 20");
        }

        [TestCase(3.4, Description = "Диаметр меньше допустимого")]
        [TestCase(4.9, Description = "Диаметр больше допустимого")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestHoleDiametersSet_DiametersUncorrect(double wrongHoleDiameters)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.HoleDiameters = 
                    wrongHoleDiameters; },
                "Возникает, если диаметр отверстий больше 4.8 или меньше 3.5");
        }

        [TestCase(0.9, Description = "Радиус меньше допустимого")]
        [TestCase(7.1, Description = "Радиус больше допустимого")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestRadiusCrossTieSet_RadiusUncorrect(double wrongRadiusCrossTie)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.RadiusCrossTie = 
                    wrongRadiusCrossTie; },
                "Возникает, если радиус фаски больше 7 или меньше 1");
        }

        [TestCase(299.9, Description = "Длина меньше допустимого")]
        [TestCase(1000.1, Description = "Длина больше допустимого")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestWaveguideLengthSet_LengthUncorrect(double wrongWaveguideLength)
        {
            var testWaveguideParameters = InitTestWaveguideParameters();

            Assert.Throws<Exception>(() =>
                { testWaveguideParameters.WaveguideLength = 
                    wrongWaveguideLength; },
                "Возникает, если длина волновода больше 1000 или меньше 300");
        }
    }
}
