namespace Vista
{
    partial class FormPelicula
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
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            dgvActoresAsignados = new DataGridView();
            btnEliminarActor = new Button();
            btnAsignarActor = new Button();
            dgvActoresDisponibles = new DataGridView();
            groupBox2 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            dgvProvAsignados = new DataGridView();
            btnEliminarProv = new Button();
            btnAsignarProv = new Button();
            dgvProvDisponibles = new DataGridView();
            btnCancelar = new Button();
            btnAceptar = new Button();
            cmbGenero = new ComboBox();
            cmbDirector = new ComboBox();
            numCantidad = new NumericUpDown();
            numPrecio = new NumericUpDown();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActoresAsignados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActoresDisponibles).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProvAsignados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProvDisponibles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(cmbGenero);
            groupBox1.Controls.Add(cmbDirector);
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(numPrecio);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(987, 542);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(dgvActoresAsignados);
            groupBox3.Controls.Add(btnEliminarActor);
            groupBox3.Controls.Add(btnAsignarActor);
            groupBox3.Controls.Add(dgvActoresDisponibles);
            groupBox3.Location = new Point(646, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(324, 510);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(98, 266);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 5;
            label9.Text = "Actores Asignados";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(92, 27);
            label10.Name = "label10";
            label10.Size = new Size(111, 15);
            label10.TabIndex = 4;
            label10.Text = "Actores Disponibles";
            // 
            // dgvActoresAsignados
            // 
            dgvActoresAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActoresAsignados.Location = new Point(17, 296);
            dgvActoresAsignados.Name = "dgvActoresAsignados";
            dgvActoresAsignados.ReadOnly = true;
            dgvActoresAsignados.RowTemplate.Height = 25;
            dgvActoresAsignados.Size = new Size(284, 175);
            dgvActoresAsignados.TabIndex = 15;
            // 
            // btnEliminarActor
            // 
            btnEliminarActor.Location = new Point(17, 481);
            btnEliminarActor.Name = "btnEliminarActor";
            btnEliminarActor.Size = new Size(67, 23);
            btnEliminarActor.TabIndex = 16;
            btnEliminarActor.Text = "Eliminar";
            btnEliminarActor.UseVisualStyleBackColor = true;
            btnEliminarActor.Click += btnEliminarActor_Click;
            // 
            // btnAsignarActor
            // 
            btnAsignarActor.Location = new Point(17, 235);
            btnAsignarActor.Name = "btnAsignarActor";
            btnAsignarActor.Size = new Size(67, 23);
            btnAsignarActor.TabIndex = 14;
            btnAsignarActor.Text = "Asignar";
            btnAsignarActor.UseVisualStyleBackColor = true;
            btnAsignarActor.Click += btnAsignarActor_Click;
            // 
            // dgvActoresDisponibles
            // 
            dgvActoresDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActoresDisponibles.Location = new Point(17, 54);
            dgvActoresDisponibles.Name = "dgvActoresDisponibles";
            dgvActoresDisponibles.ReadOnly = true;
            dgvActoresDisponibles.RowTemplate.Height = 25;
            dgvActoresDisponibles.Size = new Size(284, 175);
            dgvActoresDisponibles.TabIndex = 13;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dgvProvAsignados);
            groupBox2.Controls.Add(btnEliminarProv);
            groupBox2.Controls.Add(btnAsignarProv);
            groupBox2.Controls.Add(dgvProvDisponibles);
            groupBox2.Location = new Point(296, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(324, 510);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(98, 266);
            label8.Name = "label8";
            label8.Size = new Size(130, 15);
            label8.TabIndex = 5;
            label8.Text = "Proveedores Asignados";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(92, 27);
            label7.Name = "label7";
            label7.Size = new Size(136, 15);
            label7.TabIndex = 4;
            label7.Text = "Proveedores Disponibles";
            // 
            // dgvProvAsignados
            // 
            dgvProvAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProvAsignados.Location = new Point(17, 296);
            dgvProvAsignados.Name = "dgvProvAsignados";
            dgvProvAsignados.ReadOnly = true;
            dgvProvAsignados.RowTemplate.Height = 25;
            dgvProvAsignados.Size = new Size(284, 175);
            dgvProvAsignados.TabIndex = 11;
            // 
            // btnEliminarProv
            // 
            btnEliminarProv.Location = new Point(17, 481);
            btnEliminarProv.Name = "btnEliminarProv";
            btnEliminarProv.Size = new Size(67, 23);
            btnEliminarProv.TabIndex = 12;
            btnEliminarProv.Text = "Eliminar";
            btnEliminarProv.UseVisualStyleBackColor = true;
            btnEliminarProv.Click += btnEliminarProv_Click;
            // 
            // btnAsignarProv
            // 
            btnAsignarProv.Location = new Point(17, 235);
            btnAsignarProv.Name = "btnAsignarProv";
            btnAsignarProv.Size = new Size(67, 23);
            btnAsignarProv.TabIndex = 10;
            btnAsignarProv.Text = "Asignar";
            btnAsignarProv.UseVisualStyleBackColor = true;
            btnAsignarProv.Click += btnAsignarProv_Click;
            // 
            // dgvProvDisponibles
            // 
            dgvProvDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProvDisponibles.Location = new Point(17, 54);
            dgvProvDisponibles.Name = "dgvProvDisponibles";
            dgvProvDisponibles.ReadOnly = true;
            dgvProvDisponibles.RowTemplate.Height = 25;
            dgvProvDisponibles.Size = new Size(284, 175);
            dgvProvDisponibles.TabIndex = 9;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(182, 413);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(56, 413);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(121, 330);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(150, 23);
            cmbGenero.TabIndex = 6;
            // 
            // cmbDirector
            // 
            cmbDirector.FormattingEnabled = true;
            cmbDirector.Location = new Point(121, 270);
            cmbDirector.Name = "cmbDirector";
            cmbDirector.Size = new Size(150, 23);
            cmbDirector.TabIndex = 5;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(121, 204);
            numCantidad.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(150, 23);
            numCantidad.TabIndex = 4;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(121, 141);
            numPrecio.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 23);
            numPrecio.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 83);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(121, 23);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(150, 23);
            txtCodigo.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 333);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 5;
            label6.Text = "Género:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 149);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 4;
            label5.Text = "Precio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 268);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Director:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 204);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 86);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 31);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Codigo:";
            // 
            // FormPelicula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 552);
            Controls.Add(groupBox1);
            Name = "FormPelicula";
            Text = "FormPelicula";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActoresAsignados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActoresDisponibles).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProvAsignados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProvDisponibles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cmbGenero;
        private ComboBox cmbDirector;
        private NumericUpDown numCantidad;
        private NumericUpDown numPrecio;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnCancelar;
        private Button btnAceptar;
        private GroupBox groupBox2;
        private Button btnAsignarProv;
        private DataGridView dgvProvDisponibles;
        private Button btnEliminarProv;
        private DataGridView dgvProvAsignados;
        private Label label8;
        private Label label7;
        private GroupBox groupBox3;
        private Label label9;
        private Label label10;
        private DataGridView dgvActoresAsignados;
        private Button btnEliminarActor;
        private Button btnAsignarActor;
        private DataGridView dgvActoresDisponibles;
    }
}