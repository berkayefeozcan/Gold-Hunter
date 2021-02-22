using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerA : Gamer
    {
        public GamerA(int altinMiktari,
            int adimMiktari, int hedefBelirlemeMaaliyeti,int hamleYapmaMaaliyeti ) :
            base(altinMiktari,  adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // A oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.X = 0;
            anlikYer.Y = 0;
            oyuncuAdi = "A";
        }
        //public override bool hedefeIlerle()
        //{
        //    if (hedefBelirliMi== false)
        //    {
        //        hedefBelirle();
        //        return hedefeIlerle(); 
        //    }
            
        //}
        public override void hedefBelirle()
        {
            int enYakinAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate enYakinKordinat = null ; 
            
            foreach (Coordinate kordinat in acikAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                // her seferde en yakin kordinata ulasiliyor.
                if (enYakinAltinMesafesi > hesaplananUzaklik )
                {
                    enYakinAltinMesafesi = hesaplananUzaklik;
                    enYakinKordinat = kordinat; 
                }
            }
            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti; 
            hedeflenenYer = enYakinKordinat; // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;
            Console.WriteLine("Hedef Belirlendi : A oyuncusunun hedefi"+hedeflenenYer.X + "," + hedeflenenYer.Y);

        }
    }
}