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
    public partial class ListaProducentow : Form
    {
        public ListaProducentow()
        {
            InitializeComponent();
        }
        SellectManager sellectmanager = new SellectManager();
        private void button1_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            string sellect = sellectmanager.selectProducentList;

            string MyConString = sellectmanager.connection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;

            command.CommandText = sellect;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string thisrow = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ",        ";
                listBox1.Items.Add(thisrow);
            }
            connection.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(sellectmanager.connection);



                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sellectmanager.insertProducentList(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text), conn);

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ee)
            {
                Console.Write(ee);
            }

            void clearTextbox()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
               
            }
            clearTextbox();
        }
    }
}
