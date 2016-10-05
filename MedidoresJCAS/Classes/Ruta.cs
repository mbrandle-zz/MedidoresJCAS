using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedidoresJCAS.Classes
{
    class Ruta
    {
        List<Medidor> medidores;

        internal List<Medidor> Medidores
        {
            get { return medidores; }
            set { medidores = value; }
        }

       
        string nombreRuta;

        public string NombreRuta
        {
            get { return nombreRuta; }
            set { nombreRuta = value; }
        }
    }
}
