using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventTutorial
{
    public partial class Form1 : Form
    {
        List<Button> buttons;
        GroupBox hiddenBox;
        RadioButton rb1, rb4, rb6, rb9;

        public Form1()
        {
            InitializeComponent();

            // establish the  buttons list
            buttons = new List<Button>();

            // create a group box and hide it
            hiddenBox = new GroupBox();
            hiddenBox.Visible = false;

            // add three radio buttons to the hidden group box
            rb1 = new RadioButton();
            rb1.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            hiddenBox.Controls.Add(rb1);

            rb4 = new RadioButton();
            rb4.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            hiddenBox.Controls.Add(rb4);

            rb6 = new RadioButton();
            rb6.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            hiddenBox.Controls.Add(rb6);

            rb9 = new RadioButton();
            rb9.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            hiddenBox.Controls.Add(rb9);
        }

        // button creation and removal code ===============================

        private void ClearButtons(List<Button> buttons)
        {
            // get each button in the list and remove from form controls
            foreach (Button button in buttons)
            {
                // remove the button from the controls
                this.Controls.Remove(button);
            }
            // empty the buttons list
            buttons.Clear();
        }

        private Button MakeButton(int x, int y, int max_x, int max_y, string name, EventHandler button_click)
        {
            Button button = new Button();

            button.Text = name;

            // size and position the button
            button.Left = panel1.Width * x / max_x;
            button.Top = panel1.Top + panel1.Height * y / max_y;
            button.Width = panel1.Width / max_x;
            button.Height = panel1.Height / max_y;

            // add it to the forms controls
            this.Controls.Add(button);

            // bring the button to the front
            button.BringToFront();

            // add event handler to button
            button.Click += button_click;

            return button;
        }

        private string GetButtonName(int number)
        {
            string[] names = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            return names[number];
        }

        private void MakeButtons(int max_x, int max_y)
        {
            int num;
            Button button;

            // remove any previous buttons that have been set up from the form
            ClearButtons(buttons);

            // create the new buttons
            for (int y = 0; y < max_y; y++)
            {
                for (int x = 0; x < max_x; x++)
                {
                    // create a new button and add to button list
                    num = y * max_x + x;
                    button = MakeButton(x, y, max_x, max_y, GetButtonName(num), GetButtonClickHandler(num));
                    // add the button to the button list.
                    buttons.Add(button);
                }
            }
        }

        // hidden radio button 
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            button1ToolStripMenuItem.Checked = rb1.Checked;
            button4ToolStripMenuItem.Checked = rb4.Checked;
            button9ToolStripMenuItem.Checked = rb9.Checked;
        }

        // button click events ==============================================

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("one");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("two");
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("three");
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("four");
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("five");
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("six");
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("seven");
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("eight");
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("nine");
        }

        private EventHandler GetButtonClickHandler(int number)
        {
            if (number == 0)
                return new EventHandler(Button1_Click);
            else if (number == 1)
                return new EventHandler(Button2_Click);
            else if (number == 2)
                return new EventHandler(Button3_Click);
            else if (number == 3)
                return new EventHandler(Button4_Click);
            else if (number == 4)
                return new EventHandler(Button5_Click);
            else if (number == 5)
                return new EventHandler(Button6_Click);
            else if (number == 6)
                return new EventHandler(Button7_Click);
            else if (number == 7)
                return new EventHandler(Button8_Click);
            else
                return new EventHandler(Button9_Click);
        }

        // menu click event =======================================================
        private void button9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeButtons(3, 3);
            rb9.Checked = true;
        }

        private void buttonsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeButtons(3, 2);
            rb6.Checked = true;
        }

        private void button4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeButtons(2, 2);
            rb4.Checked = true;
        }

        private void button1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeButtons(1, 1);
            rb1.Checked = true;
        }
    }
}
