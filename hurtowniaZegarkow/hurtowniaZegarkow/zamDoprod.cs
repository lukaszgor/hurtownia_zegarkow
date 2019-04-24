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
    public partial class zamDoprod : Form
    {
        public zamDoprod()
        {
            InitializeComponent();
            ProducentBox();
            ModelBox();
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

            MessageBox.Show("DOKONANO ZAMOWIENIA PRAWIDŁOWO " +" "+ comboBox1.Text+" id Producnta= "+ comboBox1.SelectedValue+" " +comboBox2.Text+" id Modelu= "+ comboBox2.SelectedValue+"    ilość:  "+textBox1.Text);


            try
            {
                MySqlConnection conn = new MySqlConnection(sellectmanager.connection);



                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sellectmanager.insertZamDoProd(comboBox1.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), textBox1.Text), conn);

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
            }
            clearTextbox();



        }
        


        public void ProducentBox()
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = sellectmanager.connection;
            sql = sellectmanager.selectZamdoProdProducenci;
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
                comboBox1.ValueMember = "idproducenta";
                comboBox1.DisplayMember = "marka";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

            }


        public void ModelBox()
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = sellectmanager.connection;
            sql = sellectmanager.selectZamdoProdModele;
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
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "idmodelu";
                comboBox2.DisplayMember = "model";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

        }


            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();

            string sellect = sellectmanager.selectZamdoProd;

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
    }
}
   