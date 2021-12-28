using System;
using System.Collections.Generic;

namespace KompasPlugin
{
    /// <summary>
    /// Класс хранящий параметры волновода
    /// </summary>
    public class WaveguideParameters 
    {
        /// <summary>
        /// Высота креплений
        /// </summary>
        private static Parameter<double> _anchorageHeight =
            new Parameter<double>(ParameterNames.AnchorageHeight,
                MAX_ANCHORAGE_HEIGHT, MIN_ANCHORAGE_HEIGHT);

        /// <summary>
        /// Толщина креплений
        /// </summary>
        private static Parameter<double> _anchorageThickness =
            new Parameter<double>(ParameterNames.AnchorageThickness,
                MAX_ANCHORAGE_THICKNESS, MIN_ANCHORAGE_THICKNESS);

        /// <summary>
        /// Ширина креплений
        /// </summary>
        private static Parameter<double> _anchorageWidth =
            new Parameter<double>(ParameterNames.AnchorageWidth,
                MAX_ANCHORAGE_WIDTH, MIN_ANCHORAGE_WIDTH);

        /// <summary>
        /// Высота сечения
        /// </summary>
        private static Parameter<double> _crossSectionHeight =
            new Parameter<double>(ParameterNames.CrossSectionHeight,
                MAX_CROSS_SECTION_HEIGHT, MIN_CROSS_SECTION_HEIGHT);

        /// <summary>
        /// Толщина стенок сечения
        /// </summary>
        private static Parameter<double> _crossSectionThickness =
            new Parameter<double>(ParameterNames.CrossSectionThickness,
                MAX_CROSS_SECTION_THICKNESS, MIN_CROSS_SECTION_THICKNESS);

        /// <summary>
        /// Ширина сечения
        /// </summary>
        private static Parameter<double> _crossSectionWidth =
            new Parameter<double>(ParameterNames.CrossSectionWidth,
                MAX_CROSS_SECTION_WIDTH, MIN_CROSS_SECTION_WIDTH);

        /// <summary>
        /// Расстояние от угла сечения до отверстия в креплении
        /// </summary>
        private static Parameter<double> _distanceAngleToHole =
            new Parameter<double>(ParameterNames.DistanceAngleToHole,
                MAX_DISTANCE_ANGLE_TO_HOLE, MIN_DISTANCE_ANGLE_TO_HOLE);

        /// <summary>
        /// Диаметр отверстий в креплениях
        /// </summary>
        private static Parameter<double> _holeDiameters =
            new Parameter<double>(ParameterNames.HoleDiameters,
                MAX_HOLE_DIAMETERS, MIN_HOLE_DIAMETERS);

        /// <summary>
        /// Радиус фаски креплений
        /// </summary>
        private static Parameter<double> _radiusCrossTie =
            new Parameter<double>(ParameterNames.RadiusCrossTie,
                MAX_RADIUS_CROSS_TIE, MIN_RADIUS_CROSS_TIE);

        /// <summary>
        /// Длина волновода
        /// </summary>
        private static Parameter<double> _waveguideLength =
            new Parameter<double>(ParameterNames.WaveguideLenght,
                MAX_WAVEGUIDE_LENGTH, MIN_WAVEGUIDE_LENGTH);

        /// <summary>
        /// Является ли волновод изгонутым
        /// </summary>
        private bool _isWaveguideTurn;

        /// <summary>
        /// Словарь содержащий пары (Имя параметра, указатель на него)
        /// </summary>
        private Dictionary<ParameterNames, Parameter<double>> _parametersDictionary =
            new Dictionary<ParameterNames, Parameter<double>>()
            {
                {_anchorageHeight.Name, null},
                {_anchorageThickness.Name, _anchorageThickness},
                {_anchorageWidth.Name, null},
                {_crossSectionHeight.Name, null},
                {_crossSectionThickness.Name, _crossSectionThickness},
                {_crossSectionWidth.Name, null},
                {_distanceAngleToHole.Name, _distanceAngleToHole},
                {_holeDiameters.Name, _holeDiameters},
                {_radiusCrossTie.Name, _radiusCrossTie},
                {_waveguideLength.Name, _waveguideLength}
            };

        /// <summary>
        /// Конастанты минимальных и максимальных значений параметров в мм
        /// Минимальные значения являются дефолтными
        /// </summary>
        public const double MIN_ANCHORAGE_HEIGHT = 65.0;
        public const double MAX_ANCHORAGE_HEIGHT = 100.0;

        public const double MIN_ANCHORAGE_THICKNESS = 10.0;
        public const double MAX_ANCHORAGE_THICKNESS = 20.0;

        public const double MIN_ANCHORAGE_WIDTH = 80.0;
        public const double MAX_ANCHORAGE_WIDTH = 150.0;

        public const double MIN_CROSS_SECTION_HEIGHT = 15.0;
        public const double MAX_CROSS_SECTION_HEIGHT = 50.0;

        public const double MIN_CROSS_SECTION_THICKNESS = 5.0;
        public const double MAX_CROSS_SECTION_THICKNESS = 10.0;

        public const double MIN_CROSS_SECTION_WIDTH = 30.0;
        public const double MAX_CROSS_SECTION_WIDTH = 100.0;

        public const double MIN_DISTANCE_ANGLE_TO_HOLE = 20.0;
        public const double MAX_DISTANCE_ANGLE_TO_HOLE = 25.0;

        public const double MIN_HOLE_DIAMETERS = 3.5;
        public const double MAX_HOLE_DIAMETERS = 4.8;

