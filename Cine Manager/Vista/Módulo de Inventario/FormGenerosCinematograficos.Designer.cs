namespace Vista
{
    partial class FormGenerosCinematograficos
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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnModificar = new Button();
            label4 = new Label();
            btnVolver = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            txtNombre = new TextBox();
            label2 = new Label();
            dgvGenerosCinematograficos = new DataGridView();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoCinematograficoBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGenerosCinematograficos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generoCinematograficoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dgvGenerosCinematograficos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 316);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(196, 72);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(23, 72);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese nombe del género";
            txtBuscar.Size = new Size(151, 23);
            txtBuscar.TabIndex = 14;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(134, 273);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 32);
            label4.Name = "label4";
            label4.Size = new Size(190, 15);
            label4.TabIndex = 11;
            label4.Text = "Gestión Géneros Cinematograficos";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(663, 273);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(254, 273);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 273);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(108, 128);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(129, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 136);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // dgvGenerosCinematograficos
            // 
            dgvGenerosCinematograficos.AutoGenerateColumns = false;
            dgvGenerosCinematograficos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGenerosCinematograficos.Columns.AddRange(new DataGridViewColumn[] { nombreDataGridViewTextBoxColumn });
            dgvGenerosCinematograficos.DataSource = generoCinematograficoBindingSource;
            dgvGenerosCinematograficos.Location = new Point(386, 22);
            dgvGenerosCinematograficos.Name = "dgvGenerosCinematograficos";
            dgvGenerosCinematograficos.ReadOnly = true;
            dgvGenerosCinematograficos.RowTemplate.Height = 25;
            dgvGenerosCinematograficos.Size = new Size(373, 209);
            dgvGenerosCinematograficos.TabIndex = 5;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generoCinematograficoBindingSource
            // 
            generoCinematograficoBindingSource.DataSource = typeof(Modelo.Entidades.GeneroCinematografico);
            // 
            // FormGenerosCinematograficos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 349);
            Controls.Add(groupBox1);
            Name = "FormGenerosCinematograficos";
            Text = "FormGenerosCinematograficos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGenerosCinematograficos).EndInit();
            ((System.ComponentModel.ISupportInitialize)generoCinematograficoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnVolver;
        private Button btnEliminar;
        private Button btnAgregar;
        private TextBox txtNombre;
        private Label label2;
        private DataGridView dgvGenerosCinematograficos;
        private Label label4;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private BindingSource generoCinematograficoBindingSource;
        private Button btnModificar;
        private Button btnBuscar;
        private TextBox txtBuscar;
    }
}