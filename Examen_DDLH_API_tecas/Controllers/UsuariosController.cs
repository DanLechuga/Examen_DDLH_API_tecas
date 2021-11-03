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
    public class UsuariosController : ControllerBase
    {
        public IValidacionUsuarios ValidacionUsuarios { get; set; }
        public UsuariosController(IValidacionUsuarios validacionUsuarios)
        {
            this.ValidacionUsuarios = validacionUsuarios;
        }
        [HttpPost]
        [Route("/ValidarUsuario")]
        public JsonResult ValidarUsuario(ModeloUsuario modeloUsuario)
        {
            JsonResult result = new JsonResult(true);
            result.StatusCode = 403;
            try
            {
                DTO_Usuario dTO_Usuario = new DTO_Usuario(modeloUsuario.Username, modeloUsuario.Password);
                this.ValidacionUsuarios.ValidarUsuario(dTO_Usuario);
                result.StatusCode = 200;
                result.Value = true;
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = 500;
            }
            return result;
        }
        
    }
}
