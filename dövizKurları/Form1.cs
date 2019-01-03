using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dövizKurları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlElement rootelement = xmldoc.DocumentElement;
            XmlNodeList liste = rootelement.GetElementsByTagName("Currency");
            List<Doviz> dlist = new List<Doviz>();

            foreach (XmlElement item in liste)
            {
                Doviz d = new Doviz();

                XmlElement currency = item;

               string code= currency.Attributes["CurrencyCode"].Value;
                string isim = currency.GetElementsByTagName("Isim").Item(0).InnerText;

                d.CurrencyName = isim;
               string alısfiyat=currency.GetElementsByTagName("ForexBuying").Item(0).InnerText;
               string satısfiyat = currency.GetElementsByTagName("ForexSelling").Item(0).InnerText;
               string birim = currency.GetElementsByTagName("Unit").Item(0).InnerText;

                if (!string.IsNullOrEmpty(alısfiyat)) {
                    d.ForexBuying = Convert.ToDecimal(alısfiyat)/10000;
                    
                }
                if (!string.IsNullOrEmpty(satısfiyat))
                {
                    d.ForexSelling = Convert.ToDecimal(satısfiyat) / 10000;
                }
                if (!(code is null))
                {
                    d.CurrencyCode = code;
                }

                listBox1.Items.Add(d);

                dlist.Add(d);
                
            }
            dataGridView1.DataSource = dlist;

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doviz secilenDoviz = (Doviz)listBox1.SelectedItem;
            label1.Text =secilenDoviz.ForexBuying.ToString();
            label2.Text = secilenDoviz.ForexSelling.ToString();
            label3.Text = secilenDoviz.CurrencyName.ToString();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataSet doviz = new DataSet();
            doviz.ReadXml("https://www.tcmb.gov.tr/kurlar/today.xml");
            dataGridView2.DataSource = doviz.Tables[1];


        }
    }
}
