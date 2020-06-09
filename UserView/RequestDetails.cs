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
    }
}
