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
            //Dispaly();
            Insertuj();

        }
        SellectManager sellectmanager = new SellectManager();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }


        //public void Dispaly()
        //{
        //    try
        //    {

        //        MySqlConnection conn = new MySqlConnection(sellectmanager.connection);
        //        MySqlCommand cmd = new MySqlCommand(sellectmanager.innerJoinZamdoProd, conn);

        //        conn.Open();





        //        MySqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //            comboBox1.Items.Add(reader.GetString("marka"));

        //            comboBox2.Items.Add(reader.GetString("model"));
        //    }

        //    conn.Close();





        //}
        //    catch (Exception ee)
        //    {
        //        Console.Write(ee);
        //    }


        //}


        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(comboBox1.Text + " " + comboBox1.SelectedValue);
        }                                                                        






        public void Insertuj()
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = "datasource=127.0.0.1;port=3306;username=root;password=;persistsecurityinfo=True;database=czas";
            sql = "select marka,idproducenta from producenci";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
   