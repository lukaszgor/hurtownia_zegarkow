using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hurtowniaZegarkow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;username=root;password=;persistsecurityinfo=True;database=czas");



            //conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from admin where login='"+this.textBox1.Text+"'and pass='"+this.textBox2.Text+"' ; ", conn);
            MySqlDataReader Reader;
            try
            {
                conn.Open();
                Reader = cmd.ExecuteReader();
                int count = 0;
                while (Reader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("login i haslo poprawne");
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
                else if(count > 1)
                {
                    MessageBox.Show("zduplikowane");
                }
                else
                {
                    MessageBox.Show("nie poprawne!");
                }
                conn.Close();
            }
            catch (Exception ee)
            {
                Console.Write(ee);
            }

        }
    }
}
