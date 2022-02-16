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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("server=localhost;database=TelefonRehberi;Integrated Security = true");
        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("RehberEkle",bag);
            add.CommandType = CommandType.StoredProcedure;
            add.Parameters.AddWithValue("@Isim",txtisim.Text);
            add.Parameters.AddWithValue("@Soyisim",txtsoyisim.Text);
            add.Parameters.AddWithValue("@Tel1",txtt1.Text); 
            add.Parameters.AddWithValue("@Tel2",txtt2.Text);
            add.Parameters.AddWithValue("@Email",txtemail.Text); 
            add.Parameters.AddWithValue("@Webadres",txtwebadres.Text);
            add.Parameters.AddWithValue("@Adres",txtadres.Text);
            add.Parameters.AddWithValue("@Aciklama",txtaciklama.Text);
            bag.Open();
            int kont = add.ExecuteNonQuery();
            bag.Close();
            if (kont>0)
            {
                MessageBox.Show("Kayıt Eklendi!!");
                
                RehberListele();
            }
            else
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu!!");
               
            }
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RehberListele();
        }

        private void RehberListele()
        {
            SqlCommand list = new SqlCommand();
            list.CommandText = "select*from Rehber";
            list.Connection = bag;
            bag.Open();
            SqlDataReader dr = list.ExecuteReader();

            List<Rehber> rehberlistesi = new List<Rehber>();

            while (dr.Read())
            {
                rehberlistesi.Add(new Rehber()
                {
                    ID = dr.GetInt32(0),
                    isim = dr.GetString(1),
                    soyisim = dr.GetString(2),
                    tel1 = dr.GetString(3),
                    tel2 = dr.GetString(4),
                    email = dr.GetString(5),
                    webadres = dr.GetString(6),
                    adres = dr.GetString(7),
                    aciklama = dr.GetString(8)

                });

            }
            bag.Close();
            listBox1.DataSource = rehberlistesi;
        }
    }
}
