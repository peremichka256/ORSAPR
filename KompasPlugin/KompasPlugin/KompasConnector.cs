using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using KompasAPI7;
using System.Runtime.InteropServices;

namespace KompasPlugin
{
    //TODO: модификатор доступа для класса, размер строк, RSDN
    /// <summary>
    /// Класс связи с КОМПАС-3D через API
    /// </summary>
    public class KompasConnector
    {
        public void KompasConnect()
        {
            //KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            //ksDocument2D document2D = (ksDocument2D) kompas.ActiveDocument2D();
            //
            //document2D.ksPoint(12, 15, 0);
            //document2D.ksPoint(-1, 13, 0);
            KompasObject kompas;

            var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
            kompas = (KompasObject)Activator.CreateInstance(kompasType);
            kompas.ActivateControllerAPI();
        }

        public KompasObject Object
        {
            get
            {
                KompasObject kompasObject;
                kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return kompasObject;
            }
        }
    }
}
