using System;
using System.Globalization;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;
using Aplicacion.Constantes;
using FontAwesome.Sharp;
using IServicios.Articulo;
using IServicios.Caja;

using IServicios.Persona;
using Presentacion.Core.Articulo;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Configuracion;
using Presentacion.Core.Departamento;
using Presentacion.Core.Empleado;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Localidad;
using Presentacion.Core.Proveedor;
using Presentacion.Core.Provincia;
using Presentacion.Core.Usuario;
using PresentacionBase.Formularios;
using StructureMap;
using Color = System.Drawing.Color;

namespace CommerceApp
{
    public partial class Principal : Form
    {
        delegate void TiempoDelegado();
        private Thread hiloReloj;

        private readonly IClienteServicio _clienteServicio;
        private readonly IArticuloServicio _articuloServicio;
        
        private readonly ICajaServicio _cajaServicio;

        public Principal(IClienteServicio clienteServicio, IArticuloServicio articuloServicio, ICajaServicio cajaServicio)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _articuloServicio = articuloServicio;
           
            _clienteServicio = clienteServicio;
            _cajaServicio = cajaServicio;

            hiloReloj = new Thread(Tiempo);
            hiloReloj.Start();

            lblApellido.Text = $"{Identidad.Apellido}";
            lblNombre.Text = $"{Identidad.Nombre}";
            imgFotoUsuarioLogin.Image = Imagen.ConvertirImagen(Identidad.Foto);

            imgFotoUsuarioLogin.Visible = Identidad.Apellido != "Administrador";


            //  ==================================== //
            //  ============   Clientes   ========== //
            //  ==================================== //

            ctrolCliente.Titulo = "Clientes";
            ctrolCliente.Icono = IconChar.Users;
            ctrolCliente.Pie = string.Empty;
            ctrolCliente.Numero = _clienteServicio.ObtenerCantidadClientes().ToString();
            ctrolCliente.ColorNumero = Color.DarkGreen;


            //  ==================================== //
            //  ============   Productos  ========== //
            //  ==================================== //
            ctrolProducto.Titulo = "Productos";
            ctrolProducto.Icono = IconChar.BoxOpen;
            ctrolProducto.Pie = string.Empty;
            ctrolProducto.Numero = _articuloServicio.ObtenerCantidadArticulos().ToString();
            ctrolProducto.ColorNumero = Color.Red;

            //  ==================================== //
            //  =======   Cuenta Corriente  ======== //
            //  ==================================== //
     

            //  ==================================== //
            //  ============     Caja     ========== //
            //  ==================================== //
           
            //  ============================================================================================== //

           
        }

        public void CambiarTiempo()
        {
            if (this.InvokeRequired)
            {
                var delegado = new TiempoDelegado(CambiarTiempo);
                this.Invoke(delegado);
            }
            else
            {
                lblHora.Text =
                    $@"{DateTime.Now.Hour:00}" +
                    $@":{DateTime.Now.Minute:00}" +
                    $@":{DateTime.Now.Second:00}";

                lblFecha.Text = DateTime.Now.ToLongDateString();

                imgFotoUsuarioLogin.Image = Imagen.ConvertirImagen(Identidad.Foto);
            }
        }

