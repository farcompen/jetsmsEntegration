using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dakik_sms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mesaj_gonder();
        }

        public void mesaj_gonder()
        {
            servis_sms.SendSMSResult sonuc = new servis_sms.SendSMSResult();
            string kullanici = "kamuhas";
            string parola = "1659km";
            string originator = "DEMO";
            string reference = "ben";
            string bas_tarih = "14042017100000";
            string bitis = "15052017100000";
            servis_sms.ArrayOfString mesaj = new servis_sms.ArrayOfString();
            mesaj.Add(richTextBox1.Text);
            servis_sms.ArrayOfString numaralar = new servis_sms.ArrayOfString();
            numaralar.Add(textBox1.Text);
            string channel = null;
            string karaliste = null;
            string option_f = null;
            string x = null;
            servis_sms.enmOnLengthProblem onn = new servis_sms.enmOnLengthProblem();


            string yasak_saat_bas = "230000";
            string yasak_saat_bitis = "080000";

            servis_sms.SMSServiceSoapClient client = new servis_sms.SMSServiceSoapClient();
            sonuc = client.SendSMS(kullanici, parola, originator, reference, bas_tarih, bitis, mesaj, numaralar, yasak_saat_bas, yasak_saat_bitis, channel, karaliste, option_f, x, onn);

            if (sonuc.ErrorCode == "00")
                MessageBox.Show("Başarılı");
            else
                MessageBox.Show(sonuc.ErrorCode);
                

        }

       
    }
}
