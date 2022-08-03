using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
	public partial class VerComprobantes : FormBase
	{
		public VerComprobantes(List<ComprobanteCajaDto> comprobantes)
		{
			InitializeComponent();

			dgvGrilla.DataSource = comprobantes.ToList();

			FormatearGrilla(dgvGrilla);
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);


			dgv.Columns["Vendedor"].Visible = true;
			dgv.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Vendedor"].HeaderText = @"Vendedor";


			dgv.Columns["FechaStr"].Visible = true;
			dgv.Columns["FechaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["FechaStr"].HeaderText = @"Fecha";

			dgv.Columns["TotalStr"].Visible = true;
			dgv.Columns["TotalStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["TotalStr"].HeaderText = @"Total";




			dgv.Columns["EliminadoStr"].Visible = true;
			dgv.Columns["EliminadoStr"].Width = 100;
			dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
			dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
	}
}
