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
using StokTakipVeriTabaniProjesi.StokModel1;


namespace StokTakipVeriTabaniProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-V2B2B5B\\TUGBERK;Initial Catalog=StokTakipSistemi;Integrated Security=True;TrustServerCertificate=True");

        private void VerileriGoster()
        {
            using (var db = new StokTakipSistemiEntities())
            {
                var liste = db.stoktakiptablosu.ToList();
                dataGridView1.DataSource = liste;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new StokTakipSistemiEntities())
            {
                stoktakiptablosu yeni = new stoktakiptablosu();
                yeni.kodu = textBox1.Text;
                yeni.adı = textBox2.Text;
                yeni.alısfiyati = Convert.ToDecimal(textBox3.Text);
                yeni.satısfiyati = Convert.ToDecimal(textBox4.Text);
                yeni.birim = textBox5.Text;
                yeni.miktar = Convert.ToInt32(textBox6.Text);
                yeni.tarih = Convert.ToDateTime(textBox7.Text);

                db.stoktakiptablosu.Add(yeni);
                db.SaveChanges();
            }

            VerileriGoster();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }

    }
}