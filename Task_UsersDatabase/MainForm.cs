using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_UsersDatabase
{
    public partial class MainForm : Form
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder commandBuilder = null;
        private string connectionString = "";   // TODO delete !?
        private string selectQuery = "";

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.connection = new SqlConnection();
                this.connection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["UsersDBConnectionString"]
                    .ConnectionString;

                // Query
                this.selectQuery = "SELECT * FROM users";
                // DataAdapter
                this.dataAdapter = new SqlDataAdapter(this.selectQuery, this.connection);
                //CommandBuilder
                this.commandBuilder = new SqlCommandBuilder(this.dataAdapter);
                // DataSet
                this.dataSet = new DataSet();

                this.dataAdapter.Fill(this.dataSet);

                // TODO можно ли привязать ListBox DataSource к DataSet ?
                //this.listBoxUsersName.DataSource = this.dataSet.Tables[0].Select().ToList();
                //this.listBoxUsersName.DisplayMember = (this.listBoxUsersName.DataSource as List<DataRow>).;
                //this.listBoxUsersName.ValueMember = "Login";

                // TODO вторая попытка привязки. Работает.
                //this.listBoxUsersName.DataSource = this.dataSet.Tables["table"];
                //this.listBoxUsersName.DisplayMember = "Login";

                //this.dataSet.Tables["table"].Rows[1].Delete();



                if (this.dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Добавьте пользователей.", "База пуста");
                }
                else
                {
                    this.AddingLoginsToTheList(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавление логинов в список пользователей.
        /// </summary>
        /// <param name="showAdmins">Показывать администраторов.</param>
        private void AddingLoginsToTheList(bool showAdmins)
        {
            if (showAdmins)
            {
                foreach (DataRow row in this.dataSet.Tables[0].Select())
                {
                    this.listBoxUsersName.Items.Add(row["login"]);
                }
            }
            else
            {
                foreach (DataRow row in this.dataSet.Tables[0].Select("IsAdmin = false"))
                {
                    this.listBoxUsersName.Items.Add(row["login"]);
                }
            }
        }

        private void checkBoxShowAdmin_CheckedChanged(object sender, EventArgs e)
        {
            this.listBoxUsersName.Items.Clear();

            if (this.checkBoxShowAdmin.Checked)
            {
                this.AddingLoginsToTheList(true);
            }
            else
            {
                this.AddingLoginsToTheList(false);
            }
        }
    }
}
