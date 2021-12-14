using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPluginUnitTests
{
    [TestFixture]
    public class WaveguideParametersTests
    {
        /// <summary>
        /// Объект класса с параметрами для тестов
        /// </summary>
        private WaveguideParameters _testWaveguideParameters 
            = new WaveguideParameters();

        //TODO: Убрать дубли
        [TestCase(WaveguideParameters.MIN_ANCHORAGE_HEIGHT - 0.1,
            Description = "Высота меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_ANCHORAGE_HEIGHT + 0.1,
            Description = "Высота больше допустимой")]
        [Test(Description = "Негативный тест на сеттер высоты крепления")]
        public void TestAnchorageHeightSet_HeightUncorrect(double wrongAnchorageHeight)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.AnchorageHeight = wrongAnchorageHeight; },
                "Возникает, если высота крепления больше"
                + $" {WaveguideParameters.MAX_ANCHORAGE_HEIGHT} или меньше"
                + $" {WaveguideParameters.MIN_ANCHORAGE_HEIGHT}");
        }

        [TestCase(WaveguideParameters.MIN_ANCHORAGE_THICKNESS - 0.1,
            Description = "Толщина меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_ANCHORAGE_THICKNESS + 0.1,
            Description = "Толщина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер толщины крепления")]
        public void TestAnchorageWidthSet_ThicknessUncorrect(double wrongAnchorageThickness)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.AnchorageThickness = 
                    wrongAnchorageThickness; },
                "Возникает, если толщина крепления больше"
                + $" {WaveguideParameters.MAX_ANCHORAGE_THICKNESS} или меньше "
                + $" {WaveguideParameters.MIN_ANCHORAGE_THICKNESS}");
        }

        [TestCase(WaveguideParameters.MIN_ANCHORAGE_WIDTH - 0.1,
            Description = "Ширина меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_ANCHORAGE_WIDTH + 0.1,
            Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер ширины креплений")]
        public void TestAnchorageWidthSet_WidthUncorrect(double wrongAnchorageWidth)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.AnchorageWidth =
                    wrongAnchorageWidth; },
                "Возникает, если ширина крепления больше"
                + $" {WaveguideParameters.MAX_ANCHORAGE_WIDTH} или меньше"
                + $" {WaveguideParameters.MIN_ANCHORAGE_WIDTH}");
        }

        [TestCase(WaveguideParameters.MIN_CROSS_SECTION_HEIGHT - 0.1,
            Description = "Высота меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_CROSS_SECTION_HEIGHT + 0.1,
            Description = "Высота больше допустимой")]
        [Test(Description = "Негативный тест на сеттер высоты сечения")]
        public void TestCrossSectionHeightSet_HeightUncorrect(double wrongCrossSectionHeight)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.CrossSectionHeight = 
                    wrongCrossSectionHeight; },
                "Возникает, если высота сечения больше" 
                + $" {WaveguideParameters.MAX_CROSS_SECTION_HEIGHT} или меньше" 
                + $" {WaveguideParameters.MIN_CROSS_SECTION_HEIGHT}");
        }

        [TestCase(WaveguideParameters.MIN_CROSS_SECTION_THICKNESS - 0.1,
            Description = "Толщина меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_CROSS_SECTION_THICKNESS + 0.1,
            Description = "Толщина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер толщины сечения")]
        public void TestCrossSectionThicknessSet_ThicknessUncorrect(double wrongCrossSectionThickness)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.CrossSectionThickness = 
                    wrongCrossSectionThickness; },
                "Возникает, если Толщина сечения больше" 
                + $" {WaveguideParameters.MAX_CROSS_SECTION_THICKNESS} или меньше" 
                + $" {WaveguideParameters.MIN_CROSS_SECTION_THICKNESS}");
        }

        [TestCase(WaveguideParameters.MIN_CROSS_SECTION_WIDTH - 0.1,
            Description = "Ширина меньше допустимой")]
        [TestCase(WaveguideParameters.MAX_CROSS_SECTION_WIDTH + 0.1,
            Description = "Ширина больше допустимой")]
        [Test(Description = "Негативный тест на сеттер ширины сечения")]
        public void TestCrossSectionWidthSet_WidthUncorrect(double wrongCrossSectionWidth)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.CrossSectionWidth = 
                    wrongCrossSectionWidth; },
                "Возникает, если ширина сечения больше" 
                + $" {WaveguideParameters.MAX_CROSS_SECTION_WIDTH} или меньше" 
                + $" {WaveguideParameters.MIN_CROSS_SECTION_WIDTH}");
        }

        [TestCase(WaveguideParameters.MIN_DISTANCE_ANGLE_TO_HOLE - 0.1,
            Description = "Расстояние меньше допустимого")]
        [TestCase(WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE + 0.1,
            Description = "Расстояние больше допустимого")]
        [Test(Description = "Негативный тест на сеттер расстояния между углом и отверстием")]
        public void TestDistanceAngleToHoleSet_DistanceUncorrect(double wrongDistanceAngleToHole)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.DistanceAngleToHole = 
                    wrongDistanceAngleToHole; },
                "Возникает, если расстояние от угла сечения до отверстия больше" 
                + $" {WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE} или меньше" 
                + $" {WaveguideParameters.MIN_DISTANCE_ANGLE_TO_HOLE}");
        }

        [TestCase(WaveguideParameters.MIN_HOLE_DIAMETERS - 0.1,
            Description = "Диаметр меньше допустимого")]
        [TestCase(WaveguideParameters.MAX_HOLE_DIAMETERS + 0.1,
            Description = "Диаметр больше допустимого")]
        [Test(Description = "Негативный тест на сеттер диаметра отверстий")]
        public void TestHoleDiametersSet_DiametersUncorrect(double wrongHoleDiameters)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.HoleDiameters = 
                    wrongHoleDiameters; },
                "Возникает, если диаметр отверстий больше"
                + $" {WaveguideParameters.MAX_HOLE_DIAMETERS} или меньше"
                + $" {WaveguideParameters.MIN_HOLE_DIAMETERS}");
        }

        [TestCase(WaveguideParameters.MIN_RADIUS_CROSS_TIE - 0.1,
            Description = "Радиус меньше допустимого")]
        [TestCase(WaveguideParameters.MAX_RADIUS_CROSS_TIE + 0.1,
            Description = "Радиус больше допустимого")]
        [Test(Description = "Негативный тест на сеттер радиуса фаски")]
        public void TestRadiusCrossTieSet_RadiusUncorrect(double wrongRadiusCrossTie)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.RadiusCrossTie = 
                    wrongRadiusCrossTie; },
                "Возникает, если радиус фаски больше"
                + $" {WaveguideParameters.MAX_RADIUS_CROSS_TIE} или меньше"
                + $" {WaveguideParameters.MIN_RADIUS_CROSS_TIE}");
        }

        [TestCase(WaveguideParameters.MIN_WAVEGUIDE_LENGTH - 0.1,
            Description = "Длина меньше допустимого")]
        [TestCase(WaveguideParameters.MAX_WAVEGUIDE_LENGTH + 0.1,
            Description = "Длина больше допустимого")]
        [Test(Description = "Негативный тест на сеттер со значениями больше или меньше допустимых")]
        public void TestWaveguideLengthSet_LengthUncorrect(double wrongWaveguideLength)
        {
            Assert.Throws<Exception>(() =>
                { _testWaveguideParameters.WaveguideLength = 
                    wrongWaveguideLength; },
                "Возникает, если длина волновода больше"
                + $" {WaveguideParameters.MAX_WAVEGUIDE_LENGTH} или меньше"
                + $" {WaveguideParameters.MIN_WAVEGUIDE_LENGTH}");
        }
    }
}
