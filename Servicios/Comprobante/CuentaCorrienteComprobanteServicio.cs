using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Comprobante
{
	public class CuentaCorrienteComprobanteServicio : ComprobanteServicio , ICuentaCorrienteComprobanteServicio
	{
		public CuentaCorrienteComprobanteServicio(IUnidadDeTrabajo unidadDeTrabajo) 
			: base(unidadDeTrabajo)
		{

			
		}

		
	}
}
