﻿namespace ALISAPI_TEST
{
    partial class Form1
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
            this.ReadersGet = new System.Windows.Forms.Button();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.ReadersAuthorize = new System.Windows.Forms.Button();
            this.ReadersGetByOauthToken = new System.Windows.Forms.Button();
            this.bChangePwd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bInsertIntoBasket = new System.Windows.Forms.Button();
            this.bPreRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadersGet
            // 
            this.ReadersGet.Location = new System.Drawing.Point(14, 14);
            this.ReadersGet.Margin = new System.Windows.Forms.Padding(5);
            this.ReadersGet.Name = "ReadersGet";
            this.ReadersGet.Size = new System.Drawing.Size(160, 35);
            this.ReadersGet.TabIndex = 0;
            this.ReadersGet.Text = "Readers/Get";
            this.ReadersGet.UseVisualStyleBackColor = true;
            this.ReadersGet.Click += new System.EventHandler(this.ReadersGet_Click);
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(558, 14);
            this.tbResponse.Margin = new System.Windows.Forms.Padding(5);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(573, 590);
            this.tbResponse.TabIndex = 1;
            // 
            // ReadersAuthorize
            // 
            this.ReadersAuthorize.Location = new System.Drawing.Point(14, 59);
            this.ReadersAuthorize.Margin = new System.Windows.Forms.Padding(5);
            this.ReadersAuthorize.Name = "ReadersAuthorize";
            this.ReadersAuthorize.Size = new System.Drawing.Size(160, 35);
            this.ReadersAuthorize.TabIndex = 3;
            this.ReadersAuthorize.Text = "Readers/Authorize";
            this.ReadersAuthorize.UseVisualStyleBackColor = true;
            this.ReadersAuthorize.Click += new System.EventHandler(this.ReadersAuthorize_Click);
            // 
            // ReadersGetByOauthToken
            // 
            this.ReadersGetByOauthToken.Location = new System.Drawing.Point(14, 102);
            this.ReadersGetByOauthToken.Name = "ReadersGetByOauthToken";
            this.ReadersGetByOauthToken.Size = new System.Drawing.Size(219, 56);
            this.ReadersGetByOauthToken.TabIndex = 5;
            this.ReadersGetByOauthToken.Text = "Readers/GetByOauthToken";
            this.ReadersGetByOauthToken.UseVisualStyleBackColor = true;
            this.ReadersGetByOauthToken.Click += new System.EventHandler(this.ReadersGetByOauthToken_Click);
            // 
            // bChangePwd
            // 
            this.bChangePwd.Location = new System.Drawing.Point(14, 164);
            this.bChangePwd.Name = "bChangePwd";
            this.bChangePwd.Size = new System.Drawing.Size(219, 55);
            this.bChangePwd.TabIndex = 6;
            this.bChangePwd.Text = "Readers/ChangePassword";
            this.bChangePwd.UseVisualStyleBackColor = true;
            this.bChangePwd.Click += new System.EventHandler(this.bChangePwd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bInsertIntoBasket
            // 
            this.bInsertIntoBasket.Location = new System.Drawing.Point(14, 225);
            this.bInsertIntoBasket.Name = "bInsertIntoBasket";
            this.bInsertIntoBasket.Size = new System.Drawing.Size(219, 58);
            this.bInsertIntoBasket.TabIndex = 8;
            this.bInsertIntoBasket.Text = "Circulation/InsertIntoBasket";
            this.bInsertIntoBasket.UseVisualStyleBackColor = true;
            this.bInsertIntoBasket.Click += new System.EventHandler(this.bInsertIntoBasket_Click);
            // 
            // bPreRegister
            // 
            this.bPreRegister.Location = new System.Drawing.Point(14, 289);
            this.bPreRegister.Name = "bPreRegister";
            this.bPreRegister.Size = new System.Drawing.Size(219, 40);
            this.bPreRegister.TabIndex = 9;
            this.bPreRegister.Text = "Readers/PreRegister";
            this.bPreRegister.UseVisualStyleBackColor = true;
            this.bPreRegister.Click += new System.EventHandler(this.bPreRegister_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 620);
            this.Controls.Add(this.bPreRegister);
            this.Controls.Add(this.bInsertIntoBasket);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bChangePwd);
            this.Controls.Add(this.ReadersGetByOauthToken);
            this.Controls.Add(this.ReadersAuthorize);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.ReadersGet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadersGet;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Button ReadersAuthorize;
        private System.Windows.Forms.Button ReadersGetByOauthToken;
        private System.Windows.Forms.Button bChangePwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bInsertIntoBasket;
        private System.Windows.Forms.Button bPreRegister;
    }
}

