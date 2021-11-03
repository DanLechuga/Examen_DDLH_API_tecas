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
    public class ServicioHistorial : IServicioHistorial
    {
        public IRepositorioHistorial RepositorioHistorial { get; set; }
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }

        public ServicioHistorial(IRepositorioHistorial repositorioHistorial,IRepositorioUsuarios repositorioUsuarios)
        {
            this.RepositorioHistorial = repositorioHistorial;
            this.RepositorioUsuarios = repositorioUsuarios;
        }
        public List<DTO_Historial> ConsultarTodoElHistorial(DTO_Usuario usuario)
        {
            List<DTO_Historial> listDTO = new List<DTO_Historial>();
            Usuario usuario1 = RepositorioUsuarios.GetUsuarioPorNombre(usuario.Username);
            List<Historial> ListaHistoriales = RepositorioHistorial.ConsultaTodosLosHistoriales(usuario1);
            foreach (var item in ListaHistoriales)
            {
                listDTO.Add(new DTO_Historial() { idHistorial = item.Id,
                                                    idCuenta = item.Cuenta_id,
                                                    idUsuario = item.Usuario_id,
                                                    descripcion_Movimiento = item.Descripcion_movimiento,
                                                    fecha_movimiento = item.Fecha_transaccion,
                                                    monto_movimiento = item.Monto_trasaccion
                });
            }
            return listDTO;
        }
    }
}
