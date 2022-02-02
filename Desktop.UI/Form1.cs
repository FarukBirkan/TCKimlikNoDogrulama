using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long KimlikNo = long.Parse(txtTcNo.Text);
            int yil = int.Parse(txtYili.Text);
            bool? durum;
            try
            {
                using (ServiceReference1.KPSPublicSoapClient service = new ServiceReference1.KPSPublicSoapClient())
                {
                    durum = service.TCKimlikNoDogrula(KimlikNo,txtAdi.Text,txtSoyadi.Text,yil);
                }
            }
            catch (Exception)
            {

                durum = null;
            }


            if (durum==true)
            {
                MessageBox.Show("Sorgulanan TC Doğrulandı  = " + durum.ToString() );
            }
            else
            {
                MessageBox.Show("Sorgulanan TC Doğrulanamadı   = " + durum.ToString());
            }
            
        }
    }
}
