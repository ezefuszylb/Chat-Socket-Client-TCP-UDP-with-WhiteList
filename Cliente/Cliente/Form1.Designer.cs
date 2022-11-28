namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbTitulo1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(277, 250);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(25, 250);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(222, 20);
            this.txtMensaje.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(25, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(327, 208);
            this.listBox1.TabIndex = 2;
            // 
            // lbTitulo1
            // 
            this.lbTitulo1.AutoSize = true;
            this.lbTitulo1.Location = new System.Drawing.Point(106, 77);
            this.lbTitulo1.Name = "lbTitulo1";
            this.lbTitulo1.Size = new System.Drawing.Size(43, 13);
            this.lbTitulo1.TabIndex = 3;
            this.lbTitulo1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(109, 108);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(109, 135);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 5;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 284);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lbTitulo1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnEnviar);
            this.Name = "Form1";
            this.Text = "Chat Comunitario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbTitulo1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnConectar;
    }
}

