using System.Windows.Forms;
using IServicios.ListaPrecio;
using IServicios.ListaPrecio.DTOs;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Articulo
{
    public partial class _00033_Abm_ListaPrecio : FormAbm
    {
        private readonly IListaPrecioServicio _provinciaServicio;

        public _00033_Abm_ListaPrecio(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = ObjectFactory.GetInstance<IListaPrecioServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (ListaPrecioDto)_provinciaServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;
                nudPorcentaje.Value = resultado.PorcentajeGanancia;
                chkPedirAutorizacion.Checked = resultado.NecesitaAutorizacion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else // Nuevo
            {
                btnEjecutar.Text = "Nuevo";
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text);
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _provinciaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked,
                PorcentajeGanancia = nudPorcentaje.Value,
                Eliminado = false
            };

            _provinciaServicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new ListaPrecioDto
            {
                Id = EntidadId.Value, 
                Descripcion = txtDescripcion.Text,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked,
                PorcentajeGanancia = nudPorcentaje.Value,
                Eliminado = false
            };

            _provinciaServicio.Modificar(modificarRegistro);
        }


        public override void EjecutarComandoEliminar()
        {
            _provinciaServicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            base.LimpiarControles(obj);

            txtDescripcion.Focus();
        }
    }
}
