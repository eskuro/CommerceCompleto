using System;
using System.Windows.Forms;
using IServicios.ListaPrecio;
using IServicios.Marca;
using IServicios.Precio;
using IServicios.Rubro;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Articulo
{
    public partial class _00031_ActualizarPrecios : FormBase
    {
        private readonly IPrecioServicio _precioServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _00031_ActualizarPrecios(IPrecioServicio precioServicio, 
            IMarcaServicio marcaServicio, 
            IRubroServicio rubroServicio, 
            IListaPrecioServicio listaPrecioServicio)
        {
            InitializeComponent();

            _precioServicio = precioServicio;
            _marcaServicio = marcaServicio;
            _rubroServicio = rubroServicio;
            _listaPrecioServicio = listaPrecioServicio;

            this.DoubleBuffered = true;

            PoblarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

        private void _00031_ActualizarPrecios_Load(object sender, System.EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            dtpFechaActualizacion.MinDate = DateTime.Today;
            dtpFechaActualizacion.Value = DateTime.Now;

            dtpHora.Value = DateTime.Now;

            nudCodigoDesde.Value = 0;
            nudCodigoHasta.Value = 0;

            chkRubro.Checked = false;
            chkArticulo.Checked = false;
            chkMarca.Checked = false;
            chkListaPrecio.Checked = false;

            nudValor.Value = 0;

            rdbPorcentaje.Checked = false;
            RdbPrecio.Checked = true;
        }

        private void chkMarca_CheckedChanged(object sender, EventArgs e)
        {
            cmbMarca.Enabled = chkMarca.Checked;
        }

        private void chkRubro_CheckedChanged(object sender, EventArgs e)
        {
            cmbRubro.Enabled = chkRubro.Checked;
        }

        private void chkArticulo_CheckedChanged(object sender, EventArgs e)
        {
            nudCodigoDesde.Enabled = chkArticulo.Checked;
            nudCodigoHasta.Enabled = chkArticulo.Checked;
        }

        private void chkListaPrecio_CheckedChanged(object sender, EventArgs e)
        {
            cmbListaPrecio.Enabled = chkListaPrecio.Checked;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                var rubroId = chkRubro.Checked
                    ? (long) cmbRubro.SelectedValue
                    : (long?) null;

                var marcaId = chkMarca.Checked
                    ? (long) cmbMarca.SelectedValue
                    : (long?) null;

                var listaPrecioId = chkListaPrecio.Checked
                    ? (long) cmbListaPrecio.SelectedValue
                    : (long?) null;

                var codigoDesde = chkArticulo.Checked
                    ? Convert.ToInt32(nudCodigoDesde.Value)
                    : (int?) null;

                var codigoHasta = chkArticulo.Checked
                    ? Convert.ToInt32(nudCodigoHasta.Value)
                    : (int?) null;

                _precioServicio.ActualizarPrecio(nudValor.Value
                    , rdbPorcentaje.Checked
                    , marcaId
                    , rubroId
                    , codigoDesde
                    , codigoHasta);

                MessageBox.Show("Los Precios se Actualizaron Correctamente");
                Limpiar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
