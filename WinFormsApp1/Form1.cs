using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int numToGuess;
        private int attempts;

        public Form1()
        {
            InitializeComponent();
        }     
        private void StartNewGame()
        {
            numToGuess = new Random().Next(1, 3);
            attempts = 0;
        }

        private void buttonStart_Click()
        {
            string userInput = textBox1.Text;
            int userGuess;

            if (int.TryParse(userInput, out userGuess))
            {
                attempts++;

                if (userGuess == numToGuess)
                {
                    MessageBox.Show($"³����! �� ������� ����� {numToGuess}. ʳ������ �����: {attempts}",
                        "��������!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult result = MessageBox.Show("������ ������ �� ���?", "���� ���",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        StartNewGame();
                        textBox1.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }
                else if (userGuess < numToGuess)
                {
                    MessageBox.Show("�������� ����� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("�������� ����� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("������� ����������� �����. ��������� �� ���.", "�������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartNewGame();
            buttonStart_Click();
        }
    }
}
