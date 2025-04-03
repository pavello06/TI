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
            bool allow = AllowEncryption();
            encryptionButton.Enabled = allow;
            encryptionButton.BackColor = allow ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
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
            if (ciphertextOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(ciphertextOpenFileDialog.FileName))
                {
                    string plaintextString = reader.ReadLine();
                    plaintextString = plaintextString.Substring(0, plaintextString.Length - 1);
                    try
                    {
                        Encryption.plaintext = Array.ConvertAll(plaintextString.Split(' '), BigInteger.Parse);
                    }
                    catch
                    {
                        MessageBox.Show("Увы что-то не так с массивом", "Некорректное содержимое", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    plaintextTextBox.Text = plaintextString;
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
                using (StreamWriter writer = new StreamWriter(ciphertextSaveFileDialog.FileName))
                {
                    writer.Write(BackEnd.Convert.BigIntegersToString(Encryption.ciphertext));
                }
            }
        }

        private async void encryptionButton_Click(object sender, EventArgs e)
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
                await Task.Run(() => Encryption.EncryptAsync());
                plaintextSaveToolStripMenuItem.Enabled = false;
                ciphertextSaveToolStripMenuItem.Enabled = true;
            } 
            else
            {
                await Task.Run(() => Encryption.DecryptAsync());
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
            if (p <= 3)
            {
                errorText += "Число p меньше или равно 3!" + Environment.NewLine;
            }
            if (p % 4 != 3)
            {
                errorText += "Число p при делении на 4 дает остаток не 3!" + Environment.NewLine;
            }
            if (!Algorithm.IsPrime(q))
            {
                errorText += "Число q составное!" + Environment.NewLine;
            }
            if (q <= 3511)
            {
                errorText += "Число q меньше или равно 3511!" + Environment.NewLine;
            }
            if (q % 4 != 3)
            {
                errorText += "Число q при делении на 4 дает остаток не 3!" + Environment.NewLine;
            }
            if (b < 1 || b > 10532)
            {
                errorText += "Число b не принадлежит диапазону от 1 до 10532" + Environment.NewLine;
            }

            return errorText;
        }
    }
}