using System;
using Kompas6API5;
using KompasAPI7;
using Kompas6Constants;
using Kompas6Constants3D;
using System.Runtime.InteropServices;

namespace KompasPlugin
{
    /// <summary>
    /// Класс связи с КОМПАС-3D через API
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект КОМПАС-3D
        /// </summary>
        private KompasObject _object;

        /// <summary>
        /// Часть документа
        /// </summary>
        private ksPart _part;

        public KompasObject Object
        {
            get => _object;
        }

        public ksPart Part
        {
            get
            {
                return _part;
            }
        }

        /// <summary>
        /// Метод начала работы КОМПАС-3D
        /// </summary>
        public void Start()
        {
            if (!IsKompasActive(out var kompas))
            {
                if (!IsKompasOpen(out kompas))
                {
                    throw new ArgumentException("Не удалось открыть КОМПАС-3D.");
                }
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            _object = kompas;
        }

        /// <summary>
        /// Делает окно КОМПАС-3D активным
        /// </summary>
        /// <param name="kompas">Объект КОМПАС-3D</param>
        /// <returns>Является ли активным</returns>
        private bool IsKompasActive(out KompasObject kompas)
        {
            kompas = null;

            try
            {
                kompas = (KompasObject) Marshal.
                    GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// Метод запускает КОМПАС-3D
        /// </summary>
        /// <param name="kompas">Объект КОМПАС-3D</param>
        /// <returns>Является ли запущенным</returns>
        private bool IsKompasOpen(out KompasObject kompas)
        {
            try
            {
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject) Activator.CreateInstance(kompasType);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }

        /// <summary>
        /// Запускает окно создания 3D-модели
        /// </summary>
        /// <returns>Окно создания детали</returns>
        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D document3D = _object.Document3D();
            document3D.Create();
            _part = document3D.GetPart((int)Part_Type.pTop_Part);
            return document3D;
        }
    }
}
