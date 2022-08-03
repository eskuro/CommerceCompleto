using System;
using System.Windows.Forms;
using Aplicacion.Constantes;
using IServicios.Seguridad;
using PresentacionBase.Formularios;

namespace CommerceApp
{
    public partial class Login : FormBase
    {
        private readonly ISeguridadServicio _seguridad;

        public bool PuedeAccederAlSistema { get; private set; }

        public Login(ISeguridadServicio seguridad)
        {
            InitializeComponent();

            _seguridad = seguridad;

            AsignarEvento_EnterLeave(this);

            imgLogoEmpresa.Image = Imagen.ImagenLogoLogin;

            txtUsuario.Text = "mibañez";
            txtPassword.Text = "P$assword123";
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (UsuarioAdmin.Usuario == txtUsuario.Text
                    && UsuarioAdmin.Password == txtPassword.Text)
                {
                    Identidad.Apellido = "Administrador";

                    PuedeAccederAlSistema = true;
                    this.Close();
                    return;
                }

                var puedeAcceder = _seguridad.VerificarAcceso(txtUsuario.Text, txtPassword.Text);

                if (puedeAcceder)
                {
                    var usuarioLogin = _seguridad.ObtenerUsuarioLogin(txtUsuario.Text);

                    if (usuarioLogin == null)
                        throw new Exception("Ocurrio un error al obtener el Usuario");

                    if (usuarioLogin.EstaBloqueado)
                    {
                        MessageBox.Show($"El usuario {usuarioLogin.ApyNomEmpleado} esta BLOQUEADO", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        txtUsuario.Clear();
                        txtPassword.Clear();
                        return;
                    }

                    Identidad.EmpleadoId = usuarioLogin.EmpleadoId;
                    Identidad.Nombre = usuarioLogin.NombreEmpleado;
                    Identidad.Apellido = usuarioLogin.ApellidoEmpleado;
                    Identidad.Foto = usuarioLogin.FotoEmpleado;
                    // ================================================ //
                    Identidad.UsuarioId = usuarioLogin.Id;
                    Identidad.Usuario = usuarioLogin.NombreUsuario;
                    // ================================================ //
                    PuedeAccederAlSistema = puedeAcceder;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario o el Password son Icorrectos");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = Char.MinValue;
        }

        private void btnVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = Char.Parse("*");
        }
    }
}
