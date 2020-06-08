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
using Unity;

namespace UserView
{
    public partial class RateProvider : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ProvidersController service;
        public RateProvider(ProvidersController service)
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

        private void RateProvider_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            label1.Text = service.ProviderNameById(Convert.ToInt32(Providers.providerId));
        }

        private void materialButtonRate_Click(object sender, EventArgs e)
        {
            int providerId = Convert.ToInt32(Providers.providerId);
            if (radioButton1.Checked)
            {
                service.rateProvider(providerId, 1);
                MessageBox.Show("Оценка успешно выставлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            } else if (radioButton2.Checked)
            {
                service.rateProvider(providerId, 2);
                MessageBox.Show("Оценка успешно выставлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (radioButton3.Checked)
            {
                service.rateProvider(providerId, 3);
                MessageBox.Show("Оценка успешно выставлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (radioButton4.Checked)
            {
                service.rateProvider(providerId, 4);
                MessageBox.Show("Оценка успешно выставлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (radioButton5.Checked)
            {
                service.rateProvider(providerId, 5);
                MessageBox.Show("Оценка успешно выставлена", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите оценку поставщику", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            }

        }
    }
}
