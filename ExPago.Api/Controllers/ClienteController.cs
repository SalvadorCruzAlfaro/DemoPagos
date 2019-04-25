using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExPago.Api.Generics;
using ExPagos.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExPago.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ApiGeneral<CLIENTE>
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Buscar(int id)
        {
            try
            {
                var respuesta = context.Buscar(x => x.Id == id);
                if (respuesta == null)
                    return NotFound();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}