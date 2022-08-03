namespace CommerceApp
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnVerPassword = new FontAwesome.Sharp.IconButton();
			this.btnIngresar = new FontAwesome.Sharp.IconButton();
			this.btnCancelar = new FontAwesome.Sharp.IconButton();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.imgLogoEmpresa = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgLogoEmpresa)).BeginInit();
			this.SuspendLayout();
			// 
			// btnVerPassword
			// 
			this.btnVerPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnVerPassword.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnVerPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnVerPassword.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.btnVerPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
			this.btnVerPassword.IconColor = System.Drawing.Color.WhiteSmoke;
			this.btnVerPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnVerPassword.IconSize = 16;
			this.btnVerPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnVerPassword.Location = new System.Drawing.Point(603, 124);
			this.btnVerPassword.Name = "btnVerPassword";
			this.btnVerPassword.Rotation = 0D;
			this.btnVerPassword.Size = new System.Drawing.Size(28, 22);
			this.btnVerPassword.TabIndex = 45;
			this.btnVerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnVerPassword.UseVisualStyleBackColor = false;
			this.btnVerPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnVerPassword_MouseDown);
			this.btnVerPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnVerPassword_MouseUp);
			// 
			// btnIngresar
			// 
			this.btnIngresar.BackColor = System.Drawing.Color.Black;
			this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIngresar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIngresar.ForeColor = System.Drawing.Color.Tomato;
			this.btnIngresar.IconChar = FontAwesome.Sharp.IconChar.Save;
			this.btnIngresar.IconColor = System.Drawing.Color.Empty;
			this.btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnIngresar.IconSize = 22;
			this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIngresar.Location = new System.Drawing.Point(337, 175);
			this.btnIngresar.Name = "btnIngresar";
			this.btnIngresar.Padding = new System.Windows.Forms.Padding(1);
			this.btnIngresar.Rotation = 0D;
			this.btnIngresar.Size = new System.Drawing.Size(116, 36);
			this.btnIngresar.TabIndex = 43;
			this.btnIngresar.Text = "Ingresar";
			this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnIngresar.UseVisualStyleBackColor = false;
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.Black;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancelar.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Eraser;
			this.btnCancelar.IconColor = System.Drawing.Color.Empty;
			this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCancelar.IconSize = 22;
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(506, 175);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(1);
			this.btnCancelar.Rotation = 0D;
			this.btnCancelar.Size = new System.Drawing.Size(116, 36);
			this.btnCancelar.TabIndex = 44;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label5.Location = new System.Drawing.Point(309, 126);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 16);
			this.label5.TabIndex = 42;
			this.label5.Text = "Contraseña";
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(407, 123);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(190, 22);
			this.txtPassword.TabIndex = 40;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(334, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 16);
			this.label4.TabIndex = 41;
			this.label4.Text = "Usuario";
			// 
			// txtUsuario
			// 
			this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsuario.Location = new System.Drawing.Point(407, 84);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(190, 22);
			this.txtUsuario.TabIndex = 39;
			// 
			// imgLogoEmpresa
			// 
			this.imgLogoEmpresa.Location = new System.Drawing.Point(16, 12);
			this.imgLogoEmpresa.Name = "imgLogoEmpresa";
			this.imgLogoEmpresa.Size = new System.Drawing.Size(287, 297);
			this.imgLogoEmpresa.TabIndex = 46;
			this.imgLogoEmpresa.TabStop = false;
			// 
			// Login
			// 
			this.AcceptButton = this.btnIngresar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(660, 321);
			this.ControlBox = false;
			this.Controls.Add(this.imgLogoEmpresa);
			this.Controls.Add(this.btnVerPassword);
			this.Controls.Add(this.btnIngresar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUsuario);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			((System.ComponentModel.ISupportInitialize)(this.imgLogoEmpresa)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnVerPassword;
        public FontAwesome.Sharp.IconButton btnIngresar;
        public FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.PictureBox imgLogoEmpresa;
	}
}