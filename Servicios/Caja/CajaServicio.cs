using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using IServicios.Comprobante.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.Caja
{
	public class CajaServicio : ICajaServicio
	{
		private readonly IUnidadDeTrabajo _unidadDeTrabajo;


		public CajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
		{
			_unidadDeTrabajo = unidadDeTrabajo;
		}

		public void Abrir(long usuarioId, decimal monto, DateTime fecha)
		{
			var nuevaCaja = new Dominio.Entidades.Caja
			{ 
			
				UsuarioAperturaId = usuarioId,
				FechaApertura = fecha,
				MontoInicial = monto,

				//-----------------------------//
				UsuarioCierreId = (long?) null,
				FechaCierre = (DateTime?) null,
				MontoCierre =(decimal?) null,
				//-----------------------------//
				TotalEntradaCheque=0m,
				TotalEntradaCtaCte=0m,
				TotalEntradaEfectivo=0m,
				TotalEntradaTarjeta=0m,
				TotalSalidaCheque=0m,
				TotalSalidaCtaCte=0m,
				TotalSalidaEfectivo=0m,
				TotalSalidaTarjeta=0m,
				
				//-----------------------------//
				EstaEliminado = false,

			
			};

			_unidadDeTrabajo.CajaRepositorio.Insertar(nuevaCaja);
			_unidadDeTrabajo.Commit();
		}

		public void Cerrar(long usuarioCierreId,DateTime fechaCierre,decimal montoCierre,CajaDto caja)
		{

			var entidad = _unidadDeTrabajo.CajaRepositorio.Obtener(caja.Id);
			if (entidad == null) throw new Exception("Ocurrio un Error al Obtener La Caja");

			entidad.UsuarioAperturaId = caja.UsuarioAperturaId;
			entidad.FechaApertura = caja.FechaApertura;
			entidad.MontoInicial = caja.MontoInicial;
			entidad.UsuarioCierreId = usuarioCierreId;
			entidad.FechaCierre = fechaCierre;
			entidad.MontoCierre = montoCierre;
			entidad.TotalEntradaCheque = caja.TotalEntradaCheque;
			entidad.TotalEntradaCtaCte = caja.TotalEntradaCtaCte;
			entidad.TotalEntradaEfectivo = caja.TotalEntradaEfectivo;
			entidad.TotalEntradaTarjeta = caja.TotalEntradaTarjeta;
			entidad.TotalSalidaCheque = caja.TotalSalidaCheque;
			entidad.TotalSalidaCtaCte = caja.TotalSalidaCtaCte;
			entidad.TotalSalidaEfectivo = caja.TotalSalidaEfectivo;
			entidad.TotalSalidaTarjeta = caja.TotalSalidaTarjeta;

			_unidadDeTrabajo.CajaRepositorio.Modificar(entidad);
			_unidadDeTrabajo.Commit();


		}
	

		public IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool filtroporfecha, DateTime fechadesde, DateTime fechahasta)
		{
			Expression<Func<Dominio.Entidades.Caja, bool>> filtro = x => !x.EstaEliminado 
			&& x.UsuarioApertura.Nombre.Contains(cadenaBuscar);

			var _fechadesde = new DateTime(fechadesde.Year, fechadesde.Month, fechadesde.Day, 0, 0, 0);
			var _fechahasta = new DateTime(fechahasta.Year, fechahasta.Month, fechahasta.Day, 23, 59, 59);
			
			if (filtroporfecha) 
			{
				filtro = filtro.And(x => x.FechaApertura >= _fechadesde && x.FechaApertura <= _fechahasta);
			}
			return _unidadDeTrabajo.CajaRepositorio.Obtener(filtro, "UsuarioApertura, UsuarioCierre")
				.Select(x => new CajaDto
				{
					Id = x.Id,
					//-------------------------------------//
					UsuarioAperturaId = x.UsuarioAperturaId,
					UsuarioApertura = x.UsuarioApertura.Nombre,
					FechaApertura = x.FechaApertura,
					MontoInicial = x.MontoInicial,
					//-------------------------------------//
					UsuarioCierreId = x.UsuarioCierreId,
					UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : "NO ASIGNADO",
					FechaCierre = x.FechaCierre,
					MontoCierre = x.MontoCierre,
					//-------------------------------------//
					TotalEntradaCheque = x.TotalEntradaCheque,
					TotalEntradaCtaCte = x.TotalEntradaCtaCte,
					TotalEntradaEfectivo = x.TotalEntradaEfectivo,
					TotalEntradaTarjeta = x.TotalEntradaTarjeta,
					//-------------------------------------//
					TotalSalidaCheque = x.TotalSalidaCheque,
					TotalSalidaEfectivo =x.TotalSalidaEfectivo,
					TotalSalidaCtaCte = x.TotalSalidaCtaCte,
					TotalSalidaTarjeta = x.TotalSalidaTarjeta,
					//-------------------------------------//
					Eliminado = x.EstaEliminado,
					


				}).ToList();
		}
		public CajaDto Obtener(long cajaId)
		{

			return _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.Id == cajaId, "UsuarioApertura, UsuarioCierre, DetalleCajas, Movimientos, Movimientos.Comprobante, Movimientos.Comprobante.Empleado")
				.Select(x => new CajaDto
				{
					Id = x.Id,
					//-------------------------------------//
					UsuarioAperturaId = x.UsuarioAperturaId,
					UsuarioApertura = x.UsuarioApertura.Nombre,
					FechaApertura = x.FechaApertura,
					MontoInicial = x.MontoInicial,
					//-------------------------------------//
					UsuarioCierreId = x.UsuarioCierreId,
					UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : "NO ASIGNADO",
					FechaCierre = x.FechaCierre,
					MontoCierre = x.MontoCierre,
					//-------------------------------------//
					TotalEntradaCheque = x.TotalEntradaCheque,
					TotalEntradaCtaCte = x.TotalEntradaCtaCte,
					TotalEntradaEfectivo = x.TotalEntradaEfectivo,
					TotalEntradaTarjeta = x.TotalEntradaTarjeta,
					//-------------------------------------//
					TotalSalidaCheque = x.TotalSalidaCheque,
					TotalSalidaEfectivo = x.TotalSalidaEfectivo,
					TotalSalidaCtaCte = x.TotalSalidaCtaCte,
					TotalSalidaTarjeta = x.TotalSalidaTarjeta,
					//-------------------------------------//
					Eliminado = x.EstaEliminado,
					Detalles = x.DetalleCajas
					.Select(d => new CajaDetalleDto
					{
						Monto = d.Monto,
						Eliminado = d.EstaEliminado,
						TipoPago = d.TipoPago,
					}).ToList(),
					Comprobantes = x.Movimientos.Select(c=>new ComprobanteCajaDto 
					{ 
						Fecha = c.Comprobante.Fecha,
						Vendedor =$"{ c.Comprobante.Empleado.Apellido} { c.Comprobante.Empleado.Nombre}",
						Numero = c.Comprobante.Numero,
						Total = c.Comprobante.Total,
						
						Eliminado = c.Comprobante.EstaEliminado,

					}).ToList(),


				}).FirstOrDefault();
		}

		public decimal ObtenerMontoCajaAnterior(long usuarioId)
		{
			var cajasUsuario = _unidadDeTrabajo.CajaRepositorio
			.Obtener(x => x.UsuarioAperturaId == usuarioId && x.UsuarioCierre != null);

			var ultimaCaja = cajasUsuario.Where(x => x.FechaApertura == cajasUsuario.Max(f => f.FechaApertura))
				.LastOrDefault();

			return ultimaCaja == null ? 0m : ultimaCaja.MontoCierre.Value;
		}

		public bool VerificarSiExisteCajaAbierta(long usuarioId)
		{
			return _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == usuarioId &&
			x.UsuarioCierreId == null).Any() ;
		}
	}
}
