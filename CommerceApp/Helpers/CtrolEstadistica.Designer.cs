namespace CommerceApp.Helpers
{
    partial class CtrolEstadistica
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.imgLogo = new FontAwesome.Sharp.IconButton();
            this.lblPie = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(109, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLogo
            // 
            this.imgLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgLogo.BackColor = System.Drawing.Color.White;
            this.imgLogo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.imgLogo.FlatAppearance.BorderSize = 0;
            this.imgLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imgLogo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.imgLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgLogo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.imgLogo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.imgLogo.IconColor = System.Drawing.Color.Black;
            this.imgLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imgLogo.IconSize = 70;
            this.imgLogo.Location = new System.Drawing.Point(21, 44);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Rotation = 0D;
            this.imgLogo.Size = new System.Drawing.Size(65, 65);
            this.imgLogo.TabIndex = 1;
            this.imgLogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imgLogo.UseVisualStyleBackColor = false;
            // 
            // lblPie
            // 
            this.lblPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPie.Location = new System.Drawing.Point(0, 144);
            this.lblPie.Name = "lblPie";
            this.lblPie.Size = new System.Drawing.Size(109, 28);
            this.lblPie.TabIndex = 2;
            this.lblPie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumero
            // 
            this.lblNumero.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(0, 118);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(109, 26);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrolEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblPie);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "CtrolEstadistica";
            this.Size = new System.Drawing.Size(109, 172);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private FontAwesome.Sharp.IconButton imgLogo;
        private System.Windows.Forms.Label lblPie;
        private System.Windows.Forms.Label lblNumero;
    }
}
