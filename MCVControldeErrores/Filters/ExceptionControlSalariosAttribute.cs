using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MCVControldeErrores.Models;


namespace MCVControldeErrores.Filters
{
    public class ExceptionControlSalariosAttribute: FilterAttribute,IExceptionFilter
    {        

        public void OnException(ExceptionContext filterContext)
        {
            //preguntamos si la excepccion ya ha sido manejada o no..
            if (filterContext.ExceptionHandled == false)
            {
                //si no ha sido manejada lo hacemos nosotros
                filterContext.ExceptionHandled = true;
                //este codigo sirve para realizar un LOG de las excepciones en nuestras apps(la bbdd)
                String mensaje = filterContext.Exception.Message;
                String controlador = filterContext.RouteData.Values["controller"].ToString();
                DateTime fecha = DateTime.Now;
                ModeloErrores modelo = new ModeloErrores();
                modelo.InsertarExcepcion(mensaje, controlador, fecha);
                //debemos indicar que accion realizar si hay excepcion
                RouteValueDictionary ruta =
                    new RouteValueDictionary(new
                    {
                        controller = "Errores",
                        action = "ErrorSalarios"
                    });
                RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
                //redirigimos a la pag de errores
                filterContext.Result = direccion;

            }
        }
    }
}