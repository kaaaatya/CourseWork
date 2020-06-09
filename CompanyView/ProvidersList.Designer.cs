namespace CompanyView
{
    partial class ProvidersList
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
            this.materialButtonRate = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialButtonRate
            // 
            this.materialButtonRate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRate.Depth = 0;
            this.materialButtonRate.DrawShadows = true;
            this.materialButtonRate.HighEmphasis = true;
            this.materialButtonRate.Icon = null;
            this.materialButtonRate.Location = new System.Drawing.Point(574, 76);
            this.materialButtonRate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRate.Name = "materialButtonRate";
            this.materialButtonRate.Size = new System.Drawing.Size(196, 36);
            this.materialButtonRate.TabIndex = 5;
            this.materialButtonRate.Text = "Оценить поставщика";
            this.materialButtonRate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRate.UseAccentColor = false;
            this.materialButtonRate.UseVisualStyleBackColor = true;
            this.materialButtonRate.Click += new System.EventHandler(this.materialButtonRate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(556, 212);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProvidersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 275);
            this.Controls.Add(this.materialButtonRate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProvidersList";
            this.Text = "Список поставщиков";
            this.Load += new System.EventHandler(this.ProvidersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonRate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}