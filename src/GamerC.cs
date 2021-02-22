using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerC : Gamer
    {
        private int herHamledeAcilacakGA;
        public GamerC(int altinMiktari, 
            int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti,int herHamledeAcilacakGA) :
            base(altinMiktari, adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            this.herHamledeAcilacakGA = herHamledeAcilacakGA;
            anlikYer = new Coordinate();
            anlikYer.Y = StartGame._boardY-1;
            anlikYer.X = StartGame._boardX - 1;
            oyuncuAdi = "C";
        }
        public override void hedefBelirle()
        {
            gizliAltiniAcigaCikar(herHamledeAcilacakGA);

            enKarliAltiniHedefle(); // en karli altini aliyoruz.

        }
        public override bool hamleYap(Gamer gamer)
        { // bir hamlede adimMiktari kadar hareket edilir. 
            atilabilirAdimMiktari = adimMiktari;
            var bulundugumKonum = anlikYer;
            Console.WriteLine(oyuncuAdi + ": Hamle basladi : " + bulundugumKonum.X + "," + bulundugumKonum.Y);

            if (hedefBelirliMi == true && !hedefeVardiMi() && altinMiktari >= hamleYapmaMaaliyeti)
            {
                hedefeIlerle(gamer);
                var vardigimYer = anlikYer;
                Console.WriteLine(vardigimYer.X + "," + vardigimYer.Y + "\n\n");
                return true;
            }

            else if (hedefBelirliMi == false && altinMiktari >= hedefBelirlemeMaaliyeti + hamleYapmaMaaliyeti && (acikAltinListesi.Count != 0 || gizliAltinListesi.Count>0))
            {

                hedefBelirle();
                if (StartGame.oyuncularListesi.Contains(gamer))
                {
                    hedefeIlerle(gamer);
                }
                var vardigimYer = anlikYer;
                Console.WriteLine(vardigimYer.X + "," + vardigimYer.Y + "\n\n");
                return true;
            }

            return false;

        }

        private void gizliAltiniAcigaCikar(int cikaracagiGizliAltinMik)
        {
            Stack<Coordinate> kordinatStack = new Stack<Coordinate>();
            int enYakinGizliAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate enYakinKordinat = null;
            // en yakin gizli altinlar stack in en ustunde
            foreach (Coordinate kordinat in gizliAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                // her seferde en yakin kordinata ulasiliyor.
                if (enYakinGizliAltinMesafesi > hesaplananUzaklik)
                {
                    enYakinGizliAltinMesafesi = hesaplananUzaklik;
                    enYakinKordinat = kordinat;
                    kordinatStack.Push(kordinat);
                }
            }
            while(cikaracagiGizliAltinMik > 0 && kordinatStack.Count > 0)
            {
                Coordinate acigaCikanAltin = kordinatStack.Pop();
                gizliAltinListesi.Remove(acigaCikanAltin);
                acikAltinListesi.Add(acigaCikanAltin);
                StartGame.createBoard.gizliAltiniAcigaCikar(acigaCikanAltin);
                Console.WriteLine("C oyuncusu gizli altini aciga cikardi" + acigaCikanAltin.ToString());
                cikaracagiGizliAltinMik--; 
            }


        }
        
    }
}
