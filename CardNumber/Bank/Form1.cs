using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void uiExecuteButton_Click(object sender, EventArgs e)
        {
            string cardNumber = GetCardNumber();
            var sum = 0;
            var n = cardNumber.Length;
            for (int i = 1; i < n - 1; i++)
            {
                var p = (int)Char.GetNumericValue(cardNumber[n - i]);
                if (i%2 != 0)
                {
                    p = 2*p;
                }
                if (p > 9)
                {
                    p -= 9;
                }
                sum += p;
            }
            sum = (sum*9 % 10);
            uiLastCharTextBox.Text = Char.GetNumericValue((sum).ToString()[0]).ToString();
        }

        private string GetCardNumber()
        {
            string cardNumber = "";
            foreach (var number in uiCardNumberTextBox.Text.ToCharArray())
            {
                int num;
                if (int.TryParse(number.ToString(), out num))
                {
                    cardNumber += num.ToString();
                }
            }
            return cardNumber;
        }

        private void uiValidateButton_Click(object sender, EventArgs e)
        {
            string cardNumber = GetCardNumber();
            int a = 1;
            var n = cardNumber.Length;
            if (n%2 == 0)
            {
                a = 0;
            }

            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                var p = (int) Char.GetNumericValue(cardNumber[i]);
                if (i % 2 == a)
                {

                    p = p*2;
                    if (p > 9)
                    {
                        p -= 9;
                    }
                }
                sum += p;
            }
            uiCardNumberTextBox.BackColor = sum%10 == 0 ? Color.Green : Color.Red;
        }
    }
}
