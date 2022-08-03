using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00040_CierreCaja : FormBase
    {
        private readonly long _cajaId;
        private readonly ICajaServicio _cajaServicio;
        private  CajaDto _caja;
        public _00040_CierreCaja(long cajaId)
        {
            InitializeComponent();

            _cajaId = cajaId;

            _cajaServicio = ObjectFactory.GetInstance<ICajaServicio>();
            CargarDatos(_cajaId);

           
        }

		private void CargarDatos(long cajaId)
		{
           _caja= _cajaServicio.Obtener(cajaId);

            if (_caja == null) 
            {
                MessageBox.Show("Ocurrio un error al obtener la caja");
            }
            lblFechaApertura.Text = _caja.FechaAperturaStr;
            txtCajaInicial.Text = _caja.MontoInicialStr;
            var efectivo = _caja.Detalles
                .Where(x => x.TipoPago == TipoPago.Efectivo)
                .Sum(x => x.Monto)
                .ToString("C");

            var cheque = _caja.Detalles
               .Where(x => x.TipoPago == TipoPago.Cheque)
               .Sum(x => x.Monto)
               .ToString("C");

            var tarjeta = _caja.Detalles
               .Where(x => x.TipoPago == TipoPago.Tarjeta)
               .Sum(x => x.Monto)
               .ToString("C");

            var cuentaCorriente = _caja.Detalles
               .Where(x => x.TipoPago == TipoPago.CtaCte)
               .Sum(x => x.Monto)
               .ToString("C");

            
             
            txtVentas.Text = efectivo;
            txtCheque.Text = cheque;
            txtTarjeta.Text = tarjeta;
            txtCtaCte.Text = cuentaCorriente;
		}

		private void btnVerDetalleVenta_Click(object sender, EventArgs e)
		{
            var fVerComprobantes = new VerComprobantes(_caja.Comprobantes);
            fVerComprobantes.ShowDialog();
		}

		private void btnEjecutar_Click(object sender, EventArgs e)
		{
            try
            {
               
                _cajaServicio.Cerrar(Identidad.UsuarioId,DateTime.Now,nudTotalCajon.Value,_cajaServicio.Obtener(_cajaId));
               
                MessageBox.Show("Los datos se grabaron correctamente");
                //CajaAbierta = true;
                Close();

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "ERROR");
            }
        }
	}
}
