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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnTotalsemillero = new System.Windows.Forms.GroupBox();
            this.Totalsemillerosactivos = new System.Windows.Forms.Label();
            this.lblnumero = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Total_investigadores = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal_investigadores = new System.Windows.Forms.Label();
            this.Total_proyectos_en_curso = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblproyectos_en_curso = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMostrar_informacion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.btnTotalsemillero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Total_investigadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Total_proyectos_en_curso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnDashboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(1, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 521);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menú";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Location = new System.Drawing.Point(0, 25);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(144, 41);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(0, 72);
            this.btnGestion_de_usuario.Name = "btnGestion_de_usuario";
            this.btnGestion_de_usuario.Size = new System.Drawing.Size(144, 49);
            this.btnGestion_de_usuario.TabIndex = 1;
            this.btnGestion_de_usuario.Text = "Gestion de Usuario";
            this.btnGestion_de_usuario.UseVisualStyleBackColor = true;
            // 
            // btnGestion_de_Semilleros
            // 
            this.btnGestion_de_Semilleros.Location = new System.Drawing.Point(0, 127);
            this.btnGestion_de_Semilleros.Name = "btnGestion_de_Semilleros";
            this.btnGestion_de_Semilleros.Size = new System.Drawing.Size(144, 54);
            this.btnGestion_de_Semilleros.TabIndex = 2;
            this.btnGestion_de_Semilleros.Text = "Gestion de Semilleros";
            this.btnGestion_de_Semilleros.UseVisualStyleBackColor = true;
            this.btnGestion_de_Semilleros.Click += new System.EventHandler(this.btnGestion_de_Semilleros_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(0, 187);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(144, 44);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnconfiguracion_Click);
            // 
            // btnTotalsemillero
            // 
            this.btnTotalsemillero.Controls.Add(this.pictureBox1);
            this.btnTotalsemillero.Controls.Add(this.lblnumero);
            this.btnTotalsemillero.Controls.Add(this.Totalsemillerosactivos);
            this.btnTotalsemillero.Location = new System.Drawing.Point(151, 60);
            this.btnTotalsemillero.Name = "btnTotalsemillero";
            this.btnTotalsemillero.Size = new System.Drawing.Size(252, 59);
            this.btnTotalsemillero.TabIndex = 2;
            this.btnTotalsemillero.TabStop = false;
            this.btnTotalsemillero.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Totalsemillerosactivos
            // 
            this.Totalsemillerosactivos.AutoSize = true;
            this.Totalsemillerosactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totalsemillerosactivos.Location = new System.Drawing.Point(64, 12);
            this.Totalsemillerosactivos.Name = "Totalsemillerosactivos";
            this.Totalsemillerosactivos.Size = new System.Drawing.Size(152, 16);
            this.Totalsemillerosactivos.TabIndex = 0;
            this.Totalsemillerosactivos.Text = "Total Semilleros Activos";
            this.Totalsemillerosactivos.Click += new System.EventHandler(this.Totalsemillerosactivos_Click);
            // 
            // lblnumero
            // 
            this.lblnumero.AutoSize = true;
            this.lblnumero.Location = new System.Drawing.Point(73, 41);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(107, 13);
            this.lblnumero.TabIndex = 1;
            this.lblnumero.Text = "contador de semillero";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Total_investigadores
            // 
            this.Total_investigadores.Controls.Add(this.pictureBox2);
            this.Total_investigadores.Controls.Add(this.label1);
            this.Total_investigadores.Controls.Add(this.lblTotal_investigadores);
            this.Total_investigadores.Location = new System.Drawing.Point(409, 60);
            this.Total_investigadores.Name = "Total_investigadores";
            this.Total_investigadores.Size = new System.Drawing.Size(252, 59);
            this.Total_investigadores.TabIndex = 3;
            this.Total_investigadores.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "contador investigadores";
            // 
            // lblTotal_investigadores
            // 
            this.lblTotal_investigadores.AutoSize = true;
            this.lblTotal_investigadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal_investigadores.Location = new System.Drawing.Point(65, 8);
            this.lblTotal_investigadores.Name = "lblTotal_investigadores";
            this.lblTotal_investigadores.Size = new System.Drawing.Size(130, 16);
            this.lblTotal_investigadores.TabIndex = 0;
            this.lblTotal_investigadores.Text = "Total Investigadores";
            // 
            // Total_proyectos_en_curso
            // 
            this.Total_proyectos_en_curso.Controls.Add(this.pictureBox3);
            this.Total_proyectos_en_curso.Controls.Add(this.label2);
            this.Total_proyectos_en_curso.Controls.Add(this.lblproyectos_en_curso);
            this.Total_proyectos_en_curso.Location = new System.Drawing.Point(667, 60);
            this.Total_proyectos_en_curso.Name = "Total_proyectos_en_curso";
            this.Total_proyectos_en_curso.Size = new System.Drawing.Size(252, 59);
            this.Total_proyectos_en_curso.TabIndex = 4;
            this.Total_proyectos_en_curso.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "contador poyectos en curso";
            // 
            // lblproyectos_en_curso
            // 
            this.lblproyectos_en_curso.AutoSize = true;
            this.lblproyectos_en_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproyectos_en_curso.Location = new System.Drawing.Point(65, 8);
            this.lblproyectos_en_curso.Name = "lblproyectos_en_curso";
            this.lblproyectos_en_curso.Size = new System.Drawing.Size(124, 16);
            this.lblproyectos_en_curso.TabIndex = 0;
            this.lblproyectos_en_curso.Text = "Proyectos en Curso";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(151, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(768, 400);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnMostrar_informacion
            // 
            this.btnMostrar_informacion.Location = new System.Drawing.Point(682, 531);
            this.btnMostrar_informacion.Name = "btnMostrar_informacion";
            this.btnMostrar_informacion.Size = new System.Drawing.Size(158, 37);
            this.btnMostrar_informacion.TabIndex = 6;
            this.btnMostrar_informacion.Text = "Mostrar Informacion";
            this.btnMostrar_informacion.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(973, 609);
            this.Controls.Add(this.btnMostrar_informacion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Total_proyectos_en_curso);
            this.Controls.Add(this.Total_investigadores);
            this.Controls.Add(this.btnTotalsemillero);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.btnTotalsemillero.ResumeLayout(false);
            this.btnTotalsemillero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Total_investigadores.ResumeLayout(false);
            this.Total_investigadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Total_proyectos_en_curso.ResumeLayout(false);
            this.Total_proyectos_en_curso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.GroupBox btnTotalsemillero;
        private System.Windows.Forms.Label lblnumero;
        private System.Windows.Forms.Label Totalsemillerosactivos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Total_investigadores;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal_investigadores;
        private System.Windows.Forms.GroupBox Total_proyectos_en_curso;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblproyectos_en_curso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMostrar_informacion;
    }
}