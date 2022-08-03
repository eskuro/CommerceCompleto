using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Tarjeta
{
	public interface ITarjetaServicio : Base.IServicio
	{


		bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
	}
}
