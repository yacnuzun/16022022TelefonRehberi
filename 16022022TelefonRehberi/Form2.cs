using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16022022TelefonRehberi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("server = localhost; database=TelefonRehberi;Integrated Security = true");
        SqlDataReader dr;

        Form1 f1 = new Form1();
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand kon = new SqlCommand("select* from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", bag);
            kon.Parameters.AddWithValue("@KullaniciAdi", txtkad.Text);
            kon.Parameters.AddWithValue("@Sifre", txtsifre.Text);
            bag.Open();
            dr = kon.ExecuteReader();
            if (dr.Read())
            {
                f1.Show();
            }
            else
            {
                MessageBox.Show("Kullancı Adı vey Şifre Hatalı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            bag.Close();
        }
    }
}
