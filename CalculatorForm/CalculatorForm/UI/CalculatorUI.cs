using CalculatorForm.Parsing;
using System;
using System.Windows.Forms;

namespace CalculatorForm
{
    class CalculatorUI
    {
        private PanelButtons numberButtons, operationButtons;
        private RichTextBox textField;
        private Calculator calculator;
        private bool calculated = false;

        private const int NUMBER_BTN_COUNT = 11, OP_BTN_COUNT = 9;
        private readonly string[] OP_BTN_SYMB;

        public CalculatorUI(Control numberPanel, Control opPanel)
        {
            numberButtons = new PanelButtons(numberPanel, NUMBER_BTN_COUNT);
            operationButtons = new PanelButtons(opPanel, OP_BTN_COUNT);
            OP_BTN_SYMB = new string[]{
                "CE", "CL", "+", "x", "-", "/", "%", "^", "="
            };
            calculator = new Calculator();
        }
        
        public RichTextBox TextField
        {
            set { textField = value; }
        }

        public void initialiseOperationPanel(int columns = 2, int rows = 5)
        {
            operationButtons.initialiseButtons();
            operationButtons.positionButtons(columns, rows);

            for (int i = 0; i < operationButtons.Buttons.Length; i++)
            {
                operationButtons.Buttons[i].Text = OP_BTN_SYMB[i];
                operationButtons.Buttons[i].Click += onButtonUse;
            }
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
                processInput(btn.Text);
            }
        }

        private void processInput(string text)
        {
            switch(text)
            {
                case "CE":
                    if(textField.Text.Length > 1)
                        textField.Text = textField.Text.Substring(0, textField.Text.Length - 1);
                    else
                        textField.Text = "0";
                    calculated = false;
                    break;
                case "CL":
                    textField.Text = "0";
                    calculated = false;
                    break;
                case "=":
                    textField.Text = "" + calculator.evaluate(textField.Text);
                    calculated = true;
                    break;
                default:
                    if(textField.Text.Length == 1 && textField.Text == "0")
                    {
                        if (text == ".")
                            textField.Text += text;
                        else
                            textField.Text = text;
                    }
                    else if(textField.Text.Length > 1 && calculated)
                    {
                        if (text[0] >= '0' && text[0] <= '9')
                            textField.Text = text;
                        else
                            textField.Text += text;
                    }
                    else
                        textField.Text += text;
                    calculated = false;
                    break;
            }
        }
    }
}
