using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Word;
using Model.ViewModels;
using Unity;

namespace UserView
{    
    public partial class RequestDetails : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller service;
        private readonly ProvidersController proService;
        private readonly ProductController prodService;
        public RequestDetails(RequestsConroller service, ProvidersController proService, ProductController prodService)
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

        private void RequestDetails_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            int recId = Convert.ToInt32(Requests.recId);
            loadDetails(recId);
        }

        private void loadDetails(int Id)
        {

            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);
            dataGrid.design(dataGridView2);
            try
            {
                List<RequestProductViewModel> list = service.GetDetails(Id);
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

        private void materialButtonDOC_Click(object sender, EventArgs e)
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
                Filter = "doc|*.doc"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveDoc(sfd.FileName);
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

        public void saveDoc(string FileName)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref
               missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                string title = "Детали заявки № " + dataGridView1.Rows[0].Cells[1].Value.ToString();
                //задаем текст
                range.Text = title;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();
                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, dataGridView3.Rows.Count + 1, dataGridView3.Columns.Count, ref
               missing, ref missing);
                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";
                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                for (int i = 0; i < dataGridView3.Columns.Count; ++i)
                {
                    table.Cell(1, i + 1).Range.Text = dataGridView3.Columns[i].HeaderCell.Value.ToString();
                }
                for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView3.Columns.Count; ++j)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dataGridView3.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;
                font = range.Font;
                font.Size = 12;
                font.Name = "Times New Roman";
                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;
                range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(FileName, ref fileFormat, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }

        }
    }
}
