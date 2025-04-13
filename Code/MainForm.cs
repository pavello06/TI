using OpenKey.BackEnd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenKey
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructionForm instructionForm = new InstructionForm();
            instructionForm.ShowDialog();
        }

        private void pqbTextBox_TextChanged(object sender, EventArgs e)
        {
            ciphertextOpenToolStripMenuItem.Enabled = AllowOpenCiphertext();

            bool allowEncryption = AllowEncryption();
            encryptionButton.Enabled = allowEncryption;
            encryptionButton.BackColor = allowEncryption ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
        }
        private bool AllowOpenCiphertext()
        {
            return pTextBox.Text.Trim().Length > 0 && qTextBox.Text.Trim().Length > 0 && bTextBox.Text.Trim().Length > 0;
        }
        private bool AllowEncryption()
        {
            return pTextBox.Text.Trim().Length > 0 && qTextBox.Text.Trim().Length > 0 && bTextBox.Text.Trim().Length > 0 && plaintextTextBox.Text.Length > 0;
        }

        private void plaintextOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plaintextOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(plaintextOpenFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    List<BigInteger> plaintextBytes = new List<BigInteger>();
                    StringBuilder plaintextString = new StringBuilder();
                    while (fs.Position < fs.Length)
                    {
                        int symbol = fs.ReadByte();
                        plaintextBytes.Add(symbol);
                        plaintextString.Append(symbol.ToString() + " ");
                    }
                    Encryption.plaintext = plaintextBytes.ToArray();
                    plaintextTextBox.Text = plaintextString.ToString();
                }

                Encryption.ciphertext = null;
                ciphertextTextBox.Text = "";
                plaintextSaveToolStripMenuItem.Enabled = false;
                ciphertextSaveToolStripMenuItem.Enabled = false;
            }
        }
        private void ciphertextOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorText = GetMistake();
            if (errorText != "")
            {
                MessageBox.Show(errorText, "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ciphertextOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                int size = 0;
                BigInteger n = BigInteger.Parse(pTextBox.Text) * BigInteger.Parse(qTextBox.Text);
                while (n > 0)
                {
                    n /= 255;
                    size++;
                }

                using (FileStream fs = new FileStream(ciphertextOpenFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length % size != 0)
                    {
                        MessageBox.Show("Увы длина файла не подходит для расшифровки", "Некорректное содержимое", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<BigInteger> plaintextBytes = new List<BigInteger>();
                    StringBuilder plaintextString = new StringBuilder();
                    while (fs.Position < fs.Length)
                    {
                        BigInteger plainNumber = 0;
                        BigInteger multiplier = 1;
                        for (int i = 0; i < size; i++)
                        {
                            plainNumber += fs.ReadByte() * multiplier;
                            multiplier *= 255;
                        }                       
                        plaintextBytes.Add(plainNumber);
                        plaintextString.Append(plainNumber.ToString() + " ");
                    }
                    Encryption.plaintext = plaintextBytes.ToArray();
                    plaintextTextBox.Text = plaintextString.ToString();
                }

                Encryption.ciphertext = null;
                ciphertextTextBox.Text = "";
                plaintextSaveToolStripMenuItem.Enabled = false;
                ciphertextSaveToolStripMenuItem.Enabled = false;
            }
        }
        private void plaintextSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plaintextSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < Encryption.ciphertext.Length; i++)
                {
                    if (Encryption.ciphertext[i] < 0 || Encryption.ciphertext[i] > 255)
                    {
                        MessageBox.Show("Увы байты принадлежат диапазону от 0 до 255", "Некорректное содержимое", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                using (FileStream fs = new FileStream(plaintextSaveFileDialog.FileName, FileMode.Truncate, FileAccess.Write))
                {  
                    for (int i = 0; i < Encryption.ciphertext.Length; i++)
                    {
                        fs.WriteByte((byte)Encryption.ciphertext[i]);
                    }
                }
            }
        }
        private void ciphertextSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ciphertextSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                int size = 0;
                BigInteger n = Encryption.p * Encryption.q;
                while (n > 0)
                {
                    n /= 255;
                    size++;
                }

                using (FileStream fs = new FileStream(ciphertextSaveFileDialog.FileName, FileMode.Truncate, FileAccess.Write))
                {
                    for (int i = 0; i < Encryption.ciphertext.Length; i++)
                    {
                        BigInteger cipherNumber = Encryption.ciphertext[i];
                        for (int j = 0; j < size; j++)
                        {                          
                            fs.WriteByte((byte)(cipherNumber % 255));
                            cipherNumber /= 255;
                        }
                    }
                }
            }
        }

        private void encryptionButton_Click(object sender, EventArgs e)
        {
            string errorText = GetMistake();
            if (errorText != "")
            {
                MessageBox.Show(errorText, "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Encryption.p = BigInteger.Parse(pTextBox.Text);
            Encryption.q = BigInteger.Parse(qTextBox.Text);
            Encryption.b = BigInteger.Parse(bTextBox.Text);

            if (encryptRadioButton.Checked)
            {
                Encryption.Encrypt();
                plaintextSaveToolStripMenuItem.Enabled = false;
                ciphertextSaveToolStripMenuItem.Enabled = true;
            } 
            else
            {
                Encryption.Decrypt();
                plaintextSaveToolStripMenuItem.Enabled = true;
                ciphertextSaveToolStripMenuItem.Enabled = false;
            }

            ciphertextTextBox.Text = BackEnd.Convert.BigIntegersToString(Encryption.ciphertext);           
        }

        private string GetMistake()
        {
            string errorText = "";

            if (!BigInteger.TryParse(pTextBox.Text, out BigInteger p) || !BigInteger.TryParse(qTextBox.Text, out BigInteger q) || !BigInteger.TryParse(bTextBox.Text, out BigInteger b) || p < 1 || q < 1 || b < 1)
            {
                errorText += "Числа не натуральные!";
                return errorText;
            }

            if (!Algorithm.IsPrime(p))
            {
                errorText += "Число p составное!" + Environment.NewLine;
            }
            if (p % 4 != 3)
            {
                errorText += "Число p при делении на 4 дает остаток не 3!" + Environment.NewLine;
            }
            if (!Algorithm.IsPrime(q))
            {
                errorText += "Число q составное!" + Environment.NewLine;
            }
            if (q % 4 != 3)
            {
                errorText += "Число q при делении на 4 дает остаток не 3!" + Environment.NewLine;
            }
            if (b >= p * q)
            {
                errorText += "Число b должно быть меньше p * q!" + Environment.NewLine;
            }

            return errorText;
        }
    }
}