using System;

namespace API_Aplicacion.DTO
{
    public class DTO_ReporteSemanal
    {
        public int IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public string DiaDeLaSemana { get; set; }
        public DateTime FechaIngresoActividad { get; set; }
        public string Concepto { get; set; }
        public string Actividad { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int TotalDeHoras { get; set; }
    }
}