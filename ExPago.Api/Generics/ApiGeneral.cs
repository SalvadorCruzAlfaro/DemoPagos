using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CreateDTOs;
using ExPagos.BIZ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExPago.Api.Generics
{
    public class ApiGeneral<Tipo> : ControllerBase where Tipo : class, new()
    {
        public GeneralBIZ<Tipo> context;

        public ApiGeneral()
        {
            var dbContext = new PagosdbContext();
            dbContext.ChangeTracker.LazyLoadingEnabled = false;
            context = new GeneralBIZ<Tipo>(dbContext);
        }


        [HttpPost("InsertarElemento")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Insertar([FromBody] Tipo entidad)
        {
            try
            {
                var respuesta = context.Insertar(entidad);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ActualizarElemento")]
        public IActionResult Actualizar([FromBody]Tipo entidad)
        {
            try
            {
                return Ok(context.Actualizar(entidad));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("EliminarElemento")]
        public IActionResult Eliminar([FromBody]Tipo entidad)
        {
            try
            {
                return Ok(context.Eliminar(entidad));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListaElementos")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(context.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
