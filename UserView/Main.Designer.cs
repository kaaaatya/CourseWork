namespace UserView
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialButtonProviders = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonRequests = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialButtonProviders
            // 
            this.materialButtonProviders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonProviders.Depth = 0;
            this.materialButtonProviders.DrawShadows = true;
            this.materialButtonProviders.HighEmphasis = true;
            this.materialButtonProviders.Icon = null;
            this.materialButtonProviders.Location = new System.Drawing.Point(12, 122);
            this.materialButtonProviders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonProviders.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonProviders.Name = "materialButtonProviders";
            this.materialButtonProviders.Size = new System.Drawing.Size(197, 36);
            this.materialButtonProviders.TabIndex = 3;
            this.materialButtonProviders.Text = "Список поставщиков";
            this.materialButtonProviders.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonProviders.UseAccentColor = false;
            this.materialButtonProviders.UseVisualStyleBackColor = true;
            this.materialButtonProviders.Click += new System.EventHandler(this.materialButtonProviders_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(13, 194);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(1, 0);
            this.materialLabel1.TabIndex = 4;
            // 
            // materialButtonRequests
            // 
            this.materialButtonRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRequests.Depth = 0;
            this.materialButtonRequests.DrawShadows = true;
            this.materialButtonRequests.HighEmphasis = true;
            this.materialButtonRequests.Icon = null;
            this.materialButtonRequests.Location = new System.Drawing.Point(13, 74);
            this.materialButtonRequests.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRequests.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRequests.Name = "materialButtonRequests";
            this.materialButtonRequests.Size = new System.Drawing.Size(196, 36);
            this.materialButtonRequests.TabIndex = 5;
            this.materialButtonRequests.Text = "               Список заявок                ";
            this.materialButtonRequests.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRequests.UseAccentColor = false;
            this.materialButtonRequests.UseVisualStyleBackColor = true;
            this.materialButtonRequests.Click += new System.EventHandler(this.materialButtonRequests_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 174);
            this.Controls.Add(this.materialButtonRequests);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialButtonProviders);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton materialButtonProviders;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton materialButtonRequests;
    }
}

