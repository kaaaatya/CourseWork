namespace UserView
{
    partial class Requests
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialButtonNew = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonGot = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.materialButtonDateReception = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.materialButtonExcelRep = new MaterialSkin.Controls.MaterialButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.materialButtonExcel = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(491, 256);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // materialButtonNew
            // 
            this.materialButtonNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonNew.Depth = 0;
            this.materialButtonNew.DrawShadows = true;
            this.materialButtonNew.HighEmphasis = true;
            this.materialButtonNew.Icon = null;
            this.materialButtonNew.Location = new System.Drawing.Point(498, 75);
            this.materialButtonNew.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonNew.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonNew.Name = "materialButtonNew";
            this.materialButtonNew.Size = new System.Drawing.Size(223, 36);
            this.materialButtonNew.TabIndex = 2;
            this.materialButtonNew.Text = "Составить новую заявку";
            this.materialButtonNew.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonNew.UseAccentColor = false;
            this.materialButtonNew.UseVisualStyleBackColor = true;
            this.materialButtonNew.Click += new System.EventHandler(this.materialButtonNew_Click);
            // 
            // materialButtonGot
            // 
            this.materialButtonGot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonGot.Depth = 0;
            this.materialButtonGot.DrawShadows = true;
            this.materialButtonGot.HighEmphasis = true;
            this.materialButtonGot.Icon = null;
            this.materialButtonGot.Location = new System.Drawing.Point(498, 123);
            this.materialButtonGot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonGot.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonGot.Name = "materialButtonGot";
            this.materialButtonGot.Size = new System.Drawing.Size(225, 36);
            this.materialButtonGot.TabIndex = 3;
            this.materialButtonGot.Text = "         Подробности заявки         ";
            this.materialButtonGot.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonGot.UseAccentColor = false;
            this.materialButtonGot.UseVisualStyleBackColor = true;
            this.materialButtonGot.Click += new System.EventHandler(this.materialButtonGot_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(498, 171);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(223, 36);
            this.materialButton1.TabIndex = 4;
            this.materialButton1.Text = "                       Заказ получен                       ";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 123);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(171, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Укажите дату получения заказа:";
            this.label1.Visible = false;
            // 
            // materialButtonDateReception
            // 
            this.materialButtonDateReception.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonDateReception.Depth = 0;
            this.materialButtonDateReception.DrawShadows = true;
            this.materialButtonDateReception.HighEmphasis = true;
            this.materialButtonDateReception.Icon = null;
            this.materialButtonDateReception.Location = new System.Drawing.Point(145, 152);
            this.materialButtonDateReception.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonDateReception.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonDateReception.Name = "materialButtonDateReception";
            this.materialButtonDateReception.Size = new System.Drawing.Size(179, 36);
            this.materialButtonDateReception.TabIndex = 7;
            this.materialButtonDateReception.Text = "                          Указать                         ";
            this.materialButtonDateReception.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonDateReception.UseAccentColor = false;
            this.materialButtonDateReception.UseVisualStyleBackColor = true;
            this.materialButtonDateReception.Visible = false;
            this.materialButtonDateReception.Click += new System.EventHandler(this.materialButtonDateReception_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 64);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(491, 254);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.Visible = false;
            // 
            // materialButtonExcelRep
            // 
            this.materialButtonExcelRep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonExcelRep.Depth = 0;
            this.materialButtonExcelRep.DrawShadows = true;
            this.materialButtonExcelRep.HighEmphasis = true;
            this.materialButtonExcelRep.Icon = null;
            this.materialButtonExcelRep.Location = new System.Drawing.Point(498, 219);
            this.materialButtonExcelRep.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonExcelRep.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonExcelRep.Name = "materialButtonExcelRep";
            this.materialButtonExcelRep.Size = new System.Drawing.Size(221, 36);
            this.materialButtonExcelRep.TabIndex = 9;
            this.materialButtonExcelRep.Text = "       Экспорт в Excel файл        ";
            this.materialButtonExcelRep.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonExcelRep.UseAccentColor = false;
            this.materialButtonExcelRep.UseVisualStyleBackColor = true;
            this.materialButtonExcelRep.Click += new System.EventHandler(this.materialButtonPDF_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(80, 177);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(171, 20);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.Visible = false;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(268, 177);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(171, 20);
            this.dateTimePicker3.TabIndex = 11;
            this.dateTimePicker3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Выберите период (по дате оформления заявки)";
            this.label2.Visible = false;
            // 
            // materialButtonExcel
            // 
            this.materialButtonExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonExcel.Depth = 0;
            this.materialButtonExcel.DrawShadows = true;
            this.materialButtonExcel.HighEmphasis = true;
            this.materialButtonExcel.Icon = null;
            this.materialButtonExcel.Location = new System.Drawing.Point(80, 206);
            this.materialButtonExcel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonExcel.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonExcel.Name = "materialButtonExcel";
            this.materialButtonExcel.Size = new System.Drawing.Size(359, 36);
            this.materialButtonExcel.TabIndex = 13;
            this.materialButtonExcel.Text = "Сформировать отчет на выбранные даты";
            this.materialButtonExcel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonExcel.UseAccentColor = false;
            this.materialButtonExcel.UseVisualStyleBackColor = true;
            this.materialButtonExcel.Visible = false;
            this.materialButtonExcel.Click += new System.EventHandler(this.materialButtonExcel_Click);
            // 
            // Requests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 317);
            this.Controls.Add(this.materialButtonExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.materialButtonExcelRep);
            this.Controls.Add(this.materialButtonDateReception);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialButtonGot);
            this.Controls.Add(this.materialButtonNew);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Requests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список заявок";
            this.Load += new System.EventHandler(this.Requests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialButton materialButtonNew;
        private MaterialSkin.Controls.MaterialButton materialButtonGot;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton materialButtonDateReception;
        private System.Windows.Forms.DataGridView dataGridView2;
        private MaterialSkin.Controls.MaterialButton materialButtonExcelRep;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialButton materialButtonExcel;
    }
}