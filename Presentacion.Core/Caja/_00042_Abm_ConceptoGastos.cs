using System;
using System.Windows.Forms;
using IServicios.ConceptoGasto;
using IServicios.ConceptoGasto.DTOs;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Caja
{
    public partial class _00042_Abm_ConceptoGastos : FormAbm
    {
        private readonly IConceptoGastoServicio _conceptoGastoServicio;

        public _00042_Abm_ConceptoGastos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _conceptoGastoServicio = ObjectFactory.GetInstance<IConceptoGastoServicio>();

            AsignarEvento_EnterLeave(this);
        }

        public override void CargarDatos(long? entidadId)
        {

            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado =  (ConceptoGastoDto)_conceptoGastoServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrió un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                }
            }
            else
            {
                btnEjecutar.Text = "Grabar";
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _conceptoGastoServicio.Insertar(new ConceptoGastoDto
            {
                Eliminado = false,
                Descripcion = txtDescripcion.Text
            });
        }

        public override void EjecutarComandoModificar()
        {
            _conceptoGastoServicio.Modificar(new ConceptoGastoDto
            {
                Id = EntidadId.Value,
                Eliminado = false,
                Descripcion = txtDescripcion.Text
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _conceptoGastoServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text);
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return id.HasValue && _conceptoGastoServicio.VerificarSiExiste(txtDescripcion.Text, id.Value);
        }
    }
}
