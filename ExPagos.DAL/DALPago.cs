using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CreateDTOs;
using ExPagos.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExPagos.DAL
{
    public class DALPago
    {
        public IEnumerable<PAGO> ListarConCliente(byte? autorizacion)
        {
            PagosdbContext db = new PagosdbContext();
            db.ChangeTracker.LazyLoadingEnabled = false;
            var respuesta = (from pago in db.Pagoes
                            join cliente in db.Clientes on pago.IdCliente equals cliente.Id
                            where pago.Autorizacion == autorizacion
                            select new PAGO
                            {
                                 Id=pago.Id,
                                  Autorizacion=pago.Autorizacion,
                                  Comentario = pago.Comentario,
                                  Fecha = pago.Fecha,
                                  IdCliente = pago.IdCliente,
                                  Monto = pago.Monto,
                                  IdClienteNavigation = new CLIENTE
                                  {
                                      Pagoes = null,
                                       Id=cliente.Id,
                                       Comision = cliente.Comision,
                                       Estatus = cliente.Estatus,
                                       Nombre = cliente.Nombre
                                  }
                            }).ToList();
            return respuesta;
        }
    }
}
