using API_Aplicacion.DTO;
using API_Aplicacion.Interfaces;
using API_Dominio.Agregados;
using API_Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasUnitariasExamen.AplicacionPruebas
{
   public class PruebasUnitarias_Aplicacion_ValidacionDeUsuarios : IValidacionUsuarios
    {
        [Fact]
        public void CrearValidacionDeUsuarios()
        {
            DTO_Usuario dTO_Usuario = new DTO_Usuario("DanLechuga","DanLechuga");
            ValidarUsuario(dTO_Usuario);
            

        }
        [Fact]
        public void CrearValidacionUsuario_UsuarioSinNombre_Exception()
        {
            DTO_Usuario dTO_Usuario = new DTO_Usuario("","DanLechuga");
            Assert.Throws<Exception>(() => { ValidarUsuario(dTO_Usuario); });
            
        }
        [Fact]
        public void CrearValidacionesUsuarios_UsuarionSinContraseña_Exception()
        {
            DTO_Usuario dTO_Usuario = new DTO_Usuario("DanLechuga","");
            Assert.Throws<Exception>(() => { ValidarUsuario(dTO_Usuario); });
        }

        public void ValidarUsuario(DTO_Usuario _Usuario)
        {
            InfraestructuraPruebas.PruebasInfraestructura_Usuarios usuarios = new InfraestructuraPruebas.PruebasInfraestructura_Usuarios(); 
            if (_Usuario == null) throw new Exception("No se puede usar valores nulos");
            if (string.IsNullOrEmpty(_Usuario.Username)) throw new Exception("No se aceptan valores vacios");
            if (string.IsNullOrEmpty(_Usuario.Password)) throw new Exception("No se aceptan valores vacios");
            Usuario usuarioConsultado = usuarios.GetUsuarioPorNombre(_Usuario.Username);
            Password password = Password.Crear(_Usuario.Password);
            if (!(usuarioConsultado.Password.Contrasenia == password.Contrasenia)) throw new Exception("Contraseña Invalida");
        }
    }
}
