using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUI
{
    public class ColorPickerForm : System.Windows.Forms.Form
    {
        List<List<Button>> m_ColorButtons;
        const int m_ColorPickerFormNumberOfLines = 2;
        const int m_ColorPickerFormButtonsPerLine = 4;
        const int m_Spacing = 5;
        System.Drawing.Size ButtonSize = new System.Drawing.Size(25, 25);
        Color[] m_Colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
        public Color SelectedColor { get; private set; }
        public ColorPickerForm()
        {
            InitializeComponent();
            CreateButtonList();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ColorPickerForm
            // 
            this.ClientSize = new System.Drawing.Size(396, 388);
            this.Name = "ColorPickerForm";
            this.ResumeLayout(false);

        }

        private void CreateButtonList()
        {
            m_ColorButtons = new List<List<Button>>();
            int colorIdx = 0;
            for (int i = 0; i < m_ColorPickerFormNumberOfLines; i++)
            {
                List<Button> line = new List<Button>();
                for (int j = 0; j < m_ColorPickerFormButtonsPerLine; j++)
                {
                    Button b = new Button();
                    b.Size = ButtonSize;
                    b.Location = new System.Drawing.Point(j * (ButtonSize.Width + m_Spacing), i * (ButtonSize.Height + m_Spacing));
                    b.BackColor = m_Colors[colorIdx];
                    line.Add(b);
                    this.Controls.Add(b);
                    b.Click += new EventHandler(colorButtons_OnClick); // Correctly attach the event handler to the button's Click event  
                    colorIdx++;
                }
                m_ColorButtons.Add(line);
            }
        }

        private void colorButtons_OnClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                SelectedColor = clickedButton.BackColor;
                this.DialogResult = DialogResult.OK; // Set the dialog result to OK   
            }
        }

        public void ColorPickerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); // Close the form when it is closed
        }
    }
}
