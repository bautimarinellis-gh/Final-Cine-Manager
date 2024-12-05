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
            dgvPeliculas.Location = new Point(18, 180);
            dgvPeliculas.Margin = new Padding(3, 4, 3, 4);
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.RowHeadersWidth = 51;
            dgvPeliculas.RowTemplate.Height = 25;
            dgvPeliculas.Size = new Size(854, 356);
            dgvPeliculas.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            codigoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            cantidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            precioDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            precioDataGridViewTextBoxColumn.ReadOnly = true;
            precioDataGridViewTextBoxColumn.Width = 125;
            // 
            // directorDataGridViewTextBoxColumn
            // 
            directorDataGridViewTextBoxColumn.DataPropertyName = "Director";
            directorDataGridViewTextBoxColumn.HeaderText = "Director";
            directorDataGridViewTextBoxColumn.MinimumWidth = 6;
            directorDataGridViewTextBoxColumn.Name = "directorDataGridViewTextBoxColumn";
            directorDataGridViewTextBoxColumn.ReadOnly = true;
            directorDataGridViewTextBoxColumn.Width = 125;
            // 
            // generoCinematograficoDataGridViewTextBoxColumn
            // 
            generoCinematograficoDataGridViewTextBoxColumn.DataPropertyName = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.HeaderText = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.MinimumWidth = 6;
            generoCinematograficoDataGridViewTextBoxColumn.Name = "generoCinematograficoDataGridViewTextBoxColumn";
            generoCinematograficoDataGridViewTextBoxColumn.ReadOnly = true;
            generoCinematograficoDataGridViewTextBoxColumn.Width = 125;
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
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(897, 605);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(345, 139);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 19;
            label1.Text = "Grilla de Peliculas";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(277, 63);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 31);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(18, 64);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre de la película";
            txtBuscar.Size = new Size(214, 27);
            txtBuscar.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(786, 560);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(277, 560);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(142, 560);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 31);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(18, 560);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripInformacion });
            toolStrip1.Location = new Point(3, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(891, 27);
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
            toolStripInformacion.Size = new Size(134, 24);
            toolStripInformacion.Text = "Más Información";
            // 
            // directoresToolStripMenuItem
            // 
            directoresToolStripMenuItem.Name = "directoresToolStripMenuItem";
            directoresToolStripMenuItem.Size = new Size(267, 26);
            directoresToolStripMenuItem.Text = "Directores";
            directoresToolStripMenuItem.Click += directoresToolStripMenuItem_Click;
            // 
            // generosCinematograficosToolStripMenuItem
            // 
            generosCinematograficosToolStripMenuItem.Name = "generosCinematograficosToolStripMenuItem";
            generosCinematograficosToolStripMenuItem.Size = new Size(267, 26);
            generosCinematograficosToolStripMenuItem.Text = "Generos Cinematograficos";
            generosCinematograficosToolStripMenuItem.Click += generosCinematograficosToolStripMenuItem_Click;
            // 
            // actoresToolStripMenuItem
            // 
            actoresToolStripMenuItem.Name = "actoresToolStripMenuItem";
            actoresToolStripMenuItem.Size = new Size(267, 26);
            actoresToolStripMenuItem.Text = "Actores";
            actoresToolStripMenuItem.Click += actoresToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(267, 26);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // FormGestorPeliculas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 637);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
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