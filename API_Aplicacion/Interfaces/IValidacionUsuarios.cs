using API_Aplicacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Interfaces
{
   public interface IValidacionUsuarios
    {
        void ValidarUsuario(DTO_Usuario _Usuario);
    }
}
