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
    public class CuentasController : ControllerBase
    {
        public IMovimientosCuentas MovimientosCuentas { get; set; }
        public CuentasController(IMovimientosCuentas movimientosCuentas)
        {
            this.MovimientosCuentas = movimientosCuentas;
        }


       [HttpGet]   
       [Route("/GetCuentas")]
        public List<ModeloCuenta> GetCuentas(string nombreUsario)
        {
            try
            {
                List<ModeloCuenta> modeloCuentas = new List<ModeloCuenta>();
                DTO_Usuario dTO_Usuario = new DTO_Usuario(nombreUsario, "");
                List<DTO_Cuenta> listaDTO = MovimientosCuentas.ConsultaTodasLasCuentas(dTO_Usuario);                
                foreach (var item in listaDTO)
                {                    
                    modeloCuentas.Add(new(item.id_cuenta, item.DescripcionCuenta, item.saldo));
                }
                
                return modeloCuentas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("/GetCuenta")]
        public ModeloCuenta GetCuenta(int idCuenta,string nombreU)
        {
            ModeloCuenta modelo = null;
            try
            {
                DTO_Cuenta cuenta = MovimientosCuentas.ConsultarCuentaPorId(idCuenta,nombreU);
                modelo = new ModeloCuenta(cuenta.id_cuenta, cuenta.DescripcionCuenta, cuenta.saldo);
                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        [HttpPost]
        [Route("/PostCuenta")]
        public void PostCuenta(ModeloRetiro modeloRetiro)
        {
            try
            {
                DTO_ActualizacionCuenta actualizacionCuenta = new DTO_ActualizacionCuenta()
                {
                    Id_Cuenta = modeloRetiro.Id_Cuenta,
                    Movimiento = modeloRetiro.Movimiento,
                    Saldo = modeloRetiro.Saldo,
                    NombreUsuario = modeloRetiro.NombreUsuario,
                    MontoAMiniobrar = modeloRetiro.CantidadAManiaobrar
                };
                this.MovimientosCuentas.PutCuenta(actualizacionCuenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

    }
}
