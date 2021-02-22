using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altın_Toplama_Oyunu
{
    public partial class EndOfGameFrm : Form
    {
        public EndOfGameFrm()
        {
            InitializeComponent();
        }

        public void SkorDegerleriniAta(List<Gamer> oyuncular)
        {
            this.lblAdimA.Text = oyuncular[0].atilanToplamAdimSayisi.ToString();
            this.lblAdimB.Text = oyuncular[1].atilanToplamAdimSayisi.ToString();
            this.lblAdimC.Text = oyuncular[2].atilanToplamAdimSayisi.ToString();
            this.lblAdimD.Text = oyuncular[3].atilanToplamAdimSayisi.ToString();

            this.lblHarcananA.Text = oyuncular[0].harcananAltinMiktari.ToString();
            this.lblHarcananB.Text = oyuncular[1].harcananAltinMiktari.ToString();
            this.lblHarcananC.Text = oyuncular[2].harcananAltinMiktari.ToString();
            this.lblHarcananD.Text = oyuncular[3].harcananAltinMiktari.ToString();

            this.lblToplananA.Text = oyuncular[0].toplananAltinMiktari.ToString();
            this.lblToplananB.Text = oyuncular[1].toplananAltinMiktari.ToString();
            this.lblToplananC.Text = oyuncular[2].toplananAltinMiktari.ToString();
            this.lblToplananD.Text = oyuncular[3].toplananAltinMiktari.ToString();

            Label[] labelArray = { this.lblKasadakiA, this.lblKasadakiB, this.lblKasadakiC, this.lblKasadakiD };
           
            for(int i = 0;i< oyuncular.Count; i++)
            {
                int  altinMik = oyuncular[i].altinMiktari;
                int kasadakiAltin = altinMik < 0 ? 0 : altinMik;
                labelArray[i].Text = kasadakiAltin.ToString();
            }
   


        }

        private void EndOfGameFrm_Load(object sender, EventArgs e)
        {

        }

        private void lblAdimA_Click(object sender, EventArgs e)
        {

        }
    }
}
