using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUI
{
    public class GameForm : System.Windows.Forms.Form
    {
        private List<List<Button>> m_GuessButtons;
        private List<Button> m_GameButtons;
        private int m_MaxNumberOfGuesses;
        private const int m_RowWidth = 4; // Number of buttons in each row
        private const int m_Spacing = 10;
        public GameForm(int MaxNumberOfGuesses)
        {
            m_MaxNumberOfGuesses = MaxNumberOfGuesses;
            InitializeComponent();
            CreateButtonList();
            this.FormClosed += GameForm_FormClosed;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(520, 640);

            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateButtonList()
        {
            System.Drawing.Size ButtonSize = new System.Drawing.Size(81, 77);
            this.m_GuessButtons = new List<List<Button>>();
            this.m_GameButtons = new List<Button>();
            int topButtonsStartX = 12;
            int topButtonsStartY = 36;
            int topButtonsHeight = 77;

            for (int j = 0; j < m_RowWidth; j++)
            {
                int ButtonCurrX = topButtonsStartX + (ButtonSize.Width + m_Spacing) * j;
                int ButtonCurrY = topButtonsStartY;
                Button b = new Button();
                b.Size = ButtonSize;
                b.Location = new Point(ButtonCurrX, ButtonCurrY);
                b.BackColor = Color.Black;
                m_GameButtons.Add(b);
                this.Controls.Add(b);
            }
            topButtonsStartY = topButtonsStartY + topButtonsHeight + m_Spacing;
            for (int i = 0; i < m_MaxNumberOfGuesses; i++) // plus 1 for the top row
            {
                List<Button> row = new List<Button>();
                for (int j = 0; j < m_RowWidth; j++)
                {
                    int ButtonCurrX = topButtonsStartX + (j) * (ButtonSize.Width + m_Spacing);
                    int ButtonCurrY = topButtonsStartY + (i) * (topButtonsHeight + m_Spacing);
                    Button b = new Button();
                    b.Size = ButtonSize;
                    b.Location = new Point(ButtonCurrX, ButtonCurrY);
                    b.BackColor = Color.White;
                    b.Click += new EventHandler(GuessButtons_Click); // Attach the event handler to the button's Click event
                    row.Add(b);
                    this.Controls.Add(b);
                }
                this.m_GuessButtons.Add(row);
            }
        }
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();  // closes the entire app when this form closes
        }

        private void GuessButtons_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                ColorPickerForm colorPicker = new ColorPickerForm();
                colorPicker.ShowDialog();
                clickedButton.BackColor = colorPicker.SelectedColor; 
                colorPicker.Close(); 
            }
        }
    }
}
