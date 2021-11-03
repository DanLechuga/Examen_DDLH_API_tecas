using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTO
{
   public class DTO_Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DTO_Usuario(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
