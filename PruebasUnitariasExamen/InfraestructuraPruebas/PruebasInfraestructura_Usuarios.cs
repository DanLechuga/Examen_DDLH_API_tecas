using API_Dominio.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasUnitariasExamen.InfraestructuraPruebas
{
    public class PruebasInfraestructura_Usuarios : IRepositorioUsuarios
    {
        List<Usuario> ListaDeUsuarios = new List<Usuario>()
        {
            Usuario.Crear(1,"DanLechuga","DanLechuga",DateTime.Today),Usuario.Crear(2,"JesusOjeda","JesusOjeda",DateTime.Today),Usuario.Crear(3,"PabloNoriega","PabloNoriega",DateTime.Today),Usuario.Crear(4,"EnriqueZaragoza","EnriqueZaragoza",DateTime.Today),Usuario.Crear(5,"JavierMina","JavierMina",DateTime.Today)
        };
        public Usuario GetUsuarioPorNombre(string nombre)
        {
            return ListaDeUsuarios.FirstOrDefault(x => x.Username == nombre);
        }

        public void Guardar(Usuario agregado)
        {
            ListaDeUsuarios.Add(agregado);
        }

        [Fact]
        public void ConsultarUnUsuarioPorNombre_UnUsuario()
        {
            PruebasInfraestructura_Usuarios infraestructura_Usuarios = new PruebasInfraestructura_Usuarios();
            string nombreUsuario = "JesusOjeda";
            Usuario usuario = infraestructura_Usuarios.GetUsuarioPorNombre(nombreUsuario);
            Assert.NotNull(usuario);
        }
        [Fact]
        public void ConsultarUsuarioPorNombre_SinNombreDeUsuario_Exception()
        {
            PruebasInfraestructura_Usuarios infraestructura_Usuarios = new PruebasInfraestructura_Usuarios();
            string nombreUsuario = "";
            Usuario usuario = infraestructura_Usuarios.GetUsuarioPorNombre(nombreUsuario);
            Assert.Null(usuario);
        }
        [Fact]
        public void GuardarUnNuevoUsuario()
        {
            PruebasInfraestructura_Usuarios infraestructura_Usuarios = new PruebasInfraestructura_Usuarios();
            int id = 6;
            string nombre = "JesusCortez";
            string password = "JesusCortez";
            Usuario usuario = Usuario.Crear(id, nombre, password, DateTime.Today);
            infraestructura_Usuarios.Guardar(usuario);
            Assert.NotNull(infraestructura_Usuarios.GetUsuarioPorNombre(nombre));
        }
    }
}
