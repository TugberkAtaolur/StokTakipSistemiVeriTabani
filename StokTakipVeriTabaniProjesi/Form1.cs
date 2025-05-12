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

namespace StokTakipVeriTabaniProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-V2B2B5B\\TUGBERK;Initial Catalog=StokTakipSistemi;Integrated Security=True;TrustServerCertificate=True");

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from stoktakiptablosu");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bagla.Open();
            SqlCommand komut = new SqlCommand("insert into stoktakiptablosu(kodu,adı,alısfiyati,satısfiyati,birim,miktar,tarih)values(@kodu,@adı,@alısfiyati,@satısfiyati,@birim,@miktar,@tarih)", bagla);
            komut.Parameters.AddWithValue("@kodu", textBox1.Text);
            komut.Parameters.AddWithValue("@adı", textBox2.Text);
            komut.Parameters.AddWithValue("@alısfiyati", textBox3.Text);
            komut.Parameters.AddWithValue("@satısfiyati", textBox4.Text);
            komut.Parameters.AddWithValue("@birim", textBox5.Text);
            komut.Parameters.AddWithValue("@miktar", textBox6.Text);
            komut.Parameters.AddWithValue("@tarih", textBox7.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from stoktakiptablosu");
            bagla.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           
            

        }

    }
}