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
    public class DTO_Usuario
    {
        public int usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_password { get; set; }
        public DateTime usuario_fechaCreacion { get; set; }
    }
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public IUnidadDetrabajo UnidadDetrabajo { get; set; }
        public RepositorioUsuarios(IUnidadDetrabajo unidadDetrabajo)
        {
            this.UnidadDetrabajo = unidadDetrabajo;
        }
        public Usuario GetUsuarioPorNombre(string nombre)
        {
            try
            {
                Usuario usuario = null;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nombreUsuario",nombre,dbType:System.Data.DbType.String);
                CommandDefinition command = new CommandDefinition("SP_ConsultarUsuario",parameters,commandType: System.Data.CommandType.StoredProcedure,commandTimeout:0);
               DTO_Usuario dTO_Usuario =  this.UnidadDetrabajo.SqlConnection.QueryFirstOrDefault<DTO_Usuario>(command);
                if (dTO_Usuario == null) throw new Exception("No se encontro Usuario para el nombre ingresado");
                usuario = Usuario.Crear(dTO_Usuario.usuario_id, dTO_Usuario.usuario_nombre, dTO_Usuario.usuario_password, dTO_Usuario.usuario_fechaCreacion);
                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Guardar(Usuario agregado)
        {
            throw new NotImplementedException();
        }
    }
}
