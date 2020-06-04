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
            this.buttonRequests = new System.Windows.Forms.Button();
            this.buttonProviders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRequests
            // 
            this.buttonRequests.Location = new System.Drawing.Point(13, 13);
            this.buttonRequests.Name = "buttonRequests";
            this.buttonRequests.Size = new System.Drawing.Size(204, 23);
            this.buttonRequests.TabIndex = 0;
            this.buttonRequests.Text = "Список заявок";
            this.buttonRequests.UseVisualStyleBackColor = true;
            // 
            // buttonProviders
            // 
            this.buttonProviders.Location = new System.Drawing.Point(13, 42);
            this.buttonProviders.Name = "buttonProviders";
            this.buttonProviders.Size = new System.Drawing.Size(204, 23);
            this.buttonProviders.TabIndex = 1;
            this.buttonProviders.Text = "Список поставщиков";
            this.buttonProviders.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 79);
            this.Controls.Add(this.buttonProviders);
            this.Controls.Add(this.buttonRequests);
            this.Name = "Main";
            this.Text = "Главное меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRequests;
        private System.Windows.Forms.Button buttonProviders;
    }
}

