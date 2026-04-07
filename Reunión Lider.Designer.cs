namespace gestión_semillero_6trimestre
{
    partial class Reunión_Lider
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
            this.btnActualizar_reunion = new System.Windows.Forms.Button();
            this.btn_eliminarReunion = new System.Windows.Forms.Button();
            this.btnAgregar_reunion = new System.Windows.Forms.Button();
            this.lblfecha_reunion = new System.Windows.Forms.Label();
            this.txtIDsemillero = new System.Windows.Forms.TextBox();
            this.fecha_reunion = new System.Windows.Forms.DateTimePicker();
            this.lbl_IdReunion = new System.Windows.Forms.Label();
            this.lbl_descriccion_reunion = new System.Windows.Forms.Label();
            this.lbl_idSemillero = new System.Windows.Forms.Label();
            this.lbl_hora_reunion = new System.Windows.Forms.Label();
            this.txt_IDreunion = new System.Windows.Forms.TextBox();
            this.txtHora_reunion = new System.Windows.Forms.TextBox();
            this.txtDescripcion_reunion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGestionReuniones = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRegistrarProyecto = new System.Windows.Forms.Button();
            this.btnConsultarEventos = new System.Windows.Forms.Button();
            this.btnGestionarSemillero = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnActualizar_reunion);
            this.groupBox1.Controls.Add(this.btn_eliminarReunion);
            this.groupBox1.Controls.Add(this.btnAgregar_reunion);
            this.groupBox1.Controls.Add(this.lblfecha_reunion);
            this.groupBox1.Controls.Add(this.txtIDsemillero);
            this.groupBox1.Controls.Add(this.fecha_reunion);
            this.groupBox1.Controls.Add(this.lbl_IdReunion);
            this.groupBox1.Controls.Add(this.lbl_descriccion_reunion);
            this.groupBox1.Controls.Add(this.lbl_idSemillero);
            this.groupBox1.Controls.Add(this.lbl_hora_reunion);
            this.groupBox1.Controls.Add(this.txt_IDreunion);
            this.groupBox1.Controls.Add(this.txtHora_reunion);
            this.groupBox1.Controls.Add(this.txtDescripcion_reunion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(813, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 564);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión de Reuniones";
            // 
            // btnActualizar_reunion
            // 
            this.btnActualizar_reunion.Location = new System.Drawing.Point(251, 429);
            this.btnActualizar_reunion.Name = "btnActualizar_reunion";
            this.btnActualizar_reunion.Size = new System.Drawing.Size(176, 50);
            this.btnActualizar_reunion.TabIndex = 47;
            this.btnActualizar_reunion.Text = "Actualizar reunión";
            this.btnActualizar_reunion.UseVisualStyleBackColor = true;
            this.btnActualizar_reunion.Click += new System.EventHandler(this.btnActualizar_reunion_Click);
            // 
            // btn_eliminarReunion
            // 
            this.btn_eliminarReunion.Location = new System.Drawing.Point(440, 429);
            this.btn_eliminarReunion.Name = "btn_eliminarReunion";
            this.btn_eliminarReunion.Size = new System.Drawing.Size(176, 50);
            this.btn_eliminarReunion.TabIndex = 46;
            this.btn_eliminarReunion.Text = "Eliminar reunión";
            this.btn_eliminarReunion.UseVisualStyleBackColor = true;
            this.btn_eliminarReunion.Click += new System.EventHandler(this.btn_eliminarReunion_Click);
            // 
            // btnAgregar_reunion
            // 
            this.btnAgregar_reunion.Location = new System.Drawing.Point(57, 429);
            this.btnAgregar_reunion.Name = "btnAgregar_reunion";
            this.btnAgregar_reunion.Size = new System.Drawing.Size(176, 50);
            this.btnAgregar_reunion.TabIndex = 45;
            this.btnAgregar_reunion.Text = "Agregar reunión";
            this.btnAgregar_reunion.UseVisualStyleBackColor = true;
            this.btnAgregar_reunion.Click += new System.EventHandler(this.btnAgregar_reunion_Click);
            // 
            // lblfecha_reunion
            // 
            this.lblfecha_reunion.AutoSize = true;
            this.lblfecha_reunion.Location = new System.Drawing.Point(28, 184);
            this.lblfecha_reunion.Name = "lblfecha_reunion";
            this.lblfecha_reunion.Size = new System.Drawing.Size(229, 20);
            this.lblfecha_reunion.TabIndex = 44;
            this.lblfecha_reunion.Text = "Ingrese la fecha de la reunión";
            // 
            // txtIDsemillero
            // 
            this.txtIDsemillero.Location = new System.Drawing.Point(291, 103);
            this.txtIDsemillero.Name = "txtIDsemillero";
            this.txtIDsemillero.Size = new System.Drawing.Size(136, 27);
            this.txtIDsemillero.TabIndex = 37;
            // 
            // fecha_reunion
            // 
            this.fecha_reunion.Location = new System.Drawing.Point(291, 179);
            this.fecha_reunion.Name = "fecha_reunion";
            this.fecha_reunion.Size = new System.Drawing.Size(325, 27);
            this.fecha_reunion.TabIndex = 39;
            // 
            // lbl_IdReunion
            // 
            this.lbl_IdReunion.AutoSize = true;
            this.lbl_IdReunion.Location = new System.Drawing.Point(28, 67);
            this.lbl_IdReunion.Name = "lbl_IdReunion";
            this.lbl_IdReunion.Size = new System.Drawing.Size(210, 20);
            this.lbl_IdReunion.TabIndex = 40;
            this.lbl_IdReunion.Text = "Ingrese el ID de la reunión ";
            // 
            // lbl_descriccion_reunion
            // 
            this.lbl_descriccion_reunion.AutoSize = true;
            this.lbl_descriccion_reunion.Location = new System.Drawing.Point(41, 253);
            this.lbl_descriccion_reunion.Name = "lbl_descriccion_reunion";
            this.lbl_descriccion_reunion.Size = new System.Drawing.Size(182, 20);
            this.lbl_descriccion_reunion.TabIndex = 41;
            this.lbl_descriccion_reunion.Text = "Descripcion de reunion";
            // 
            // lbl_idSemillero
            // 
            this.lbl_idSemillero.AutoSize = true;
            this.lbl_idSemillero.Location = new System.Drawing.Point(28, 108);
            this.lbl_idSemillero.Name = "lbl_idSemillero";
            this.lbl_idSemillero.Size = new System.Drawing.Size(95, 20);
            this.lbl_idSemillero.TabIndex = 42;
            this.lbl_idSemillero.Text = "Id semillero";
            // 
            // lbl_hora_reunion
            // 
            this.lbl_hora_reunion.AutoSize = true;
            this.lbl_hora_reunion.Location = new System.Drawing.Point(28, 141);
            this.lbl_hora_reunion.Name = "lbl_hora_reunion";
            this.lbl_hora_reunion.Size = new System.Drawing.Size(203, 20);
            this.lbl_hora_reunion.TabIndex = 43;
            this.lbl_hora_reunion.Text = "Ingrese la hora de reunión";
            // 
            // txt_IDreunion
            // 
            this.txt_IDreunion.Location = new System.Drawing.Point(291, 67);
            this.txt_IDreunion.Name = "txt_IDreunion";
            this.txt_IDreunion.Size = new System.Drawing.Size(136, 27);
            this.txt_IDreunion.TabIndex = 35;
            // 
            // txtHora_reunion
            // 
            this.txtHora_reunion.Location = new System.Drawing.Point(291, 136);
            this.txtHora_reunion.Name = "txtHora_reunion";
            this.txtHora_reunion.Size = new System.Drawing.Size(136, 27);
            this.txtHora_reunion.TabIndex = 36;
            // 
            // txtDescripcion_reunion
            // 
            this.txtDescripcion_reunion.Location = new System.Drawing.Point(251, 250);
            this.txtDescripcion_reunion.Multiline = true;
            this.txtDescripcion_reunion.Name = "txtDescripcion_reunion";
            this.txtDescripcion_reunion.Size = new System.Drawing.Size(352, 142);
            this.txtDescripcion_reunion.TabIndex = 38;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnGestionReuniones);
            this.groupBox3.Controls.Add(this.btnSalir);
            this.groupBox3.Controls.Add(this.btnRegistrarProyecto);
            this.groupBox3.Controls.Add(this.btnConsultarEventos);
            this.groupBox3.Controls.Add(this.btnGestionarSemillero);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1460, 100);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            // 
            // btnGestionReuniones
            // 
            this.btnGestionReuniones.Location = new System.Drawing.Point(714, 24);
            this.btnGestionReuniones.Margin = new System.Windows.Forms.Padding(4);
            this.btnGestionReuniones.Name = "btnGestionReuniones";
            this.btnGestionReuniones.Size = new System.Drawing.Size(225, 60);
            this.btnGestionReuniones.TabIndex = 9;
            this.btnGestionReuniones.Text = "Gestionar reuniones";
            this.btnGestionReuniones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestionReuniones.UseVisualStyleBackColor = true;
            this.btnGestionReuniones.Click += new System.EventHandler(this.btnGestionReuniones_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1222, 24);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(225, 60);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistrarProyecto
            // 
            this.btnRegistrarProyecto.Location = new System.Drawing.Point(248, 24);
            this.btnRegistrarProyecto.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarProyecto.Name = "btnRegistrarProyecto";
            this.btnRegistrarProyecto.Size = new System.Drawing.Size(225, 60);
            this.btnRegistrarProyecto.TabIndex = 1;
            this.btnRegistrarProyecto.Text = "Registrar proyecto";
            this.btnRegistrarProyecto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrarProyecto.UseVisualStyleBackColor = true;
            this.btnRegistrarProyecto.Click += new System.EventHandler(this.btnRegistrarProyecto_Click);
            // 
            // btnConsultarEventos
            // 
            this.btnConsultarEventos.Location = new System.Drawing.Point(481, 24);
            this.btnConsultarEventos.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarEventos.Name = "btnConsultarEventos";
            this.btnConsultarEventos.Size = new System.Drawing.Size(225, 60);
            this.btnConsultarEventos.TabIndex = 3;
            this.btnConsultarEventos.Text = "Consultar eventos";
            this.btnConsultarEventos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultarEventos.UseVisualStyleBackColor = true;
            this.btnConsultarEventos.Click += new System.EventHandler(this.btnConsultarEventos_Click);
            // 
            // btnGestionarSemillero
            // 
            this.btnGestionarSemillero.Location = new System.Drawing.Point(15, 24);
            this.btnGestionarSemillero.Margin = new System.Windows.Forms.Padding(4);
            this.btnGestionarSemillero.Name = "btnGestionarSemillero";
            this.btnGestionarSemillero.Size = new System.Drawing.Size(225, 60);
            this.btnGestionarSemillero.TabIndex = 8;
            this.btnGestionarSemillero.Text = "Gestionar semillero";
            this.btnGestionarSemillero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestionarSemillero.UseVisualStyleBackColor = true;
            this.btnGestionarSemillero.Click += new System.EventHandler(this.btnGestionarSemillero_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(731, 590);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Reunión_Lider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gestión_semillero_6trimestre.Properties.Resources.fondo_loguin_semillero__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1482, 793);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Reunión_Lider";
            this.Text = "Reunión_Lider";
            this.Load += new System.EventHandler(this.Reunión_Lider_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActualizar_reunion;
        private System.Windows.Forms.Button btn_eliminarReunion;
        private System.Windows.Forms.Button btnAgregar_reunion;
        private System.Windows.Forms.Label lblfecha_reunion;
        private System.Windows.Forms.TextBox txtIDsemillero;
        private System.Windows.Forms.DateTimePicker fecha_reunion;
        private System.Windows.Forms.Label lbl_IdReunion;
        private System.Windows.Forms.Label lbl_descriccion_reunion;
        private System.Windows.Forms.Label lbl_idSemillero;
        private System.Windows.Forms.Label lbl_hora_reunion;
        private System.Windows.Forms.TextBox txt_IDreunion;
        private System.Windows.Forms.TextBox txtHora_reunion;
        private System.Windows.Forms.TextBox txtDescripcion_reunion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGestionReuniones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRegistrarProyecto;
        private System.Windows.Forms.Button btnConsultarEventos;
        private System.Windows.Forms.Button btnGestionarSemillero;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}