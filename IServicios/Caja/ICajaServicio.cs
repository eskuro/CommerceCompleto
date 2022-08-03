using IServicios.Caja.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Caja
{
	public interface ICajaServicio
	{

		bool VerificarSiExisteCajaAbierta(long usuarioId);

		IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool filtroporfecha, DateTime fechadesde, DateTime fechahasta);

		CajaDto Obtener(long cajaId);

		decimal ObtenerMontoCajaAnterior(long usuarioId);

		void Abrir(long usuarioId,decimal monto,DateTime fecha);

		void Cerrar(long usuarioCierreId, DateTime fechaCierre, decimal montoCierre, CajaDto caja);
	
	}
}
