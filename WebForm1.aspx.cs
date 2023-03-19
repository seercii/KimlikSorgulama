using Kisiler.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kisiler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string ad = TextBoxAd.Text;
                string soyad = TextBoxSoyad.Text;
                string telefonNo = TextBoxTelefonNo.Text;
                long tcKimlikNo = Convert.ToInt64(TextBoxTCKimlikNo.Text);
                DateTime dogumTarihi = Convert.ToDateTime(TextBoxDogumTarihi.Text);

                // NVİ'ne bağlanarak girilen bilgilerin gerçek bir vatandaşa ait olup olmadığını kontrol ettım
                KPSPublicSoapClient client = new KPSPublicSoapClient();
                bool result = client.TCKimlikNoDogrula(tcKimlikNo, ad.ToUpper(), soyad.ToUpper(), dogumTarihi.Year);

                if (!result)
                {
                    HataLabel.Text = "Hata: Girilen bilgiler gerçek bir vatandaşa ait değil.";
                    return;
                }

                // Veritabanına kaydedelim
                string connectionString = "Server=91.93.1.160;Database=sergu;User Id=sergu;Password=SercanGure*1879;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Kisiler (Ad, Soyad, TelefonNo, TcKimlikNo, DogumTarihi, KayitTarihi) VALUES (@Ad, @Soyad, @TelefonNo, @TcKimlikNo, @DogumTarihi, @KayitTarihi)", connection);
                command.Parameters.AddWithValue("@Ad", ad);
                command.Parameters.AddWithValue("@Soyad", soyad);
                command.Parameters.AddWithValue("@TelefonNo", telefonNo);
                command.Parameters.AddWithValue("@TcKimlikNo", tcKimlikNo);
                command.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                command.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
                command.ExecuteNonQuery();
                connection.Close();

                SuccessLabel.Text = "Kayıt işlemi başarıyla tamamlandı.";
            }
            catch (SoapException ex)
            {
                HataLabel.Text = "Hata: " + ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                HataLabel.Text = "Hata: " + ex.Message;
            }
        }
    }
}