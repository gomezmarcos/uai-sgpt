using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BE;
using System.Reflection;
using BLL.servicio.encriptacion;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            string valor = "hola";
            syso(valor);
            syso(Encriptador.Encriptar(valor));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Usuario u = new Usuario();
            u.Id = 1L;
            u.Alias = "Cyclops";
            u.Area = "Informatica";
            u.FechaCreacion = new DateTime(2017,1,1);
            u.FechaActualizacion = new DateTime(2017, 9, 24);

            int i = 0;
            foreach (var p in u.GetType().GetProperties())
            {
                syso(p.Name + ": " + GetPropValue(u, p).ToString());
                i++;
            }
            syso(i.ToString());

        }

        public object GetPropValue(object instance, PropertyInfo property)
        {
            object r = property.GetValue(instance);
            return r;
        }

        public void syso(String text)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out)); Trace.WriteLine(text);
        }
    }
}
