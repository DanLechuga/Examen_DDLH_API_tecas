using API_Aplicacion.DTO;
using API_Aplicacion.Interfaces;
using Examen_DDLH_API_tecas.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_DDLH_API_tecas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistorialController : ControllerBase
    {
        public IServicioHistorial ServicioHistorial { get; set; }
        public HistorialController(IServicioHistorial servicioHistorial)
        {
            this.ServicioHistorial = servicioHistorial;
        }

        [HttpGet]
        [Route("/GetHistorial")]
        public List<ModeloHistorial> GetHistorial(string nombreUsuario)
        {
            try
            {
                List<ModeloHistorial> modelo = new List<ModeloHistorial>();
                DTO_Usuario dTO_Usuario = new DTO_Usuario(nombreUsuario, "");
                List<DTO_Historial> listaDTO = ServicioHistorial.ConsultarTodoElHistorial(dTO_Usuario);
                foreach (var item in listaDTO)
                {
                    modelo.Add(new ModeloHistorial() { idUsuario = item.idUsuario,idCuenta = item.idCuenta,descripcion_Movimiento = item.descripcion_Movimiento,fecha_movimiento = item.fecha_movimiento, monto_movimiento = item.monto_movimiento, idHistorial = item.idHistorial});
                }

                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
