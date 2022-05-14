using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proje_1__şifre_oluşturma_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bağlantı;
        OleDbCommand sorgu;
        OleDbDataReader veri;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (eskisifredogru()&&yenisifresogru())
                {
                    baglantı();
                    sorgu = new OleDbCommand();
                    sorgu.CommandText = "update kullanicilar set sifre='" + tbSifre.Text + Form2.kullanıcıadı + "'";
                    sorgu.Connection = bağlantı;
                    sorgu.ExecuteNonQuery();
                    bağlantı.Close();
                    MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception w)
            {
                int sil = 0;
            }
        }
        private bool eskisifredogru()
        {
            if (Form2.şifre == tbKullaniciAdi.Text)
            return false;
            else
            {
                return true;
                MessageBox.Show("Eski Şifreniz Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool yenisifresogru()
        {
            if (tbSifre.Text == null || tbSifre.Text == "")
            {
                MessageBox.Show("Yeni Şifrenizi Boş Bırakamazsınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (tbSifre.Text == textBox1.Text)
                return true;
                else
                {
                    MessageBox.Show("Yeni Şifreler Birbirini Tutmuyor", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } 
        }
        public void baglantı()
        {
            try
            {
                bağlantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabanı.mdb");
                bağlantı.Open();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }
    }
}
