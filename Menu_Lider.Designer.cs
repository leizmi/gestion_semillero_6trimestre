namespace gestión_semillero_6trimestre
{
    partial class Menu_Lider
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
            this.btnGestionEventos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnGestionEventos);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox1.Controls.Add(this.btnDashboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 602);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btnGestionEventos
            // 
            this.btnGestionEventos.Location = new System.Drawing.Point(6, 278);
            this.btnGestionEventos.Name = "btnGestionEventos";
            this.btnGestionEventos.Size = new System.Drawing.Size(138, 52);
            this.btnGestionEventos.TabIndex = 7;
            this.btnGestionEventos.Text = "Aplicar filtros";
            this.btnGestionEventos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(5, 401);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir de la app";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(0, 210);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(144, 51);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Consultar eventos  ";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnGestion_de_Semilleros
            // 
            this.btnGestion_de_Semilleros.Location = new System.Drawing.Point(0, 82);
            this.btnGestion_de_Semilleros.Name = "btnGestion_de_Semilleros";
            this.btnGestion_de_Semilleros.Size = new System.Drawing.Size(144, 54);
            this.btnGestion_de_Semilleros.TabIndex = 2;
            this.btnGestion_de_Semilleros.Text = "Consultar semilleros";
            this.btnGestion_de_Semilleros.UseVisualStyleBackColor = true;
            // 
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(0, 150);
            this.btnGestion_de_usuario.Name = "btnGestion_de_usuario";
            this.btnGestion_de_usuario.Size = new System.Drawing.Size(144, 49);
            this.btnGestion_de_usuario.TabIndex = 1;
            this.btnGestion_de_usuario.Text = "Registrar proyecto";
            this.btnGestion_de_usuario.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Location = new System.Drawing.Point(0, 25);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(144, 41);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Menú principal";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Gestionar semillero";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Menu_Lider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu_Lider";
            this.Text = "Menu_Lider";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGestionEventos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button button1;
    }
}