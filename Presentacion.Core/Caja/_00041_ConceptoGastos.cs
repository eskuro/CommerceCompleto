using System.Windows.Forms;
using IServicios.ConceptoGasto;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Caja
{
    public partial class _00041_ConceptoGastos : FormConsulta
    {
        private readonly IConceptoGastoServicio _conceptoGastoServicio;
        public _00041_ConceptoGastos(IConceptoGastoServicio conceptoGastoServicio)
        {
            InitializeComponent();

            _conceptoGastoServicio = conceptoGastoServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _conceptoGastoServicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Descripción";

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 70;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00042_Abm_ConceptoGastos(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}
