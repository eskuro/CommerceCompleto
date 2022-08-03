using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IServicios.CuentaCorriente;
using IServicios.CuentaCorriente.DTOs;
using IServicios.Persona.DTOs;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Cliente
{
    public partial class _00034_ClienteCtaCte : FormBase
    {
        private ClienteDto _clienteSeleccionado;
        private ICuentaCorrienteServicio _cuentaCorrienteServicio;
        public _00034_ClienteCtaCte(ICuentaCorrienteServicio cuentaCorrienteServicio)
        {
            InitializeComponent();


            _cuentaCorrienteServicio = cuentaCorrienteServicio;

            _clienteSeleccionado = null;
            dgvGrilla.DataSource = new List<CuentaCorrienteDto>();

            var fechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

            dtpDesde.Value = fechaInicioMes;

            FormatearGrilla(dgvGrilla);
        }

		private void btnBuscarCliente_Click(object sender, EventArgs e)
		{
            var fClienteLookup = ObjectFactory.GetInstance<ClienteLookUp>();

            fClienteLookup.ShowDialog();

            if (fClienteLookup.EntidadSeleccionada != null) 
            {
                if (fClienteLookup.EntidadSeleccionada != null)
                {

                    _clienteSeleccionado = (ClienteDto)fClienteLookup.EntidadSeleccionada;

                    txtApyNom.Text = _clienteSeleccionado.ApyNom;
                    txtCelular.Text = _clienteSeleccionado.Telefono;
                    txtDni.Text = _clienteSeleccionado.Dni;

                    CargarDatos();


                }
                else 
                {

                    txtCelular.Clear();
                    txtApyNom.Clear();
                    txtDni.Clear();
                    _clienteSeleccionado = null;

                    dgvGrilla.DataSource = new List<CuentaCorrienteDto>();
                }
                
            
            }
		}

		private void CargarDatos()
		{
            var resultado =  _cuentaCorrienteServicio.Obtener(_clienteSeleccionado.Id,dtpDesde.Value, dtpHasta.Value, false);

            dgvGrilla.DataSource = resultado;
            FormatearGrilla(dgvGrilla);

            txtTotal.Text = resultado.Sum(x => x.Monto) >=0 ? resultado.Sum(x => x.Monto).ToString("C")
                : (resultado.Sum(x => x.Monto )*-1).ToString("C");

            txtTotal.BackColor = resultado.Sum(x => x.Monto) >= 0
                ? Color.DarkGreen
                : Color.DarkRed;

   		}
		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["FechaStr"].Visible = true;
            dgv.Columns["FechaStr"].Width = 100;
            dgv.Columns["FechaStr"].HeaderText = "Fecha";

            dgv.Columns["HoraStr"].Visible = true;
            dgv.Columns["HoraStr"].Width = 100;
            dgv.Columns["HoraStr"].HeaderText = "Hora";
            
            dgv.Columns["MontoStr"].Visible = true;
            dgv.Columns["MontoStr"].Width = 100;
            dgv.Columns["MontoStr"].HeaderText = "Monto";
            


        }

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            if (_clienteSeleccionado == null) return;
            CargarDatos();
		}

		private void dtpDesde_ValueChanged(object sender, EventArgs e)
		{
            if (_clienteSeleccionado == null) return;

            dtpHasta.MinDate = dtpDesde.Value;

            if (dtpDesde.Value > dtpHasta.Value) 
            {

                dtpHasta.Value = dtpDesde.Value;
            
            }
            CargarDatos();
		}

		private void dtpHasta_ValueChanged(object sender, EventArgs e)
		{
            if (_clienteSeleccionado == null) return;
            CargarDatos();
		}

		

		private void btnActualizar_Click(object sender, EventArgs e)
		{
            if (_clienteSeleccionado == null) return;

            CargarDatos();
        }

		private void btnRealizarPago_Click(object sender, EventArgs e)
		{
            if (_clienteSeleccionado != null) 
            {

                var fpagodeuda = new _00035_ClientePagoCtaCte(_clienteSeleccionado);
                fpagodeuda.ShowDialog();

                if (fpagodeuda.RealizoPago) 
                {

                    CargarDatos();
                }
            
            }
		}
	}
}
