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
    }
}
