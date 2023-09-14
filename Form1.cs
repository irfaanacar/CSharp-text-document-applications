using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetinBelgesiUygulamalari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamWriter sw;
        string belgeadi, belgeyolu;

        private void button2_Click(object sender, EventArgs e)
        {
            belgeadi = textBox1.Text; //isimlendireceğim belgenin ismidir.
            sw = File.CreateText(belgeyolu+"\\"+belgeadi+".txt"); //bu satırda ilgili konuma belge kaydetme işlemini gerçekleştirir.       
            sw.Close();
            MessageBox.Show("Belgeniz oluşturuldu.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)//burası buton3 e tıklandığında açılan kısımdır ve eğer bir belge seçilirse;
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName); //dosyayı okusun.
                string satir = oku.ReadLine();//okuduğu verileri satir adlı değişkene aktarsın.
                while(satir!=null)//ve okuduğu verileri null değerine ulaşana kadar okumaya devam etsin.
                {
                    listBox1.Items.Add(satir);//veriler listbox'a ekleniyor ancak hafızada.
                    satir = oku.ReadLine();//ve hafızayı okuma kısmı.

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Filter = "Metin Dosyası(*.txt) | *.txt";
            ac.Multiselect = false;
            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ac.SafeFileName;
                try
                {
                    StreamReader oku = new StreamReader(ac.FileName);
                    richTextBox1.Text= oku.ReadToEnd();
                    oku.Close();
                    MessageBox.Show("Veriler başarıyla eklendi.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Bu dosyayı okurken bir hata oluştu.");
                  
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           textBox3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt Yerini Seçin"; //Klasör seçmek için açılan görünümün başlığını belirler.
                saveFileDialog1.Filter = "Metin Dosyası(*.txt) | *.txt"; //Yalnızca metin belgesi şeklinde kaydeder.
                saveFileDialog1.FilterIndex = 2; //yukarıdaki kod satırındaki ikinci indisi seçer.(FilterIndisler 1. indisten başlar). 2.indisi seçtiği için dosya uzantısı [.txt] olur.
                saveFileDialog1.InitialDirectory = "C:\\"; //İlk açıldığında C klasöründen başlatmasını istedik.
                saveFileDialog1.ShowDialog(); //Ve diyalog açıldı.
                StreamWriter kaydet= new StreamWriter(saveFileDialog1.FileName); // save edilecek dosyayı kaydet değişkenine aktardık.
                kaydet.WriteLine(richTextBox2.Text); // richtextbox2'den gelen değerler kaydet adlı değişkene gider.
                kaydet.Close();
                MessageBox.Show("Kaynak Metin Belgesine Yazdırıldı.");
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen bir hatadan ötürü işlem gerçekleşmedi.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                belgeyolu = folderBrowserDialog1.SelectedPath.ToString();//Seçtiğimiz yolu belgeyolu adlı değişkene aktardık.
                textBox2.Text=belgeyolu.ToString(); //textbox2'ye belgeyolunu yazdırdık.
            }
        }
    }
}
