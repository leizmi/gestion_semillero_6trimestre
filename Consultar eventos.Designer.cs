namespace gestión_semillero_6trimestre
{
    partial class Consultar_eventos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGestionSemillero = new System.Windows.Forms.Button();
            this.btnRegistrarProyecto = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultarEvento = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnGestionSemillero);
            this.groupBox1.Controls.Add(this.btnRegistrarProyecto);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnConsultarEvento);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 409);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // btnGestionSemillero
            // 
            this.btnGestionSemillero.Location = new System.Drawing.Point(0, 37);
            this.btnGestionSemillero.Name = "btnGestionSemillero";
            this.btnGestionSemillero.Size = new System.Drawing.Size(140, 48);
            this.btnGestionSemillero.TabIndex = 8;
            this.btnGestionSemillero.Text = "Gestionar semillero";
            this.btnGestionSemillero.UseVisualStyleBackColor = true;
            this.btnGestionSemillero.Click += new System.EventHandler(this.btnGestionSemillero_Click);
            // 
            // btnRegistrarProyecto
            // 
            this.btnRegistrarProyecto.Location = new System.Drawing.Point(0, 117);
            this.btnRegistrarProyecto.Name = "btnRegistrarProyecto";
            this.btnRegistrarProyecto.Size = new System.Drawing.Size(140, 49);
            this.btnRegistrarProyecto.TabIndex = 1;
            this.btnRegistrarProyecto.Text = "Registrar proyecto";
            this.btnRegistrarProyecto.UseVisualStyleBackColor = true;
            this.btnRegistrarProyecto.Click += new System.EventHandler(this.btnRegistrarProyecto_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(0, 283);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnConsultarEvento
            // 
            this.btnConsultarEvento.Location = new System.Drawing.Point(0, 201);
            this.btnConsultarEvento.Name = "btnConsultarEvento";
            this.btnConsultarEvento.Size = new System.Drawing.Size(140, 51);
            this.btnConsultarEvento.TabIndex = 3;
            this.btnConsultarEvento.Text = "Consultar eventos  ";
            this.btnConsultarEvento.UseVisualStyleBackColor = true;
            this.btnConsultarEvento.Click += new System.EventHandler(this.btnConsultarEvento_Click);
            // 
            // Consultar_eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Consultar_eventos";
            this.Text = "Consultar_eventos";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGestionSemillero;
        private System.Windows.Forms.Button btnRegistrarProyecto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultarEvento;
    }
}