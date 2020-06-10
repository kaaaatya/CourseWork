namespace CompanyView
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialButtonRequests = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonProviders = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialButtonRequests
            // 
            this.materialButtonRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRequests.Depth = 0;
            this.materialButtonRequests.DrawShadows = true;
            this.materialButtonRequests.HighEmphasis = true;
            this.materialButtonRequests.Icon = null;
            this.materialButtonRequests.Location = new System.Drawing.Point(14, 75);
            this.materialButtonRequests.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRequests.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRequests.Name = "materialButtonRequests";
            this.materialButtonRequests.Size = new System.Drawing.Size(196, 36);
            this.materialButtonRequests.TabIndex = 7;
            this.materialButtonRequests.Text = "               Список заявок                ";
            this.materialButtonRequests.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRequests.UseAccentColor = false;
            this.materialButtonRequests.UseVisualStyleBackColor = true;
            this.materialButtonRequests.Click += new System.EventHandler(this.materialButtonRequests_Click);
            // 
            // materialButtonProviders
            // 
            this.materialButtonProviders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonProviders.Depth = 0;
            this.materialButtonProviders.DrawShadows = true;
            this.materialButtonProviders.HighEmphasis = true;
            this.materialButtonProviders.Icon = null;
            this.materialButtonProviders.Location = new System.Drawing.Point(13, 123);
            this.materialButtonProviders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonProviders.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonProviders.Name = "materialButtonProviders";
            this.materialButtonProviders.Size = new System.Drawing.Size(197, 36);
            this.materialButtonProviders.TabIndex = 6;
            this.materialButtonProviders.Text = "Список поставщиков";
            this.materialButtonProviders.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonProviders.UseAccentColor = false;
            this.materialButtonProviders.UseVisualStyleBackColor = true;
            this.materialButtonProviders.Click += new System.EventHandler(this.materialButtonProviders_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 173);
            this.Controls.Add(this.materialButtonRequests);
            this.Controls.Add(this.materialButtonProviders);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonRequests;
        private MaterialSkin.Controls.MaterialButton materialButtonProviders;
    }
}