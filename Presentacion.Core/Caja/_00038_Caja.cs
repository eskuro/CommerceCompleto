using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
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
    public partial class _00038_Caja : FormBase
    {
        private readonly ICajaServicio _cajaServicio;
        private CajaDto _cajaSeleccionada;
        public _00038_Caja(ICajaServicio cajaServicio)
        {


            InitializeComponent();

            _cajaServicio = cajaServicio;
            _cajaSeleccionada = null;

        }

		private void btnAbrirCaja_Click(object sender, EventArgs e)
		{
            if (!_cajaServicio.VerificarSiExisteCajaAbierta(Identidad.UsuarioId))
            {
                var fAbrirCaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();

                fAbrirCaja.ShowDialog();

                ActualizarDatos(string.Empty,false,DateTime.Now,DateTime.Now);
            }
            else
            {
                MessageBox.Show($"Ya se encuentra una caja abierta para el usuario {Identidad.Apellido} {Identidad.Nombre}");
            
            }
		}

		private void ActualizarDatos(string cadenaBuscar,bool filtroporfecha,DateTime fechadesde,DateTime fechahasta)
		{
            dgvGrilla.DataSource = _cajaServicio.Obtener(cadenaBuscar, filtroporfecha, fechadesde, fechahasta);

            FormatearGrilla(dgvGrilla);


        }

		private void chkActFecha_CheckedChanged(object sender, EventArgs e)
		{
            dtpFechaDesde.Enabled = chkActFecha.Checked;
            dtpFechaHasta.Enabled = chkActFecha.Checked;

            if (chkActFecha.Checked) 
            {
                dtpFechaDesde.Value = DateTime.Now;
                dtpFechaHasta.Value = DateTime.Now;
            }

		}

		private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
		{
            dtpFechaHasta.Value = dtpFechaDesde.Value;
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            ActualizarDatos(!string.IsNullOrEmpty(txtBuscar.Text)? txtBuscar.Text : string.Empty, chkActFecha.Checked,dtpFechaDesde.Value, dtpFechaHasta.Value);
        }

		private void _00038_Caja_Load(object sender, EventArgs e)
		{
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
            txtBuscar.Clear();
            ActualizarDatos(!string.IsNullOrEmpty(txtBuscar.Text) ? txtBuscar.Text : string.Empty, chkActFecha.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
        }
		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);

            
            dgv.Columns["UsuarioApertura"].Visible = true;
            dgv.Columns["UsuarioApertura"].Width = 150;
            dgv.Columns["UsuarioApertura"].HeaderText = @"Usu. Apertura";
            dgv.Columns["UsuarioApertura"].DisplayIndex = 0;

            dgv.Columns["FechaAperturaStr"].Visible = true;
            dgv.Columns["FechaAperturaStr"].Width = 70;
            dgv.Columns["FechaAperturaStr"].HeaderText = @"Fec. Apertura";
            dgv.Columns["FechaAperturaStr"].DisplayIndex = 1;

            dgv.Columns["MontoInicialStr"].Visible = true;
            dgv.Columns["MontoInicialStr"].Width = 60;
            dgv.Columns["MontoInicialStr"].HeaderText = @"Monto Apertura";
            dgv.Columns["MontoInicialStr"].DisplayIndex = 2;

            dgv.Columns["UsuarioCierre"].Visible = true;
            dgv.Columns["UsuarioCierre"].Width = 150;
            dgv.Columns["UsuarioCierre"].HeaderText = @"Usu. Cierre";
            dgv.Columns["UsuarioCierre"].DisplayIndex = 3;

            dgv.Columns["FechaCierreStr"].Visible = true;
            dgv.Columns["FechaCierreStr"].Width = 70;
            dgv.Columns["FechaCierreStr"].HeaderText = @"Fec. Cierre";
            dgv.Columns["FechaCierreStr"].DisplayIndex = 4;

            dgv.Columns["MontoCierreStr"].Visible = true;
            dgv.Columns["MontoCierreStr"].Width = 60;
            dgv.Columns["MontoCierreStr"].HeaderText = @"Monto Cierre";
            dgv.Columns["MontoCierreStr"].DisplayIndex = 5;
            //--------------------------------------------------------//
            dgv.Columns["TotalEntradaEfectivoStr"].Visible = true;
            dgv.Columns["TotalEntradaEfectivoStr"].Width = 60;
            dgv.Columns["TotalEntradaEfectivoStr"].HeaderText = @"Efectivo Entrada";
            dgv.Columns["TotalEntradaEfectivoStr"].DisplayIndex = 6;

            dgv.Columns["TotalEntradaTarjetaStr"].Visible = true;
            dgv.Columns["TotalEntradaTarjetaStr"].Width = 60;
            dgv.Columns["TotalEntradaTarjetaStr"].HeaderText = @"Tarjeta Entrada";
            dgv.Columns["TotalEntradaTarjetaStr"].DisplayIndex = 7;

            dgv.Columns["TotalEntradaChequeStr"].Visible = true;
            dgv.Columns["TotalEntradaChequeStr"].Width = 60;
            dgv.Columns["TotalEntradaChequeStr"].HeaderText = @"Cheque Entrada";
            dgv.Columns["TotalEntradaChequeStr"].DisplayIndex = 8;

            dgv.Columns["TotalEntradaCtaCteStr"].Visible = true;
            dgv.Columns["TotalEntradaCtaCteStr"].Width = 60;
            dgv.Columns["TotalEntradaCtaCteStr"].HeaderText = @"Cuenta CTE Entrada";
            dgv.Columns["TotalEntradaCtaCteStr"].DisplayIndex = 9;

            //--------------------------------------------------------//

            dgv.Columns["TotalSalidaEfectivoStr"].Visible = true;
            dgv.Columns["TotalSalidaEfectivoStr"].Width = 60;
            dgv.Columns["TotalSalidaEfectivoStr"].HeaderText = @"Efectivo Salida";
            dgv.Columns["TotalSalidaEfectivoStr"].DisplayIndex = 10;

            dgv.Columns["TotalSalidaTarjetaStr"].Visible = true;
            dgv.Columns["TotalSalidaTarjetaStr"].Width = 60;
            dgv.Columns["TotalSalidaTarjetaStr"].HeaderText = @"Tarjeta Salida";
            dgv.Columns["TotalSalidaTarjetaStr"].DisplayIndex = 11;

            dgv.Columns["TotalSalidaChequeStr"].Visible = true;
            dgv.Columns["TotalSalidaChequeStr"].Width = 60;
            dgv.Columns["TotalSalidaChequeStr"].HeaderText = @"Cheque Salida";
            dgv.Columns["TotalSalidaChequeStr"].DisplayIndex = 12;

            dgv.Columns["TotalSalidaCtaCteStr"].Visible = true;
            dgv.Columns["TotalSalidaCtaCteStr"].Width = 60;
            dgv.Columns["TotalSalidaCtaCteStr"].HeaderText = @"Cuenta CTE Salida";
            dgv.Columns["TotalSalidaCtaCteStr"].DisplayIndex = 13;

            //--------------------------------------------------------//
            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }

		private void btnCierreCaja_Click(object sender, EventArgs e)
		{
            var fCierreDecaja = new _00040_CierreCaja(_cajaSeleccionada.Id);
            fCierreDecaja.ShowDialog();
            ActualizarDatos(string.Empty, chkActFecha.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
		}

		private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
            if (dgvGrilla.RowCount <= 0)
            {
                _cajaSeleccionada = null;
                return;

            }
            else 
            {
                _cajaSeleccionada = (CajaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
		}
	}
}
