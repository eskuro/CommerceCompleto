using System;
using IServicios.BaseDto;

namespace IServicios.BajaArticulo.DTOs
{
    public class BajaArticuloDto : DtoBase
    {
        public long ArticuloId { get; set; }

        public string Articulo { get; set; }

        public long MotivoBajaId { get; set; }

        public string MotivoBaja { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string FechaStr => Fecha.ToShortDateString();

        public string Observacion { get; set; }
    }
}


