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

using System.Windows.Forms.DataVisualization.Charting; // Para gráficos
using System.Drawing.Imaging;

namespace Vista.Módulo_de_Inventario
{
    public partial class FormReportesPeliculas : Form
    {
        private Sesion _sesion;

        public FormReportesPeliculas(Sesion sesion)
        {
            InitializeComponent();
            dgvVentasPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this._sesion = sesion;
            ActualizarGrilla();
        }



        private void ActualizarGrilla()
        {
            // Recuperar las películas más vendidas
            var peliculasMasVendidas = ControladoraReportes.Instancia.RecuperarPeliculasMasVendidas()
                .Select(p => new
                {
                    Nombre = p.Item1?.Nombre ?? "Desconocido",
                    Codigo = p.Item1?.Codigo ?? "Sin código",
                    CantidadVendida = p.Item2
                })
                .ToList();

            dgvVentasPeliculas.DataSource = null;
            dgvVentasPeliculas.DataSource = peliculasMasVendidas;
        }




        private void btnExportar_Click(object sender, EventArgs e)
        {
            var peliculasMasVendidas = ControladoraReportes.Instancia.RecuperarPeliculasMasVendidas();

            // Crear la ruta para guardar el PDF en el escritorio
            string pdfPath = CrearRutaPdf();

            // Crear documento PDF
            using (var writer = new PdfWriter(pdfPath))
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                // Agregar contenido al documento
                AgregarEncabezado(document);
                AgregarTabla(document, peliculasMasVendidas);

                // Generar gráfico y agregarlo al documento
                var grafico = GenerarGrafico(peliculasMasVendidas);
                using (var stream = new MemoryStream())
                {
                    grafico.Save(stream, ImageFormat.Png);
                    var image = iText.IO.Image.ImageDataFactory.Create(stream.ToArray());
                    document.Add(new iText.Layout.Element.Image(image).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER));
                }



                document.Close(); // Cerrar el documento
            }

            // Informar al usuario que el archivo se ha creado
            MessageBox.Show($"PDF exportado correctamente a {pdfPath}");
        }



        #region Metodos de exportación de PDFS

        // Método para crear la ruta del PDF
        private string CrearRutaPdf()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = System.IO.Path.Combine(desktopPath, "PDFS CineManager");

            // Crear la carpeta si no existe
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            // Crear un nombre único para el archivo PDF basado en la fecha y hora actual
            string fileName = $"PeliculasMasVendidas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // Ruta del archivo PDF
            return System.IO.Path.Combine(folderPath, fileName);
        }



        private void AgregarTabla(Document document, ReadOnlyCollection<(Pelicula, int)> peliculasMasVendidas)
        {
            // Crear tabla para mostrar los datos
            var table = new Table(3).SetWidth(UnitValue.CreatePercentValue(100)); // Ancho del 100% de la página

            // Agregar encabezados de columna
            table.AddHeaderCell(new Cell()
                .Add(new Paragraph("Nombre").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                .SetBackgroundColor(new DeviceRgb(50, 100, 200))); // Color de fondo azul

            table.AddHeaderCell(new Cell()
                .Add(new Paragraph("Código").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                .SetBackgroundColor(new DeviceRgb(50, 100, 200))); // Color de fondo azul

            table.AddHeaderCell(new Cell()
                .Add(new Paragraph("Cantidad Vendida").SetBold().SetFontColor(ColorConstants.WHITE))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                .SetBackgroundColor(new DeviceRgb(50, 100, 200))); // Color de fondo azul

            // Llenar la tabla con datos
            foreach (var pelicula in peliculasMasVendidas)
            {
                table.AddCell(new Cell()
                    .Add(new Paragraph(pelicula.Item1?.Nombre ?? "Desconocido"))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                    .SetPadding(5)); // Padding para dar espacio alrededor del texto

                table.AddCell(new Cell()
                    .Add(new Paragraph(pelicula.Item1?.Codigo ?? "Sin código"))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                    .SetPadding(5)); // Padding para dar espacio alrededor del texto

                table.AddCell(new Cell()
                    .Add(new Paragraph(pelicula.Item2.ToString()))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                    .SetPadding(5)); // Padding para dar espacio alrededor del texto
            }

            // Centrar la tabla en el documento
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            // Agregar la tabla al documento
            document.Add(table);
        }



        // Método para agregar el encabezado al documento
        private void AgregarEncabezado(Document document)
        {
            var title = new Paragraph("CineManager")
                .SetFontSize(28) // Tamaño de fuente
                .SetBold()
                .SetFontColor(ColorConstants.BLACK) // Color del texto
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetPadding(10); // Espacio alrededor del texto

            // Agregar la fecha de generación
            var date = new Paragraph($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                .SetFontSize(12)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            // Agregar el título y la fecha al documento
            document.Add(title);
            document.Add(date);
            document.Add(new Paragraph("\n"));
        }

        private Bitmap GenerarGrafico(ReadOnlyCollection<(Pelicula, int)> peliculasMasVendidas)
        {
            // Crear un nuevo gráfico
            var chart = new Chart();
            chart.Width = 600; // Ancho del gráfico
            chart.Height = 400; // Alto del gráfico

            // Crear un área del gráfico
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Agregar una serie de datos (gráfico de barras)
            var series = new Series
            {
                Name = "Cantidad Vendida",
                Color = System.Drawing.Color.Blue,
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Bar // Cambiar a SeriesChartType.Bar para gráfico de barras
            };

            // Agregar los datos de las películas al gráfico
            foreach (var pelicula in peliculasMasVendidas)
            {
                series.Points.AddXY(pelicula.Item1.Nombre, pelicula.Item2);
            }

            chart.Series.Add(series);

            // Guardar el gráfico como una imagen
            var bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, chart.Width, chart.Height));

            return bmp; // Devolver la imagen del gráfico
        }


        #endregion


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
