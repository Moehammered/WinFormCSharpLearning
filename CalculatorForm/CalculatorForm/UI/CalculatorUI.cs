using CalculatorForm.Parsing;
using System;
using System.Windows.Forms;

namespace CalculatorForm
{
    class CalculatorUI
    {
        private PanelButtons numberButtons, operationButtons;
        private RichTextBox textField;
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
                    clearDigit();
                    calculated = false;
                    break;
                case "CL": //reset input field
                    textField.Text = "0";
                    calculated = false;
                    break;
                case "=":
                    textField.Text = "" + evaluate(textField.Text);
                    calculated = true;
                    break;
                default:
                    appendInput(text);
                    calculated = false;
                    break;
            }
        }

        private void clearDigit()
        {
            if (textField.Text.Length > 1 && !calculated)
            {
                string originalText = textField.Text;
                textField.Text = originalText.Substring(0, originalText.Length - 1);
            }
            else
                textField.Text = "0";
        }

        private void appendInput(string input)
        {
            if (textField.Text.Length == 1 && textField.Text == "0")
            {
                if (input == ".")
                    textField.Text += input;
                else
                    textField.Text = input;
            }
            else if (textField.Text.Length > 1 && calculated)
            {
                if (input[0] >= '0' && input[0] <= '9' || input[0] == '.')
                    textField.Text = input;
                else
                    textField.Text += input;
            }
            else
                textField.Text += input;
        }

        private string evaluate(string expression)
        {
            Parser calcParser = new Parser(expression);
            try
            {
                calcParser.parseExpression();
                return "" + calcParser.evaluate();
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
