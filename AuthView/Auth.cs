using Controller;
using System;
using System.Windows.Forms;
using Unity;
using MaterialSkin;
using MaterialSkin.Controls;

namespace AuthView
{
    public partial class Auth : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly AuthController service;
        public Auth(AuthController service)
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

        private void materialButtonSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            else
            {
                string res = service.CheckAuthInfo(textBoxLogin.Text, textBoxPassword.Text);
                if (res == "Заказчик")
                {
                    this.Visible = false;
                    var form1 = Container.Resolve<UserView.Main>();
                    form1.ShowDialog();
                    this.Visible = true;
                }
                else if (res == "Исполнитель")
                {
                    this.Visible = false;
                    var form1 = Container.Resolve<CompanyView.RequestsList>();
                    form1.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show(res, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                }
            }
        }

        private void materialButtonSignUp_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<SignUp>();
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
        }
    }
}
