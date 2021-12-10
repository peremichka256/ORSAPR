using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

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
        /// Метод построения крепления
        /// </summary>
        private void BuildAnchorage(ksPart part)
        {

        }

        /// <summary>
        /// Метод построения половины сечения
        /// </summary>
        private void BuildCrossSection(ksPart part)
        {

        }

        /// <summary>
        /// Метод собирающий сечение и крепление в единый волновод путем отражения
        /// </summary>
        public void BuildWaveguide(ksPart part)
        {
            BuildAnchorage(part);
            BuildCrossSection(part);
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Парамаетры введенные в главной форме</param>
        public WaveguideBuilder(WaveguideParameters parameters, KompasConnector connector)
        {
            _parameters = parameters;
            _connector = connector;
        }
    }
}
