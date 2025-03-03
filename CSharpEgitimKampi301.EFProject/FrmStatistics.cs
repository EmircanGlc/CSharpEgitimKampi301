using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon sayısı

            lblLocationCount.Text = db.Location.Count().ToString(); //lblLocationCount textine db den gelen Location adedini string formatta yaz. 


            #endregion

            #region Toplam Kapasite Sayısı

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString(); //Location tablosundaki Capacity sütunundaki değerleri Topla

            #endregion

            #region Rehber Sayısı
            lblGuideCount.Text = db.Guide.Count().ToString();
            #endregion
            #region Ortalama Kapasite
            lblAvgCapacity.Text = ((int)db.Location.Average(x => x.Capacity)).ToString();
            #endregion
            #region Ortalama Tur Fiyatı
             lblAvgLocationPrice.Text = ((int)db.Location.Sum(x=>x.Price)).ToString() + "₺";
            //lblAvgLocationPrice.Text = String.Format("{0:0.00}", db.Location.Average(x => x.Price),2);

            #endregion

            #region En son Eklemen Ülke
            int LastCountryId = db.Location.Max(x => x.LocationId); //Location tablosundaki en büyük Id'yi bul. zaten en sona eklendiğinden en son eklenen en büyük olacaktır.
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == LastCountryId).Select(y => y.Country).FirstOrDefault(); //lastyCouuntryName e en yüksek Id 'yi getirmeliyim.



            #endregion

            #region Kapadokya Tur Kapasitesi

            lblCappadociaLocationCapacity.Text = db.Location.Where(x=>x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            #endregion

            #region Türkiye Turları ort. Kapasite
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            #endregion

            #region Roma Gezisinin rehberinin İsmi
            var Id= db.Location.Where(x=>x.City =="Roma").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == Id).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();  //Guideıd=1 olanın adını soyadını lblromeguidename e yaz.

            #endregion

            #region Max kapasiteli olan turun şehrinin ismini getir.
            var maxCapacity = db.Location.Max(x => x.Capacity); //x=80
            lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Capacity == maxCapacity).Select(y=>y.City + " \n" + y.Price + " ₺" +"\n" + y.Capacity + " Kişi").FirstOrDefault().ToString();
            #endregion

            #region En pahalı tur
            var maxPriceTour = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x=>x.Price == maxPriceTour).Select(y=>y.City).FirstOrDefault().ToString();
            #endregion

            #region Ayşegül Çınarın tur sayısı

            var Aysegülİd = db.Guide.Where(x=>x.GuideName =="Ayşegül" && x.GuideSurname == "Çınar").Select(y=>y.GuideId).FirstOrDefault();
            lblAysegülCinarLocationCount.Text = db.Location.Where(x => x.GuideId == Aysegülİd).Count().ToString();

            #endregion
        }
    }
}
