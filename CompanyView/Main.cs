using System;
using MaterialSkin;
using MaterialSkin.Controls;
using Unity;

namespace CompanyView
{
    public partial class Main : MaterialForm
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public Main()
        {
            InitializeComponent();
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

        private void materialButtonRequests_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<RequestsList>();
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }

        private void materialButtonProviders_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ProvidersList>();
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
        }
    }
}
