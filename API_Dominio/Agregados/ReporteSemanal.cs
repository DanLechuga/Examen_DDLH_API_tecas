using API_Comun;
using System;
namespace API_Dominio.Agregados
{
    public class ReporteSemanal  : Agregado
    {
        public int IdUsuario { get; set; }
        public string DiaDeLaSemana {   get; private set; }
        public DateTime FechaDeLaActividad { get; set; }
        public string Concepto { get; set; }
        public string Actividad { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int HorasTotales { get; set; }
        public ReporteSemanal(int id,int idUsuario,string diaDeLaSemana, DateTime fecaDeLaActividad, string concepto, string actividad, TimeSpan horaInicio,TimeSpan horaFin, int totalHoras)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.DiaDeLaSemana = diaDeLaSemana;
            this.FechaDeLaActividad = fecaDeLaActividad;
            this.Concepto = concepto;
            this.Actividad = actividad;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.HorasTotales = totalHoras;          
       }


        public static ReporteSemanal Crear(int id,int idUsuario, string diaDeLaSemana, DateTime fecaDeLaActividad, string concepto, string actividad, TimeSpan horaInicio, TimeSpan horaFin, int totalHoras)
        {
            return new ReporteSemanal(id, idUsuario,diaDeLaSemana,  fecaDeLaActividad,  concepto, actividad, horaInicio, horaFin, totalHoras);
        }
    }
}