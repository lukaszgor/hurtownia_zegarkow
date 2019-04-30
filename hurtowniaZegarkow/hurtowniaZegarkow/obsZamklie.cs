using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace hurtowniaZegarkow
{
    public partial class obsZamklie : Form
    {


        public obsZamklie()
        {
            InitializeComponent();
            StatusChange();
        }
        SellectManager sellectmanager = new SellectManager();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();

            string sellect = sellectmanager.selectZamKlienta;

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
            MessageBox.Show("Zmieniono status dla zamowienia nr    "+comboBox1.SelectedValue.ToString()+"  Status został zmieniony na : "+ textBox1.Text);

            try
            {
                MySqlConnection conn = new MySqlConnection(sellectmanager.connection);



                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sellectmanager.updateObsZamKlie(comboBox1.SelectedValue.ToString(), textBox1.Text), conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ee)
            {
                Console.Write(ee);
            }

            



        }
        public void StatusChange()
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = sellectmanager.connection;
            sql = sellectmanager.selectObsZamodKlienta;
            connection = new MySqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new MySqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "idzamodklienta";
                comboBox1.DisplayMember = "idzamodklienta";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }


    }
       
    
}
