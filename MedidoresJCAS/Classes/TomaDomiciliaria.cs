using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedidoresJCAS.Classes
{
    public class TomaDomiciliaria
    {
        String cuenta;

        public String Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
        String latitud;

        public String Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        String longitud;

        public String Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        String periodo;

        public String Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }
        String nomUsuario;

        public String NomUsuario
        {
            get { return nomUsuario; }
            set { nomUsuario = value; }
        }
    }
}
