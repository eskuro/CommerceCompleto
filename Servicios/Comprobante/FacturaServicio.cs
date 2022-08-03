 using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Comprobante
{
	public class FacturaServicio :ComprobanteServicio , IFacturaServicio
	{
		public FacturaServicio(IUnidadDeTrabajo unidadDeTrabajo)
			: base(unidadDeTrabajo)
		{
		}

		public IEnumerable<ComprobantePendienteDto> ObtenerPedientesPago()
		{


			return _unidadDeTrabajo.FacturaRepositorio
				.Obtener(x => !x.EstaEliminado && x.Estado == Aplicacion.Constantes.Estado.Pendiente, "Cliente, DetalleComprobantes")
				.Select(x => new ComprobantePendienteDto
				{
					Id = x.Id,
					Cliente = new ClienteDto 
					{ 
							Id = x.Cliente.Id,

							Dni = x.Cliente.Dni,
							Nombre = x.Cliente.Nombre,
							Apellido = x.Cliente.Apellido,
							Telefono =x.Cliente.Telefono,
							Direccion = x.Cliente.Direccion,
							Eliminado = x.Cliente.EstaEliminado,
							ActivarCtaCte = x.Cliente.ActivarCtaCte,
							TieneLimiteCompra = x.Cliente.TieneLimiteCompra,
							MontoMaximoCtaCte = x.Cliente.MontoMaximoCtaCte,
							


					},
					ClienteApyNom = $"{x.Cliente.Apellido} {x.Cliente.Nombre}",
					Fecha=x.Fecha,
					Direccion = x.Cliente.Direccion,
					Dni = x.Cliente.Dni,
					Telefono =x.Cliente.Telefono,
					MontoPagar = x.Total,
					Numero = x.Numero,
					TipoComprobante = x.TipoComprobante,
					Eliminado = x.EstaEliminado,
					Items=x.DetalleComprobantes.Select(d=> new DetallePendienteDto 
					{ 
						Id = d.Id,
						Descripcion = d.Descripcion,
						Cantidad = d.Cantidad,
						Precio =d.Precio,
						SubTotal = d.SubTotal,
						Eliminado = d.EstaEliminado,

							
					
					}).ToList(),

				})
				.OrderByDescending(x => x.Fecha)
				.ToList();
		}
	}
}
