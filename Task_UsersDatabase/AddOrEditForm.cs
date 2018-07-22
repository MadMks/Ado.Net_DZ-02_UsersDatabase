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

            //this.Load += AddOrEditForm_Load;
            //this.comboBoxAdmin.Items.Add("False");
            //this.comboBoxAdmin.Items.Add("True");

            //this.comboBoxAdmin.SelectedIndex = 0;

            this.editingTable = table;

            //this.Text = "Добавление пользователя";
            //this.isAddition = true;
            this.Load += AddForm_Load;
        }

        

        public AddOrEditForm(DataTable table, string selectedUser)
        {
            InitializeComponent();

            //this.Load += AddOrEditForm_Load;
            //this.comboBoxAdmin.Items.Add("False");
            //this.comboBoxAdmin.Items.Add("True");

            //this.comboBoxAdmin.SelectedIndex = 0;

            this.editingTable = table;

            //this.Text = "Редактирование пользователя";
            //this.isAddition = false;
            this.editingUser = selectedUser;

            //this.FillingUserData();
            this.Load += EditForm_Load;

        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.comboBoxAdmin.Items.Add("False");
            this.comboBoxAdmin.Items.Add("True");

            this.comboBoxAdmin.SelectedIndex = 0;


            this.Text = "Редактирование пользователя";
            this.isAddition = false;

            this.FillingUserData();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            this.comboBoxAdmin.Items.Add("False");
            this.comboBoxAdmin.Items.Add("True");

            this.comboBoxAdmin.SelectedIndex = 0;

            this.Text = "Добавление пользователя";
            this.isAddition = true;
        }

        /// <summary>
        /// Заполнение текстБоксов данными редактируемого пользователя.
        /// </summary>
        private void FillingUserData()
        {    
            this.textBoxLogin.Text = GetTheValueOfTheCurrentUser("Login");
            this.textBoxPass.Text = GetTheValueOfTheCurrentUser("Password");
            this.textBoxAddress.Text = GetTheValueOfTheCurrentUser("Address");
            this.textBoxTel.Text = GetTheValueOfTheCurrentUser("Tel");



            switch (GetTheValueOfTheCurrentUser("IsAdmin"))
            {
                case "False":
                    this.comboBoxAdmin.SelectedIndex = 0;
                    break;
                case "True":
                    this.comboBoxAdmin.SelectedIndex = 1;
                    break;
                default:
                    break;
            }
        }

        private string GetTheValueOfTheCurrentUser(string columnName)
        {
            string filterString = "Login = '" + this.editingUser + "'";

            return (this.editingTable.Select(filterString))[0][columnName].ToString();
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
            //this.comboBoxAdmin.Items.Add("False");
            //this.comboBoxAdmin.Items.Add("True");

            //this.comboBoxAdmin.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (false)   // пустые текстбоксы
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            // TODO проверка на пустые текстбоксы
            // TODO проверка на цыфры в телефоне
            // TODO проверка на длину вводимых данных (имя, пароль, адрес, телефон?)

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
        /// Редактирование строки.
        /// </summary>
        private void EditingARow()
        {
            string filterString = "Login = '" + this.editingUser + "'";

            DataRow editRow = (this.editingTable.Select(filterString))[0];

            editRow[0] = this.textBoxLogin.Text;
            editRow[1] = this.textBoxPass.Text;
            editRow[2] = this.textBoxAddress.Text;
            editRow[3] = this.textBoxTel.Text;
            editRow[4] = this.comboBoxAdmin.Text;
        }

        /// <summary>
        /// Добавление новой строки.
        /// </summary>
        private void AddingANewRow()
        {
            

            DataRow addRow = this.editingTable.NewRow();

            //addRow[0] = "test log add";
            //addRow[1] = "test pass";
            //addRow[2] = "test address";
            //addRow[3] = 111;
            //addRow[4] = "False";

            addRow[0] = this.textBoxLogin.Text;
            addRow[1] = this.textBoxPass.Text;
            addRow[2] = this.textBoxAddress.Text;
            addRow[3] = this.textBoxTel.Text;
            addRow[4] = this.comboBoxAdmin.Text;


            this.editingTable.Rows.Add(addRow);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
