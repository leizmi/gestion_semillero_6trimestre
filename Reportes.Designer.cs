namespace gestión_semillero_6trimestre
{
    partial class Reportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantidadReuniones = new System.Windows.Forms.Label();
            this.lblCantidadEventos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidadInvestigadores = new System.Windows.Forms.Label();
            this.lblCantidadSemi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMostrarCantidadInvestigadores = new System.Windows.Forms.Button();
            this.btnMostrarCantidadEventos = new System.Windows.Forms.Button();
            this.btnMostrarCantidadReuniones = new System.Windows.Forms.Button();
            this.btnMostrarCantidadSemileros = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnDashboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 521);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menú";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Gestion de eventos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(2, 296);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir de la app";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(0, 187);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(144, 44);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
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
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(0, 72);
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
            this.btnDashboard.Location = new System.Drawing.Point(0, 25);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(144, 41);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Menú principal";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.lblCantidadReuniones);
            this.groupBox2.Controls.Add(this.lblCantidadEventos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblCantidadInvestigadores);
            this.groupBox2.Controls.Add(this.lblCantidadSemi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(177, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 206);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // lblCantidadReuniones
            // 
            this.lblCantidadReuniones.AutoSize = true;
            this.lblCantidadReuniones.Location = new System.Drawing.Point(420, 170);
            this.lblCantidadReuniones.Name = "lblCantidadReuniones";
            this.lblCantidadReuniones.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadReuniones.TabIndex = 9;
            this.lblCantidadReuniones.Text = "label7";
            // 
            // lblCantidadEventos
            // 
            this.lblCantidadEventos.AutoSize = true;
            this.lblCantidadEventos.Location = new System.Drawing.Point(343, 119);
            this.lblCantidadEventos.Name = "lblCantidadEventos";
            this.lblCantidadEventos.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadEventos.TabIndex = 7;
            this.lblCantidadEventos.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "CANTIDAD TOTAL DE EVENTOS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(385, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "CANTIDAD TOTAL DE REUNIONES PROGRAMAS:";
            // 
            // lblCantidadInvestigadores
            // 
            this.lblCantidadInvestigadores.AutoSize = true;
            this.lblCantidadInvestigadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadInvestigadores.Location = new System.Drawing.Point(344, 69);
            this.lblCantidadInvestigadores.Name = "lblCantidadInvestigadores";
            this.lblCantidadInvestigadores.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadInvestigadores.TabIndex = 3;
            this.lblCantidadInvestigadores.Text = "label4";
            // 
            // lblCantidadSemi
            // 
            this.lblCantidadSemi.AutoSize = true;
            this.lblCantidadSemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadSemi.Location = new System.Drawing.Point(344, 23);
            this.lblCantidadSemi.Name = "lblCantidadSemi";
            this.lblCantidadSemi.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadSemi.TabIndex = 2;
            this.lblCantidadSemi.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CANTIDAD TOTAL DE INVESTIGADORES:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CANTIDAD DE SEMILLEROS EN TOTAL: ";
            // 
            // btnMostrarCantidadInvestigadores
            // 
            this.btnMostrarCantidadInvestigadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarCantidadInvestigadores.Location = new System.Drawing.Point(700, 90);
            this.btnMostrarCantidadInvestigadores.Name = "btnMostrarCantidadInvestigadores";
            this.btnMostrarCantidadInvestigadores.Size = new System.Drawing.Size(213, 48);
            this.btnMostrarCantidadInvestigadores.TabIndex = 27;
            this.btnMostrarCantidadInvestigadores.Text = "Mostrar cantidad de investigadores";
            this.btnMostrarCantidadInvestigadores.UseVisualStyleBackColor = true;
            this.btnMostrarCantidadInvestigadores.Click += new System.EventHandler(this.btnMostrarCantidadInvestigadores_Click);
            // 
            // btnMostrarCantidadEventos
            // 
            this.btnMostrarCantidadEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarCantidadEventos.Location = new System.Drawing.Point(700, 144);
            this.btnMostrarCantidadEventos.Name = "btnMostrarCantidadEventos";
            this.btnMostrarCantidadEventos.Size = new System.Drawing.Size(213, 48);
            this.btnMostrarCantidadEventos.TabIndex = 28;
            this.btnMostrarCantidadEventos.Text = "Mostrar cantidad de eventos";
            this.btnMostrarCantidadEventos.UseVisualStyleBackColor = true;
            this.btnMostrarCantidadEventos.Click += new System.EventHandler(this.btnMostrarCantidadEventos_Click);
            // 
            // btnMostrarCantidadReuniones
            // 
            this.btnMostrarCantidadReuniones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarCantidadReuniones.Location = new System.Drawing.Point(700, 211);
            this.btnMostrarCantidadReuniones.Name = "btnMostrarCantidadReuniones";
            this.btnMostrarCantidadReuniones.Size = new System.Drawing.Size(213, 37);
            this.btnMostrarCantidadReuniones.TabIndex = 30;
            this.btnMostrarCantidadReuniones.Text = "Mostrar cantidad de reuniones programadas";
            this.btnMostrarCantidadReuniones.UseVisualStyleBackColor = true;
            this.btnMostrarCantidadReuniones.Click += new System.EventHandler(this.btnMostrarCantidadReuniones_Click);
            // 
            // btnMostrarCantidadSemileros
            // 
            this.btnMostrarCantidadSemileros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnMostrarCantidadSemileros.Location = new System.Drawing.Point(700, 49);
            this.btnMostrarCantidadSemileros.Name = "btnMostrarCantidadSemileros";
            this.btnMostrarCantidadSemileros.Size = new System.Drawing.Size(213, 32);
            this.btnMostrarCantidadSemileros.TabIndex = 31;
            this.btnMostrarCantidadSemileros.Text = "Mostrar cantidad de semilleros";
            this.btnMostrarCantidadSemileros.UseVisualStyleBackColor = true;
            this.btnMostrarCantidadSemileros.Click += new System.EventHandler(this.btnMostrarCantidadSemileros_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(177, 273);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Semilleros por nombre";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(504, 236);
            this.chart1.TabIndex = 32;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(936, 519);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnMostrarCantidadSemileros);
            this.Controls.Add(this.btnMostrarCantidadReuniones);
            this.Controls.Add(this.btnMostrarCantidadInvestigadores);
            this.Controls.Add(this.btnMostrarCantidadEventos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCantidadInvestigadores;
        private System.Windows.Forms.Label lblCantidadSemi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidadEventos;
        private System.Windows.Forms.Label lblCantidadReuniones;
        private System.Windows.Forms.Button btnMostrarCantidadInvestigadores;
        private System.Windows.Forms.Button btnMostrarCantidadEventos;
        private System.Windows.Forms.Button btnMostrarCantidadReuniones;
        private System.Windows.Forms.Button btnMostrarCantidadSemileros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}