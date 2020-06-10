using Controller;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using MaterialSkin;
using MaterialSkin.Controls;
using Model;

namespace UserView
{
    public partial class RequestForm : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly RequestsConroller recService;
        private readonly ProductController prodService;
        public DateTime recDate; 
        public RequestForm(RequestsConroller recService, ProductController prodService)
        {
            InitializeComponent();
            this.recService = recService;
            this.prodService = prodService;
        }

        private void Request_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            DataGridController dataGrid = new DataGridController();
            dataGrid.design(dataGridView1);
            LoadProducts();
            dataGridView1.Columns[0].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
        }
        private void LoadProducts()
        {
            List<ProductViewModel> list = prodService.GetList();
            if (list != null)
            {
                comboBoxProduct.DisplayMember = "ProductName";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }
        }

        private void materialButtonAddToRequest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAmount.Text))
            {
                if (comboBoxProduct.SelectedIndex != -1)
                {
                    int i = dataGridView1.Rows.Count;
                    bool added = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (dataGridView1.Rows[j].Cells[0].Value.ToString() == comboBoxProduct.Text)
                        {
                            dataGridView1.Rows[j].Cells[1].Value = Convert.ToInt32(dataGridView1.Rows[j].Cells[1].Value) + Convert.ToInt32(textBoxAmount.Text);
                            added = true;
                        }
                    }
                    if (!added)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = comboBoxProduct.Text;
                        dataGridView1.Rows[i].Cells[1].Value = textBoxAmount.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите товар", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите количество товара", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
        }

        private void materialButtonNewRequest_Click(object sender, EventArgs e)
        {
            if (comboBoxAddress.SelectedIndex!=-1)
            {
                if (DateTime.Today.AddDays(7) < dateTimePicker1.Value)
                {
                    try
                    {
                        recService.AddElement(new Request
                        {
                            Date = dateTimePicker1.Value,
                            Address = comboBoxAddress.Text.ToString(),
                            ReceiptMark = false,
                            UserId = AuthController.authId

                        });
                        recDate = dateTimePicker1.Value;
                        MessageBox.Show("Заявка успешно добавлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    finally{
                        prodList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите дату не раньше " + DateTime.Today.AddDays(7).ToString(), "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Выберите адрес" , "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
        }
        public void prodList()
        {
            int j = dataGridView1.Rows.Count;
            for (int i = 0; i < j; i++)
            {
                string ProductName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int am = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                recService.addProdToRequest(new RequestProduct
                {
                    RequestId = recService.recId(recDate),
                    ProductId = prodService.findIdByName(ProductName),
                    Status = "Заказ принят в обработку",
                    Amount = am,
                    ProviderId = 1
                });

            }


        }
    }
}
