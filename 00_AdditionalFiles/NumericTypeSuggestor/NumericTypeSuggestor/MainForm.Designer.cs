
namespace NumericTypeSuggestor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MinValue = new Label();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            MaxValueLabel = new Label();
            IntegralOnlyCheckedBox = new CheckBox();
            MustPreciseCheckedBox = new CheckBox();
            SuggestedType = new Label();
            NumericType = new Label();
            SuspendLayout();
            // 
            // MinValue
            // 
            MinValue.AutoSize = true;
            MinValue.Font = new Font("Segoe UI", 17F);
            MinValue.Location = new Point(79, 60);
            MinValue.Name = "MinValue";
            MinValue.Size = new Size(126, 31);
            MinValue.TabIndex = 0;
            MinValue.Text = "Min Value: ";
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Font = new Font("Segoe UI", 16F);
            MinValueTextBox.Location = new Point(211, 55);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(561, 36);
            MinValueTextBox.TabIndex = 1;
            MinValueTextBox.TextChanged += SuggestNumericType;
            MinValueTextBox.KeyPress += TexBoxTypingValidator;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Font = new Font("Segoe UI", 16F);
            MaxValueTextBox.Location = new Point(211, 115);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(561, 36);
            MaxValueTextBox.TabIndex = 3;
            MaxValueTextBox.TextChanged += SuggestNumericType;
            MaxValueTextBox.KeyPress += TexBoxTypingValidator;
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Segoe UI", 17F);
            MaxValueLabel.Location = new Point(75, 117);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(130, 31);
            MaxValueLabel.TabIndex = 2;
            MaxValueLabel.Text = "Max Value: ";
            // 
            // IntegralOnlyCheckedBox
            // 
            IntegralOnlyCheckedBox.AutoSize = true;
            IntegralOnlyCheckedBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckedBox.Checked = true;
            IntegralOnlyCheckedBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckedBox.Font = new Font("Segoe UI", 17F);
            IntegralOnlyCheckedBox.Location = new Point(57, 169);
            IntegralOnlyCheckedBox.Name = "IntegralOnlyCheckedBox";
            IntegralOnlyCheckedBox.Size = new Size(171, 35);
            IntegralOnlyCheckedBox.TabIndex = 4;
            IntegralOnlyCheckedBox.Text = "Integral only?";
            IntegralOnlyCheckedBox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckedBox.CheckedChanged += OnIntegralOnlyClick;
            // 
            // MustPreciseCheckedBox
            // 
            MustPreciseCheckedBox.AutoSize = true;
            MustPreciseCheckedBox.CheckAlign = ContentAlignment.MiddleRight;
            MustPreciseCheckedBox.Font = new Font("Segoe UI", 17F);
            MustPreciseCheckedBox.Location = new Point(22, 228);
            MustPreciseCheckedBox.Name = "MustPreciseCheckedBox";
            MustPreciseCheckedBox.Size = new Size(206, 35);
            MustPreciseCheckedBox.TabIndex = 5;
            MustPreciseCheckedBox.Text = "Must be precise?";
            MustPreciseCheckedBox.UseVisualStyleBackColor = true;
            MustPreciseCheckedBox.Visible = false;
            MustPreciseCheckedBox.CheckedChanged += OnMustBePreciseClick;
            // 
            // SuggestedType
            // 
            SuggestedType.AutoSize = true;
            SuggestedType.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            SuggestedType.Location = new Point(57, 318);
            SuggestedType.Name = "SuggestedType";
            SuggestedType.Size = new Size(169, 28);
            SuggestedType.TabIndex = 6;
            SuggestedType.Text = "Suggested type: ";
            // 
            // NumericType
            // 
            NumericType.AutoSize = true;
            NumericType.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            NumericType.Location = new Point(211, 318);
            NumericType.Name = "NumericType";
            NumericType.Size = new Size(169, 28);
            NumericType.TabIndex = 7;
            NumericType.Text = "not enough data";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(229, 241, 251);
            ClientSize = new Size(800, 450);
            Controls.Add(NumericType);
            Controls.Add(SuggestedType);
            Controls.Add(MustPreciseCheckedBox);
            Controls.Add(IntegralOnlyCheckedBox);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueTextBox);
            Controls.Add(MinValue);
            Name = "MainForm";
            Text = "Numeric Type Suggestor";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label MinValue;
        private TextBox textBox1;
        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
        private Label MaxValueLabel;
        private CheckBox IntegralOnlyCheckedBox;
        private CheckBox MustPreciseCheckedBox;
        private Label SuggestedType;
        private Label NumericType;
    }
}
