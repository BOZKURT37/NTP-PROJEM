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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
        OleDbConnection baglanti;
        OleDbCommand sorgu;
        OleDbDataReader veri;
        public void Baglanti()
        {
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabani.mdb");
                baglanti.Open();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabani.mdb");
            baglanti.Open();

            OleDbCommand sorgu = new OleDbCommand();
            sorgu.CommandText = "insert into ekle(k_ad,k_sad,k_g,k_tel) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            sorgu.Connection = baglanti;
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text="";
            textBox4.Text="";
            dataGridView1.Refresh();
            verilerigetir();
            MessageBox.Show("KAYDINIZ EKLENMİŞTİR", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 
        private void verilerigetir()
        {
            OleDbCommand sorgu = new OleDbCommand("select * from ekle", baglanti);
            OleDbDataAdapter veri = new OleDbDataAdapter(sorgu);
            DataTable dt = new DataTable();
            veri.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabani.mdb");
        OleDbCommand sorguu;
        OleDbDataReader verii;
        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int silineceksatir = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            string id  = dataGridView1.Rows[silineceksatir].Cells[0].Value.ToString();
            string k_ad = dataGridView1.Rows[silineceksatir].Cells[1].Value.ToString();
            string k_sad = dataGridView1.Rows[silineceksatir].Cells[2].Value.ToString();
            string k_g = dataGridView1.Rows[silineceksatir].Cells[3].Value.ToString();
            string k_tel =dataGridView1.Rows[silineceksatir].Cells[4].Value.ToString();

            baglanti.Open();
            String sqlsorgu = "delete from ekle where id=@id and k_ad=@k_ad and k_sad=@k_sad and k_g=@k_g and k_tel=@k_tel ";
            OleDbCommand sorgu = new OleDbCommand();
            sorgu.CommandText = sqlsorgu;
            sorgu.Connection = con;
            sorgu.Parameters.AddWithValue("@id", id);
            sorgu.Parameters.AddWithValue("@k_ad",k_ad);
            sorgu.Parameters.AddWithValue("@k_sad", k_sad);
            sorgu.Parameters.AddWithValue("@k_g", k_g);
            sorgu.Parameters.AddWithValue("@k_tel",k_tel);
            sorgu.ExecuteNonQuery();

            con.Close();

            dataGridView1.Rows.RemoveAt(silineceksatir);
            dataGridView1.ClearSelection();

            MessageBox.Show("Kaydınız Silinmiştir", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }  
    } 
}
