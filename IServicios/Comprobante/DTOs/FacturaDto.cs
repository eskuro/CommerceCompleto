using Aplicacion.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Comprobante.DTOs
{
	public class FacturaDto : ComprobanteDto
	{
		public long ClienteId { get; set; }
		public long PuestoTrabajoId { get; set; }
		public Estado Estado { get; set; }

		public bool VieneVentas { get; set; }


	}
}
