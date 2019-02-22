using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using ProyectoCartera.App_Start;
using ProyectoCartera.Models.ModeloClases.Seguridad;

namespace ProyectoCartera.Controllers
{
    /// <summary>
    /// Controlador utilizado para administrar 
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/Seguridad")]
    public class SeguridadController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Usuarios login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.Clave == "123456");
            if (isCredentialValid)
            {
                var token = TokenValidationHandler.GenerateTokenJwt(login.Usuario);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
