using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using Google.Cloud.Firestore;

namespace SAKATAR_ZGİ_UPDATE
{
    public partial class Form1 : Form
    {
        FirestoreDb database;
        public string data;
        public int veri;
        public int sıcaklık;
        public int nem;
        public int basınc;
        public int i = 0;
        public string c;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //bunifuCircleProgressbar1.Value = 45;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            ana_Sayfa1.Visible = false;
            droneCAnlıYayın1.Visible = false;
            harita_Takip1.Visible = false;
            // bağlantılar1.Visible = false;
            panel4.Visible = false;
            hava_Durumu1.Visible = false;
            görüntüişleme1.Visible = true;
            detaylı_Grafikler1.Visible = false;

        }
        int mouse_x, mouse_y;

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_x = MousePosition.X - this.Left;
            mouse_y = MousePosition.Y - this.Top;
            timer1.Enabled = true;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
           droneCAnlıYayın1.Visible = true;
           ana_Sayfa1.Visible = false;
           harita_Takip1.Visible = false;
           //bağlantılar1.Visible = false;
           panel4.Visible = false;
           hava_Durumu1.Visible = false;
           görüntüişleme1.Visible = false;
            detaylı_Grafikler1.Visible = false;



        }

        private void droneCAnlıYayın1_Load(object sender, EventArgs e)
        {

        }

        private void droneCAnlıYayın1_Load_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
           ana_Sayfa1.Visible = true;
           droneCAnlıYayın1.Visible = false;
           harita_Takip1.Visible = false;
           //bağlantılar1.Visible = false;
           panel4.Visible = false;
           hava_Durumu1.Visible = false;
           görüntüişleme1.Visible = false;
           detaylı_Grafikler1.Visible = false;



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ana_Sayfa1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           droneCAnlıYayın1.Visible = false;
           ana_Sayfa1.Visible = false;
           harita_Takip1.Visible = true;
           //bağlantılar1.Visible = false;
           panel4.Visible = false;
           hava_Durumu1.Visible = false;
           görüntüişleme1.Visible = false;
            detaylı_Grafikler1.Visible = false;




        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void ana_Sayfa1_Load_1(object sender, EventArgs e)
        {
          //  ana_Sayfa1.label16.Text = bağlantılar1.data ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portlar = SerialPort.GetPortNames();
            foreach (string port in portlar)
                comboBox1.Items.Add(port);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            bunifuThinButton21.ButtonText = DateTime.Now.ToLongDateString();
            timer2.Enabled = true;
            timer3.Enabled = false;
            timer5.Enabled = true;
            timer6.Enabled = true;
            timer4.Start();
            timer5.Start();
            timer6.Start();
          
            hava_Durumu1.webBrowser1.Navigate("https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1");
            hava_Durumu1.webBrowser1.ScriptErrorsSuppressed = true;







            string path = AppDomain.CurrentDomain.BaseDirectory + @"solar-galaxy.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("solar-galaxy-303109");

        }
        
        void Add_Documents_with_AutoID()
        {
            CollectionReference coll = database.Collection("Add_Docments_with_AutoID");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"Sıcaklık", "tacv" },
                {"Nem", "amazing codeverse" },
                {"Basınc", "875" },

            };
            coll.AddAsync(data1);
           // MessageBox.Show("Veriler başarıyla eklendi :D");
        }

        void SAKATAR()
        {
            if (pictureBox14.Visible == false)
            {
                c = "1";
            }
            else
            {
                c = "0";
            }
            string b = ana_Sayfa1.bunifuCircleProgressbar1.Value.ToString();
            DocumentReference DOC = database.Collection("SAKATAR").Document("ZGİ Veriler");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"Sıcaklık", ana_Sayfa1.label16.Text },
                {"Nem", b },
                {"Basınç", ana_Sayfa1.label19.Text  },
                {"Rüzgar", ana_Sayfa1.label8.Text },
                {"DroneUçabilirlikDurumu", c },

            };
            DOC.SetAsync(data1);
            // MessageBox.Show("Veriler başarıyla eklendi :D");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "Açık")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                güneşli.Visible = true;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;


            }
            else if (label3.Text == "Parçalı Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                parçalubulutlu.Visible = true;
                güneşli.Visible = false;
                rüzgarlı.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Güneşli")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                güneşli.Visible = true;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;


            }
            else if (label3.Text == "Rüzgarlı")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                rüzgarlı.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Yağmurlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                yağmurlu.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Sıcak")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                güneşli.Visible = true;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Az Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                azbulultlu.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                yağmurlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Çok Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                Çokbllutlu.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                rüzgarlı.Visible = false;
                bulutlu.Visible = false;

            }

            else if (label3.Text == "Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                Çokbllutlu.Visible = false;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                yağmurlu.Visible = false;
                azbulultlu.Visible = false;
                rüzgarlı.Visible = false;
                bulutlu.Visible = true;

            }
            else if (label3.Text == "Hafif Yağmurlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                yağmurlu.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }
            else if (label3.Text == "Yağışlı")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = false;
                yağmurlu.Visible = true;
                güneşli.Visible = false;
                parçalubulutlu.Visible = false;
                rüzgarlı.Visible = false;
                azbulultlu.Visible = false;
                Çokbllutlu.Visible = false;
                bulutlu.Visible = false;



            }




            timer2.Enabled = false;  
            timer3.Enabled = true;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "Açık")
            {

                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Parçalı Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Güneşli")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Rüzgarlı")
            {
                pictureBox14.Visible = true;
                pictureBox24.Visible = false;
            }
            else if (label3.Text == "Yağmurlu")
            {
                pictureBox14.Visible = true;
                pictureBox24.Visible = false;
            }
            else if (label3.Text == "Sıcak")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Az Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Çok Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Bulutlu")
            {
                pictureBox14.Visible = false;
                pictureBox24.Visible = true;
            }
            else if (label3.Text == "Yağışlı")
            {
                pictureBox14.Visible = true;
                pictureBox24.Visible = false;
            }
            else if (label3.Text == "Hafif Yağmurlu")
            {
                pictureBox14.Visible = true;
                pictureBox24.Visible = false;
            }

            timer3.Enabled = false;
            timer2.Enabled = true;
        }

        private void gaugeControl2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            digitalGauge2.Text = DateTime.Now.ToLongTimeString();

        }

        private void bağlantılar1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            ana_Sayfa1.Visible = false;
            droneCAnlıYayın1.Visible = false;
            harita_Takip1.Visible = false;
           // bağlantılar1.Visible = false;
            panel4.Visible=true;
            hava_Durumu1.Visible = false;
            görüntüişleme1.Visible = false;
            detaylı_Grafikler1.Visible = false;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                data = serialPort1.ReadLine();
                this.Invoke(new EventHandler(displayData_event));
            }
            catch (Exception ex)
            {
                data = "11/11/11";
            }
            
                
            
        }
        public void displayData_event(object sender, EventArgs e)
        {
            DateTime myDateValue = DateTime.Now; //Güncel zaman bilgisini al
            
            //textBox1.Text += data;
            //veri = int.Parse(data);
            //label4.Text = data;
            string[] value = data.Split('/');
            sıcaklık = int.Parse(value[1]);
            nem = int.Parse(value[0]);
            basınc = int.Parse(value[2]);
            if (serialPort1.IsOpen) pictureBox20.Visible = true; pictureBox19.Visible = false;

            ana_Sayfa1.label19.Text = value[2];

            ana_Sayfa1.linearScaleRangeBarComponent1.Value = sıcaklık;
            ana_Sayfa1.label16.Text = value[1];
            ana_Sayfa1.bunifuCircleProgressbar1.Value = nem;
            ana_Sayfa1.arcScaleComponent2.Value = basınc;
            // ana_Sayfa1.arcScaleComponent2.Value = veri;
            // ana_Sayfa1.label19.Text = data;
            // ana_Sayfa1.bunifuCircleProgressbar1.Value = veri;
            // ana_Sayfa1.label16.Text = data;
            // ana_Sayfa1.linearScaleRangeBarComponent1.Value = veri;


        }
   /*     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
           serialPort1.Open();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
        
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
       /*     while (true)
            {
                try
                {
                    HtmlElementCollection htmlElementCollection = ana_Sayfa1.webBrowser1.Document.All;
                    foreach (HtmlElement name in htmlElementCollection)
                        if (name.GetAttribute("ng-bind") == "sondurum[0].ruzgarHiz|number:0")
                        {
                            ana_Sayfa1.label8.Text = name.InnerText;
                        }
                        else if (name.GetAttribute("ng-bind") == "sondurum[0].hadiseAdi")
                        {
                            label3.Text = name.InnerText;

                        }

                }


                catch (Exception ex)
                {
                    ana_Sayfa1.label8.Text = "!!!";

                }
                
            }*/


        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            pictureBox20.Visible = false;
            pictureBox19.Visible = true;
             

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            ana_Sayfa1.Visible = false;
            droneCAnlıYayın1.Visible = false;
            harita_Takip1.Visible = false;
            // bağlantılar1.Visible = false;
            panel4.Visible = false;
            hava_Durumu1.Visible = true;
            görüntüişleme1.Visible = false;
            detaylı_Grafikler1.Visible = false;

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            hava_Durumu1.webBrowser1.Navigate("https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1");
            hava_Durumu1.webBrowser1.ScriptErrorsSuppressed = true;
            ana_Sayfa1.webBrowser1.Navigate("https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1");
            ana_Sayfa1.webBrowser1.ScriptErrorsSuppressed = true;
            try
            {
                HtmlElementCollection htmlElementCollection = ana_Sayfa1.webBrowser1.Document.All;
                foreach (HtmlElement name in htmlElementCollection)
                    if (name.GetAttribute("ng-bind") == "sondurum[0].ruzgarHiz|number:0")
                    {
                        ana_Sayfa1.label8.Text = name.InnerText;
                    }
                    else if (name.GetAttribute("ng-bind") == "sondurum[0].hadiseAdi")
                    {
                        label3.Text = name.InnerText;

                    }

            }


            catch (Exception ex)
            {
                ana_Sayfa1.label8.Text = "!!!";

            }
            // ana_Sayfa1.webBrowser1.Refresh();
            SAKATAR();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            ana_Sayfa1.Visible = false;
            droneCAnlıYayın1.Visible = false;
            harita_Takip1.Visible = false;
            // bağlantılar1.Visible = false;
            panel4.Visible = false;
            hava_Durumu1.Visible = false;
            görüntüişleme1.Visible = false;
            detaylı_Grafikler1.Visible = true;
        }

    /*    private void timer6_Tick(object sender, EventArgs e)
        {
    https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1
                hava_Durumu1.webBrowser1.Navigate("https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1");
                hava_Durumu1.webBrowser1.ScriptErrorsSuppressed = true;
                ana_Sayfa1.webBrowser1.Navigate("https://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx?il=%C4%B0stanbul&ilce=Atat%C3%BCrk%20Havaliman%C4%B1");
                ana_Sayfa1.webBrowser1.ScriptErrorsSuppressed = true;
                try
                {
                    HtmlElementCollection htmlElementCollection = ana_Sayfa1.webBrowser1.Document.All;
                    foreach (HtmlElement name in htmlElementCollection)
                        if (name.GetAttribute("ng-bind") == "sondurum[0].ruzgarHiz|number:0")
                        {
                            ana_Sayfa1.label8.Text = name.InnerText;
                        }
                        else if (name.GetAttribute("ng-bind") == "sondurum[0].hadiseAdi")
                        {
                            label3.Text = name.InnerText;

                        }

                }


                catch (Exception ex)
                {

                    ana_Sayfa1.label8.Text = "!!!";

                }
                SAKATAR();
            }
        


        */
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouse_x;
            this.Top = MousePosition.Y - mouse_y;
        }
    }
}
