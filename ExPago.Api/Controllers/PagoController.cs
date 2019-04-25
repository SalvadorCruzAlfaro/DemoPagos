using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExPago.Api.Generics;
using ExPagos.BIZ;
using ExPagos.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExPago.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ApiGeneral<PAGO>
    {
        [HttpGet("ListaElementosConCliente")]
        public IActionResult Listar(byte? autorizacion)
        {
            try
            {
                PagoBiz contexto = new PagoBiz();
                var respuesta = contexto.ListarConCliente(autorizacion);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Buscar(int id)
        {
            try
            {
                var respuesta = context.Buscar(x=>x.Id==id);
                if (respuesta == null)
                    return NotFound();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("ActualizarElementoConFecha")]
        public IActionResult Actualizar([FromBody]PAGO entidad)
        {
            try
            {
                entidad.Fecha = DateTime.Now;
                return Ok(context.Actualizar(entidad));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}