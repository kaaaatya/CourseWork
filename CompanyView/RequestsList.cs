using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using Controller;
using Model.ViewModels;

namespace CompanyView
{
    public partial class RequestsList : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller service;
        public static string recId;
        public RequestsList(RequestsConroller service)
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
                List<RequestViewModel> list = service.GetFullList();
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

        private void RequestsList_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            LoadRequests();
        }       

        private void materialButtonUnclassified_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<Details>();
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }
    }
}
