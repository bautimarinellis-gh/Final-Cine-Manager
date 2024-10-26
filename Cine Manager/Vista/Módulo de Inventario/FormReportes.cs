using Controladora.Negocio;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Importaciones de iText7
using iText.Kernel.Pdf; // Para PdfWriter y PdfDocument
using iText.Layout; // Para Document
using iText.Layout.Element; // Para los elementos de Layout como Table y Paragraph
using System.Collections.ObjectModel;
using Modelo.Entidades;
using iText.Layout.Properties;
using iText.Kernel.Colors;



namespace Vista.Módulo_de_Inventario
{
    public partial class FormReportes : Form
    {
        private Sesion _sesion;

        public FormReportes(Sesion sesion)
        {
            InitializeComponent();
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbTipoReporte.SelectedIndexChanged += cmbTipoReporte_SelectedIndexChanged;

            // Cargar el primer reporte como predeterminado si existe una opción
            if (cmbTipoReporte.Items.Count > 0)
            {
                cmbTipoReporte.SelectedIndex = 0; // Selecciona el primer reporte
            }

            this._sesion = sesion;
        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            // Crear la ruta para guardar el PDF en la carpeta correspondiente
            string pdfPath = CrearRutaPdf();

            using (var writer = new PdfWriter(pdfPath))
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                // Agregar encabezado común
                AgregarEncabezado(document);

                // Verificar el reporte seleccionado y exportar el reporte correspondiente
                switch (cmbTipoReporte.SelectedIndex)
                {
                    case 0: // Películas más vendidas
                        var peliculasMasVendidas = ControladoraReportes.Instancia.RecuperarPeliculasMasVendidas();
                        AgregarTablaPeliculasMasVendidas(document, peliculasMasVendidas);
                        break;

                    case 1: // Proveedores con órdenes pendientes
                        var proveedoresConPendientes = ControladoraReportes.Instancia.RecuperarProveedoresConOrdenesPendientes();
                        AgregarTablaProveedoresConOrdenesPendientes(document, proveedoresConPendientes);
                        break;
                    case 2:
                        var peliculasBajaDisponibilidad = ControladoraReportes.Instancia.RecuperarPeliculasConBajaDisponibilidad();
                        AgregarTablaPeliculasConBajaDisponibilidad(document, peliculasBajaDisponibilidad);
                        break;

                }

                document.Close(); // Cerrar el documento
            }

            // Informar al usuario que el archivo se ha creado
            MessageBox.Show($"PDF exportado correctamente a {pdfPath}");
        }



        #region Metodos de exportación de PDFS

        /// Método para crear la ruta del PDF en la carpeta específica de cada reporte
        private string CrearRutaPdf()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = System.IO.Path.Combine(desktopPath, "PDFS CineManager");

            // Subcarpetas específicas para cada tipo de reporte
            string subfolderPath;
            switch (cmbTipoReporte.SelectedIndex)
            {
                case 0:
                    subfolderPath = System.IO.Path.Combine(folderPath, "Reportes Peliculas mas vendidas");
                    break;
                case 1:
                    subfolderPath = System.IO.Path.Combine(folderPath, "Reportes Proveedores con ordenes de compra pendientes");
                    break;
                case 2:
                    subfolderPath = System.IO.Path.Combine(folderPath, "Reportes Peliculas con baja disponibilidad");
                    break;
                default:
                    subfolderPath = folderPath;
                    break;
            }

            // Crear la subcarpeta si no existe
            if (!System.IO.Directory.Exists(subfolderPath))
            {
                System.IO.Directory.CreateDirectory(subfolderPath);
            }

            // Cambiar el nombre del archivo PDF basado en el reporte seleccionado
            string fileName;
            switch (cmbTipoReporte.SelectedIndex)
            {
                case 0:
                    fileName = $"PeliculasMasVendidas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    break;
                case 1:
                    fileName = $"ProveedoresConOrdenesPendientes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    break;
                case 2:
                    fileName = $"PeliculasConBajaDisponibilidad_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    break;
                default:
                    fileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    break;
            }

