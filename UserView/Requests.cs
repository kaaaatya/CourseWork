using Controller;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace UserView
{
    public partial class Requests : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller service;
        public static string recId;
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
                    dataGridView1.Columns[1].HeaderText = "Дата поставки";
                    dataGridView1.Columns[2].HeaderText = "Адрес поставки";
                    dataGridView1.Columns[3].HeaderText = "Отзыв";
                    dataGridView1.Columns[4].HeaderText = "Отметка получения";
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
                service.finishOrder(Convert.ToInt32(recId));
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку из списка", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }
        }
    }
}
