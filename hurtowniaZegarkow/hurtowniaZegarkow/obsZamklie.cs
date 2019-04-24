using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace hurtowniaZegarkow
{
    public partial class obsZamklie : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;



        public obsZamklie()
        {
            InitializeComponent();
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
            try
            {
                SqlConnection con = new SqlConnection(@"datasource=localhost;port=3306;username=root;password=;persistsecurityinfo=True;database=czas");
                sda = new SqlDataAdapter("SELECT * FROM czas.zam_od_klienta;", con);
                //dt = new DataTable();
                DataSet ds = new DataSet();
                sda.Fill(ds, "zam_od_klienta");
                dataGridView1.DataSource = ds.Tables["zam_od_klienta"];
                con.Close();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
