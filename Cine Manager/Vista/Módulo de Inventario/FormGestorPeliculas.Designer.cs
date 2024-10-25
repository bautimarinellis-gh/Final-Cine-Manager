namespace Vista
{
    partial class FormGestorPeliculas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestorPeliculas));
            dgvPeliculas = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            directorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoCinematograficoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            peliculaBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnVolver = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            toolStrip1 = new ToolStrip();
            toolStripInformacion = new ToolStripDropDownButton();
            directoresToolStripMenuItem = new ToolStripMenuItem();
            generosCinematograficosToolStripMenuItem = new ToolStripMenuItem();
            actoresToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPeliculas
            // 
            dgvPeliculas.AutoGenerateColumns = false;
            dgvPeliculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeliculas.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, precioDataGridViewTextBoxColumn, directorDataGridViewTextBoxColumn, generoCinematograficoDataGridViewTextBoxColumn });
            dgvPeliculas.DataSource = peliculaBindingSource;
            dgvPeliculas.Location = new Point(16, 135);
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.RowTemplate.Height = 25;
            dgvPeliculas.Size = new Size(699, 267);
            dgvPeliculas.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // directorDataGridViewTextBoxColumn
            // 
            directorDataGridViewTextBoxColumn.DataPropertyName = "Director";
            directorDataGridViewTextBoxColumn.HeaderText = "Director";
            directorDataGridViewTextBoxColumn.Name = "directorDataGridViewTextBoxColumn";
            directorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generoCinematograficoDataGridViewTextBoxColumn
            // 
            generoCinematograficoDataGridViewTextBoxColumn.DataPropertyName = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.HeaderText = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.Name = "generoCinematograficoDataGridViewTextBoxColumn";
            generoCinematograficoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // peliculaBindingSource
            // 
            peliculaBindingSource.DataSource = typeof(Modelo.Entidades.Pelicula);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Controls.Add(dgvPeliculas);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(731, 454);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 104);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 19;
            label1.Text = "Grilla de Peliculas";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(242, 47);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(16, 48);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre de la película";
            txtBuscar.Size = new Size(188, 23);
            txtBuscar.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(640, 420);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(242, 420);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(124, 420);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(16, 420);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripInformacion });
            toolStrip1.Location = new Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(725, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripInformacion
            // 
            toolStripInformacion.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripInformacion.DropDownItems.AddRange(new ToolStripItem[] { directoresToolStripMenuItem, generosCinematograficosToolStripMenuItem, actoresToolStripMenuItem, reportesToolStripMenuItem });
            toolStripInformacion.Image = (Image)resources.GetObject("toolStripInformacion.Image");
            toolStripInformacion.ImageTransparentColor = Color.Magenta;
            toolStripInformacion.Name = "toolStripInformacion";
            toolStripInformacion.Size = new Size(110, 22);
            toolStripInformacion.Text = "Más Información";
            // 
            // directoresToolStripMenuItem
            // 
            directoresToolStripMenuItem.Name = "directoresToolStripMenuItem";
            directoresToolStripMenuItem.Size = new Size(214, 22);
            directoresToolStripMenuItem.Text = "Directores";
            directoresToolStripMenuItem.Click += directoresToolStripMenuItem_Click;
            // 
            // generosCinematograficosToolStripMenuItem
            // 
            generosCinematograficosToolStripMenuItem.Name = "generosCinematograficosToolStripMenuItem";
            generosCinematograficosToolStripMenuItem.Size = new Size(214, 22);
            generosCinematograficosToolStripMenuItem.Text = "Generos Cinematograficos";
            generosCinematograficosToolStripMenuItem.Click += generosCinematograficosToolStripMenuItem_Click;
            // 
            // actoresToolStripMenuItem
            // 
            actoresToolStripMenuItem.Name = "actoresToolStripMenuItem";
            actoresToolStripMenuItem.Size = new Size(214, 22);
            actoresToolStripMenuItem.Text = "Actores";
            actoresToolStripMenuItem.Click += actoresToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(214, 22);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // FormGestorPeliculas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 478);
            Controls.Add(groupBox1);
            Name = "FormGestorPeliculas";
            Text = "FormGestorPeliculas";
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).EndInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPeliculas;
        private GroupBox groupBox1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripInformacion;
        private Button btnVolver;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private ToolStripMenuItem directoresToolStripMenuItem;
        private ToolStripMenuItem generosCinematograficosToolStripMenuItem;
        private ToolStripMenuItem actoresToolStripMenuItem;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoCinematograficoDataGridViewTextBoxColumn;
        private BindingSource peliculaBindingSource;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label1;
        private ToolStripMenuItem reportesToolStripMenuItem;
    }
}