        private void Tiempo()
        {
            Thread.Sleep(100);
            CambiarTiempo();
            Tiempo();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            hiloReloj.Abort();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00001_Provincia>().ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00003_Departamento>().ShowDialog();
        }

        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00005_Localidad>().ShowDialog();
        }

        private void consultaDeCondicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00013_CondicionIva>().ShowDialog();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00012_Configuracion>().ShowDialog();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.VerificarSiExisteCajaAbierta(Identidad.UsuarioId))
            {

                ObjectFactory.GetInstance<_00050_Venta>().Show();
            }
            else 
            {
                if (MessageBox.Show("La caja aun no fue abierta. Desea hacerlo ahora", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
                {
                    var fcaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();
                    fcaja.ShowDialog();
					if (fcaja.CajaAbierta) 
                    {
                        ObjectFactory.GetInstance<_00050_Venta>().Show();
                    }
                }
            }
            
        }

        private void consultaToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00007_Empleado>().ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00009_Cliente>().ShowDialog();
        }

        private void consultaToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00009_Cliente>().ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00010_Abm_Cliente(TipoOperacion.Nuevo).ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00008_Abm_Empleado(TipoOperacion.Nuevo).ShowDialog();
        }

        private void nuevaProvinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00002_Abm_Provincia(TipoOperacion.Nuevo).ShowDialog();
        }

        private void nuevoDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00004_Abm_Departamento(TipoOperacion.Nuevo).ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00006_AbmLocalidad(TipoOperacion.Nuevo).ShowDialog();
        }

        private void nuevaCondicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00014_Abm_CondicionIva(TipoOperacion.Nuevo).ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00011_Usuario>().ShowDialog();
        }

        private void salirDelSIstemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de Salir del Sistema", "Atención", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Identidad.Limpiar();

            lblNombre.Text = string.Empty;
            lblApellido.Text = string.Empty;
            imgFotoUsuarioLogin.Image = null;
            imgFotoUsuarioLogin.Visible = false;

            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (!fLogin.PuedeAccederAlSistema)
            {
                Application.Exit();
            }
            else
            {
                imgFotoUsuarioLogin.Visible = true;
                lblApellido.Text = $"{Identidad.Apellido}";
                lblNombre.Text = $"{Identidad.Nombre}";
                imgFotoUsuarioLogin.Image = Imagen.ConvertirImagen(Identidad.Foto);
            }
        }

        private void consultaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00032_ListaPrecio>().ShowDialog();
        }

        private void nuevaListaDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00033_Abm_ListaPrecio(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00025_Iva>().ShowDialog();
        }

        private void nuevoArticuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new _00026_Abm_Iva(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00019_Rubro>().ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00020_Abm_Rubro(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00021_Marca>().ShowDialog();
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00022_Abm_Marca(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00023_UnidadDeMedida>().ShowDialog();
        }

        private void nuevaUnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00024_Abm_UnidadDeMedida(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00017_Articulo>().ShowDialog();
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00018_Abm_Articulo(TipoOperacion.Nuevo).ShowDialog();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00017_Articulo>().ShowDialog();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00012_Configuracion>().ShowDialog();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00053_Compra>().ShowDialog();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00038_Caja>().ShowDialog();
        }

        private void consultaToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00015_Proveedor>().ShowDialog();
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00016_Abm_Proveedor(TipoOperacion.Nuevo).ShowDialog();
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ObjectFactory.GetInstance<_00034_ClienteCtaCte>().ShowDialog();
        }

        private void cuentaCorrienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new _00036_ProveedorCtaCte().ShowDialog();
        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_cajaServicio.VerificarSiExisteCajaAbierta(Identidad.UsuarioId))
            {
                ObjectFactory.GetInstance<_00039_AperturaCaja>().ShowDialog();

            }
            else 
            {
                MessageBox.Show($"Ya se encuentra abierta una caja para el usuario {Identidad.Apellido} {Identidad.Nombre}");
            
            }


            
        }

        

        private void consultaToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00041_ConceptoGastos>().ShowDialog();
        }

        private void nuevoConceptoDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00042_Abm_ConceptoGastos(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00043_Gastos>().ShowDialog();
        }

        private void nuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00044_Abm_Gastos(TipoOperacion.Nuevo).ShowDialog();
        }

        private void cobroDePendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00049_CobroDiferido>().ShowDialog();
        }

        private void ajusteDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00031_ActualizarPrecios>().ShowDialog();
        }

        private void consultaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00029_BajaDeArticulos>().ShowDialog();
        }

        private void nuevaBajaDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00030_Abm_BajaArticulos(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00027_MotivoBaja>().ShowDialog();
        }

        private void nuevoMotivoDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00028_Abm_MotivoBaja(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00054_Deposito>().ShowDialog();
        }

        private void nuevoDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00055_Abm_Deposito(TipoOperacion.Nuevo).ShowDialog();
        }

        private void consultaToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00051_PuestoTrabajo>().ShowDialog();
        }

        private void nuevoPuestoDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00052_Abm_PuestoTrabajo(TipoOperacion.Nuevo).ShowDialog();
        }

		private void consultaToolStripMenuItem14_Click(object sender, EventArgs e)
		{
            ObjectFactory.GetInstance<_00038_Caja>().ShowDialog();
		}

		private void consultaToolStripMenuItem19_Click(object sender, EventArgs e)
		{
            ObjectFactory.GetInstance<_00047_Banco>().ShowDialog();
		}

		private void nuevoBancoToolStripMenuItem_Click(object sender, EventArgs e)
		{
            new _00048_Abm_Banco(TipoOperacion.Nuevo).ShowDialog();
        }

		private void consultaToolStripMenuItem20_Click(object sender, EventArgs e)
		{
            ObjectFactory.GetInstance<_00045_Tarjeta>().ShowDialog();
		}

		private void nuevaTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
		{
            new _00046_Abm_tarjeta(TipoOperacion.Nuevo).ShowDialog();
		}

		
	}
}
