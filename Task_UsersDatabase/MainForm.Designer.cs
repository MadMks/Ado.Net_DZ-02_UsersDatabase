﻿namespace Task_UsersDatabase
{
    partial class MainForm
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
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonDelUser = new System.Windows.Forms.Button();
            this.checkBoxShowAdmin = new System.Windows.Forms.CheckBox();
            this.listBoxUsersName = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(13, 12);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 0;
            this.buttonAddUser.Text = "Добавить";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonDelUser
            // 
            this.buttonDelUser.Location = new System.Drawing.Point(197, 12);
            this.buttonDelUser.Name = "buttonDelUser";
            this.buttonDelUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDelUser.TabIndex = 3;
            this.buttonDelUser.Text = "Удалить";
            this.buttonDelUser.UseVisualStyleBackColor = true;
            this.buttonDelUser.Click += new System.EventHandler(this.buttonDelUser_Click);
            // 
            // checkBoxShowAdmin
            // 
            this.checkBoxShowAdmin.AutoSize = true;
            this.checkBoxShowAdmin.Location = new System.Drawing.Point(13, 209);
            this.checkBoxShowAdmin.Name = "checkBoxShowAdmin";
            this.checkBoxShowAdmin.Size = new System.Drawing.Size(181, 17);
            this.checkBoxShowAdmin.TabIndex = 1;
            this.checkBoxShowAdmin.Text = "Показывать администраторов";
            this.checkBoxShowAdmin.UseVisualStyleBackColor = true;
            this.checkBoxShowAdmin.CheckedChanged += new System.EventHandler(this.checkBoxShowAdmin_CheckedChanged);
            // 
            // listBoxUsersName
            // 
            this.listBoxUsersName.FormattingEnabled = true;
            this.listBoxUsersName.Location = new System.Drawing.Point(13, 49);
            this.listBoxUsersName.Name = "listBoxUsersName";
            this.listBoxUsersName.Size = new System.Drawing.Size(259, 147);
            this.listBoxUsersName.TabIndex = 2;
            this.listBoxUsersName.Enter += new System.EventHandler(this.listBoxUsersName_Enter);
            this.listBoxUsersName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxUsersName_KeyPress);
            this.listBoxUsersName.Leave += new System.EventHandler(this.listBoxUsersName_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 236);
            this.Controls.Add(this.listBoxUsersName);
            this.Controls.Add(this.checkBoxShowAdmin);
            this.Controls.Add(this.buttonDelUser);
            this.Controls.Add(this.buttonAddUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "База пользователей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDelUser;
        private System.Windows.Forms.CheckBox checkBoxShowAdmin;
        private System.Windows.Forms.ListBox listBoxUsersName;
    }
}

