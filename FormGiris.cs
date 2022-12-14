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


namespace Ornek_28_Personel_ID
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-K2UDTIR\\SQLYENI;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Tbl_YöneticiGiris where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            if (dr1.Read())
            {
                FrmAnaForm f = new FrmAnaForm();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı Kullanıcı adı ya da Şifre!");
            baglanti.Close();
        }
    }
}
