using System;
using NUnit.Framework;
using KompasPlugin;

namespace KompasPluginUnitTests
{
    //Проверить геттеры
    [TestFixture]
    public class WaveguideParametersTests
    {
        /// <summary>
        /// Объект класса с параметрами для тестов
        /// </summary>
        private WaveguideParameters _testWaveguideParameters;

        /// <summary>
        /// Возвращает условие "Не поменялись ли значения параметров"
        /// </summary>
        private bool IsParametersNotDefault(
            WaveguideParameters testWaveguideParameters)
        {
            return (_testWaveguideParameters.AnchorageHeight
                != WaveguideParameters.MIN_ANCHORAGE_HEIGHT
                || _testWaveguideParameters.AnchorageWidth
                != WaveguideParameters.MIN_ANCHORAGE_WIDTH
                || _testWaveguideParameters.CrossSectionHeight
                != WaveguideParameters.MIN_CROSS_SECTION_HEIGHT
                || _testWaveguideParameters.CrossSectionWidth
                != WaveguideParameters.MIN_CROSS_SECTION_WIDTH);
        }

        /// <summary>
        /// Возвращает условие "Поменялись ли значения параметров"
        /// </summary>
        private bool IsParametersChanged(
            WaveguideParameters testWaveguideParameters)
        {
            return (testWaveguideParameters.AnchorageHeight
                == WaveguideParameters.MAX_ANCHORAGE_HEIGHT
                && testWaveguideParameters.AnchorageWidth
                == WaveguideParameters.MAX_ANCHORAGE_WIDTH
                && testWaveguideParameters.CrossSectionHeight
                == WaveguideParameters.MAX_CROSS_SECTION_HEIGHT
                && testWaveguideParameters.CrossSectionWidth
                == WaveguideParameters.MAX_CROSS_SECTION_WIDTH);
        }

        /// <summary>
        /// Сообщение для сеттера непрошедшего проверку
        /// </summary>
        private static string _uncorrectSetterErrorMessage =
                "Возникает, если значения поменялись, когда не должны " +
                "были или остались дефолтными, когда должны были " +
                "поменяться";

        [Test(Description = "Тест на сеттер высоты крепления")]
        public void TestAnchorageHeightSet_SetMaxAndDefault()
        {
            _testWaveguideParameters = new WaveguideParameters();
            _testWaveguideParameters.AnchorageHeight =
                WaveguideParameters.MIN_ANCHORAGE_HEIGHT;
            var negativeTestResult = 
                !IsParametersNotDefault(_testWaveguideParameters);
            _testWaveguideParameters.AnchorageHeight =
                WaveguideParameters.MAX_ANCHORAGE_HEIGHT;
            var positiveTestResult = 
                IsParametersChanged(_testWaveguideParameters);

            Assert.IsTrue(negativeTestResult && positiveTestResult,
                _uncorrectSetterErrorMessage);
        }

        [Test(Description = "Тест на сеттер ширины крепления")]
        public void TestAnchorageWidthtSet_SetMaxAndDefault()
        {
            _testWaveguideParameters = new WaveguideParameters();
            _testWaveguideParameters.AnchorageWidth = 
                WaveguideParameters.MIN_ANCHORAGE_WIDTH;
            var negativeTestResult = 
                !IsParametersNotDefault(_testWaveguideParameters);
            _testWaveguideParameters.AnchorageWidth =
                WaveguideParameters.MAX_ANCHORAGE_WIDTH;
            var positiveTestResult = 
                IsParametersChanged(_testWaveguideParameters);

            Assert.IsTrue(negativeTestResult && positiveTestResult,
                _uncorrectSetterErrorMessage);
        }

        [Test(Description = "Тест на сеттер высоты сечения")]
        public void TestCrossSectionHeightSet_SetMaxAndDefault()
        {
            _testWaveguideParameters = new WaveguideParameters();
            _testWaveguideParameters.CrossSectionHeight = 
                WaveguideParameters.MIN_CROSS_SECTION_HEIGHT;
            var negativeTestResult = 
                !IsParametersNotDefault(_testWaveguideParameters);
            _testWaveguideParameters.CrossSectionHeight =
                WaveguideParameters.MAX_CROSS_SECTION_HEIGHT;
            var positiveTestResult = 
                IsParametersChanged(_testWaveguideParameters);

            Assert.IsTrue(negativeTestResult && positiveTestResult,
                _uncorrectSetterErrorMessage);
        }

