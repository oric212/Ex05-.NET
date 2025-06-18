using System;
using System.Windows.Forms;

namespace AppUI
{
    public class StartForm : Form
    {
        private TextBox textBox1;
        private Label label1;
        private Button btnGuessCount;

        public StartForm()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Arial", 16F);
            this.FormClosing += StartForm_FormClosing;  // Subscribe to FormClosing event
        }

        private void InitializeComponent()
        {
            this.btnGuessCount = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Center the form on the screen
            this.SuspendLayout();
            // 
            // btnGuessCount
            // 
            this.btnGuessCount.Location = new System.Drawing.Point(166, 258);
            this.btnGuessCount.Name = "btnGuessCount";
            this.btnGuessCount.Size = new System.Drawing.Size(205, 93);
            this.btnGuessCount.TabIndex = 0;
            this.btnGuessCount.Text = "Start";
            this.btnGuessCount.UseVisualStyleBackColor = true;
            this.btnGuessCount.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(324, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(83, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of chances:";
            // 
            // StartForm
            // 
            this.ClientSize = new System.Drawing.Size(554, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGuessCount);
            this.Name = "StartForm";
            this.Text = "Start Form";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserInput = textBox1.Text;
            if (int.TryParse(UserInput, out int UserChoice))
            {
                if (UserChoice >= 4 && UserChoice <= 10)
                {
                    GameForm gameForm = new GameForm(UserChoice);
                    gameForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please enter a number between 4 and 10.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a number.");
            }
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();  // Exit the entire application when this form is closing
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
