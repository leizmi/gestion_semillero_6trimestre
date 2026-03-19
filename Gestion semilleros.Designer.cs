namespace gestión_semillero_6trimestre
{
    partial class Gestion_semilleros
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombre_Semillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea_investigacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lider_semillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarSemi = new System.Windows.Forms.Button();
            this.btnActualizarSemi = new System.Windows.Forms.Button();
            this.btnEliminarSemi = new System.Windows.Forms.Button();
            this.groupBoxDetalleSemi = new System.Windows.Forms.GroupBox();
            this.lblNombreSemillero = new System.Windows.Forms.Label();
            this.lblLineInvesSemi = new System.Windows.Forms.Label();
            this.lblLiderSemi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxDetalleSemi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnDashboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(2, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 521);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menú";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(2, 242);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir de la app";
            this.btnSalir.UseVisualStyleBackColor = true;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_Semillero,
            this.Linea_investigacion,
            this.Lider_semillero,
            this.FechaCreacion});
            this.dataGridView1.Location = new System.Drawing.Point(167, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 325);
            this.dataGridView1.TabIndex = 22;
            // 
            // nombre_Semillero
            // 
            this.nombre_Semillero.HeaderText = "Nombre de semillero";
            this.nombre_Semillero.Name = "nombre_Semillero";
            // 
            // Linea_investigacion
            // 
            this.Linea_investigacion.HeaderText = "Linea de investigación";
            this.Linea_investigacion.Name = "Linea_investigacion";
            // 
            // Lider_semillero
            // 
            this.Lider_semillero.HeaderText = "Lider del semillero";
            this.Lider_semillero.Name = "Lider_semillero";
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.HeaderText = "Fecha de creación";
            this.FechaCreacion.Name = "FechaCreacion";
            // 
            // btnAgregarSemi
            // 
            this.btnAgregarSemi.Location = new System.Drawing.Point(13, 242);
            this.btnAgregarSemi.Name = "btnAgregarSemi";
            this.btnAgregarSemi.Size = new System.Drawing.Size(104, 29);
            this.btnAgregarSemi.TabIndex = 0;
            this.btnAgregarSemi.Text = "Agregar semillero";
            this.btnAgregarSemi.UseVisualStyleBackColor = true;
            // 
            // btnActualizarSemi
            // 
            this.btnActualizarSemi.Location = new System.Drawing.Point(159, 242);
            this.btnActualizarSemi.Name = "btnActualizarSemi";
            this.btnActualizarSemi.Size = new System.Drawing.Size(110, 29);
            this.btnActualizarSemi.TabIndex = 1;
            this.btnActualizarSemi.Text = "Actualizar semillero";
            this.btnActualizarSemi.UseVisualStyleBackColor = true;
            // 
            // btnEliminarSemi
            // 
            this.btnEliminarSemi.Location = new System.Drawing.Point(83, 285);
            this.btnEliminarSemi.Name = "btnEliminarSemi";
            this.btnEliminarSemi.Size = new System.Drawing.Size(114, 24);
            this.btnEliminarSemi.TabIndex = 2;
            this.btnEliminarSemi.Text = "Eliminar semillero";
            this.btnEliminarSemi.UseVisualStyleBackColor = true;
            // 
            // groupBoxDetalleSemi
            // 
            this.groupBoxDetalleSemi.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDetalleSemi.Controls.Add(this.btnEliminarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox5);
            this.groupBoxDetalleSemi.Controls.Add(this.btnActualizarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox4);
            this.groupBoxDetalleSemi.Controls.Add(this.btnAgregarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox3);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox2);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox1);
            this.groupBoxDetalleSemi.Controls.Add(this.label2);
            this.groupBoxDetalleSemi.Controls.Add(this.label1);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLiderSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLineInvesSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblNombreSemillero);
            this.groupBoxDetalleSemi.Location = new System.Drawing.Point(629, 74);
            this.groupBoxDetalleSemi.Name = "groupBoxDetalleSemi";
            this.groupBoxDetalleSemi.Size = new System.Drawing.Size(291, 325);
            this.groupBoxDetalleSemi.TabIndex = 24;
            this.groupBoxDetalleSemi.TabStop = false;
            this.groupBoxDetalleSemi.Text = "Detalles del semillero (Actualizar/Eliminar)";
            // 
            // lblNombreSemillero
            // 
            this.lblNombreSemillero.AutoSize = true;
            this.lblNombreSemillero.Location = new System.Drawing.Point(10, 32);
            this.lblNombreSemillero.Name = "lblNombreSemillero";
            this.lblNombreSemillero.Size = new System.Drawing.Size(102, 13);
            this.lblNombreSemillero.TabIndex = 0;
            this.lblNombreSemillero.Text = "Nombre de semillero";
            // 
            // lblLineInvesSemi
            // 
            this.lblLineInvesSemi.AutoSize = true;
            this.lblLineInvesSemi.Location = new System.Drawing.Point(8, 60);
            this.lblLineInvesSemi.Name = "lblLineInvesSemi";
            this.lblLineInvesSemi.Size = new System.Drawing.Size(113, 13);
            this.lblLineInvesSemi.TabIndex = 1;
            this.lblLineInvesSemi.Text = "Linea de investigación";
            // 
            // lblLiderSemi
            // 
            this.lblLiderSemi.AutoSize = true;
            this.lblLiderSemi.Location = new System.Drawing.Point(16, 94);
            this.lblLiderSemi.Name = "lblLiderSemi";
            this.lblLiderSemi.Size = new System.Drawing.Size(90, 13);
            this.lblLiderSemi.TabIndex = 2;
            this.lblLiderSemi.Text = "Lider del semillero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha de creación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripcion general";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 192);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 44);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 90);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 57);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(138, 20);
            this.textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(131, 29);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(138, 20);
            this.textBox5.TabIndex = 9;
            // 
            // Gestion_semilleros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 435);
            this.Controls.Add(this.groupBoxDetalleSemi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Gestion_semilleros";
            this.Text = "Gestion_semilleros";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxDetalleSemi.ResumeLayout(false);
            this.groupBoxDetalleSemi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Semillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea_investigacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lider_semillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.Button btnEliminarSemi;
        private System.Windows.Forms.Button btnActualizarSemi;
        private System.Windows.Forms.Button btnAgregarSemi;
        private System.Windows.Forms.GroupBox groupBoxDetalleSemi;
        private System.Windows.Forms.Label lblLineInvesSemi;
        private System.Windows.Forms.Label lblNombreSemillero;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLiderSemi;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
    }
}