using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompasPlugin
{
    /// <summary>
    /// Класс осуществляющий построение детали
    /// </summary>
    public class WaveguideBuilder
    {
        /// <summary>
        /// Объект класса коннектора для связи с КОММПАС-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Объект класса параметра для построение детали
        /// </summary>
        private WaveguideParameters _parameters;

        /// <summary>
        /// Метод построения крепления
        /// </summary>
        private void BuildAnchorage()
        {

        }

        /// <summary>
        /// Метод построения сечения
        /// </summary>
        private void BuildCrossSection()
        {

        }

        /// <summary>
        /// Метод собирающий сечение и крепление в волновод
        /// </summary>
        public void BuildWaveguide()
        {

        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Парамаетры введенные в главной форме</param>
        public WaveguideBuilder(WaveguideParameters parameters)
        {
            _parameters = parameters;
        }
    }
}
