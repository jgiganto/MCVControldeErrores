using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCVControldeErrores.Excepciones
{
    public class ExceptionSalario:Exception
    {


        public string Miexcepcion()
        {

            String tipo = "salarioerror";
            return tipo;
        }



    }
}