using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace AppUI
{
    public class GameForm : System.Windows.Forms.Form
    {
        private List<List<Button>> m_GuessButtons;
        private List<Button> m_BlackGameButtons;
        private List<List<Button>> m_ResultButtons;
        private int m_MaxNumberOfGuesses;
        private const int m_RowWidth = 4; // Number of buttons in each row
        private const int m_Spacing = 10;
        private const int m_ButtonStartLocationX = 12; // X location of the first button in the top row
        private const int m_ButtonStartLocationY = 36; // Y location of the first button in the top row
        private const int m_ButtonSize = 80; // Size of each button in pixels
        private Color[] m_Colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
        private Color[] m_ColorsForGame = new Color[4];

        public GameForm(int MaxNumberOfGuesses)
        {
            m_MaxNumberOfGuesses = MaxNumberOfGuesses;
            InitializeComponent();
            CreateButtonList();
            CreateResultButtons();
            m_ColorsForGame = new Color[] { Color.Blue, Color.Red, Color.Blue, Color.Red };
            //GenerateGuess();
            this.FormClosed += GameForm_FormClosed;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(540, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "GameForm";
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateButtonList()
        {
            System.Drawing.Size ButtonSize = new System.Drawing.Size(80, 80);
            this.m_GuessButtons = new List<List<Button>>();
            this.m_BlackGameButtons = new List<Button>();
            int ButtonCurrX = 0;
            int ButtonCurrY = 0;

            for (int j = 0; j < m_RowWidth; j++)
            {
                ButtonCurrX = m_ButtonStartLocationX + (ButtonSize.Width + m_Spacing) * j;
                ButtonCurrY = m_ButtonStartLocationY;

                Button b = new Button();
                b.Size = ButtonSize;
                b.Location = new Point(ButtonCurrX, ButtonCurrY);
                b.BackColor = Color.Black;

                m_BlackGameButtons.Add(b);
                this.Controls.Add(b);
            }

            for (int i = 0; i < m_MaxNumberOfGuesses; i++)
            {
                ButtonCurrY = m_ButtonStartLocationY + (i + 1) * (ButtonSize.Height + m_Spacing);
                List<Button> row = new List<Button>();
                for (int j = 0; j < m_RowWidth; j++)
                {
                    ButtonCurrX = m_ButtonStartLocationX + (j) * (ButtonSize.Width + m_Spacing);
                    Button b = new Button();
                    b.Size = ButtonSize;
                    b.Location = new Point(ButtonCurrX, ButtonCurrY);
                    b.BackColor = Color.White;
                    b.Click += new EventHandler(GuessButtons_OnClick); // Attach the event handler to the button's Click event
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

        private void GuessButtons_OnClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Point screenLocation = clickedButton.PointToScreen(Point.Empty);
                ColorPickerForm colorPicker = new ColorPickerForm(screenLocation,m_Colors);
                colorPicker.ShowDialog();
                clickedButton.BackColor = colorPicker.SelectedColor;
                colorPicker.Close();
            }
        }

        private void CreateResultButtons()
        {
            m_ResultButtons = new List<List<Button>>();
            int ArrowLocationX = m_ButtonStartLocationX + m_RowWidth * (m_ButtonSize + m_Spacing);
            for (int i = 0; i < m_MaxNumberOfGuesses; i++)
            {
                int ArrowLocationY = m_ButtonStartLocationY + (i + 1) * (m_ButtonSize + m_Spacing);

                Button ArrowButton = new Button();
                ArrowButton.Size = new System.Drawing.Size(30, 30);
                ArrowButton.Text = "→";
                ArrowButton.Location = new Point(ArrowLocationX, ArrowLocationY);
                ArrowButton.Click += new EventHandler(ArrowButtons_OnClick); // Attach the event handler to the button's Click event
                List<Button> row = new List<Button>();
                row.Add(ArrowButton);
                this.Controls.Add(ArrowButton);
                for (int j = 0; j < m_RowWidth; j++)
                {
                    Button button = new Button();
                    button.Size = new System.Drawing.Size(25, 25);
                    int CurrButtonX = ArrowLocationX + (j * (button.Width + m_Spacing)) + ArrowButton.Width;
                    int CurrButtonY = ArrowLocationY + m_ButtonSize / 2;
                    button.Location = new Point(CurrButtonX, CurrButtonY);
                    this.Controls.Add(button);
                    row.Add(button);
                }
                m_ResultButtons.Add(row);
            }
        }

        private void ArrowButtons_OnClick(object sender, EventArgs e)
        {
            Button ArrowButton = sender as Button;
            if (ArrowButton != null)
            {
                int arrowRowIndex = -1;
                for (int i = 0; i < m_ResultButtons.Count; i++)
                {
                    if (m_ResultButtons[i].Contains(ArrowButton))
                    {
                        arrowRowIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < m_GuessButtons[arrowRowIndex].Count; i++)
                {
                    Button button = m_GuessButtons[arrowRowIndex][i];
                    if (button.BackColor == Color.White)
                    {
                        return;
                    }
                    if (button.BackColor == m_ColorsForGame[i])
                    {
                        m_ResultButtons[arrowRowIndex][i + 1].BackColor = Color.Black; // Correct color in the correct position
                    }
                    else if (m_ColorsForGame.Contains(button.BackColor))
                    {
                        m_ResultButtons[arrowRowIndex][i + 1].BackColor = Color.Yellow; // Correct color but in the wrong position
                    }
                }
                ArrowButton.BackColor = Color.Green; // Change the arrow button color to indicate a valid guess
            }
        }


        private void GenerateGuess()
        {
            for (int i = 0; i < m_RowWidth; i++)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(0, m_Colors.Length);
                m_ColorsForGame[i] = m_Colors[randomNumber];
            }
        }
    }
}
