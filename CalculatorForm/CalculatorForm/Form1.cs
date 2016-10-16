using System;
using System.Linq;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class Form1 : Form
    {
        private CalculatorUI uiBuilder;

        public Form1()
        {
            InitializeComponent();
            uiBuilder = new CalculatorUI(numeracyPanel, opPanel);
            uiBuilder.initialiseNumberPanel();
            uiBuilder.initialiseOperationPanel();
            uiBuilder.TextField = TextField;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void TextField_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Current:{0}\tLast:{1}", TextField.Text, TextField.Text.Last());
        }
    }
}
