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
    public partial class MainFrm : Form
    {

        StartGame start;
        //Bu iki değişkene diğer classlardan daha sonra erişilmek istenecek.
        
        public MainFrm()
        {
            InitializeComponent();
        }

        public static int adımSayisi;
        public static int oyuncuAltinSayisi;
        public static int hedefBelirlemeMaaliyetiA;
        public static int hedefBelirlemeMaaliyetiB;
        public static int hedefBelirlemeMaaliyetiC;
        public static int hedefBelirlemeMaaliyetiD;
        public static int hamleYapmaMaaliyetiA;
        public static int hamleYapmaMaaliyetiB;
        public static int hamleYapmaMaaliyetiC;
        public static int hamleYapmaMaaliyetiD;
        private void button1_Click(object sender, EventArgs e)
        {
            int boardX = Convert.ToInt32(this.tbxX.Text);
            int boardY = Convert.ToInt32(this.tbxY.Text);
            double altinOrani = Convert.ToDouble(this.tbxAltinOran.Text);
            double gizliAltinOrani = Convert.ToDouble(this.tbxGizliAltin.Text);
            adımSayisi = Convert.ToInt32(this.tbxAdımSayısı.Text);
            oyuncuAltinSayisi = Convert.ToInt32(this.tbxOyuncuAltın.Text);
            hedefBelirlemeMaaliyetiA = Convert.ToInt32(this.HDBMATextBox.Text);
            hedefBelirlemeMaaliyetiB = Convert.ToInt32(this.HDBMBTextBox.Text);
            hedefBelirlemeMaaliyetiC = Convert.ToInt32(this.HDBMCTextBox.Text);
            hedefBelirlemeMaaliyetiD = Convert.ToInt32(this.HDBMDTextBox.Text);
            hamleYapmaMaaliyetiA = Convert.ToInt32(this.HYMATextBox.Text);
            hamleYapmaMaaliyetiB = Convert.ToInt32(this.HYMBTextBox.Text);
            hamleYapmaMaaliyetiC = Convert.ToInt32(this.HYMCTextBox.Text);
            hamleYapmaMaaliyetiD = Convert.ToInt32(this.HYMDTextBox.Text);

            start = new StartGame(boardX, boardY, altinOrani, gizliAltinOrani);
            start.createGameBoard();
            
        }

        private void lblX_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
