using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextForm
{
    class CalculatorUI
    {
        private PanelButtons numberButtons;
        private RichTextBox textField;

        public CalculatorUI(Control numberPanel, Control opPanel)
        {
            numberButtons = new PanelButtons(numberPanel, 11);
        }
        
        public RichTextBox TextField
        {
            set { textField = value; }
        }

        public void initialiseNumberPanel(int columns = 3, int rows = 4)
        {
            numberButtons.initialiseButtons();
            numberButtons.positionButtons(columns, rows);

            for(int i = 0; i < numberButtons.Buttons.Length; i++)
            {
                numberButtons.Buttons[i].Text = getDigitText(i);
                numberButtons.Buttons[i].Click += onButtonUse;
            }
        }

        private string getDigitText(int index)
        {
            if (index < 10)
                return "" + (9 - index);
            else
                return ".";
        }

        private void onButtonUse(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                textField.Text += btn.Text;
            }
        }
    }
}
