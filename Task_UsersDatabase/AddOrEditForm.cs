using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_UsersDatabase
{
    public partial class AddOrEditForm : Form
    {
        //public DataRow AdditionRow { get; set; }
        //public DataTable AdditionTable { get; set; }

        private DataTable editingTable;
        private bool isAddition;
        private string editingUser;

        public AddOrEditForm(DataTable table)
        {
            InitializeComponent();

            this.editingTable = table;

            this.Load += AddForm_Load;

            // HACK TEMP
            this.maskedTextBoxTel.TextChanged += MaskedTextBoxTel_TextChanged;
        }

        

        public AddOrEditForm(DataTable table, string selectedUser)
        {
            InitializeComponent();

            this.editingTable = table;
            this.editingUser = selectedUser;

            this.Load += EditForm_Load;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.ComboBoxConfiguration();

            this.Text = "Редактирование пользователя";
            this.isAddition = false;

            this.FillingUserData();
        }

        private void MaskedTextBoxTel_TextChanged(object sender, EventArgs e)
        {
            //this.maskedTextBoxTel.Text = this.maskedTextBoxTel.Text.Replace("(", "");
            //this.labeltest.Text = this.maskedTextBoxTel.Text.Replace("(", "").Replace(")", "").Replace(" ", "");
            
            this.labeltest.Text = this.maskedTextBoxTel.Text;

            //MessageBox.Show(this.maskedTextBoxTel.Text.Length.ToString());
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            this.ComboBoxConfiguration();

            this.Text = "Добавление пользователя";
            this.isAddition = true;
        }

        /// <summary>
        /// Настройка comboBox.
        /// </summary>
        private void ComboBoxConfiguration()
        {
            this.comboBoxAdmin.Items.Add("False");
            this.comboBoxAdmin.Items.Add("True");

            this.comboBoxAdmin.SelectedIndex = 0;
        }

        /// <summary>
        /// Заполнение текстБоксов данными редактируемого пользователя.
        /// </summary>
        private void FillingUserData()
        {    
            this.textBoxLogin.Text = GetTheValueOfTheCurrentUser("Login");
            this.textBoxPass.Text = GetTheValueOfTheCurrentUser("Password");
            this.textBoxAddress.Text = GetTheValueOfTheCurrentUser("Address");
            //this.textBoxTel.Text = GetTheValueOfTheCurrentUser("Tel");
            this.maskedTextBoxTel.Text = GetTheValueOfTheCurrentUser("Tel");
            this.comboBoxAdmin.SelectedItem = GetTheValueOfTheCurrentUser("IsAdmin");
        }

        private string GetTheValueOfTheCurrentUser(string columnName)
        {
            string filterString = "Login = '" + this.editingUser + "'";

            return (this.editingTable.Select(filterString))[0][columnName].ToString();
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            //if (!this.isAddition)
            //{
            //    string filterString = "Login = '" + this.editingUser + "'";

            //    (this.editingTable.Select(filterString))[0].Delete();
            //}

            if (this.IsEnteredDataIsNotCorrect())   // пустые текстбоксы
            {
                //this.DialogResult = DialogResult.Cancel;
                return;
            }
            // TODO проверка на пустые текстбоксы
            // TODO проверка на цыфры в телефоне
            // TODO проверка на длину вводимых данных (имя, пароль, адрес, телефон?)

            // TODO проверка на повтор логина

            if (this.isAddition)
            {
                this.AddingANewRow();
            }
            else
            {
                this.EditingARow();
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Введенные данные некорректны.
        /// </summary>
        /// <returns>true если введенные данные некорректны.</returns>
        private bool IsEnteredDataIsNotCorrect()
        {
            if (this.IsOneOfTheFieldsIsEmpty())
            {
                MessageBox.Show("Заполните все поля!");
                return true;
            }
            else if (this.IsEnteredLoginAlreadyExistsInTheDatabase())
            {
                MessageBox.Show("Введенный логин уже существует в базе данных.");
                return true;
            }
            //else if (true)
            //{
            //    // 
            //}

            return false;
        }

        /// <summary>
        /// Введенный логин уже существует в базе данных.
        /// </summary>
        /// <returns>true если логин занят.</returns>
        private bool IsEnteredLoginAlreadyExistsInTheDatabase()
        {
            string filterString = "Login = '" + this.textBoxLogin.Text + "'";

            if (this.IsWhenEditingLeaveTheOldLogin())
            {
                return false;
            }
            else if (this.editingTable.Select(filterString).Length > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// При редактировании оставляем старый логин (логин без изменений).
        /// </summary>
        /// <returns>true если логин без изменений.</returns>
        private bool IsWhenEditingLeaveTheOldLogin()
        {
            if (!this.isAddition
                && this.editingUser == this.textBoxLogin.Text)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Одно из полей пустое.
        /// </summary>
        /// <returns>true если одно из полей текстБокса пустое.</returns>
        private bool IsOneOfTheFieldsIsEmpty()
        {
            if (this.textBoxLogin.Text.Length == 0
                || this.textBoxPass.Text.Length == 0
                || this.textBoxAddress.Text.Length == 0
                /*|| this.textBoxTel.Text.Length == 0*/
                || !this.maskedTextBoxTel.MaskCompleted)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Редактирование строки.
        /// </summary>
        private void EditingARow()
        {
            string filterString = "Login = '" + this.editingUser + "'";

            DataRow editRow = (this.editingTable.Select(filterString))[0];

            editRow[0] = this.textBoxLogin.Text;
            editRow[1] = this.textBoxPass.Text;
            editRow[2] = this.textBoxAddress.Text;
            //editRow[3] = this.textBoxTel.Text;
            editRow[3] = this.maskedTextBoxTel.Text;
            editRow[4] = this.comboBoxAdmin.Text;
        }

        /// <summary>
        /// Добавление новой строки.
        /// </summary>
        private void AddingANewRow()
        {
            DataRow addRow = this.editingTable.NewRow();

            addRow[0] = this.textBoxLogin.Text;
            addRow[1] = this.textBoxPass.Text;
            addRow[2] = this.textBoxAddress.Text;
            //addRow[3] = this.textBoxTel.Text;
            addRow[3] = this.maskedTextBoxTel.Text;
            addRow[4] = this.comboBoxAdmin.Text;


            this.editingTable.Rows.Add(addRow);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            this.textBoxLogin.Text = this.textBoxLogin.Text.Replace(" ", "");
            this.textBoxLogin.SelectionStart = this.textBoxLogin.Text.Length;

            this.textBoxPass.Text = this.textBoxPass.Text.Replace(" ", "");
            this.textBoxPass.SelectionStart = this.textBoxPass.Text.Length;
        }

    }
}
