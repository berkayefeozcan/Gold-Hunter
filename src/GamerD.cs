using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerD : Gamer
    {
        List<Gamer> oyuncular;
        public GamerD(int altinMiktari,
            int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti) :
            base(altinMiktari, adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.Y = StartGame._boardY - 1;
            anlikYer.X = 0;
            oyuncuAdi = "D";
            oyuncular = StartGame.oyuncularListesi;
        }
        public override void hedefBelirle()
        {
            int oncekiHedefleneYerX;
            int oncekiHedefleneYerY;
            if (hedeflenenYer != null)
            {
                oncekiHedefleneYerX = hedeflenenYer.X;
                oncekiHedefleneYerY = hedeflenenYer.Y;
            }
            else
            {
                oncekiHedefleneYerX = anlikYer.X;
                oncekiHedefleneYerY = anlikYer.Y;
            }
            hedeflenenYer = null;

            int enYakinAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate hedefKordinat = null;
            double maliyet;
            double karTutari = int.MinValue;
            
            //diğer oyuncuların hedeflerine onlardan önce ulaşabiliryor mu diye kontrol edecek
            bool dahaOnceUlasirMi = false;
            List<Coordinate> oyuncuHedefleri = new List<Coordinate>();

            if (oyuncular.Count > 1)
            {
                int hesaplananUzaklik_D;
                int hesaplananUzaklik_Oyuncu;

                foreach (var oyuncu in oyuncular)
                {
                    if (!oyuncu.oyuncuAdi.Equals("D") && oyuncu.hedefBelirliMi)
                    {

                        hesaplananUzaklik_Oyuncu = uzaklikHesapla(oyuncu.anlikYer, oyuncu.hedeflenenYer);
                        hesaplananUzaklik_D = uzaklikHesapla(anlikYer, oyuncu.hedeflenenYer);

                        if (hesaplananUzaklik_D < hesaplananUzaklik_Oyuncu && hesaplananUzaklik_D < enYakinAltinMesafesi)
                        {
                            enYakinAltinMesafesi = hesaplananUzaklik_Oyuncu;
                            hedefKordinat = oyuncu.hedeflenenYer;
                            dahaOnceUlasirMi = true;
                        }

                        oyuncuHedefleri.Add(oyuncu.hedeflenenYer);
                    }
                }

            }
            enYakinAltinMesafesi = int.MaxValue;

            if (!dahaOnceUlasirMi)
            {
                foreach (Coordinate kordinat in acikAltinListesi)
                {
                    //oyuncuların hedeflerine onlardan önce ulaşamıyorsa bu hedefleri hariç tutar.
                    if (!oyuncuHedefleri.Contains(kordinat))
                    {
                        // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                        hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                        maliyet = (hesaplananUzaklik / adimMiktari) * hamleYapmaMaaliyeti;
                        if ((kordinat.AltınDegeri - Convert.ToInt32(maliyet)) > karTutari)
                        {
                            karTutari = (kordinat.AltınDegeri - maliyet);
                            hedefKordinat = kordinat;
                        }
                    }

                }
            }

            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti;
            hedeflenenYer = hedefKordinat; // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;

            if (hedeflenenYer == null ||(oncekiHedefleneYerX == hedeflenenYer.X && oncekiHedefleneYerY == hedeflenenYer.Y)  )
            {
                StartGame.oyuncularListesi.Remove(StartGame.gamerD);
                StartGame.gamerD.oyuncuElendiMi = true;
                //createBoard.oyuncuyuEle(gamer);
                Console.WriteLine("Oyuncu D elendi");
            }

            else if  (hedeflenenYer != null)
            {
                Console.WriteLine("Hedef Belirlendi : D oyuncusunun hedefi" + hedeflenenYer.X + "," + hedeflenenYer.Y);
            }
            else
            {
                Console.WriteLine("Hedef Null");
            }



        }



    }
}
