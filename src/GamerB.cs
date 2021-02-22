using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerB : Gamer
    {
        public GamerB(int altinMiktari,  int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti)
            : base(altinMiktari,  adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.X = StartGame._boardX-1;
            anlikYer.Y = 0;
            oyuncuAdi = "B";
        }

        public override void hedefBelirle()
        {
            enKarliAltiniHedefle();
            Console.WriteLine("Hedef Belirlendi : B oyuncusunun hedefi" + hedeflenenYer.X + "," + hedeflenenYer.Y);

        }
    }
}
