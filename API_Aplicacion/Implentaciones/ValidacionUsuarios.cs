using API_Aplicacion.DTO;
using API_Aplicacion.Interfaces;
using API_Dominio.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implentaciones
{
    public class ValidacionUsuarios : IValidacionUsuarios
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public ValidacionUsuarios(IRepositorioUsuarios repositorioUsuarios)
        {
            this.RepositorioUsuarios = repositorioUsuarios;
        }
        public void ValidarUsuario(DTO_Usuario _Usuario)
        {
            if (_Usuario == null) throw new Exception("No se puede utilizar objetos nulos");
            Usuario usuarioConsultado = this.RepositorioUsuarios.GetUsuarioPorNombre(_Usuario.Username);
            if (usuarioConsultado == null) throw new Exception("No se encontro usuario para el nombre dado");
            if (usuarioConsultado.Password.Contrasenia != _Usuario.Password) throw new Exception("Contraseña invalida");
           
        }
    }
}
