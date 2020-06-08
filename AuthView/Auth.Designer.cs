namespace AuthView
{
    partial class Auth
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
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.materialButtonSignIn = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonSignUp = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(77, 90);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(204, 20);
            this.textBoxLogin.TabIndex = 1;
            this.textBoxLogin.UseSystemPasswordChar = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(77, 122);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(204, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // materialButtonSignIn
            // 
            this.materialButtonSignIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonSignIn.Depth = 0;
            this.materialButtonSignIn.DrawShadows = true;
            this.materialButtonSignIn.HighEmphasis = true;
            this.materialButtonSignIn.Icon = null;
            this.materialButtonSignIn.Location = new System.Drawing.Point(11, 171);
            this.materialButtonSignIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonSignIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonSignIn.Name = "materialButtonSignIn";
            this.materialButtonSignIn.Size = new System.Drawing.Size(71, 36);
            this.materialButtonSignIn.TabIndex = 6;
            this.materialButtonSignIn.Text = "Войти";
            this.materialButtonSignIn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonSignIn.UseAccentColor = false;
            this.materialButtonSignIn.UseVisualStyleBackColor = true;
            this.materialButtonSignIn.Click += new System.EventHandler(this.materialButtonSignIn_Click);
            // 
            // materialButtonSignUp
            // 
            this.materialButtonSignUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonSignUp.Depth = 0;
            this.materialButtonSignUp.DrawShadows = true;
            this.materialButtonSignUp.HighEmphasis = true;
            this.materialButtonSignUp.Icon = null;
            this.materialButtonSignUp.Location = new System.Drawing.Point(90, 171);
            this.materialButtonSignUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonSignUp.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonSignUp.Name = "materialButtonSignUp";
            this.materialButtonSignUp.Size = new System.Drawing.Size(191, 36);
            this.materialButtonSignUp.TabIndex = 7;
            this.materialButtonSignUp.Text = "Зарегистрироваться";
            this.materialButtonSignUp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonSignUp.UseAccentColor = false;
            this.materialButtonSignUp.UseVisualStyleBackColor = true;
            this.materialButtonSignUp.Click += new System.EventHandler(this.materialButtonSignUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 237);
            this.Controls.Add(this.materialButtonSignUp);
            this.Controls.Add(this.materialButtonSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label1);
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Auth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private MaterialSkin.Controls.MaterialButton materialButtonSignIn;
        private MaterialSkin.Controls.MaterialButton materialButtonSignUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

