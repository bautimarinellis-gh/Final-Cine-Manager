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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            dgvActoresAsignados = new DataGridView();
            nombreDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            actorBindingSource = new BindingSource(components);
            btnEliminarActor = new Button();
            btnAsignarActor = new Button();
            dgvActoresDisponibles = new DataGridView();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnCancelar = new Button();
            btnAceptar = new Button();
            cmbGenero = new ComboBox();
            cmbDirector = new ComboBox();
            numPrecio = new NumericUpDown();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            clienteBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActoresAsignados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)actorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActoresDisponibles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(cmbGenero);
            groupBox1.Controls.Add(cmbDirector);
            groupBox1.Controls.Add(numPrecio);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(669, 542);
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
            groupBox3.Location = new Point(310, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(333, 510);
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
            dgvActoresAsignados.AutoGenerateColumns = false;
            dgvActoresAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActoresAsignados.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn1, apellidoDataGridViewTextBoxColumn1 });
            dgvActoresAsignados.DataSource = actorBindingSource;
            dgvActoresAsignados.Location = new Point(17, 296);
            dgvActoresAsignados.Name = "dgvActoresAsignados";
            dgvActoresAsignados.ReadOnly = true;
            dgvActoresAsignados.RowTemplate.Height = 25;
            dgvActoresAsignados.Size = new Size(301, 175);
            dgvActoresAsignados.TabIndex = 15;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // apellidoDataGridViewTextBoxColumn1
            // 
            apellidoDataGridViewTextBoxColumn1.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn1.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn1.Name = "apellidoDataGridViewTextBoxColumn1";
            apellidoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // actorBindingSource
            // 
            actorBindingSource.DataSource = typeof(Modelo.Entidades.Actor);
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
            dgvActoresDisponibles.AutoGenerateColumns = false;
            dgvActoresDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActoresDisponibles.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn });
            dgvActoresDisponibles.DataSource = actorBindingSource;
            dgvActoresDisponibles.Location = new Point(17, 54);
            dgvActoresDisponibles.Name = "dgvActoresDisponibles";
            dgvActoresDisponibles.ReadOnly = true;
            dgvActoresDisponibles.RowTemplate.Height = 25;
            dgvActoresDisponibles.Size = new Size(301, 175);
            dgvActoresDisponibles.TabIndex = 13;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(166, 358);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(40, 358);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cmbGenero
            // 
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(121, 253);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(150, 23);
            cmbGenero.TabIndex = 6;
            // 
            // cmbDirector
            // 
            cmbDirector.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDirector.FormattingEnabled = true;
            cmbDirector.Location = new Point(121, 193);
            cmbDirector.Name = "cmbDirector";
            cmbDirector.Size = new Size(150, 23);
            cmbDirector.TabIndex = 5;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(121, 137);
            numPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrecio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 23);
            numPrecio.TabIndex = 3;
            numPrecio.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            label6.Location = new Point(19, 256);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 5;
            label6.Text = "Género:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 145);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 4;
            label5.Text = "Precio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 191);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Director:";
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
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(Modelo.Entidades.Cliente);
            // 
            // FormPelicula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 552);
            Controls.Add(groupBox1);
            Name = "FormPelicula";
            Text = "FormPelicula";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActoresAsignados).EndInit();
            ((System.ComponentModel.ISupportInitialize)actorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActoresDisponibles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cmbGenero;
        private ComboBox cmbDirector;
        private NumericUpDown numPrecio;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private Label label6;
        private Label label5;
        private Label label4;
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
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn1;
        private BindingSource actorBindingSource;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private BindingSource clienteBindingSource;
    }
}