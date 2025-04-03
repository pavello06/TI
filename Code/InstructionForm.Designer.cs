namespace OpenKey
{
    partial class InstructionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pLabel = new System.Windows.Forms.Label();
            this.qLabel = new System.Windows.Forms.Label();
            this.bLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pLabel.Location = new System.Drawing.Point(12, 24);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(683, 29);
            this.pLabel.TabIndex = 0;
            this.pLabel.Text = "1. p — простое число, больше 3, при делении на 4 остаток 3.";
            // 
            // qLabel
            // 
            this.qLabel.AutoSize = true;
            this.qLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.qLabel.Location = new System.Drawing.Point(12, 67);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(722, 29);
            this.qLabel.TabIndex = 1;
            this.qLabel.Text = "2. q — простое число, больше 3511, при делении на 4 остаток 3.";
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bLabel.Location = new System.Drawing.Point(12, 110);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(729, 29);
            this.bLabel.TabIndex = 2;
            this.bLabel.Text = "3. b — натуральное число, меньше p * q, диапазон от 1 до 10532.";
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(813, 167);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.qLabel);
            this.Controls.Add(this.pLabel);
            this.Name = "InstructionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Инструкция";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.Label bLabel;
    }
}