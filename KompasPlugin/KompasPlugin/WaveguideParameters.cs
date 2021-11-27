using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private double _anchorageThickness;

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
        private double _crossSectionThickness;

        /// <summary>
        /// Ширина сечения
        /// </summary>
        private double _crossSectionWidth;

        /// <summary>
        /// Расстояние от угла сечения до отверстия в креплении
        /// </summary>
        private double _distanceAngleToHole;

        /// <summary>
        /// Диаметр отверстий в креплениях
        /// </summary>
        private double _holeDiameters;

        /// <summary>
        /// Радиус фаски креплений
        /// </summary>
        private double _radiusCrossTie;

        /// <summary>
        /// Длина волновода
        /// </summary>
        private double _waveguideLength;

        /// <summary>
        /// Конастанты минимальных и максимальных значений параметров в миллиметрах
        /// </summary>
        private const double MIN_ANCHORAGE_HEIGHT = 65.0;
        private const double MAX_ANCHORAGE_HEIGHT = 100.0;

        private const double MIN_ANCHORAGE_THICKNESS = 10.0;
        private const double MAX_ANCHORAGE_THICKNESS = 20.0;

        private const double MIN_ANCHORAGE_WIDTH = 80.0;
        private const double MAX_ANCHORAGE_WIDTH = 150.0;

        private const double MIN_CROSS_SECTION_HEIGHT = 15.0;
        private const double MAX_CROSS_SECTION_HEIGHT = 50.0;

        private const double MIN_CROSS_SECTION_THICKNESS = 5.0;
        private const double MAX_CROSS_SECTION_THICKNESS = 10.0;

        private const double MIN_CROSS_SECTION_WIDTH = 30.0;
        private const double MAX_CROSS_SECTION_WIDTH = 100.0;

        private const double MIN_DISTANCE_ANGLE_TO_HOLE = 20.0;
        private const double MAX_DISTANCE_ANGLE_TO_HOLE = 50.0;

        private const double MIN_HOLE_DIAMETERS = 3.5;
        private const double MAX_HOLE_DIAMETERS = 4.8;

        private const double MIN_RADIUS_CROSS_TIE = 1.0;
        private const double MAX_RADIUS_CROSS_TIE = 7.0;

        private const double MIN_WAVEGUIDE_LENGTH = 300.0;
        private const double MAX_WAVEGUIDE_LENGTH = 1000.0;

        /// <summary>
        /// Задаёт или возвращает высоту крепления
        /// </summary>
        public double AchorageHeight
        {
            get
            {
                return _anchorageHeight;
            }

            set
            {
                if(Validator.IsValidateSize(MIN_ANCHORAGE_HEIGHT, 
                    MAX_ANCHORAGE_HEIGHT, value))
                {
                    _anchorageHeight = value;
                }
                else
                {
                    throw new Exception
                        ("Anchorage height should be not less than 65 and no more 100");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину крепления
        /// </summary>
        public double AnchorageThickness
        {
            get
            {
                return _anchorageThickness;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_ANCHORAGE_THICKNESS,
                    MAX_ANCHORAGE_THICKNESS, value))
                {
                    _anchorageThickness = value;
                }
                else
                {
                    throw new Exception
                        ("Anchorage thickness should be not less than 10 and no more 20");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину крепления
        /// </summary>
        public double AnchorageWidth
        {
            get
            {
                return _anchorageWidth;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_ANCHORAGE_WIDTH,
                    MAX_ANCHORAGE_WIDTH, value))
                {
                    _anchorageWidth = value;
                }
                else
                {
                    throw new Exception
                        ("Anchorage width should be not less than 60 and no more 150");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает высоту сечения
        /// </summary>
        public double СrossSectionHeight
        {
            get
            {
                return _crossSectionHeight;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_CROSS_SECTION_HEIGHT,
                    MAX_CROSS_SECTION_HEIGHT, value))
                {
                    _crossSectionHeight = value;
                }
                else
                {
                    throw new Exception
                        ("Cross section height should be not less than 15 and no more 50");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину стенок сечения
        /// </summary>
        public double СrossSectionThickness
        {
            get
            {
                return _crossSectionThickness;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_CROSS_SECTION_THICKNESS,
                    MAX_CROSS_SECTION_THICKNESS, value))
                {
                    _crossSectionThickness = value;
                }
                else
                {
                    throw new Exception
                        ("Cross section thickness should be not less than 5 and no more 10");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину сечения
        /// </summary>
        public double СrossSectionWidth
        {
            get
            {
                return _crossSectionWidth;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_CROSS_SECTION_WIDTH,
                    MAX_CROSS_SECTION_WIDTH, value))
                {
                    _crossSectionWidth = value;
                }
                else
                {
                    throw new Exception
                        ("Cross section width should be not less than 30 and no more 100");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает расстояние от угла сечения до отверстий в креплений
        /// </summary>
        public double DistanceAngleToHole
        {
            get
            {
                return _distanceAngleToHole;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_DISTANCE_ANGLE_TO_HOLE,
                    MAX_DISTANCE_ANGLE_TO_HOLE, value))
                {
                    _distanceAngleToHole = value;
                }
                else
                {
                    throw new Exception
                        ("Distance angle to hole should be not less than 20 and no more 50");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает диаметр отверстий в креплений
        /// </summary>
        public double HoleDiameters
        {
            get
            {
                return _holeDiameters;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_HOLE_DIAMETERS,
                    MAX_HOLE_DIAMETERS, value))
                {
                    _holeDiameters = value;
                }
                else
                {
                    throw new Exception
                        ("Hole diameters should be not less than 3.5 and no more 4.8");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает радиус фаски креплений
        /// </summary>
        public double RadiusCrossTie
        {
            get
            {
                return _radiusCrossTie;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_RADIUS_CROSS_TIE,
                    MAX_RADIUS_CROSS_TIE, value))
                {
                    _radiusCrossTie = value;
                }
                else
                {
                    throw new Exception
                        ("Radius cross tie should be not less than 1 and no more 7");
                }
            }
        }

        /// <summary>
        /// Задаёт или возвращает длину волновода
        /// </summary>
        public double WaveguideLength
        {
            get
            {
                return _waveguideLength;
            }

            set
            {
                if (Validator.IsValidateSize(MIN_WAVEGUIDE_LENGTH,
                    MAX_WAVEGUIDE_LENGTH, value))
                {
                    _waveguideLength = value;
                }
                else
                {
                    throw new Exception
                        ("Waveguide length should be not less than 1 and no more 7");
                }
            }
        }
    }
}
