using API_Comun;
using API_Dominio.Agregados;
using API_Infraestructura.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Implementaciones
{
    public class DTO_Historial
    {
        public int historial_id { get; set; }
        public int cuenta_id { get; set; }
        public int usuario_id { get; set; }
        public string descripcion_movimiento { get; set; }
        public DateTime fecha_transaccion { get; set; }
        public double monto_trasaccion { get; set; }
    }
    public class RepositorioHistorial : IRepositorioHistorial
    {
        public IUnidadDetrabajo UnidadDetrabajo { get; set; }
        public RepositorioHistorial(IUnidadDetrabajo unidadDetrabajo)
        {
            this.UnidadDetrabajo = unidadDetrabajo;
        }
        public List<Historial> ConsultaTodosLosHistoriales(Usuario usuario)
        {
            List<Historial> listaH = new();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario",usuario.Id,System.Data.DbType.Int32);
            CommandDefinition command = new("SP_ConsultarHistorialPorUsuario",parameters,commandTimeout:0,commandType:System.Data.CommandType.StoredProcedure);
            List<DTO_Historial> listaDtos = (List<DTO_Historial>)UnidadDetrabajo.SqlConnection.Query<DTO_Historial>(command);
            foreach (var item in listaDtos)
            {
                listaH.Add(Historial.Crear(item.historial_id,item.cuenta_id,item.usuario_id,item.fecha_transaccion,item.monto_trasaccion,item.descripcion_movimiento));
            }
            
            return listaH;
        }

        public void Guardar(Historial agregado)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cuentaid", agregado.Cuenta_id, System.Data.DbType.Int32);
                parameters.Add("@usuarioid", agregado.Usuario_id, System.Data.DbType.Int32);
                parameters.Add("@monto", agregado.Monto_trasaccion);
                parameters.Add("@movimiento", agregado.Descripcion_movimiento, System.Data.DbType.String);
                CommandDefinition command = new CommandDefinition("SP_IngresarHistorial", parameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                UnidadDetrabajo.SqlConnection.Execute(command);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
