using System.Windows.Forms;
using IServicios.Provincia;
using IServicios.Provincia.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.ValidacionDatosEntrada;

namespace Presentacion.Core.Provincia
{
    public partial class _00002_Abm_Provincia : FormAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public _00002_Abm_Provincia(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoSimbolos(sender, args);
                NoInyeccion(sender, args);
            };
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (ProvinciaDto) _provinciaServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else // Nuevo
            {
                btnEjecutar.Text = "Grabar";
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
            var nuevoRegistro = new ProvinciaDto
            {
                Descripcion = txtDescripcion.Text, 
                Eliminado = false
            };

            _provinciaServicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new ProvinciaDto
            {
                Id = EntidadId.Value, 
                Descripcion = txtDescripcion.Text, 
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
