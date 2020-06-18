using Controller;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using MaterialSkin;
using MaterialSkin.Controls;
using iTextSharp.text;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using Image = iTextSharp.text.Image;

namespace UserView
{
    public partial class Requests : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller service;
        public static string recId;
        public static DateTime dateMadeRec;
        public Requests(RequestsConroller service)
        {
            InitializeComponent();
            this.service = service;
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
        public void LoadRequests()
        {
            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);
            try
            {
                List<RequestViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Дата поставки";
                    dataGridView1.Columns[2].HeaderText = "Адрес поставки";
                    dataGridView1.Columns[3].HeaderText = "Отметка получения";
                    dataGridView1.Columns[4].HeaderText = "Дата получения";
                    dataGridView1.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void Requests_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            LoadRequests();
        }


        private void materialButtonNew_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<RequestForm>();
            this.Visible = false;
            form.ShowDialog();
            LoadRequests();
            this.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //выбрана строка CurrentRow
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение выбранной строки
            recId = dataGridView1[0, CurrentRow].Value.ToString();
            dateMadeRec = Convert.ToDateTime(dataGridView1[1, CurrentRow].Value.ToString());
        }

        private void materialButtonGot_Click(object sender, EventArgs e)
        {
            if ((recId != null) && (recId != ""))
            {
                var form = Container.Resolve<RequestDetails>();
                this.Visible = false;
                form.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Выберите заявку из списка", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if ((recId != null) && (recId != ""))
            {
                label1.Visible = true;
                materialButtonDateReception.Visible = true;
                dateTimePicker1.Visible = true;
                dataGridView1.Visible = false;
            }
            else
            {
                MessageBox.Show("Выберите заявку из списка", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }
        }

        private void materialButtonDateReception_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateMadeRec)
            {
                service.finishOrder(Convert.ToInt32(recId), dateTimePicker1.Value);
                label1.Visible = false;
                materialButtonDateReception.Visible = false;
                dateTimePicker1.Visible = false;
                dataGridView1.Visible = true;
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Дата получения товара не может быть меньше даты создания заявки", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }
            
        }

        private void materialButtonPDF_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            materialButtonDateReception.Visible = false;
            dateTimePicker1.Visible = false;
            dataGridView1.Visible = false;

            label2.Visible = true;
            dateTimePicker2.Visible = true;
            dateTimePicker3.Visible = true;
            materialButtonExcel.Visible = true;
        }

        public void saveXls(string FileName)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (File.Exists(FileName))
                {
                    excel.Workbooks.Open(FileName, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(FileName, XlFileFormat.xlExcel8,
                    Type.Missing,
                     Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                Sheets excelsheets = excel.Workbooks[1].Worksheets;

                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                excelworksheet.Cells.Clear();
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "H1");
                excelcells.Merge(Type.Missing);
                excelcells.Font.Bold = true;
                string title = "Список заявок " + "c " + dateTimePicker2.Value.Date.ToString() + " до " + dateTimePicker3.Value.Date.ToString();
                excelcells.Value2 = title;
                excelcells.RowHeight = 40;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    excelcells = excelworksheet.get_Range("B3", "B3");
                    excelcells = excelcells.get_Offset(0, j);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = dataGridView2.Columns[j].HeaderCell.Value.ToString();
                    excelcells.Font.Bold = true;
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        excelcells = excelworksheet.get_Range("B4", "B4");
                        excelcells = excelcells.get_Offset(i, j);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = dataGridView2.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelcells = excelcells.get_Offset(1, 0);
                excelcells.Font.Bold = true;
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
            }
            finally
            {
                excel.Quit();
            }
        }

        private void materialButtonExcel_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();


            if (dateTimePicker3.Value > dateTimePicker2.Value)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                DateTime datePrint = DateTime.Now;
                string datePrintList = datePrint.ToString("yyyy-MM-dd");

                dataGridView2.Columns.Add("Column1", "Дата поставки");
                dataGridView2.Columns.Add("Column2", "Адрес");
                dataGridView2.Columns.Add("Column3", "Получение");
                dataGridView2.Columns.Add("Column4", "Дата получения");
                dataGridView2.Columns.Add("Column5", "Приоритет");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value.ToString()) >= Convert.ToDateTime(dateTimePicker2.Value.ToString()))&&(Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value.ToString()) <= Convert.ToDateTime(dateTimePicker3.Value.ToString())))
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        dataGridView2.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        dataGridView2.Rows[i].Cells[2].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "true")
                        {
                            dataGridView2.Rows[i].Cells[3].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[3].Value = "Не получен";
                        }
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value.ToString()) == 0)
                        {
                            dataGridView2.Rows[i].Cells[4].Value = "Цена";
                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[4].Value = "Рейтинг";
                        }
                        
                    }
                    
                }


                dataGridView2.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[1].AutoSizeMode =
                dataGridView2.Columns[0].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;


                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "xls|*.xls|xlsx|*.xlsx"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        saveXls(sfd.FileName);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }

                label1.Visible = false;
                materialButtonDateReception.Visible = false;
                dateTimePicker1.Visible = false;
                dataGridView1.Visible = true;

                label2.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                materialButtonExcel.Visible = false;
            }
            else
            {
                MessageBox.Show("Дата конца периода должна быть больше даты начала", "Ошибка", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
            
        }
    }
}
