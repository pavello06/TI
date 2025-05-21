using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace ElectronicDigitalSignature
{
    public partial class MainForm : Form
    {
        private String fileName;

        private String fileText;
        private byte[] fileBytes;

        private BigInteger q;
        private BigInteger p;
        private BigInteger h;
        private BigInteger x;
        private BigInteger k;
        private BigInteger g;
        private BigInteger y;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            fileName = openFileDialog.FileName;

            fileBytes = System.IO.File.ReadAllBytes(fileName);
            fileText = System.Text.Encoding.UTF8.GetString(fileBytes);

            fileTextBox.Text = fileText.Replace("\0", " ");
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            if (!IsCorrectInput())
            {
                return;
            }

            (BigInteger h, BigInteger r, BigInteger s) = Functions.GetSignature(fileBytes, q, p, x, k, g);

            if (r == 0)
            {
                MessageBox.Show("Выберите другое k, т. к. r = 0");
                return;
            }

            if (s == 0)
            {
                MessageBox.Show("Выберите другое k, т. к. s = 0");
                return;
            }

            resultTextBox.Text = "h = " + h.ToString() + Environment.NewLine + 
                                 "r = " + r.ToString() + Environment.NewLine +
                                 "s = " + s.ToString() + Environment.NewLine +
                                 "g = " + g.ToString() + Environment.NewLine +
                                 "y = " + y.ToString();

            fileText += ' ' + r.ToString() + ' ' + s.ToString();

            fileTextBox.Text = fileText.Replace("\0", " ");

            System.IO.File.WriteAllText(fileName, fileText);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (!IsCorrectInput())
            {
                return;
            }

            BigInteger h, r, s;

            string[] words = fileText.TrimEnd().Split(' ');

            if (!BigInteger.TryParse(words[words.Length - 2], out r) || !BigInteger.TryParse(words[words.Length - 1], out s))
            {
                MessageBox.Show("Файл не подписан");
                return;
            }

            int len = words[words.Length - 1].Length + words[words.Length - 2].Length + 2;
            string text = fileText.TrimEnd().Substring(0, fileText.Length - len);
            byte[] data = Encoding.UTF8.GetBytes(text);
            h = Functions.GetHash(data, q);

            BigInteger w = Functions.FastPow(s, q - 2, q);
            BigInteger u1 = (h * w) % q;
            BigInteger u2 = (r * w) % q;
            BigInteger v = Functions.FastPow(g, u1, p) * Functions.FastPow(y, u2, p) % p % q;

            string res = "h = " + h.ToString() + Environment.NewLine +
                         "r = " + r.ToString() + Environment.NewLine +
                         "s = " + s.ToString() + Environment.NewLine +
                         "g = " + g.ToString() + Environment.NewLine +
                         "y = " + y.ToString() + Environment.NewLine + Environment.NewLine +
                         "w = " + w.ToString() + Environment.NewLine +
                         "u1 = " + u1.ToString() + Environment.NewLine +
                         "u2 = " + u2.ToString() + Environment.NewLine +
                         "v = " + v.ToString() + Environment.NewLine;

            resultTextBox.Text = res;

            MessageBox.Show(v == r ? "Подпись подлинна" : "Подпись не подлинна");
        }

        private bool IsCorrectInput()
        {
            if (fileText == null)
            {
                MessageBox.Show("Сначала откройте файл.", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!BigInteger.TryParse(qTextBox.Text, out q) || !Functions.IsPrime(q))
            {
                MessageBox.Show("Число q должно быть простым.", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!BigInteger.TryParse(pTextBox.Text, out p) || !Functions.IsPrime(p))
            {
                MessageBox.Show("Число p должно быть простым.", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((p - 1) % q != 0)
            {
                MessageBox.Show("Число q должно являться делителем (p - 1).", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!BigInteger.TryParse(hTextBox.Text, out h) || h <= 1 || h >= p - 1)
            {
                MessageBox.Show("Число h должно быть в диапазоне (1; p - 1).", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            g = Functions.FastPow(h, (p - 1) / q, p);
            if (g <= 1)
            {
                MessageBox.Show("Число g = h^((p - 1) / q) mod p должно быть больше 1.", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!BigInteger.TryParse(xTextBox.Text, out x) || x <= 0 || x >= q)
            {
                MessageBox.Show("Число x должно быть в диапазоне (0; q).", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!BigInteger.TryParse(kTextBox.Text, out k) || k <= 0 || k >= q)
            {
                MessageBox.Show("Число k должно быть в диапазоне (0; q).", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            y = Functions.FastPow(g, x, p);

            return true;
        }
    }
}
