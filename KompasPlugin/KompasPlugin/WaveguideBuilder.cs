using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace KompasPlugin
{
    /// <summary>
    /// Класс осуществляющий построение детали
    /// </summary>
    public class WaveguideBuilder
    {
        /// <summary>
        /// Объект класса конектора для связи с КОММПАС-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Объект класса параметра для построение детали
        /// </summary>
        private WaveguideParameters _parameters;

        /// <summary>
        /// Стиль линии: основная
        /// </summary>
        /// 
        private const int MainLineStyle = 1;
        /// <summary>
        /// Стиль линии: вспомогательная
        /// </summary>
        private const int AuxiliaryLineStyle = 3;

        /// <summary>
        /// Метод построения крепления
        /// </summary>
        private void BuildAnchorage(double height, double thickness,
            double width, double distanceAngleToHole, 
            double holeDiameters, double radiusCrossTie)
        {
            var sketch = CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            //Создание внтуреннего контура
            doc2d.ksRectangle(DrawRectangle(
                WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2,
                WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2,
                height - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE,
                width - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE), 0);
            //Создание внешнего контура
            var externalRectangleParam = DrawRectangle(0,0, height, width);
            //Скругление крепления
            var crossTiePar = (ksCornerParam)_connector.Object.GetParamStruct
                ((short)StructType2DEnum.ko_CornerParam);
            crossTiePar.fillet = true;
            crossTiePar.index = 1;
            crossTiePar.l1 = radiusCrossTie;
            crossTiePar.Init();
            externalRectangleParam.SetPCorner(crossTiePar);
            doc2d.ksRectangle(externalRectangleParam, 0);
            
            //Создание отверстий
            //Выдавливание крепления
            sketch.EndEdit();
            СreateExtrusion(sketch, thickness);
        }

        /// <summary>
        /// Метод построения половины сечения
        /// </summary>
        private void BuildCrossSection(double height, double thickness,
            double width, double length)
        {
            var sketch = CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            //Создание внтуреннего контура
            doc2d.ksRectangle(DrawRectangle(WaveguideParameters.
                ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2, WaveguideParameters.
                ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2, height, width),0);
            //Создание внешнего контура
            doc2d.ksRectangle(DrawRectangle(
                WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2 - thickness,
                WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE / 2 - thickness,
                height + thickness * 2, width + thickness * 2), 0);
            //Выдавливание сечения
            sketch.EndEdit();
            СreateExtrusion(sketch, length / 2);
        }

        /// <summary>
        /// Метод собирающий сечение и крепление в единый волновод путем отражения
        /// </summary>
        public void BuildWaveguide()
        {
            _connector.Start();
            _connector.CreateDocument3D();
            BuildAnchorage(_parameters.AnchorageHeight,
                _parameters.AnchorageThickness,
                _parameters.AnchorageWidth,
                _parameters.DistanceAngleToHole,
                _parameters.HoleDiameters,
                _parameters.RadiusCrossTie);
            BuildCrossSection(_parameters.CrossSectionHeight,
                _parameters.CrossSectionThickness,
                _parameters.CrossSectionWidth,
                _parameters.WaveguideLength);
            //Отражение половины волновода
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Парамаетры введенные в главной форме</param>
        public WaveguideBuilder(WaveguideParameters parameters,
            KompasConnector connector)
        {
            _parameters = parameters;
            _connector = connector;
        }

        /// <summary>
        /// Метод создающий эскиз
        /// </summary>
        /// <param name="planeType"></param>
        /// <param name="offsetPlane"></param>
        /// <returns></returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType
                = Obj3dType.o3d_planeXOY,
            ksPlaneOffsetDefinition offsetPlane = null)
        {
            var plane =
                (ksEntity)_connector.Part.GetDefaultEntity((short)planeType);

            var sketch = (ksEntity)_connector.Part.
                NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition ksSketch = (ksSketchDefinition)sketch.
                GetDefinition();

            if (offsetPlane != null)
            {
                ksSketch.SetPlane(offsetPlane);
                sketch.Create();

                return ksSketch;
            }

            ksSketch.SetPlane(plane);
            sketch.Create();
            return ksSketch;
        }

        /// <summary>
        /// Метод осущетсвляющий выдавливание
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="depth">Расстояние выдавливания</param>
        private void СreateExtrusion(ksSketchDefinition sketch,
            double depth, bool side = true)
        {
            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion;
            var extrusionEntity =
                (ksEntity)_connector.Part.NewEntity((short)type);
            var extrusionDef =
                (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side ?
                (short)Direction_Type.dtNormal :
                (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);

            extrusionEntity.Create();
        }

        /// <summary>
        /// Метод рисования прямоугольника
        /// </summary>
        /// <param name="x">X базовой точки</param>
        /// <param name="y">Y базовой точки</param>
        /// <param name="height">Высота</param>
        /// <param name="width">Ширина</param>
        /// <returns>Переменная с параметрами прямоугольника</returns>
        ksRectangleParam DrawRectangle(double x, double y,
            double height, double width)
        {
            var rectangleParam =
                (ksRectangleParam)_connector.Object.GetParamStruct
                    ((short)StructType2DEnum.ko_RectangleParam);
            rectangleParam.x = x;
            rectangleParam.y = y;
            rectangleParam.height = height;
            rectangleParam.width = width;
            rectangleParam.style = MainLineStyle;
            return rectangleParam;
        }
    }
}
