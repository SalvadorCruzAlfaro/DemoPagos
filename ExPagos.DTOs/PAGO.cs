using System;
using System.Collections.Generic;

namespace ExPagos.DTOs
{
    public partial class PAGO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public byte? Autorizacion { get; set; }
        public string Comentario { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual CLIENTE IdClienteNavigation { get; set; }
    }
}
