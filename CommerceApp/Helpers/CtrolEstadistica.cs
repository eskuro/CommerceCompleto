using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CommerceApp.Helpers
{
    public partial class CtrolEstadistica : UserControl
    {
        public string Titulo {
            set
            {
                lblTitulo.Text = !string.IsNullOrEmpty(value)
                    ? value
                    : "TITULO";
            }
        }

        public string Numero
        {
            set
            {
                lblNumero.Text = !string.IsNullOrEmpty(value)
                    ? value
                    : "0";
            }
        }

        public Color ColorNumero
        {
            get
            {
                return Color.Black;
            }
            set
            {
                lblNumero.ForeColor = value;
            }
        }

        public string Pie
        {
            set
            {
                lblPie.Text = !string.IsNullOrEmpty(value)
                    ? value
                    : DateTime.Today.ToShortDateString();

                lblPie.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public IconChar Icono
        {
            set
            {
                imgLogo.IconChar = value;
            }
        }

        

        public CtrolEstadistica()
        {
            InitializeComponent();
        }
    }
}
