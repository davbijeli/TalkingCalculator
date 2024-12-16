using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace CS_TalkingCalculator
{
    public partial class FrmMain : Form
    {
        double firstNum, secondNum, answer;
        string op;

        SpeechSynthesizer sapi = new SpeechSynthesizer();
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }

            sapi.Speak("Backspace");
        }

        private void NumberClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text += b.Text;
                }
                sapi.Speak("Point");
            }
            else
            {
                txtDisplay.Text += b.Text;
            }
            sapi.Speak(txtDisplay.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            sapi.Speak("Calculator Reset back to Zero");
        }

        private void btnNegate_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = (Convert.ToInt32(txtDisplay.Text) * (-1)).ToString();
            sapi.Speak("Negation");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(txtDisplay.Text);
            op = "+";
            txtDisplay.Text = "";
            sapi.Speak("Plus");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(txtDisplay.Text);
            op = "-";
            txtDisplay.Text = "";
            sapi.Speak("Minus");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(txtDisplay.Text);
            op = "*";
            txtDisplay.Text = "";
            sapi.Speak("Multiply");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(txtDisplay.Text);
            op = "/";
            txtDisplay.Text = "";
            sapi.Speak("Divide");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNum = Convert.ToDouble(txtDisplay.Text);

            if (op == "+")
            {
                answer = firstNum + secondNum;
                txtDisplay.Text = Convert.ToString(answer);
                sapi.Speak(txtDisplay.Text);
            }

            if (op == "-")
            {
                answer = firstNum - secondNum;
                txtDisplay.Text = Convert.ToString(answer);
                sapi.Speak(txtDisplay.Text);
            }

            if (op == "*")
            {
                answer = firstNum * secondNum;
                txtDisplay.Text = Convert.ToString(answer);
                sapi.Speak(txtDisplay.Text);
            }

            if (op == "/")
            {
                answer = firstNum / secondNum;
                txtDisplay.Text = Convert.ToString(answer);
                sapi.Speak(txtDisplay.Text);
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            string f, s;

            f = Convert.ToString(firstNum);
            s = Convert.ToString(secondNum);

            f = "";
            s = "";

            sapi.Speak("Delete");
        }

        
        public FrmMain()
        {
            InitializeComponent();
        }
    }
}
