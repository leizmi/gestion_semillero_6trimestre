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
            this.btnGestionarSemillero = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxDetalleSemi = new System.Windows.Forms.GroupBox();
            this.btnAgregarSemi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblIDSemillero = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarSemi = new System.Windows.Forms.Button();
            this.btnActualizarSemi = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnMostraSemiDataGridView = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLiderSemi = new System.Windows.Forms.Label();
            this.lblLineInvesSemi = new System.Windows.Forms.Label();
            this.lblNombreSemillero = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nombre_Semillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea_investigacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lider_semillero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxDetalleSemi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnGestionarSemillero);
            this.groupBox1.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(196, 503);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btnGestionarSemillero
            // 
            this.btnGestionarSemillero.Location = new System.Drawing.Point(0, 36);
            this.btnGestionarSemillero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGestionarSemillero.Name = "btnGestionarSemillero";
            this.btnGestionarSemillero.Size = new System.Drawing.Size(187, 59);
            this.btnGestionarSemillero.TabIndex = 8;
            this.btnGestionarSemillero.Text = "Gestionar semillero";
            this.btnGestionarSemillero.UseVisualStyleBackColor = true;
            this.btnGestionarSemillero.Click += new System.EventHandler(this.btnGestionarSemillero_Click);
            // 
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(0, 137);
            this.btnGestion_de_usuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGestion_de_usuario.Name = "btnGestion_de_usuario";
            this.btnGestion_de_usuario.Size = new System.Drawing.Size(187, 60);
            this.btnGestion_de_usuario.TabIndex = 1;
            this.btnGestion_de_usuario.Text = "Registrar proyecto";
            this.btnGestion_de_usuario.UseVisualStyleBackColor = true;
            this.btnGestion_de_usuario.Click += new System.EventHandler(this.btnGestion_de_usuario_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1, 330);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(187, 53);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(0, 233);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(187, 63);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reporte";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(324, 49);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(592, 198);
            this.dataGridView1.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1025, 49);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(317, 162);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda por filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione un semillero";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "adasasd"});
            this.comboBox1.Location = new System.Drawing.Point(25, 65);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(253, 33);
            this.comboBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 107);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Realizar busqueda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBoxDetalleSemi
            // 
            this.groupBoxDetalleSemi.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDetalleSemi.Controls.Add(this.btnAgregarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox1);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox5);
            this.groupBoxDetalleSemi.Controls.Add(this.lblIDSemillero);
            this.groupBoxDetalleSemi.Controls.Add(this.dateTimePicker1);
            this.groupBoxDetalleSemi.Controls.Add(this.btnEliminarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.btnActualizarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox2);
            this.groupBoxDetalleSemi.Controls.Add(this.btnMostraSemiDataGridView);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox3);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox4);
            this.groupBoxDetalleSemi.Controls.Add(this.label2);
            this.groupBoxDetalleSemi.Controls.Add(this.label3);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLiderSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLineInvesSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblNombreSemillero);
            this.groupBoxDetalleSemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalleSemi.Location = new System.Drawing.Point(324, 345);
            this.groupBoxDetalleSemi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDetalleSemi.Name = "groupBoxDetalleSemi";
            this.groupBoxDetalleSemi.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDetalleSemi.Size = new System.Drawing.Size(520, 500);
            this.groupBoxDetalleSemi.TabIndex = 25;
            this.groupBoxDetalleSemi.TabStop = false;
            this.groupBoxDetalleSemi.Text = "Detalles del semillero (Actualizar/Eliminar)";
            // 
            // btnAgregarSemi
            // 
            this.btnAgregarSemi.Location = new System.Drawing.Point(148, 460);
            this.btnAgregarSemi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarSemi.Name = "btnAgregarSemi";
            this.btnAgregarSemi.Size = new System.Drawing.Size(209, 36);
            this.btnAgregarSemi.TabIndex = 14;
            this.btnAgregarSemi.Text = "Agregar semillero";
            this.btnAgregarSemi.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(233, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 30);
            this.textBox1.TabIndex = 13;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(233, 229);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(252, 30);
            this.textBox5.TabIndex = 12;
            // 
            // lblIDSemillero
            // 
            this.lblIDSemillero.AutoSize = true;
            this.lblIDSemillero.Location = new System.Drawing.Point(23, 228);
            this.lblIDSemillero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDSemillero.Name = "lblIDSemillero";
            this.lblIDSemillero.Size = new System.Drawing.Size(144, 25);
            this.lblIDSemillero.TabIndex = 11;
            this.lblIDSemillero.Text = "ID del semillero";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(232, 270);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(276, 30);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // btnEliminarSemi
            // 
            this.btnEliminarSemi.Location = new System.Drawing.Point(259, 415);
            this.btnEliminarSemi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarSemi.Name = "btnEliminarSemi";
            this.btnEliminarSemi.Size = new System.Drawing.Size(191, 38);
            this.btnEliminarSemi.TabIndex = 2;
            this.btnEliminarSemi.Text = "Eliminar semillero";
            this.btnEliminarSemi.UseVisualStyleBackColor = true;
            // 
            // btnActualizarSemi
            // 
            this.btnActualizarSemi.Location = new System.Drawing.Point(41, 415);
            this.btnActualizarSemi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizarSemi.Name = "btnActualizarSemi";
            this.btnActualizarSemi.Size = new System.Drawing.Size(209, 38);
            this.btnActualizarSemi.TabIndex = 1;
            this.btnActualizarSemi.Text = "Actualizar semillero";
            this.btnActualizarSemi.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 143);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 30);
            this.textBox2.TabIndex = 8;
            // 
            // btnMostraSemiDataGridView
            // 
            this.btnMostraSemiDataGridView.Location = new System.Drawing.Point(148, 43);
            this.btnMostraSemiDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostraSemiDataGridView.Name = "btnMostraSemiDataGridView";
            this.btnMostraSemiDataGridView.Size = new System.Drawing.Size(191, 36);
            this.btnMostraSemiDataGridView.TabIndex = 0;
            this.btnMostraSemiDataGridView.Text = "Mostrar semillero";
            this.btnMostraSemiDataGridView.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(232, 183);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(253, 30);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(24, 340);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(461, 53);
            this.textBox4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 313);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripcion general";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de creación";
            // 
            // lblLiderSemi
            // 
            this.lblLiderSemi.AutoSize = true;
            this.lblLiderSemi.Location = new System.Drawing.Point(19, 188);
            this.lblLiderSemi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLiderSemi.Name = "lblLiderSemi";
            this.lblLiderSemi.Size = new System.Drawing.Size(168, 25);
            this.lblLiderSemi.TabIndex = 2;
            this.lblLiderSemi.Text = "Lider del semillero";
            // 
            // lblLineInvesSemi
            // 
            this.lblLineInvesSemi.AutoSize = true;
            this.lblLineInvesSemi.Location = new System.Drawing.Point(12, 146);
            this.lblLineInvesSemi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineInvesSemi.Name = "lblLineInvesSemi";
            this.lblLineInvesSemi.Size = new System.Drawing.Size(205, 25);
            this.lblLineInvesSemi.TabIndex = 1;
            this.lblLineInvesSemi.Text = "Linea de investigación";
            // 
            // lblNombreSemillero
            // 
            this.lblNombreSemillero.AutoSize = true;
            this.lblNombreSemillero.Location = new System.Drawing.Point(15, 112);
            this.lblNombreSemillero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreSemillero.Name = "lblNombreSemillero";
            this.lblNombreSemillero.Size = new System.Drawing.Size(190, 25);
            this.lblNombreSemillero.TabIndex = 0;
            this.lblNombreSemillero.Text = "Nombre de semillero";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_Semillero,
            this.Linea_investigacion,
            this.Lider_semillero,
            this.FechaCreacion});
            this.dataGridView2.Location = new System.Drawing.Point(897, 359);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(592, 485);
            this.dataGridView2.TabIndex = 26;
            // 
            // nombre_Semillero
            // 
            this.nombre_Semillero.HeaderText = "Nombre de semillero";
            this.nombre_Semillero.MinimumWidth = 6;
            this.nombre_Semillero.Name = "nombre_Semillero";
            this.nombre_Semillero.Width = 125;
            // 
            // Linea_investigacion
            // 
            this.Linea_investigacion.HeaderText = "Linea de investigación";
            this.Linea_investigacion.MinimumWidth = 6;
            this.Linea_investigacion.Name = "Linea_investigacion";
            this.Linea_investigacion.Width = 125;
            // 
            // Lider_semillero
            // 
            this.Lider_semillero.HeaderText = "Lider del semillero";
            this.Lider_semillero.MinimumWidth = 6;
            this.Lider_semillero.Name = "Lider_semillero";
            this.Lider_semillero.Width = 125;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.HeaderText = "Fecha de creación";
            this.FechaCreacion.MinimumWidth = 6;
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.Width = 125;
            // 
            // Menu_Lider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1560, 951);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBoxDetalleSemi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu_Lider";
            this.Text = "Menu_Lider";
            this.Load += new System.EventHandler(this.Menu_Lider_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDetalleSemi.ResumeLayout(false);
            this.groupBoxDetalleSemi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnGestionarSemillero;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDetalleSemi;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblIDSemillero;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnEliminarSemi;
        private System.Windows.Forms.Button btnActualizarSemi;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnMostraSemiDataGridView;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLiderSemi;
        private System.Windows.Forms.Label lblLineInvesSemi;
        private System.Windows.Forms.Label lblNombreSemillero;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Semillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea_investigacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lider_semillero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.Button btnAgregarSemi;
    }
}