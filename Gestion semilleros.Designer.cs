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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestion_de_Semilleros = new System.Windows.Forms.Button();
            this.btnGestion_de_usuario = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAgregarSemi = new System.Windows.Forms.Button();
            this.btnActualizarSemi = new System.Windows.Forms.Button();
            this.btnEliminarSemi = new System.Windows.Forms.Button();
            this.groupBoxDetalleSemi = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIDSemillero = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtLider = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLiderSemi = new System.Windows.Forms.Label();
            this.lblLineInvesSemi = new System.Windows.Forms.Label();
            this.lblNombreSemillero = new System.Windows.Forms.Label();
            this.btnConsultarEvento = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActivarSemillero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxDetalleSemi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1042, 21);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 53);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(738, 21);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(174, 53);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnGestion_de_Semilleros
            // 
            this.btnGestion_de_Semilleros.Location = new System.Drawing.Point(556, 21);
            this.btnGestion_de_Semilleros.Margin = new System.Windows.Forms.Padding(4);
            this.btnGestion_de_Semilleros.Name = "btnGestion_de_Semilleros";
            this.btnGestion_de_Semilleros.Size = new System.Drawing.Size(174, 53);
            this.btnGestion_de_Semilleros.TabIndex = 2;
            this.btnGestion_de_Semilleros.Text = "Semilleros";
            this.btnGestion_de_Semilleros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestion_de_Semilleros.UseVisualStyleBackColor = true;
            this.btnGestion_de_Semilleros.Click += new System.EventHandler(this.btnGestion_de_Semilleros_Click);
            // 
            // btnGestion_de_usuario
            // 
            this.btnGestion_de_usuario.Location = new System.Drawing.Point(192, 24);
            this.btnGestion_de_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnGestion_de_usuario.Name = "btnGestion_de_usuario";
            this.btnGestion_de_usuario.Size = new System.Drawing.Size(174, 50);
            this.btnGestion_de_usuario.TabIndex = 1;
            this.btnGestion_de_usuario.Text = " Usuario";
            this.btnGestion_de_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestion_de_usuario.UseVisualStyleBackColor = true;
            this.btnGestion_de_usuario.Click += new System.EventHandler(this.btnGestion_de_usuario_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Location = new System.Drawing.Point(10, 24);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(174, 50);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Menú principal";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 142);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(715, 431);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnAgregarSemi
            // 
            this.btnAgregarSemi.Location = new System.Drawing.Point(14, 321);
            this.btnAgregarSemi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarSemi.Name = "btnAgregarSemi";
            this.btnAgregarSemi.Size = new System.Drawing.Size(191, 43);
            this.btnAgregarSemi.TabIndex = 0;
            this.btnAgregarSemi.Text = "Agregar semillero";
            this.btnAgregarSemi.UseVisualStyleBackColor = true;
            this.btnAgregarSemi.Click += new System.EventHandler(this.btnAgregarSemi_Click);
            // 
            // btnActualizarSemi
            // 
            this.btnActualizarSemi.Location = new System.Drawing.Point(252, 321);
            this.btnActualizarSemi.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizarSemi.Name = "btnActualizarSemi";
            this.btnActualizarSemi.Size = new System.Drawing.Size(232, 43);
            this.btnActualizarSemi.TabIndex = 1;
            this.btnActualizarSemi.Text = "Actualizar semillero";
            this.btnActualizarSemi.UseVisualStyleBackColor = true;
            this.btnActualizarSemi.Click += new System.EventHandler(this.btnActualizarSemi_Click);
            // 
            // btnEliminarSemi
            // 
            this.btnEliminarSemi.Location = new System.Drawing.Point(252, 372);
            this.btnEliminarSemi.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarSemi.Name = "btnEliminarSemi";
            this.btnEliminarSemi.Size = new System.Drawing.Size(232, 43);
            this.btnEliminarSemi.TabIndex = 2;
            this.btnEliminarSemi.Text = "Desactivar semillero";
            this.btnEliminarSemi.UseVisualStyleBackColor = true;
            this.btnEliminarSemi.Click += new System.EventHandler(this.btnEliminarSemi_Click);
            // 
            // groupBoxDetalleSemi
            // 
            this.groupBoxDetalleSemi.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDetalleSemi.Controls.Add(this.btnActivarSemillero);
            this.groupBoxDetalleSemi.Controls.Add(this.txtID);
            this.groupBoxDetalleSemi.Controls.Add(this.lblIDSemillero);
            this.groupBoxDetalleSemi.Controls.Add(this.dateTimePicker1);
            this.groupBoxDetalleSemi.Controls.Add(this.btnEliminarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox1);
            this.groupBoxDetalleSemi.Controls.Add(this.btnActualizarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox2);
            this.groupBoxDetalleSemi.Controls.Add(this.btnAgregarSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.txtLider);
            this.groupBoxDetalleSemi.Controls.Add(this.textBox4);
            this.groupBoxDetalleSemi.Controls.Add(this.label2);
            this.groupBoxDetalleSemi.Controls.Add(this.label1);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLiderSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblLineInvesSemi);
            this.groupBoxDetalleSemi.Controls.Add(this.lblNombreSemillero);
            this.groupBoxDetalleSemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalleSemi.Location = new System.Drawing.Point(761, 158);
            this.groupBoxDetalleSemi.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDetalleSemi.Name = "groupBoxDetalleSemi";
            this.groupBoxDetalleSemi.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDetalleSemi.Size = new System.Drawing.Size(508, 425);
            this.groupBoxDetalleSemi.TabIndex = 24;
            this.groupBoxDetalleSemi.TabStop = false;
            this.groupBoxDetalleSemi.Text = "Detalles del semillero (Actualizar/Eliminar)";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(188, 141);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(193, 27);
            this.txtID.TabIndex = 12;
            // 
            // lblIDSemillero
            // 
            this.lblIDSemillero.AutoSize = true;
            this.lblIDSemillero.Location = new System.Drawing.Point(8, 144);
            this.lblIDSemillero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDSemillero.Name = "lblIDSemillero";
            this.lblIDSemillero.Size = new System.Drawing.Size(126, 20);
            this.lblIDSemillero.TabIndex = 11;
            this.lblIDSemillero.Text = "ID del semillero";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(175, 176);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(309, 27);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 27);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(188, 71);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 27);
            this.textBox2.TabIndex = 8;
            // 
            // txtLider
            // 
            this.txtLider.Location = new System.Drawing.Point(188, 106);
            this.txtLider.Margin = new System.Windows.Forms.Padding(4);
            this.txtLider.Name = "txtLider";
            this.txtLider.Size = new System.Drawing.Size(193, 27);
            this.txtLider.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(14, 245);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(367, 53);
            this.textBox4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 221);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripcion general";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha de creación";
            // 
            // lblLiderSemi
            // 
            this.lblLiderSemi.AutoSize = true;
            this.lblLiderSemi.Location = new System.Drawing.Point(8, 109);
            this.lblLiderSemi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLiderSemi.Name = "lblLiderSemi";
            this.lblLiderSemi.Size = new System.Drawing.Size(147, 20);
            this.lblLiderSemi.TabIndex = 2;
            this.lblLiderSemi.Text = "Lider del semillero";
            // 
            // lblLineInvesSemi
            // 
            this.lblLineInvesSemi.AutoSize = true;
            this.lblLineInvesSemi.Location = new System.Drawing.Point(8, 74);
            this.lblLineInvesSemi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineInvesSemi.Name = "lblLineInvesSemi";
            this.lblLineInvesSemi.Size = new System.Drawing.Size(175, 20);
            this.lblLineInvesSemi.TabIndex = 1;
            this.lblLineInvesSemi.Text = "Linea de investigación";
            // 
            // lblNombreSemillero
            // 
            this.lblNombreSemillero.AutoSize = true;
            this.lblNombreSemillero.Location = new System.Drawing.Point(8, 35);
            this.lblNombreSemillero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreSemillero.Name = "lblNombreSemillero";
            this.lblNombreSemillero.Size = new System.Drawing.Size(164, 20);
            this.lblNombreSemillero.TabIndex = 0;
            this.lblNombreSemillero.Text = "Nombre de semillero";
            // 
            // btnConsultarEvento
            // 
            this.btnConsultarEvento.Location = new System.Drawing.Point(374, 24);
            this.btnConsultarEvento.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarEvento.Name = "btnConsultarEvento";
            this.btnConsultarEvento.Size = new System.Drawing.Size(174, 50);
            this.btnConsultarEvento.TabIndex = 5;
            this.btnConsultarEvento.Text = "Eventos  ";
            this.btnConsultarEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultarEvento.UseVisualStyleBackColor = true;
            this.btnConsultarEvento.Click += new System.EventHandler(this.btnConsultarEvento_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.btnConsultarEvento);
            this.groupBox2.Controls.Add(this.btnReportes);
            this.groupBox2.Controls.Add(this.btnGestion_de_Semilleros);
            this.groupBox2.Controls.Add(this.btnGestion_de_usuario);
            this.groupBox2.Controls.Add(this.btnDashboard);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(55, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1190, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btnActivarSemillero
            // 
            this.btnActivarSemillero.Location = new System.Drawing.Point(19, 374);
            this.btnActivarSemillero.Name = "btnActivarSemillero";
            this.btnActivarSemillero.Size = new System.Drawing.Size(186, 40);
            this.btnActivarSemillero.TabIndex = 13;
            this.btnActivarSemillero.Text = "Activar semillero";
            this.btnActivarSemillero.UseVisualStyleBackColor = true;
            this.btnActivarSemillero.Click += new System.EventHandler(this.btnActivarSemillero_Click);
            // 
            // Gestion_semilleros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1308, 603);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxDetalleSemi);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gestion_semilleros";
            this.Text = "Gestion_semilleros";
            this.Load += new System.EventHandler(this.Gestion_semilleros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxDetalleSemi.ResumeLayout(false);
            this.groupBoxDetalleSemi.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnGestion_de_Semilleros;
        private System.Windows.Forms.Button btnGestion_de_usuario;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarSemi;
        private System.Windows.Forms.Button btnActualizarSemi;
        private System.Windows.Forms.Button btnAgregarSemi;
        private System.Windows.Forms.GroupBox groupBoxDetalleSemi;
        private System.Windows.Forms.Label lblLineInvesSemi;
        private System.Windows.Forms.Label lblNombreSemillero;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLiderSemi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtLider;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIDSemillero;
        private System.Windows.Forms.Button btnConsultarEvento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnActivarSemillero;
    }
}