        [Test(Description = "Тест на сеттер ширины сечения")]
        public void TestCrossSectionWidthSet_SetMaxAndDefault()
        {
            _testWaveguideParameters = new WaveguideParameters();
            _testWaveguideParameters.CrossSectionWidth = 
                WaveguideParameters.MIN_CROSS_SECTION_WIDTH;
            var negativeTestResult = 
                !IsParametersNotDefault(_testWaveguideParameters);
            _testWaveguideParameters.CrossSectionWidth =
                WaveguideParameters.MAX_CROSS_SECTION_WIDTH;
            var positiveTestResult = 
                IsParametersChanged(_testWaveguideParameters);

            Assert.IsTrue(negativeTestResult && positiveTestResult,
                _uncorrectSetterErrorMessage);
        }

        [Test(Description = "Тест метода передающий значение "
            + "в сеттер параметра по его имени")]
        public void TestSetParameterByName()
        {
            _testWaveguideParameters = new WaveguideParameters();

            _testWaveguideParameters.SetParameterByName((ParameterNames)0,
                WaveguideParameters.MAX_ANCHORAGE_HEIGHT);
            _testWaveguideParameters.SetParameterByName((ParameterNames)1,
                WaveguideParameters.MAX_ANCHORAGE_THICKNESS);
            _testWaveguideParameters.SetParameterByName((ParameterNames)2,
                WaveguideParameters.MAX_ANCHORAGE_WIDTH);
            _testWaveguideParameters.SetParameterByName((ParameterNames)3,
                WaveguideParameters.MAX_CROSS_SECTION_HEIGHT);
            _testWaveguideParameters.SetParameterByName((ParameterNames)4,
                WaveguideParameters.MAX_CROSS_SECTION_THICKNESS);
            _testWaveguideParameters.SetParameterByName((ParameterNames)5,
                WaveguideParameters.MAX_CROSS_SECTION_WIDTH);
            _testWaveguideParameters.SetParameterByName((ParameterNames)6,
                WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE);
            _testWaveguideParameters.SetParameterByName((ParameterNames)7,
                WaveguideParameters.MAX_HOLE_DIAMETERS);
            _testWaveguideParameters.SetParameterByName((ParameterNames)8,
                WaveguideParameters.MAX_RADIUS_CROSS_TIE);
            _testWaveguideParameters.SetParameterByName((ParameterNames)9,
                WaveguideParameters.MAX_WAVEGUIDE_LENGTH);

            Assert.IsTrue(_testWaveguideParameters.AnchorageHeight
                == WaveguideParameters.MAX_ANCHORAGE_HEIGHT
                && _testWaveguideParameters.AnchorageThickness
                == WaveguideParameters.MAX_ANCHORAGE_THICKNESS
                && _testWaveguideParameters.AnchorageWidth
                == WaveguideParameters.MAX_ANCHORAGE_WIDTH
                && _testWaveguideParameters.CrossSectionHeight
                == WaveguideParameters.MAX_CROSS_SECTION_HEIGHT
                && _testWaveguideParameters.CrossSectionThickness
                == WaveguideParameters.MAX_CROSS_SECTION_THICKNESS
                && _testWaveguideParameters.CrossSectionWidth
                == WaveguideParameters.MAX_CROSS_SECTION_WIDTH
                && _testWaveguideParameters.DistanceAngleToHole
                == WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE
                && _testWaveguideParameters.HoleDiameters
                == WaveguideParameters.MAX_HOLE_DIAMETERS
                && _testWaveguideParameters.RadiusCrossTie
                == WaveguideParameters.MAX_RADIUS_CROSS_TIE
                && _testWaveguideParameters.WaveguideLength
                == WaveguideParameters.MAX_WAVEGUIDE_LENGTH,
                "Значения не были помещены в сеттеры параметров");
        }
    }
}