        public const double MIN_RADIUS_CROSS_TIE = 1.0;
        public const double MAX_RADIUS_CROSS_TIE = 7.0;

        public const double MIN_WAVEGUIDE_LENGTH = 300.0;
        public const double MAX_WAVEGUIDE_LENGTH = 1000.0;

        /// <summary>
        /// Константы ограничений для параметров
        /// </summary>
        public const double ANCHORAGE_CROSS_SECTION_DIFFERENCE = 50.0;
        public const int CROSS_SECTION_SIDE_MULTIPLIER = 2;

        /// <summary>
        /// Задаёт или возвращает высоту крепления
        /// </summary>
        public double AnchorageHeight
        {
            get => _anchorageHeight.Value;

            set
            {
                _anchorageHeight.Value = value;

                if (CrossSectionHeight != (AnchorageHeight
                    - ANCHORAGE_CROSS_SECTION_DIFFERENCE))
                {
                    CrossSectionHeight = AnchorageHeight
                        - ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину крепления
        /// </summary>
        public double AnchorageThickness
        {
            get => _anchorageThickness.Value;
            set => _anchorageThickness.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает ширину крепления
        /// </summary>
        public double AnchorageWidth
        {
            get => _anchorageWidth.Value;

            set
            {
                _anchorageWidth.Value = value;

                if (AnchorageHeight !=
                    (AnchorageWidth - ANCHORAGE_CROSS_SECTION_DIFFERENCE)
                    * CROSS_SECTION_SIDE_MULTIPLIER
                    + ANCHORAGE_CROSS_SECTION_DIFFERENCE)
                {
                    AnchorageHeight = (AnchorageWidth 
                        - ANCHORAGE_CROSS_SECTION_DIFFERENCE)
                        / CROSS_SECTION_SIDE_MULTIPLIER
                        + ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает высоту сечения
        /// </summary>
        public double CrossSectionHeight
        {
            get => _crossSectionHeight.Value; 

            set
            {
                _crossSectionHeight.Value = value;

                if (CrossSectionWidth != CrossSectionHeight 
                    / CROSS_SECTION_SIDE_MULTIPLIER)
                {
                    CrossSectionWidth = 
                        CrossSectionHeight * CROSS_SECTION_SIDE_MULTIPLIER;
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину стенок сечения
        /// </summary>
        public double CrossSectionThickness
        {
            get => _crossSectionThickness.Value;
            set => _crossSectionThickness.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает ширину сечения
        /// </summary>
        public double CrossSectionWidth
        {
            get => _crossSectionWidth.Value;

            set
            {
                _crossSectionWidth.Value = value;

                if (AnchorageWidth != CrossSectionWidth 
                    + ANCHORAGE_CROSS_SECTION_DIFFERENCE)
                {
                    AnchorageWidth = CrossSectionWidth 
                        + ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает расстояние от угла сечения до отверстий
        /// </summary>
        public double DistanceAngleToHole
        {
            get => _distanceAngleToHole.Value;
            set => _distanceAngleToHole.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает диаметр отверстий в креплений
        /// </summary>
        public double HoleDiameters
        {
            get => _holeDiameters.Value;
            set => _holeDiameters.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает радиус фаски креплений
        /// </summary>
        public double RadiusCrossTie
        {
            get => _radiusCrossTie.Value;
            set => _radiusCrossTie.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает длину волновода
        /// </summary>
        public double WaveguideLength
        {
            get => _waveguideLength.Value;
            set => _waveguideLength.Value = value;
        }

        public bool IsWaveguideTurn
        {
            get => _isWaveguideTurn;
            set => _isWaveguideTurn = value;
        }

        /// <summary>
        /// Конструктор класса с минимальными значенми по умолчанию
        /// </summary>
        public WaveguideParameters()
        {
            this.AnchorageHeight = MIN_ANCHORAGE_HEIGHT;
            this.AnchorageThickness = MIN_ANCHORAGE_THICKNESS;
            this.AnchorageWidth = MIN_ANCHORAGE_WIDTH;
            this.CrossSectionHeight = MIN_CROSS_SECTION_HEIGHT;
            this.CrossSectionThickness = MIN_CROSS_SECTION_THICKNESS;
            this.CrossSectionWidth = MIN_CROSS_SECTION_WIDTH;
            this.DistanceAngleToHole = MIN_DISTANCE_ANGLE_TO_HOLE;
            this.HoleDiameters = MIN_HOLE_DIAMETERS;
            this.RadiusCrossTie = MIN_RADIUS_CROSS_TIE;
            this.WaveguideLength = MIN_WAVEGUIDE_LENGTH;
            this.IsWaveguideTurn = false;
        }

        /// <summary>
        /// Метод передающй значение в сеттер параметра по имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetParameterByName(ParameterNames name, double value)
        {
            if (_parametersDictionary.ContainsKey(name))
            {
                if (name == ParameterNames.AnchorageHeight)
                {
                    AnchorageHeight = value;
                }
                else if (name == ParameterNames.AnchorageWidth)
                {
                    AnchorageWidth = value;
                }
                else if(name == ParameterNames.CrossSectionHeight)
                {
                    CrossSectionHeight = value;
                }
                else if(name == ParameterNames.CrossSectionWidth)
                {
                    CrossSectionWidth = value;
                }
                else
                {
                    _parametersDictionary.TryGetValue(name,
                        out var parameter);
                    parameter.Value = value;
                }
            }
        }
    }
}
