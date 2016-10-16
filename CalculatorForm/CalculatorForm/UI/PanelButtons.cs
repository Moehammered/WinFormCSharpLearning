using System.Drawing;
using System.Windows.Forms;

namespace CalculatorForm
{
    class PanelButtons
    {
        private Button[] buttons;
        private Control root;

        public PanelButtons(Control root, int amount)
        {
            this.root = root;
            buttons = new Button[amount];
        }

        public Control Root
        {
            get { return root; }
        }

        public Button[] Buttons
        {
            get { return buttons; }
        }

        public void initialiseButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Font = new Font("Arial", 12);
            }
            root.Controls.AddRange(buttons);
        }

        public void positionButtons(int columns, int rows)
        {
            Size btnSize = new Size();
            Point btnPos = new Point();

            btnSize.Width = root.Size.Width / columns;
            btnSize.Height = root.Size.Height / rows;

            for(int y = 0; y < rows; y++)
            {
                btnPos.Y = y * btnSize.Height;
                for(int x = 0; x < columns; x++)
                {
                    int index = y * columns + x;
                    if (index >= buttons.Length)
                        return;

                    btnPos.X = x * btnSize.Width;
                    buttons[index].Location = btnPos;
                    buttons[index].Size = btnSize;
                }
            }
        }
    }
}
