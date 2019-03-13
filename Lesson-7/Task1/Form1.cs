using System;
using System.Windows.Forms;

namespace Task1
{
    public partial class MyForm : Form
    {
        Random rnd = new Random();
        private static int curNumber = 0;
        private static int tryCount = 0;
        private static int numberTask = 0;
        public MyForm()
        {
            InitializeComponent();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Text = "Reset";
            numberTask = rnd.Next(10, 100);
            curNumber = 0;
            tryCount = 0;
            lblTryCount.Text = tryCount.ToString();
            lblCurentNumber.Text = curNumber.ToString();
            lblNumberTask.Text = numberTask.ToString();
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            if (ChekReturn()) return;

            curNumber++;
            tryCount++;
            lblCurentNumber.Text = curNumber.ToString();
            lblTryCount.Text = tryCount.ToString();
            CheckWin();

        }

        private void btnMult2_Click(object sender, EventArgs e)
        {
            if (ChekReturn()) return;
            curNumber *= 2;
            tryCount++;
            lblCurentNumber.Text = curNumber.ToString();
            lblTryCount.Text = tryCount.ToString();
            CheckWin();
        }

        private void CheckWin()
        {
            if (curNumber == numberTask)
            {
                MessageBox.Show("Поздравляю. Вы победили. Начните сначала");
                btnReset.Text = "Start";
            }
            if (curNumber > numberTask)
            {
                MessageBox.Show("К сожалению вы проиграли. Начните сначала");
                btnReset.Text = "Start";
            }


        }
        private bool ChekReturn()
        {
            if (numberTask == 0) return true;
            if (curNumber == numberTask)
            {
                MessageBox.Show("Игра окончена. Вы победили. Начните сначала");
                return true;
            }
            if (curNumber > numberTask)
            {
                MessageBox.Show("Игра окончена. Вы проиграли. Начните сначала");
                return true;
            }
            if (numberTask == 0) return true;
            return false;
        }
    }
}