            return System.IO.Path.Combine(subfolderPath, fileName);
        }


        // Métodos para agregar tablas y encabezados (sin cambios)
        private void AgregarTablaPeliculasMasVendidas(Document document, ReadOnlyCollection<(Pelicula, int)> peliculasMasVendidas)
        {
            // Crear tabla y agregar datos
            var table = new Table(3).SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Código").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad Vendida").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));

            foreach (var pelicula in peliculasMasVendidas)
            {
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Item1?.Nombre ?? "Desconocido"))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Item1?.Codigo ?? "Sin código"))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Item2.ToString()))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            }

            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(table);
        }

        private void AgregarTablaProveedoresConOrdenesPendientes(Document document, ReadOnlyCollection<(string RazonSocial, string Codigo, int CantidadOrdenesPendientes)> proveedoresConPendientes)
        {
            var table = new Table(3).SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Razón Social").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Código").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad Órdenes Pendientes").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));

            foreach (var proveedor in proveedoresConPendientes)
            {
                table.AddCell(new Cell().Add(new Paragraph(proveedor.RazonSocial))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(proveedor.Codigo))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(proveedor.CantidadOrdenesPendientes.ToString()))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            }

            document.Add(table);
        }

        private void AgregarTablaPeliculasConBajaDisponibilidad(Document document, ReadOnlyCollection<Pelicula> peliculas)
        {
            var table = new Table(3).SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Título de la Película").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Código").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad en Inventario").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(50, 100, 200)));

            foreach (var pelicula in peliculas)
            {
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Nombre))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Codigo))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph(pelicula.Cantidad.ToString()))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            }

            document.Add(table);
        }

        // Método para agregar el encabezado al documento
        private void AgregarEncabezado(Document document)
        {
            var title = new Paragraph("CineManager")
                .SetFontSize(28)
                .SetBold()
                .SetFontColor(ColorConstants.BLACK)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetPadding(10);

            var date = new Paragraph($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                .SetFontSize(12)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            document.Add(title);
            document.Add(date);
            document.Add(new Paragraph("\n"));
        }

        #endregion



        #region Lógica combobox
        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Usar SelectedIndex para verificar la selección en el ComboBox
            switch (cmbTipoReporte.SelectedIndex)
            {
                case 0:
                    MostrarPeliculasMasVendidas();
                    break;
                case 1:
                    MostrarProveedoresConOrdenesPendientes();
                    break;
                case 2:
                    MostrarPeliculasConBajaDisponibilidad();
                    break;
            }
        }



        private void MostrarPeliculasMasVendidas()
        {
            // Llama al método para recuperar las películas más vendidas y asigna los datos al DataGridView
            var peliculasMasVendidas = ControladoraReportes.Instancia.RecuperarPeliculasMasVendidas()
                .Select(p => new
                {
                    Nombre = p.Item1?.Nombre ?? "Desconocido",
                    Codigo = p.Item1?.Codigo ?? "Sin código",
                    CantidadVendida = p.Item2
                })
                .ToList();

            dgvReportes.DataSource = null; // Limpia el DataGridView
            dgvReportes.DataSource = peliculasMasVendidas;
        }

        private void MostrarProveedoresConOrdenesPendientes()
        {
            // Llama al método para recuperar los proveedores con órdenes pendientes y asigna los datos al DataGridView
            var proveedoresConPendientes = ControladoraReportes.Instancia.RecuperarProveedoresConOrdenesPendientes()
                .Select(p => new
                {
                    RazonSocial = p.RazonSocial,
                    Codigo = p.Codigo,
                    CantidadOrdenesPendientes = p.CantidadOrdenesPendientes,
                })
                .ToList();

            dgvReportes.DataSource = null; // Limpia el DataGridView
            dgvReportes.DataSource = proveedoresConPendientes;
        }


        private void MostrarPeliculasConBajaDisponibilidad()
        {
            // Llama al método para recuperar las películas con baja disponibilidad y asigna los datos al DataGridView
            var peliculasConBajaDisponibilidad = ControladoraReportes.Instancia.RecuperarPeliculasConBajaDisponibilidad()
                .Select(p => new
                {
                    Nombre = p.Nombre,
                    Codigo = p.Codigo,
                    CantidadInventario = p.Cantidad // Accede directamente a la propiedad de la entidad Pelicula
                })
                .ToList();

            dgvReportes.DataSource = null; // Limpia el DataGridView
            dgvReportes.DataSource = peliculasConBajaDisponibilidad;
        }

        #endregion


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
