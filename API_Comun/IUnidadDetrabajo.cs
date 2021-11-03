using System;
using System.Data.SqlClient;

namespace API_Comun
{
    public interface IUnidadDetrabajo:IDisposable
    {
        public SqlConnection SqlConnection { get; set; }
        public SqlTransaction SqlTransaction { get; set; }
        public SqlCommand SqlCommand { get; set; }
        void SaveChanges();
       
    }
}
