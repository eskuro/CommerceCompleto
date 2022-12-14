using IServicios.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Comprobante.DTOs
{
	 public class DetallePendienteDto : DtoBase
	 {

		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public string PrecioStr => Precio.ToString("C");
		public decimal Cantidad { get; set; }

		public decimal SubTotal { get; set; }


	}


}
