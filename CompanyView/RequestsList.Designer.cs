namespace CompanyView
{
    partial class RequestsList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialButtonUnclassified = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(502, 219);
            this.dataGridView1.TabIndex = 0;
            // 
            // materialButtonUnclassified
            // 
            this.materialButtonUnclassified.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUnclassified.Depth = 0;
            this.materialButtonUnclassified.DrawShadows = true;
            this.materialButtonUnclassified.HighEmphasis = true;
            this.materialButtonUnclassified.Icon = null;
            this.materialButtonUnclassified.Location = new System.Drawing.Point(509, 75);
            this.materialButtonUnclassified.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUnclassified.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUnclassified.Name = "materialButtonUnclassified";
            this.materialButtonUnclassified.Size = new System.Drawing.Size(241, 36);
            this.materialButtonUnclassified.TabIndex = 4;
            this.materialButtonUnclassified.Text = "                            Детали заявок                             ";
            this.materialButtonUnclassified.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUnclassified.UseAccentColor = false;
            this.materialButtonUnclassified.UseVisualStyleBackColor = true;
            this.materialButtonUnclassified.Click += new System.EventHandler(this.materialButtonUnclassified_Click);
            // 
            // RequestsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 283);
            this.Controls.Add(this.materialButtonUnclassified);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RequestsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список заявок";
            this.Load += new System.EventHandler(this.RequestsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialButton materialButtonUnclassified;
    }
}

