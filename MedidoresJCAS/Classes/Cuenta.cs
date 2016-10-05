using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedidoresJCAS.Classes
{
    class Cuenta
    {
        Medidor[] medidor;

        internal Medidor[] Medidor
        {
            get { return medidor; }
            set { medidor = value; }
        }


        String ruta;

        public String Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }
        String domicilio;

        public String Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
    }
}
