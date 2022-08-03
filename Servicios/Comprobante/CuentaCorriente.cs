using Aplicacion.Constantes;
using Dominio.Entidades;
using IServicios.Comprobante.DTOs;
using IServicios.Configuracion;
using IServicios.Contador;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
	public class CuentaCorriente :Comprobante
	{

		private readonly IContadorServicio _contadorServicio;
		private readonly IConfiguracionServicio _configuracionServicio;

		public CuentaCorriente()
		: base()
		{
			_contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
			_configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
		}


		public override long Insertar(ComprobanteDto comprobante)
		{


			using (var tran = new TransactionScope())
			{
				try
				{
					int numeroComprobante = 0;


					var cajaActual = _unidadDeTrabajo.CajaRepositorio.Obtener
				   (x => x.UsuarioAperturaId == comprobante.UsuarioId
				   && x.UsuarioCierreId == null, "DetalleCajas").FirstOrDefault();
					if (cajaActual == null)
						throw new Exception("Ocurrio un error al obtener la Caja");

					//cajaActual.DetalleCajas = new List<DetalleCaja>();
					var ctacteComprobanteDto = (CuentaCorrienteComprobanteDto)comprobante;
					
					
				CuentaCorrienteCliente _ctacteNueva = new CuentaCorrienteCliente();

				
						numeroComprobante = _contadorServicio.ObtenerSiguienteNumeroComprobante(comprobante.TipoComprobante);

						_ctacteNueva = new CuentaCorrienteCliente
						{
							
							ClienteId = ctacteComprobanteDto.ClienteId,
							Descuento = ctacteComprobanteDto.Descuento,
							EmpleadoId = ctacteComprobanteDto.EmpleadoId,
							
							Fecha = ctacteComprobanteDto.Fecha,
							Iva105 = ctacteComprobanteDto.Iva105,
							Iva21 = ctacteComprobanteDto.Iva21,
							Numero = numeroComprobante,
							SubTotal = ctacteComprobanteDto.SubTotal,
							Total = ctacteComprobanteDto.Total,
							
							TipoComprobante = ctacteComprobanteDto.TipoComprobante,
							UsuarioId = ctacteComprobanteDto.UsuarioId,
							DetalleComprobantes = new List<DetalleComprobante>(),
							Movimientos = new List<Movimiento>(),
							FormaPagos = new List<FormaPago>(),
							EstaEliminado = false
						};
						
	
							_ctacteNueva.Movimientos.Add(new Movimiento
							{
								ComprobanteId = _ctacteNueva.Id,
								CajaId = cajaActual.Id,
								Fecha = ctacteComprobanteDto.Fecha,
								Monto = ctacteComprobanteDto.Total,
								UsuarioId = ctacteComprobanteDto.UsuarioId,
								TipoMovimiento = TipoMovimiento.Ingreso,
								Descripcion = $"Pago Cta Cte-{ ctacteComprobanteDto.TipoComprobante.ToString() }-Nro { numeroComprobante }",
								EstaEliminado = false
							});

						
						foreach (var fp in ctacteComprobanteDto.FormasDePagos)
						{
							
								
									var fpCtaCTe = (FormaPagoCtaCteDto)fp;
									_ctacteNueva.FormaPagos.Add(new FormaPagoCtaCte
									{
										ComprobanteId = _ctacteNueva.Id,
										Monto = fpCtaCTe.Monto,
										TipoPago = TipoPago.CtaCte,
										ClienteId = fpCtaCTe.ClienteId,
										EstaEliminado = false
									});
									_ctacteNueva.Movimientos.Add(new MovimientoCuentaCorriente
									{
										ComprobanteId = _ctacteNueva.Id,
										CajaId = cajaActual.Id,
										Fecha = ctacteComprobanteDto.Fecha,
										Monto = fpCtaCTe.Monto,
										UsuarioId = ctacteComprobanteDto.UsuarioId,
										TipoMovimiento = TipoMovimiento.Ingreso,
										Descripcion = $"Pago Cta Cte-{ ctacteComprobanteDto.TipoComprobante.ToString() }-Nro { numeroComprobante }",
										ClienteId = fpCtaCTe.ClienteId,
										EstaEliminado = false
									});
									cajaActual.TotalEntradaCtaCte +=
									fpCtaCTe.Monto;
									cajaActual.DetalleCajas.Add(new DetalleCaja
									{
										CajaId = cajaActual.Id,

										Monto = fpCtaCTe.Monto,
										TipoPago = TipoPago.CtaCte
									});

						_unidadDeTrabajo.CajaRepositorio.Modificar(cajaActual);
						}
						



						_unidadDeTrabajo.CuentaClienteCorrienteRepositorio.Insertar(_ctacteNueva);

					
						_unidadDeTrabajo.Commit();
						tran.Complete();
						return 0;



				}

				catch
				{

					tran.Dispose();
					throw new Exception("Ocurrio un error grave al grabar la Factura");

				}

			}
		}
	}
}
