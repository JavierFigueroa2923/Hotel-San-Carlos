﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Graf1
{
    public partial class frm_grafpieDiseño : Form
    {
        public frm_grafpieDiseño(List<string> _listx, List<int> _listy, int tot, string texto)
        {
            InitializeComponent();
            this._listx = _listx;
            this._listy = _listy;
            this.tot = tot;
            this.texto = texto;



        }

        List<string> _listx;
        List<int> _listy;
        int tot;
        string texto;



        private void frm_grafpieDiseño_Load(object sender, EventArgs e)
        {
            string[] series = _listx.ToArray();
            int[] puntos = _listy.ToArray();

            chart1.Titles.Add(texto);
            chart1.Palette = ChartColorPalette.Berry;

            MessageBox.Show(Convert.ToString(tot));
            for (int i = 0; i < tot; i++)
            {

                int y = puntos[i];
                MessageBox.Show(Convert.ToString(y));
                string x = series[i];
                MessageBox.Show(Convert.ToString(x));

                chart1.Series["Series1"].Points.AddXY(x, y);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveFileDialog1.Title = "Guardar Grafico en Imagen";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        chart1.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        chart1.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        chart1.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Obtiene la gráfica
            var charimgen = new MemoryStream();
            chart1.SaveImage(charimgen, ChartImageFormat.Png);
            iTextSharp.text.Image charImagen = iTextSharp.text.Image.GetInstance(charimgen.GetBuffer());
            charImagen.Alignment = Element.ALIGN_CENTER;

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\Merlyn\\Pictures\\Geek Software.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            //EXPORTA AL PDF
            string folderPath = " D:\\Merlyn c\\Desktop\\Graficas pdf\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (Directory.Exists(folderPath))
            {
                MessageBox.Show("Gráfica guardada exitosamente!!!");
            }

            string descripcion = textBox1.Text;



            using (FileStream stream = new FileStream(folderPath + "Gráfica Pie.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(imagen);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(charImagen); //agrega la gráfica
                pdfDoc.Add(new Paragraph(descripcion)); //una breve descripcion de la grafica
                pdfDoc.Close();
                stream.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chart1 != null)
            {
                chart1.Series.Clear();
                _listx.Clear();
                _listy.Clear();
                this.Close();
            }
        }
    }
}
