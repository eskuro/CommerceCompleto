using System.Collections.Generic;
using System.Windows.Forms;
using IServicios.ListaPrecio;
using IServicios.ListaPrecio.DTOs;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Articulo
{
    public partial class _00032_ListaPrecio : FormConsulta
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _00032_ListaPrecio(IListaPrecioServicio listaPrecioServicio)
        {
            InitializeComponent();

            _listaPrecioServicio = listaPrecioServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = (List<ListaPrecioDto>)_listaPrecioServicio
                .Obtener(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Lista de Precio";
            dgv.Columns["Descripcion"].Visible = true;

            dgv.Columns["AutorizacionStr"].Width = 100;
            dgv.Columns["AutorizacionStr"].HeaderText = "Autorización";
            dgv.Columns["AutorizacionStr"].Visible = true;
            dgv.Columns["AutorizacionStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["PorcentajeGananciaStr"].Width = 100;
            dgv.Columns["PorcentajeGananciaStr"].HeaderText = "Ganancia";
            dgv.Columns["PorcentajeGananciaStr"].Visible = true;
            dgv.Columns["PorcentajeGananciaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion operacion, long? entidadId = null)
        {
            var formulario = new _00033_Abm_ListaPrecio(operacion, entidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
