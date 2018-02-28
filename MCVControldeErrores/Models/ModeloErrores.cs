using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCVControldeErrores.Models
{
    public class ModeloErrores
    {
        ContextoHospital contexto;
        public ModeloErrores()
        {
            contexto = new ContextoHospital();
        }

        public List<EMP> GetEmpleados()
        {
            var consulta = from datos in contexto.EMP
                           select datos;
            return consulta.ToList();
        }
        public EMP BuscarEmpleado(int empno)
        {
            return contexto.EMP.Find(empno);
        }
        public void InsertarEmpleado(int empno, String apellido,
            String oficio,int director,DateTime fecha,int salario,int comision,int depno)
        {
            EMP empleado = new EMP();
            empleado.EMP_NO = empno;
            empleado.APELLIDO = apellido;
            empleado.OFICIO = oficio;
            empleado.DIR = director;
            empleado.FECHA_ALT = fecha;
            empleado.SALARIO = salario;
            empleado.COMISION = comision;
            empleado.DEPT_NO = depno;
            contexto.EMP.Add(empleado);
            contexto.SaveChanges();

        }

        public int GetMaximoIdException()
        {
            int? maximo = (from datos in contexto.EXCEPCIONES
                          select datos.IDEXCEPCION).FirstOrDefault();
            if (maximo == null)
            {
                return 1;
            }
            else
            {
                return (maximo.GetValueOrDefault() + 1);
            }
        }

        public void InsertarExcepcion(String mensaje,String controlador,DateTime fecha)
        {
            EXCEPCIONES ex = new EXCEPCIONES();
            ex.IDEXCEPCION = this.GetMaximoIdException();
            ex.MENSAJE = mensaje;
            ex.CONTROLADOR = controlador;
            ex.FECHA = fecha;
            contexto.EXCEPCIONES.Add(ex);
            contexto.SaveChanges();
        }
    }
}