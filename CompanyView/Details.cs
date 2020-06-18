using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Excel;
using Model.ViewModels;
using Unity;

namespace CompanyView
{
    public partial class Details : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller service;
        private readonly ProvidersController proService;
        private readonly ProductController prodService;
        public Details(RequestsConroller service, ProvidersController proService, ProductController prodService)
        {
            InitializeComponent();
            this.service = service;
            this.proService = proService;
            this.prodService = prodService;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void Details_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            loadDetails();
        }

        private void loadDetails()
        {
            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);
            dataGrid.design(dataGridView2);
            dataGridView2.Rows.Clear();
            try
            {
                List<RequestProductViewModel> list = service.GetDetailsOnAll();
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Номер заявки";
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].HeaderText = "Статус";
                    dataGridView1.Columns[5].HeaderText = "Количество";
                    dataGridView1.Columns[4].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()) == 1)
                        {
                            dataGridView2.Rows[i].Cells[1].Value = "Не назначен";
                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[1].Value = proService.ProviderNameById(Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                        }

                        dataGridView2.Rows[i].Cells[0].Value = prodService.ProductNameById(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                        dataGridView2.Columns[0].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void materialButtonUnclassified_Click(object sender, EventArgs e)
        {           
            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);
            dataGrid.design(dataGridView2);
            dataGridView2.Rows.Clear();
            try
            {
                List<RequestProductViewModel> list = service.GetUnclassified();
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Номер заявки";
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].HeaderText = "Статус";
                    dataGridView1.Columns[5].HeaderText = "Количество";
                    dataGridView1.Columns[4].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()) == 1)
                        {
                            dataGridView2.Rows[i].Cells[1].Value = "Не назначен";
                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[1].Value = proService.ProviderNameById(Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                        }

                        dataGridView2.Rows[i].Cells[0].Value = prodService.ProductNameById(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                        dataGridView2.Columns[0].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void materialButtonCancel_Click(object sender, EventArgs e)
        {
            loadDetails();
        }

        private void materialButtonClassify_Click(object sender, EventArgs e)
        {
            service.FindProviders();
            loadDetails();
        }

        private void materialButtonPDF_Click(object sender, EventArgs e)
        {

            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            DateTime datePrint = DateTime.Now;
            string datePrintList = datePrint.ToString("yyyy-MM-dd");

            dataGridView3.Columns.Add("Column1", "Номер заявки");
            dataGridView3.Columns.Add("Column2", "Статус");
            dataGridView3.Columns.Add("Column3", "Количество");
            dataGridView3.Columns.Add("Column4", "Наименование товара");
            dataGridView3.Columns.Add("Column5", "Поставщик");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                dataGridView3.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                dataGridView3.Rows[i].Cells[2].Value = dataGridView1.Rows[i].Cells[5].Value.ToString();               
                dataGridView3.Rows[i].Cells[3].Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                dataGridView3.Rows[i].Cells[4].Value = dataGridView2.Rows[i].Cells[1].Value.ToString();

            }


            dataGridView3.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[1].AutoSizeMode =
            dataGridView3.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;




            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    savePDF(sfd.FileName);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        public void savePDF(string FileName)
        {
            string FONT_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.TTF"); //определяем В СИСТЕМЕ(чтобы не копировать файл) расположение шрифта arial.ttf
            BaseFont baseFont = BaseFont.CreateFont(FONT_LOCATION, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //создаем шрифт
            iTextSharp.text.Font fontParagraph = new iTextSharp.text.Font(baseFont, 17, iTextSharp.text.Font.NORMAL); //регистрируем + можно задать параметры для него(17 - размер, последний параметр - стиль)
            string title = "Список деталей заявок на " + DateTime.Now.ToString();

            var phraseTitle = new Phrase(title,
            new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new
           iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };

            PdfPTable table = new PdfPTable(dataGridView3.Columns.Count);

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridView3.Columns[i].HeaderCell.Value.ToString(), fontParagraph));
            }
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView3.Rows[i].Cells[j].Value.ToString(), fontParagraph));
                }
            }
            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(paragraph);
                pdfDoc.Add(table);
                pdfDoc.Close();
                stream.Close();
            }

        }
    }
}
