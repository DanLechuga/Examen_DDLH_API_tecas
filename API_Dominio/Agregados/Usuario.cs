using API_Comun;
using API_Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Dominio.Agregados
{
   public class Usuario : Agregado
    {
        public string Username { get; set; }
        public Password Password { get; set; }
        private DateTime FechaCreacion { get; set; }
        private Usuario(int Id, string username, Password password, DateTime fechaCreacion)
        {
            this.Id = Id;
            if (string.IsNullOrEmpty(username)) throw new Exception("No se pueden usar valores vacios para el campo dado");
            this.Username = username;
            this.Password = password ?? throw new Exception("No se pueden usar valores vacios para el campo dado");
            this.FechaCreacion = fechaCreacion; 
        }
        public static Usuario Crear(int id,string username, string password,DateTime fechaCreacion)
        {
            return new Usuario(id,username, Password.Crear(password), fechaCreacion);
        }
    }
}
