using API_Aplicacion.DTO;
using API_Aplicacion.Interfaces;
using Examen_DDLH_API_tecas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_DDLH_API_tecas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportesSemanalesController : ControllerBase
    {
        public IServicioReportesSemanales ServicioReportesSemanales { get; set; }
        public ReportesSemanalesController(IServicioReportesSemanales servicioReportesSemanales)
        {
            this.ServicioReportesSemanales = servicioReportesSemanales;
        }

        [HttpGet]
        [Route("/GetReportes")]
        public List<ModeloReporte> GetModeloReportes(string nombreUsario)
        {
            List<ModeloReporte> modelo = new();
            DTO_Usuario usuario = new(nombreUsario, "");
            List<DTO_ReporteSemanal> listaDTO = ServicioReportesSemanales.GetReportesSemanalaes(usuario);
            foreach (var item in listaDTO)
            {
                modelo.Add(new ModeloReporte() {IdReporte = item.IdReporte, IdUsuario = item.IdUsuario,Actividad = item.Actividad, Concepto = item.Concepto, FechaIngresoActividad = item.FechaIngresoActividad, DiaDeLaSemana = item.DiaDeLaSemana, HoraFin = item.HoraFin, HoraInicio =item.HoraInicio,TotalDeHoras = item.TotalDeHoras });
            }

            return modelo;
        }
    }
}
