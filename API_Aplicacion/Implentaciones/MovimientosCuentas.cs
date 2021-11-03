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
    public class MovimientosCuentas : IMovimientosCuentas
    {
        public IRepositorioCuentas RepositorioCuentas { get; set; }
        public IRepositorioUsuarios RepositorioUsuarios  { get; set; }
        public IRepositorioHistorial RepositorioHistorial { get; set; }
        public MovimientosCuentas(IRepositorioCuentas repositorioCuentas, IRepositorioUsuarios repositorioUsuarios, IRepositorioHistorial repositorioHistorial)
        {
            this.RepositorioCuentas = repositorioCuentas;
            this.RepositorioUsuarios = repositorioUsuarios;
            this.RepositorioHistorial = repositorioHistorial;
        }
        public List<DTO_Cuenta> ConsultaTodasLasCuentas(DTO_Usuario dtousuario)
        {            
            List<DTO_Cuenta> listaDtos = new List<DTO_Cuenta>();
            Usuario usuario = RepositorioUsuarios.GetUsuarioPorNombre(dtousuario.Username);
            List<Cuenta> ListaCuentas = RepositorioCuentas.GetCuentas(usuario);
            foreach (var item in ListaCuentas)
            {
                listaDtos.Add(new DTO_Cuenta(item.Id,item.DescripcionCuenta,item.SaldoCuenta));
            }
            return listaDtos;
        }

        public DTO_Cuenta ConsultarCuentaPorId(int idCuenta,string nombreU)
        {
            Usuario usuario = RepositorioUsuarios.GetUsuarioPorNombre(nombreU);
            Cuenta cuenta = RepositorioCuentas.ConsultarPorId(idCuenta,usuario);
            DTO_Cuenta dTO = new DTO_Cuenta(cuenta.Id, cuenta.DescripcionCuenta, cuenta.SaldoCuenta);
            return dTO;
        }

        public void PutCuenta(DTO_ActualizacionCuenta actualizacionCuenta)
        {
            Usuario usuario = RepositorioUsuarios.GetUsuarioPorNombre(actualizacionCuenta.NombreUsuario);
            Cuenta cuenta = RepositorioCuentas.ConsultarPorId(actualizacionCuenta.Id_Cuenta, usuario);

            if (actualizacionCuenta.Movimiento== "Deposito")
            {
                double suma = actualizacionCuenta.Saldo + actualizacionCuenta.MontoAMiniobrar;
                Cuenta cuentaactualizar = Cuenta.Crear(cuenta.Id, cuenta.DescripcionCuenta, suma,usuario.Id);
                RepositorioCuentas.Guardar(cuentaactualizar);
            }else if(actualizacionCuenta.Movimiento == "Retiro")
            {
                double resta = actualizacionCuenta.Saldo - actualizacionCuenta.MontoAMiniobrar;
                Cuenta cuentaactual = Cuenta.Crear(cuenta.Id, cuenta.DescripcionCuenta, resta,usuario.Id);
                RepositorioCuentas.Guardar(cuentaactual);
            }
            
            Historial historial = Historial.Crear(0,cuenta.Id,usuario.Id,DateTime.Now,actualizacionCuenta.MontoAMiniobrar,actualizacionCuenta.Movimiento);
            RepositorioHistorial.Guardar(historial);
        }
    }
}
