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
using Model.ViewModels;
using Unity;

namespace CompanyView
{
    public partial class ProvidersList : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ProvidersController service;
        public static string providerId;
        public ProvidersList(ProvidersController service)
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

        private void ProvidersList_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            LoadProviders();
        }

        public void LoadProviders()
        {
            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);

            try
            {
                List<ProviderViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Компания";
                    dataGridView1.Columns[2].HeaderText = "Рейтинг";
                    dataGridView1.Columns[3].HeaderText = "Адрес";
                    dataGridView1.Columns[4].HeaderText = "Email";
                    dataGridView1.Columns[5].HeaderText = "Номер телефона";
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

        private void materialButtonRate_Click(object sender, EventArgs e)
        {
            if ((providerId != null) && (providerId != ""))
            {
                var form = Container.Resolve<RateProvider>();
                this.Visible = false;
                form.ShowDialog();
                LoadProviders();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Выберите поставщика из списка", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //выбрана строка CurrentRow
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение выбранной строки
            providerId = dataGridView1[0, CurrentRow].Value.ToString();
        }
    }
}
