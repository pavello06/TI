namespace OpenKey
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pLabel = new System.Windows.Forms.Label();
            this.pTextBox = new System.Windows.Forms.TextBox();
            this.encryptionButton = new System.Windows.Forms.Button();
            this.qLabel = new System.Windows.Forms.Label();
            this.qTextBox = new System.Windows.Forms.TextBox();
            this.bLabel = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plaintextOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciphertextOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plaintextSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciphertextSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plaintextLabel = new System.Windows.Forms.Label();
            this.plaintextTextBox = new System.Windows.Forms.TextBox();
            this.ciphertextTextBox = new System.Windows.Forms.TextBox();
            this.ciphertextLabel = new System.Windows.Forms.Label();
            this.plaintextOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.plaintextSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ciphertextOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ciphertextSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.encryptRadioButton = new System.Windows.Forms.RadioButton();
            this.decryptRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pLabel.Location = new System.Drawing.Point(12, 152);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(248, 29);
            this.pLabel.TabIndex = 0;
            this.pLabel.Text = "Введите значение p:";
            // 
            // pTextBox
            // 
            this.pTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pTextBox.Location = new System.Drawing.Point(296, 151);
            this.pTextBox.Name = "pTextBox";
            this.pTextBox.Size = new System.Drawing.Size(698, 34);
            this.pTextBox.TabIndex = 1;
            this.pTextBox.Text = "3511";
            this.pTextBox.TextChanged += new System.EventHandler(this.pqbTextBox_TextChanged);
            // 
            // encryptionButton
            // 
            this.encryptionButton.BackColor = System.Drawing.Color.LightGray;
            this.encryptionButton.Enabled = false;
            this.encryptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encryptionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.encryptionButton.Location = new System.Drawing.Point(296, 62);
            this.encryptionButton.Name = "encryptionButton";
            this.encryptionButton.Size = new System.Drawing.Size(698, 69);
            this.encryptionButton.TabIndex = 2;
            this.encryptionButton.Text = "Шифровать";
            this.encryptionButton.UseVisualStyleBackColor = false;
            this.encryptionButton.Click += new System.EventHandler(this.encryptionButton_Click);
            // 
            // qLabel
            // 
            this.qLabel.AutoSize = true;
            this.qLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.qLabel.Location = new System.Drawing.Point(12, 200);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(248, 29);
            this.qLabel.TabIndex = 3;
            this.qLabel.Text = "Введите значение q:";
            // 
            // qTextBox
            // 
            this.qTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qTextBox.Location = new System.Drawing.Point(296, 199);
            this.qTextBox.Name = "qTextBox";
            this.qTextBox.Size = new System.Drawing.Size(698, 34);
            this.qTextBox.TabIndex = 4;
            this.qTextBox.Text = "3527";
            this.qTextBox.TextChanged += new System.EventHandler(this.pqbTextBox_TextChanged);
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bLabel.Location = new System.Drawing.Point(12, 249);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(248, 29);
            this.bLabel.TabIndex = 5;
            this.bLabel.Text = "Введите значение b:";
            // 
            // bTextBox
            // 
            this.bTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTextBox.Location = new System.Drawing.Point(296, 248);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(698, 34);
            this.bTextBox.TabIndex = 6;
            this.bTextBox.Text = "11000000";
            this.bTextBox.TextChanged += new System.EventHandler(this.pqbTextBox_TextChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.instructionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1006, 36);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plaintextOpenToolStripMenuItem,
            this.ciphertextOpenToolStripMenuItem,
            this.plaintextSaveToolStripMenuItem,
            this.ciphertextSaveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(74, 32);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // plaintextOpenToolStripMenuItem
            // 
            this.plaintextOpenToolStripMenuItem.Name = "plaintextOpenToolStripMenuItem";
            this.plaintextOpenToolStripMenuItem.Size = new System.Drawing.Size(406, 32);
            this.plaintextOpenToolStripMenuItem.Text = "Открыть исходный текст";
            this.plaintextOpenToolStripMenuItem.Click += new System.EventHandler(this.plaintextOpenToolStripMenuItem_Click);
            // 
            // ciphertextOpenToolStripMenuItem
            // 
            this.ciphertextOpenToolStripMenuItem.Name = "ciphertextOpenToolStripMenuItem";
            this.ciphertextOpenToolStripMenuItem.Size = new System.Drawing.Size(406, 32);
            this.ciphertextOpenToolStripMenuItem.Text = "Открыть зашифрованный текст";
            this.ciphertextOpenToolStripMenuItem.Click += new System.EventHandler(this.ciphertextOpenToolStripMenuItem_Click);
            // 
            // plaintextSaveToolStripMenuItem
            // 
            this.plaintextSaveToolStripMenuItem.Enabled = false;
            this.plaintextSaveToolStripMenuItem.Name = "plaintextSaveToolStripMenuItem";
            this.plaintextSaveToolStripMenuItem.Size = new System.Drawing.Size(406, 32);
            this.plaintextSaveToolStripMenuItem.Text = "Сохранить исходный текст";
            this.plaintextSaveToolStripMenuItem.Click += new System.EventHandler(this.plaintextSaveToolStripMenuItem_Click);
            // 
            // ciphertextSaveToolStripMenuItem
            // 
            this.ciphertextSaveToolStripMenuItem.Enabled = false;
            this.ciphertextSaveToolStripMenuItem.Name = "ciphertextSaveToolStripMenuItem";
            this.ciphertextSaveToolStripMenuItem.Size = new System.Drawing.Size(406, 32);
            this.ciphertextSaveToolStripMenuItem.Text = "Сохранить зашифрованный текст";
            this.ciphertextSaveToolStripMenuItem.Click += new System.EventHandler(this.ciphertextSaveToolStripMenuItem_Click);
            // 
            // instructionToolStripMenuItem
            // 
            this.instructionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.instructionToolStripMenuItem.Name = "instructionToolStripMenuItem";
            this.instructionToolStripMenuItem.Size = new System.Drawing.Size(136, 32);
            this.instructionToolStripMenuItem.Text = "Инструкция";
            this.instructionToolStripMenuItem.Click += new System.EventHandler(this.instructionToolStripMenuItem_Click);
            // 
            // plaintextLabel
            // 
            this.plaintextLabel.AutoSize = true;
            this.plaintextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plaintextLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plaintextLabel.Location = new System.Drawing.Point(12, 302);
            this.plaintextLabel.Name = "plaintextLabel";
            this.plaintextLabel.Size = new System.Drawing.Size(199, 29);
            this.plaintextLabel.TabIndex = 9;
            this.plaintextLabel.Text = "Исходный текст:";
            // 
            // plaintextTextBox
            // 
            this.plaintextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plaintextTextBox.Location = new System.Drawing.Point(12, 334);
            this.plaintextTextBox.Multiline = true;
            this.plaintextTextBox.Name = "plaintextTextBox";
            this.plaintextTextBox.ReadOnly = true;
            this.plaintextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.plaintextTextBox.Size = new System.Drawing.Size(465, 303);
            this.plaintextTextBox.TabIndex = 10;
            this.plaintextTextBox.TextChanged += new System.EventHandler(this.pqbTextBox_TextChanged);
            // 
            // ciphertextTextBox
            // 
            this.ciphertextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ciphertextTextBox.Location = new System.Drawing.Point(529, 334);
            this.ciphertextTextBox.Multiline = true;
            this.ciphertextTextBox.Name = "ciphertextTextBox";
            this.ciphertextTextBox.ReadOnly = true;
            this.ciphertextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ciphertextTextBox.Size = new System.Drawing.Size(465, 303);
            this.ciphertextTextBox.TabIndex = 11;
            // 
            // ciphertextLabel
            // 
            this.ciphertextLabel.AutoSize = true;
            this.ciphertextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ciphertextLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ciphertextLabel.Location = new System.Drawing.Point(524, 302);
            this.ciphertextLabel.Name = "ciphertextLabel";
            this.ciphertextLabel.Size = new System.Drawing.Size(253, 29);
            this.ciphertextLabel.TabIndex = 12;
            this.ciphertextLabel.Text = "Шифрованный текст:";
            // 
            // plaintextOpenFileDialog
            // 
            this.plaintextOpenFileDialog.FileName = "plaintextOpenFileDialog";
            // 
            // ciphertextOpenFileDialog
            // 
            this.ciphertextOpenFileDialog.FileName = "ciphertextOpenFileDialog";
            // 
            // encryptRadioButton
            // 
            this.encryptRadioButton.AutoSize = true;
            this.encryptRadioButton.Checked = true;
            this.encryptRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encryptRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.encryptRadioButton.Location = new System.Drawing.Point(17, 62);
            this.encryptRadioButton.Name = "encryptRadioButton";
            this.encryptRadioButton.Size = new System.Drawing.Size(198, 33);
            this.encryptRadioButton.TabIndex = 15;
            this.encryptRadioButton.TabStop = true;
            this.encryptRadioButton.Text = "Зашифровать";
            this.encryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // decryptRadioButton
            // 
            this.decryptRadioButton.AutoSize = true;
            this.decryptRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decryptRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.decryptRadioButton.Location = new System.Drawing.Point(17, 98);
            this.decryptRadioButton.Name = "decryptRadioButton";
            this.decryptRadioButton.Size = new System.Drawing.Size(202, 33);
            this.decryptRadioButton.TabIndex = 16;
            this.decryptRadioButton.TabStop = true;
            this.decryptRadioButton.Text = "Дешифровать";
            this.decryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1006, 652);
            this.Controls.Add(this.decryptRadioButton);
            this.Controls.Add(this.encryptRadioButton);
            this.Controls.Add(this.ciphertextLabel);
            this.Controls.Add(this.ciphertextTextBox);
            this.Controls.Add(this.plaintextTextBox);
            this.Controls.Add(this.plaintextLabel);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.qTextBox);
            this.Controls.Add(this.qLabel);
            this.Controls.Add(this.encryptionButton);
            this.Controls.Add(this.pTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Криптосистема Рабина";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox pTextBox;
        private System.Windows.Forms.Button encryptionButton;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.TextBox qTextBox;
        private System.Windows.Forms.Label bLabel;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plaintextOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciphertextOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionToolStripMenuItem;
        private System.Windows.Forms.Label plaintextLabel;
        private System.Windows.Forms.TextBox plaintextTextBox;
        private System.Windows.Forms.TextBox ciphertextTextBox;
        private System.Windows.Forms.Label ciphertextLabel;
        private System.Windows.Forms.OpenFileDialog plaintextOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog plaintextSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog ciphertextOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog ciphertextSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem plaintextSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciphertextSaveToolStripMenuItem;
        private System.Windows.Forms.RadioButton encryptRadioButton;
        private System.Windows.Forms.RadioButton decryptRadioButton;
    }
}

