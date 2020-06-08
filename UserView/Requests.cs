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

        private void Requests_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
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


        private void materialButtonNew_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<RequestForm>();
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }
    }
}
