using API_Dominio.Agregados;
using API_Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasUnitariasExamen.DominioPruebas.PruebasAgregados
{
    public class PruebasUnitariasDominio_Agregados
    {
        [Fact]
        public void CrearUsuarioSinPassword_Exception()
        {
            //Organiza
            string password = null;
            string nombreUsuario = "DanLechuga";
            int id = 1;
            //Actua
            //Verifica
            Assert.Throws<Exception>(() => {

                Usuario usuario = Usuario.Crear(id, nombreUsuario, password, DateTime.Now);
            });
        }
        [Fact]
        public void CrearUsuarioSinNombre_Exception()
        {
            //Organiza
            string password = "DanLechuga";
            string nombreUsuario = "";
            int id = 1;
            //Actua
            //Verifica
            Assert.Throws<Exception>(() => {

                Usuario usuario = Usuario.Crear(id, nombreUsuario, password, DateTime.Now);
            });
        }
        [Fact]
        public void CrearUsuarioCompleto_Usuario()
        {
            //Organiza
            string password = "DanLechuga";
            string nombreUsuario = "DanLechuga";
            int id = 1;
            //Actua
            //Verifica
            Assert.NotNull(Usuario.Crear(id, nombreUsuario, password, DateTime.Now));
        }
    }
}
