using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using PresentacionBase.Formularios;

namespace Presentacion.Core.FormaPago
{
    public partial class _00049_CobroDiferido : FormBase
    {
		private readonly IFacturaServicio _facturaServicio;

		private ComprobantePendienteDto  _comprobanteSeleccionado;
		public _00049_CobroDiferido(IFacturaServicio facturaServicio)
		{
			
			InitializeComponent();
			_facturaServicio = facturaServicio;

			_comprobanteSeleccionado = null;

			dgvGrillaPedientePago.DataSource = new List<ComprobantePendienteDto>();


			FormatearGrilla(dgvGrillaPedientePago);


			dgvGrillaDetalleComprobante.DataSource = new List<DetallePendienteDto>();

			FormatearGrillaDetalle(dgvGrillaDetalleComprobante);



			// Libreria para que refresque cada 60 seg la grilla
			// con las facturas que estan pendientes de pago.
			Observable.Interval(TimeSpan.FromSeconds(10))
				.ObserveOn(DispatcherScheduler.Current)
				.Subscribe(_ =>
				{
					dgvGrillaPedientePago.DataSource = null;
					dgvGrillaPedientePago.DataSource = _facturaServicio.ObtenerPedientesPago();

					FormatearGrilla(dgvGrillaPedientePago);
				});
			
		}




		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);

			dgv.Columns["Numero"].Visible = true;
			dgv.Columns["Numero"].Width = 100;
			dgv.Columns["Numero"].HeaderText = @"Numero Comprobante";

			dgv.Columns["ClienteApyNom"].Visible = true;
			dgv.Columns["ClienteApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["ClienteApyNom"].HeaderText = @"Cliente";

			dgv.Columns["MontoPagar"].Visible = true;
			dgv.Columns["MontoPagar"].Width = 150;
			dgv.Columns["MontoPagar"].HeaderText = @"Total";

			

		}

		private void dgvGrillaPedientePago_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvGrillaPedientePago.RowCount <= 0)
			{
				_comprobanteSeleccionado = null;
				return;
				   

			}

			_comprobanteSeleccionado =
				   (ComprobantePendienteDto)dgvGrillaPedientePago.Rows[e.RowIndex].DataBoundItem;
			if (_comprobanteSeleccionado != null) 
				{

					nudTotal.Value = _comprobanteSeleccionado.MontoPagar;

					dgvGrillaDetalleComprobante.DataSource = null;
					dgvGrillaDetalleComprobante.DataSource = _comprobanteSeleccionado.Items.ToList();

					FormatearGrillaDetalle(dgvGrillaDetalleComprobante);
				
				}
			
			
		}

		private void FormatearGrillaDetalle(DataGridView dgv)
		{
			for (int i = 0; i < dgv.ColumnCount; i++) 
			{
				dgv.Columns[i].Visible = false;
			
			}

			

			dgv.Columns["Descripcion"].Visible = true;
			dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Descripcion"].HeaderText = @"Articulo";

			dgv.Columns["PrecioStr"].Visible = true;
			dgv.Columns["PrecioStr"].Width = 100;
			dgv.Columns["PrecioStr"].HeaderText = @"Precio";

			dgv.Columns["Cantidad"].Visible = true;
			dgv.Columns["Cantidad"].Width = 150;
			dgv.Columns["Cantidad"].HeaderText = @"Cantidad";

		}

		private void dgvGrillaPedientePago_DoubleClick(object sender, EventArgs e)
		{
			var fFormaDepago = new _00044_FormaPago(_comprobanteSeleccionado);
			fFormaDepago.ShowDialog();

			if (fFormaDepago.RealizoVenta)
			{

				MessageBox.Show("Los datos se grabaron correctamente");

			}
		}
	}
}
