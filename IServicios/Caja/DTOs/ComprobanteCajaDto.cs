using Aplicacion.Constantes;
using IServicios.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Caja.DTOs
{
	public class ComprobanteCajaDto : DtoBase
	{
		public string Vendedor { get; set; }

		public DateTime Fecha { get; set; }

		public string FechaStr => Fecha.ToShortDateString();


		public int Numero { get; set; }

		public decimal Total { get; set; }

		public string TotalStr => Total.ToString("C");


	}
}
