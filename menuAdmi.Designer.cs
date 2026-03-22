namespace gestión_semillero_6trimestre
{
    partial class Form2
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
            this.groupBoxAsignarUsuario = new System.Windows.Forms.GroupBox();
            this.btnAgregarInvestigador = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMostrarSemi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDSemillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_semilleros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea_investigacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lider_semillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionSemi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGestionEventos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.groupBoxAsignarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAsignarUsuario
            // 
            this.groupBoxAsignarUsuario.Controls.Add(this.btnAgregarInvestigador);
            this.groupBoxAsignarUsuario.Controls.Add(this.comboBox2);
            this.groupBoxAsignarUsuario.Controls.Add(this.label6);
            this.groupBoxAsignarUsuario.Controls.Add(this.label5);
            this.groupBoxAsignarUsuario.Controls.Add(this.comboBox1);
            this.groupBoxAsignarUsuario.Controls.Add(this.textBox2);
            this.groupBoxAsignarUsuario.Controls.Add(this.label4);
            this.groupBoxAsignarUsuario.Controls.Add(this.label3);
            this.groupBoxAsignarUsuario.Controls.Add(this.textBox1);
            this.groupBoxAsignarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAsignarUsuario.Location = new System.Drawing.Point(866, 212);
            this.groupBoxAsignarUsuario.Name = "groupBoxAsignarUsuario";
            this.groupBoxAsignarUsuario.Size = new System.Drawing.Size(309, 171);
            this.groupBoxAsignarUsuario.TabIndex = 24;
            this.groupBoxAsignarUsuario.TabStop = false;
            this.groupBoxAsignarUsuario.Text = "Asignar usuario";
            // 
            // btnAgregarInvestigador
            // 
            this.btnAgregarInvestigador.Location = new System.Drawing.Point(28, 208);
            this.btnAgregarInvestigador.Name = "btnAgregarInvestigador";
            this.btnAgregarInvestigador.Size = new System.Drawing.Size(183, 30);
            this.btnAgregarInvestigador.TabIndex = 8;
            this.btnAgregarInvestigador.Text = "Agregar investigador";
            this.btnAgregarInvestigador.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox2.Location = new System.Drawing.Point(24, 171);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(203, 28);
            this.comboBox2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Seleccionar semillero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Seleccionar rol";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lider",
            "Investigador"});
            this.comboBox1.Location = new System.Drawing.Point(23, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 28);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(161, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 26);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Correo electronico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre completo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 26);
            this.textBox1.TabIndex = 0;
            // 
            // btnMostrarSemi
            // 
            this.btnMostrarSemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarSemi.Location = new System.Drawing.Point(866, 80);
            this.btnMostrarSemi.Name = "btnMostrarSemi";
            this.btnMostrarSemi.Size = new System.Drawing.Size(145, 36);
            this.btnMostrarSemi.TabIndex = 25;
            this.btnMostrarSemi.Text = "Mostrar semilleros";
            this.btnMostrarSemi.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDSemillero,
            this.Nombre_semilleros,
            this.Fecha_creacion,
            this.Linea_investigacion,
            this.Lider_semillero,
            this.descripcionSemi});
            this.dataGridView1.Location = new System.Drawing.Point(199, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(641, 400);
            this.dataGridView1.TabIndex = 23;
            // 
            // IDSemillero
            // 
            this.IDSemillero.HeaderText = "ID semillero";
            this.IDSemillero.Name = "IDSemillero";
            this.IDSemillero.ReadOnly = true;
            // 
            // Nombre_semilleros
            // 
            this.Nombre_semilleros.HeaderText = "Nombre semilleros";
            this.Nombre_semilleros.Name = "Nombre_semilleros";
            this.Nombre_semilleros.ReadOnly = true;
            // 
            // Fecha_creacion
            // 
            this.Fecha_creacion.HeaderText = "Fecha creacion";
            this.Fecha_creacion.Name = "Fecha_creacion";
            this.Fecha_creacion.ReadOnly = true;
            // 
            // Linea_investigacion
            // 
            this.Linea_investigacion.HeaderText = "Linea investigacion";
            this.Linea_investigacion.Name = "Linea_investigacion";
            this.Linea_investigacion.ReadOnly = true;
            // 
            // Lider_semillero
            // 
            this.Lider_semillero.HeaderText = "Lider semillero";
            this.Lider_semillero.Name = "Lider_semillero";
            this.Lider_semillero.ReadOnly = true;
            // 
            // descripcionSemi
            // 
            this.descripcionSemi.HeaderText = "Descrpción semillero";
            this.descripcionSemi.Name = "descripcionSemi";
            this.descripcionSemi.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnGestionEventos);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnDashboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(13, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 590);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnGestionEventos
            // 
            this.btnGestionEventos.Location = new System.Drawing.Point(6, 351);
            this.btnGestionEventos.Name = "btnGestionEventos";
            this.btnGestionEventos.Size = new System.Drawing.Size(138, 52);
            this.btnGestionEventos.TabIndex = 6;
            this.btnGestionEventos.Text = "Gestion de eventos";
            this.btnGestionEventos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(3, 422);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 53);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir de la app";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(2, 281);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(144, 54);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnGestion_de_Semilleros
            // 
            this.btnGestion_de_Semilleros.Location = new System.Drawing.Point(2, 207);
            this.btnGestion_de_Semilleros.Name = "btnGestion_de_Semilleros";
            this.btnGestion_de_Semilleros.Size = new System.Drawing.Size(144, 54);
            this.btnGestion_de_Semilleros.TabIndex = 2;
            this.btnGestion_de_Semilleros.Text = "Gestion de Semilleros";
            this.btnGestion_de_Semilleros.UseVisualStyleBackColor = true;
            this.btnGestion_de_Semilleros.Click += new System.EventHandler(this.btnGestion_de_Semilleros_Click_1);
            // 
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(1, 136);
            this.btnGestion_de_usuario.Name = "btnGestion_de_usuario";
            this.btnGestion_de_usuario.Size = new System.Drawing.Size(144, 49);
            this.btnGestion_de_usuario.TabIndex = 1;
            this.btnGestion_de_usuario.Text = "Gestion de Usuario";
            this.btnGestion_de_usuario.UseVisualStyleBackColor = true;
            this.btnGestion_de_usuario.Click += new System.EventHandler(this.btnGestion_de_usuario_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Location = new System.Drawing.Point(0, 64);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(144, 53);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Menú principal";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1217, 527);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxAsignarUsuario);
            this.Controls.Add(this.btnMostrarSemi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBoxAsignarUsuario.ResumeLayout(false);
            this.groupBoxAsignarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxAsignarUsuario;
        private System.Windows.Forms.Button btnAgregarInvestigador;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMostrarSemi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSemillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_semilleros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea_investigacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lider_semillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionSemi;
        private System.Windows.Forms.Button btnGestionEventos;
    }
}