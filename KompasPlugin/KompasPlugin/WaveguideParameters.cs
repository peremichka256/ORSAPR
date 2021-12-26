using System;

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
        private double _anchorageHeight;

        /// <summary>
        /// Толщина креплений
        /// </summary>
        private Parameter<double> _anchorageThickness =
            new Parameter<double>("Anchorage thickness",
                MAX_ANCHORAGE_THICKNESS, MIN_ANCHORAGE_THICKNESS);

        /// <summary>
        /// Ширина креплений
        /// </summary>
        private double _anchorageWidth;

        /// <summary>
        /// Высота сечения
        /// </summary>
        private double _crossSectionHeight;

        /// <summary>
        /// Толщина стенок сечения
        /// </summary>
        private Parameter<double> _crossSectionThickness =
            new Parameter<double>("Cross section thickness",
                MAX_CROSS_SECTION_THICKNESS, MIN_CROSS_SECTION_THICKNESS);

        /// <summary>
        /// Ширина сечения
        /// </summary>
        private double _crossSectionWidth;

        /// <summary>
        /// Расстояние от угла сечения до отверстия в креплении
        /// </summary>
        private Parameter<double> _distanceAngleToHole =
            new Parameter<double>("Distance angle to hole",
                MAX_DISTANCE_ANGLE_TO_HOLE, MIN_DISTANCE_ANGLE_TO_HOLE);

        /// <summary>
        /// Диаметр отверстий в креплениях
        /// </summary>
        private Parameter<double> _holeDiameters =
            new Parameter<double>("Hole diameters",
                MAX_HOLE_DIAMETERS, MIN_HOLE_DIAMETERS);

        /// <summary>
        /// Радиус фаски креплений
        /// </summary>
        private Parameter<double> _radiusCrossTie =
            new Parameter<double>("Radius cross tie",
                MAX_RADIUS_CROSS_TIE, MIN_RADIUS_CROSS_TIE);

        /// <summary>
        /// Длина волновода
        /// </summary>
        private Parameter<double> _waveguideLength =
            new Parameter<double>("Waveguide lenght",
                MAX_WAVEGUIDE_LENGTH, MIN_WAVEGUIDE_LENGTH);

        /// <summary>
        /// Является ли волновод изгонутым
        /// </summary>
        private bool _isWaveguideTurn;

        /// <summary>
        /// Конастанты минимальных и максимальных значений параметров в мм
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
            get => _anchorageHeight;

            set
            {
                //TODO: Убрать дубли
                SetValue(ref _anchorageHeight, value, 
                    MIN_ANCHORAGE_HEIGHT, MAX_ANCHORAGE_HEIGHT);

                if (CrossSectionHeight != (_anchorageHeight 
                    - ANCHORAGE_CROSS_SECTION_DIFFERENCE))
                {
                    CrossSectionHeight = _anchorageHeight
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

            set
            {
                //TODO: Убрать дубли
                _anchorageThickness.Value = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину крепления
        /// </summary>
        public double AnchorageWidth
        {
            get => _anchorageWidth;

            set
            {
                //TODO: Убрать дубли
                SetValue(ref _anchorageWidth, value, 
                MIN_ANCHORAGE_WIDTH, MAX_ANCHORAGE_WIDTH);

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
            get => _crossSectionHeight; 

            set
            {
                //TODO: Убрать дубли
                SetValue(ref _crossSectionHeight, value,
                    MIN_CROSS_SECTION_HEIGHT, MAX_CROSS_SECTION_HEIGHT);

                if (CrossSectionWidth != _crossSectionHeight 
                    / CROSS_SECTION_SIDE_MULTIPLIER)
                {
                    CrossSectionWidth = 
                        _crossSectionHeight * CROSS_SECTION_SIDE_MULTIPLIER;
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину стенок сечения
        /// </summary>
        public double CrossSectionThickness
        {
            get => _crossSectionThickness.Value;

            set
            {
                //TODO: Убрать дубли
                _crossSectionThickness.Value = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину сечения
        /// </summary>
        public double CrossSectionWidth
        {
            get => _crossSectionWidth;

            set
            {
                //TODO: Убрать дубли
                SetValue(ref _crossSectionWidth, value,
                    MIN_CROSS_SECTION_WIDTH, MAX_CROSS_SECTION_WIDTH);

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

            set
            {
                //TODO: Убрать дубли
                _distanceAngleToHole.Value = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает диаметр отверстий в креплений
        /// </summary>
        public double HoleDiameters
        {
            get => _holeDiameters.Value;

            set
            {
                //TODO: Убрать дубли
                _holeDiameters.Value = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает радиус фаски креплений
        /// </summary>
        public double RadiusCrossTie
        {
            get => _radiusCrossTie.Value;

            set
            {
                //TODO: Убрать дубли
                _radiusCrossTie.Value = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает длину волновода
        /// </summary>
        public double WaveguideLength
        {
            get => _waveguideLength.Value;

            set
            {
                //TODO: Убрать дубли
                _waveguideLength.Value = value;
            }
        }

        public bool IsWaveguideTurn
        {
            get => _isWaveguideTurn;

            set
            {
                _isWaveguideTurn = value;
            }
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

        public void SetValue(ref double property, double value,
            double minValue, double maxValue)
        {
            if (value >= minValue && value <= maxValue)
            {
                property = value;
            }
            else
            {
                throw new Exception($"{nameof(property)} should be "
                                    + $"more or equal to {minValue} " 
                                    + $"and less or equal to {maxValue}");
            }
        }
    }
}
