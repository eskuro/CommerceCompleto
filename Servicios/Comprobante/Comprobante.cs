using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante.DTOs;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Comprobante
{
	public class Comprobante
	{

		protected readonly IUnidadDeTrabajo _unidadDeTrabajo;
		public Comprobante()
		{
			_unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
		}
		public virtual long Insertar(ComprobanteDto comprobante)
		{
			return 0;
		}

	}
}
