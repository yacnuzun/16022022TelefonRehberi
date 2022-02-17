using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        SqlConnection bag = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
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

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            int id = ((Rehber)listBox1.SelectedItem).ID;
            SqlCommand upd = new SqlCommand("RehberUpdt",bag);
            upd.CommandType = CommandType.StoredProcedure;
            upd.Parameters.AddWithValue("@ID",id);
            upd.Parameters.AddWithValue("@Isim", txtgisim.Text);
            upd.Parameters.AddWithValue("@Soyisim", txtgsoyisim.Text);
            upd.Parameters.AddWithValue("@Tel1", txtgt1.Text);
            upd.Parameters.AddWithValue("@Tel2", txtgt2.Text);
            upd.Parameters.AddWithValue("@Email", txtgemail.Text);
            upd.Parameters.AddWithValue("@Webadres", txtgwebadres.Text);
            upd.Parameters.AddWithValue("@Adres", txtgadres.Text);
            upd.Parameters.AddWithValue("@Aciklama", txtgaciklama.Text);
            int kont = 0;
            try
            {
                bag.Open();
                kont = upd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            { 
                bag.Close();
            }
            
            if (kont>0)
            {
                MessageBox.Show("Kayıt Güncellendi!");
                RehberListele();
            }
            else
            {
                MessageBox.Show("Kayı Güncellenemedi!!");
            }
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Rehber r = (Rehber)listBox1.SelectedItem;

            txtgisim.Text = r.isim;
            txtgsoyisim.Text = r.soyisim;
            txtgt1.Text = r.tel1;
            txtgt2.Text = r.tel2;
            txtgadres.Text = r.adres;
            txtgemail.Text = r.email;
            txtgwebadres.Text = r.webadres;
            txtgaciklama.Text = r.aciklama;

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = ((Rehber)listBox1.SelectedItem).ID;
            SqlCommand del = new SqlCommand("RehberDel",bag);
            del.CommandType = CommandType.StoredProcedure;
            del.Parameters.AddWithValue("@ID",id);
            bag.Open();
            int kont = del.ExecuteNonQuery();
            bag.Close();
            if (kont>0)
            {
                MessageBox.Show("Kayıt Silindi!!");
                RehberListele();
                txtgaciklama.Clear();
                txtgadres.Clear();
                txtgemail.Clear();
                txtgisim.Clear();
                txtgsoyisim.Clear();
                txtgt1.Clear();
                txtgt2.Clear();
                txtgwebadres.Clear();
               
            }
            else
            {
                MessageBox.Show("Kayıt Silinemedi!!");
            }
        }
    }
}
