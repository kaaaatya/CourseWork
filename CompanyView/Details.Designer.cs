namespace CompanyView
{
    partial class Details
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialButtonUnclassified = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonClassify = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonCancel = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.materialButtonPDF = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView2.Location = new System.Drawing.Point(383, 64);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(245, 243);
            this.dataGridView2.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Наименование товара";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Поставщик";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(383, 243);
            this.dataGridView1.TabIndex = 3;
            // 
            // materialButtonUnclassified
            // 
            this.materialButtonUnclassified.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUnclassified.Depth = 0;
            this.materialButtonUnclassified.DrawShadows = true;
            this.materialButtonUnclassified.HighEmphasis = true;
            this.materialButtonUnclassified.Icon = null;
            this.materialButtonUnclassified.Location = new System.Drawing.Point(635, 74);
            this.materialButtonUnclassified.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUnclassified.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUnclassified.Name = "materialButtonUnclassified";
            this.materialButtonUnclassified.Size = new System.Drawing.Size(279, 36);
            this.materialButtonUnclassified.TabIndex = 5;
            this.materialButtonUnclassified.Text = "           Нераспределенные заявки            ";
            this.materialButtonUnclassified.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUnclassified.UseAccentColor = false;
            this.materialButtonUnclassified.UseVisualStyleBackColor = true;
            this.materialButtonUnclassified.Click += new System.EventHandler(this.materialButtonUnclassified_Click);
            // 
            // materialButtonClassify
            // 
            this.materialButtonClassify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonClassify.Depth = 0;
            this.materialButtonClassify.DrawShadows = true;
            this.materialButtonClassify.HighEmphasis = true;
            this.materialButtonClassify.Icon = null;
            this.materialButtonClassify.Location = new System.Drawing.Point(635, 122);
            this.materialButtonClassify.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonClassify.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonClassify.Name = "materialButtonClassify";
            this.materialButtonClassify.Size = new System.Drawing.Size(280, 36);
            this.materialButtonClassify.TabIndex = 6;
            this.materialButtonClassify.Text = "Распределить по поставщикам";
            this.materialButtonClassify.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonClassify.UseAccentColor = false;
            this.materialButtonClassify.UseVisualStyleBackColor = true;
            this.materialButtonClassify.Click += new System.EventHandler(this.materialButtonClassify_Click);
            // 
            // materialButtonCancel
            // 
            this.materialButtonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCancel.Depth = 0;
            this.materialButtonCancel.DrawShadows = true;
            this.materialButtonCancel.HighEmphasis = true;
            this.materialButtonCancel.Icon = null;
            this.materialButtonCancel.Location = new System.Drawing.Point(635, 170);
            this.materialButtonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCancel.Name = "materialButtonCancel";
            this.materialButtonCancel.Size = new System.Drawing.Size(280, 36);
            this.materialButtonCancel.TabIndex = 7;
            this.materialButtonCancel.Text = "                    Отменить фильтрацию                   ";
            this.materialButtonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonCancel.UseAccentColor = false;
            this.materialButtonCancel.UseVisualStyleBackColor = true;
            this.materialButtonCancel.Click += new System.EventHandler(this.materialButtonCancel_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, 64);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(606, 243);
            this.dataGridView3.TabIndex = 8;
            this.dataGridView3.Visible = false;
            // 
            // materialButtonPDF
            // 
            this.materialButtonPDF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonPDF.Depth = 0;
            this.materialButtonPDF.DrawShadows = true;
            this.materialButtonPDF.HighEmphasis = true;
            this.materialButtonPDF.Icon = null;
            this.materialButtonPDF.Location = new System.Drawing.Point(635, 218);
            this.materialButtonPDF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonPDF.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonPDF.Name = "materialButtonPDF";
            this.materialButtonPDF.Size = new System.Drawing.Size(280, 36);
            this.materialButtonPDF.TabIndex = 9;
            this.materialButtonPDF.Text = "             Сформировать отчет (PDF)             ";
            this.materialButtonPDF.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonPDF.UseAccentColor = false;
            this.materialButtonPDF.UseVisualStyleBackColor = true;
            this.materialButtonPDF.Click += new System.EventHandler(this.materialButtonPDF_Click);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 308);
            this.Controls.Add(this.materialButtonPDF);
            this.Controls.Add(this.materialButtonCancel);
            this.Controls.Add(this.materialButtonClassify);
            this.Controls.Add(this.materialButtonUnclassified);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView3);
            this.Name = "Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список заявок";
            this.Load += new System.EventHandler(this.Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialButton materialButtonUnclassified;
        private MaterialSkin.Controls.MaterialButton materialButtonClassify;
        private MaterialSkin.Controls.MaterialButton materialButtonCancel;
        private System.Windows.Forms.DataGridView dataGridView3;
        private MaterialSkin.Controls.MaterialButton materialButtonPDF;
    }
}