using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Banco
{
	public interface IBancoServicio : Base.IServicio
	{

		bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
	}
}
