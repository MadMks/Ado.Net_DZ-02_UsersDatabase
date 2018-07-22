using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_UsersDatabase
{
    public partial class AdditiomForm : Form
    {
        //public DataRow AdditionRow { get; set; }
        public DataTable AdditionTable { get; set; }

        public AdditiomForm(DataTable table)
        {
            InitializeComponent();

            this.AdditionTable = table;

            this.Load += AdditiomForm_Load;
        }

        private void AdditiomForm_Load(object sender, EventArgs e)
        {
            this.comboBoxAdmin.Items.Add("False");
            this.comboBoxAdmin.Items.Add("True");

            this.comboBoxAdmin.SelectedIndex = 0;
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

            DataRow addRow = this.AdditionTable.NewRow();

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


            this.AdditionTable.Rows.Add(addRow);

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
