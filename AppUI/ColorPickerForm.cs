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
        private const int m_ColorPickerFormNumberOfLines = 2;
        private const int m_ColorPickerFormButtonsPerLine = 4;
        private const int m_Spacing = 5;
        private const int m_ButtonSize = 30;
        private const int m_totalButtonsWidth = (m_ColorPickerFormButtonsPerLine * m_ButtonSize) + (m_ColorPickerFormButtonsPerLine - 1) * m_Spacing;
        private const int m_totalButtonsHeight = (m_ColorPickerFormNumberOfLines * m_ButtonSize) + (m_ColorPickerFormNumberOfLines - 1) * m_Spacing;
        private System.Drawing.Size ButtonSize = new System.Drawing.Size(30,30);
        private Color[] m_Colors;

        public Color SelectedColor { get; private set; }
        public ColorPickerForm(Point FormLocation, Color[] Colors)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual; // Set the start position to manual to allow custom location
            this.Location = FormLocation;
            m_Colors = Colors;
            CreateButtonList();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(m_totalButtonsWidth,m_totalButtonsHeight);
            this.Text = "Color Picker";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Set the form border style to fixed dialog
            this.MaximizeBox = false;
            this.MinimizeBox = false; 
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
                    b.Click += new EventHandler(ColorButtons_OnClick); // Correctly attach the event handler to the button's Click event  
                    colorIdx++;
                }
                m_ColorButtons.Add(line);
            }
        }

        private void ColorButtons_OnClick(object sender, EventArgs e)
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
