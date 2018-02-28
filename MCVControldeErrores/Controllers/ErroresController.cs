using MCVControldeErrores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCVControldeErrores.Filters;
using MCVControldeErrores.Excepciones;

namespace MCVControldeErrores.Controllers
{
    public class ErroresController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            base.HandleUnknownAction(actionName);
        }
        //si queremos manejar cualquier excepcion dentro de un controlador , sin filtro
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        ModeloErrores modelo;
        public ErroresController()
        {
            modelo = new ModeloErrores();
        }
        public ActionResult Index()
        {
            List<EMP> empleados = modelo.GetEmpleados();
            return View(empleados);
        }
        public ActionResult Create()
        {

            return View();
        }
        //post create, a capturar la excepcion 
        [HttpPost]
        [ExceptionControlSalarios]
        public ActionResult Create(EMP empleado)
        {
            //comprobamos el salario del empleado con respecto al de su jefe
            EMP jefe = modelo.BuscarEmpleado(empleado.DIR.GetValueOrDefault());
            if(empleado.SALARIO.GetValueOrDefault() > jefe.SALARIO.GetValueOrDefault())
            {
                ExceptionSalario error = new ExceptionSalario();
                //error.mitipo

                    throw new ExceptionSalario("El salario del empleado (" + empleado.SALARIO.GetValueOrDefault() + ") no puede ser mayor al de su jefe("
                        + jefe.SALARIO + ") .");
              
                
            }

            modelo.InsertarEmpleado(empleado.EMP_NO,empleado.APELLIDO,
                empleado.OFICIO,
                empleado.DIR.GetValueOrDefault()
                , empleado.FECHA_ALT.GetValueOrDefault()
                , empleado.SALARIO.GetValueOrDefault(),
                empleado.COMISION.GetValueOrDefault(),
                empleado.DEPT_NO.GetValueOrDefault());

           return RedirectToAction("Index");
        }
        public ActionResult ErrorSalarios()
        {

            return View();
        }
    }
}