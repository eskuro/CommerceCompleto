using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
	public partial class CambiarCantidad : Form
	{

		private ItemView _itemSeleccionado;
		public ItemView Item => _itemSeleccionado;
		public CambiarCantidad(ItemView item)
		{
			InitializeComponent();
			_itemSeleccionado = item;
		}

		private void CambiarCantidad_Load(object sender, EventArgs e)
		{
			if (_itemSeleccionado == null) 
			{
				MessageBox.Show("Ocurrio un Error al Obtener el Articulo");
				Close();
			}
			
			lblArticulo.Text = _itemSeleccionado.Descripcion;
			nudCantidad.Value = _itemSeleccionado.Cantidad;
			nudCantidad.Select(0, nudCantidad.Text.Length);
			
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_itemSeleccionado = null;
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_itemSeleccionado.Cantidad = nudCantidad.Value;
			Close();
		}

		
	}
}
