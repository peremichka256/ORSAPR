using System;
using System.Collections.Generic;
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
        /// Словарь имён и максимальных значений параметров
        /// </summary>
        private Dictionary<ParameterNames, double>
            _maxValuesOfParameterDictionary =
                new Dictionary<ParameterNames, double>()
                {
                    {
                        ParameterNames.AnchorageHeight,
                        WaveguideParameters.MAX_ANCHORAGE_HEIGHT
                    },
                    {
                        ParameterNames.AnchorageThickness, 
                        WaveguideParameters.MAX_ANCHORAGE_THICKNESS
                    },
                    {
                        ParameterNames.AnchorageWidth,
                        WaveguideParameters.MAX_ANCHORAGE_WIDTH
                    },
                    {
                        ParameterNames.CrossSectionHeight,
                        WaveguideParameters.MAX_CROSS_SECTION_HEIGHT
                    },
                    {
                        ParameterNames.CrossSectionThickness,
                        WaveguideParameters.MAX_CROSS_SECTION_THICKNESS
                    },
                    {
                        ParameterNames.CrossSectionWidth,
                        WaveguideParameters.MAX_CROSS_SECTION_WIDTH
                    },
                    {
                        ParameterNames.DistanceAngleToHole,
                        WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE
                    },
                    {
                        ParameterNames.HoleDiameters,
                        WaveguideParameters.MAX_HOLE_DIAMETERS
                    },
                    {
                        ParameterNames.RadiusCrossTie,
                        WaveguideParameters.MAX_RADIUS_CROSS_TIE
                    },
                    {
                        ParameterNames.WaveguideLenght,
                        WaveguideParameters.MAX_WAVEGUIDE_LENGTH
                    },
                };

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
        
            foreach (var parameterMaxValue 
                     in _maxValuesOfParameterDictionary)
            {
                _testWaveguideParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            int errorCounter = 0;
            
            foreach (var parameterMaxValue 
                     in _maxValuesOfParameterDictionary)
            {
                if (_testWaveguideParameters.GetParameterValueByName(
                          parameterMaxValue.Key) != parameterMaxValue.Value)
                {
                    errorCounter++;
                }
            }
            
            Assert.Zero(errorCounter,
                "Значения не были помещены в сеттеры параметров");
        }

        [Test(Description = "Тест на геттер значения параметра по имени")]
        public void TestGetParameterByName()
        {
            _testWaveguideParameters = new WaveguideParameters();

            var newValue = (WaveguideParameters.MIN_HOLE_DIAMETERS
                            + WaveguideParameters.MAX_HOLE_DIAMETERS)/2;
            ParameterNames testParameterName =
                ParameterNames.HoleDiameters;
            _testWaveguideParameters
                .SetParameterByName(testParameterName, newValue);

            Assert.AreEqual(newValue, _testWaveguideParameters
                    .GetParameterValueByName(testParameterName),
                "Из геттера вернулось неверное значение");
        }

        [Test(Description = "Тест на геттер изогнутости волновода")]
        public void TestIsWaveguideTurnGet()
        {
            _testWaveguideParameters = new WaveguideParameters();
            var expectedWaveguideTurn = true;
            _testWaveguideParameters.IsWaveguideTurn = expectedWaveguideTurn;
            var actualWaveguideTurn =
                _testWaveguideParameters.IsWaveguideTurn;

            Assert.AreEqual(expectedWaveguideTurn, actualWaveguideTurn,
                "Геттер вернул не то значение");
        }

        [Test(Description = "Позитивный тест на геттеры параметров")]
        public void TestParameterGet()
        {
            _testWaveguideParameters = new WaveguideParameters();

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                _testWaveguideParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            Assert.IsTrue(_testWaveguideParameters.AnchorageThickness 
                == WaveguideParameters.MAX_ANCHORAGE_THICKNESS
                && _testWaveguideParameters.CrossSectionThickness
                == WaveguideParameters.MAX_CROSS_SECTION_THICKNESS
                && _testWaveguideParameters.HoleDiameters
                == WaveguideParameters.MAX_HOLE_DIAMETERS
                && _testWaveguideParameters.DistanceAngleToHole
                == WaveguideParameters.MAX_DISTANCE_ANGLE_TO_HOLE
                && _testWaveguideParameters.RadiusCrossTie
                == WaveguideParameters.MAX_RADIUS_CROSS_TIE
                && _testWaveguideParameters.WaveguideLength
                == WaveguideParameters.MAX_WAVEGUIDE_LENGTH,
                "Возникает, если геттер вернул не то значение");
        }
    }
}
