using System;
using System.Collections.Generic;
using System.Text;
using ExPagos.DAL;
using ExPagos.DTOs;

namespace ExPagos.BIZ
{
    public class PagoBiz
    {
        public IEnumerable<PAGO> ListarConCliente(byte? autorizacion)
        {
            DALPago contexto = new DALPago();
            var resultado = contexto.ListarConCliente(autorizacion);
            return resultado;
        }
    }
}
