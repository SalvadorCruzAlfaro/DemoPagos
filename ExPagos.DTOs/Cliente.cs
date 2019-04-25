using System;
using System.Collections.Generic;

namespace ExPagos.DTOs
{
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            Pagoes = new HashSet<PAGO>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Comision { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<PAGO> Pagoes { get; set; }
    }
}
