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
    public class DTO_Cuenta
    {
        public int cuenta_id { get; set; }
        public int cuenta_usuarioId { get; set; }
        public string cuenta_descripcion { get; set; }
        public double cuenta_saldo { get; set; }
    }
    public class RepositorioCuenta : IRepositorioCuentas
    {
        public IUnidadDetrabajo UnidadDetrabajo { get; set; }
        public RepositorioCuenta(IUnidadDetrabajo unidadDetrabajo)
        {
            this.UnidadDetrabajo = unidadDetrabajo;
        }
        public List<Cuenta> GetCuentas(Usuario usuario)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id_usuario", usuario.Id, dbType: System.Data.DbType.Int32);
            CommandDefinition command = new CommandDefinition("SP_ConsultaCuentas",parameters,commandType:System.Data.CommandType.StoredProcedure,commandTimeout: 0);
            IEnumerable<DTO_Cuenta> listaDTO = this.UnidadDetrabajo.SqlConnection.Query<DTO_Cuenta>(command);
            List<Cuenta> listaCuentas = new List<Cuenta>();
            foreach (var item in listaDTO)
            {
                listaCuentas.Add(Cuenta.Crear(item.cuenta_id,item.cuenta_descripcion,item.cuenta_saldo,item.cuenta_usuarioId));
            }
            return listaCuentas;
        }

        public void Guardar(Cuenta agregado)
        {
            DynamicParameters parameters = new();
            parameters.Add("@idCuenta",agregado.Id);
            parameters.Add("@idUsuario",agregado.IdUsuario);
            parameters.Add("@monto", agregado.SaldoCuenta);
            CommandDefinition command = new("SP_ActualizarCuenta",parameters,commandTimeout:0,commandType:System.Data.CommandType.StoredProcedure);
            UnidadDetrabajo.SqlConnection.Execute(command);
        }

        public Cuenta ConsultarPorId(int idCuenta,Usuario usuario)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id_cuenta",idCuenta,dbType:System.Data.DbType.Int32);
                parameters.Add("@id_Usuario",usuario.Id,dbType:System.Data.DbType.Int32);
                CommandDefinition command = new CommandDefinition("SP_ConsultarCuentaPorId", commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure, parameters: parameters);
                DTO_Cuenta dTO = UnidadDetrabajo.SqlConnection.QueryFirstOrDefault<DTO_Cuenta>(command);
                return Cuenta.Crear(dTO.cuenta_id, dTO.cuenta_descripcion, dTO.cuenta_saldo,dTO.cuenta_usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
