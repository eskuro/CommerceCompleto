using Aplicacion.Constantes;
using IServicios.BaseDto;
using IServicios.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Comprobante.DTOs
{
	public class ComprobantePendienteDto : DtoBase
	{

		public ComprobantePendienteDto()
		{
			if (Items == null)
				Items = new List<DetallePendienteDto>();
		}



		public int Numero { get; set; }
		public string ClienteApyNom {get;set;	}
		public string  Dni {get;set;}
		public string Direccion { get; set; }
		public string Telefono { get;set; }

		public TipoComprobante	TipoComprobante { get; set; }
		public ClienteDto Cliente { get; set; }

		public decimal MontoPagar { get; set; }
		
		public string MontoPagarStr => MontoPagar.ToString("C");

		

		public DateTime Fecha { get; set; }

		public List<DetallePendienteDto> Items { get; set; }




	}
}
