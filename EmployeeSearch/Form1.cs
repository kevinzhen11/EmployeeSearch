using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EmployeeSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string name = this.textBox_name.Text;
            ShowData(name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string name = this.textBox_name.Text;
            ShowData(name);
        }
        /// <summary>
        /// Query binding data
        /// </summary>
        /// <param name="name"></param>
        private void ShowData(string name)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog="+Application.StartupPath+@"\PERSONNEL.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "select * from Employee where name like '%"+name+"%'";
            SqlConnection mycon = new SqlConnection(con);
            mycon.Open();
            SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            myda.Fill(table);
            mycon.Close();
            dataGridView1.DataSource = table;
        }
    }
}
