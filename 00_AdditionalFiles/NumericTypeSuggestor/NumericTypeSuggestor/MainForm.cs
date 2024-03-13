
using System.Globalization;
using System.Numerics;

namespace NumericTypeSuggestor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TexBoxTypingValidator(object sender, KeyPressEventArgs e)
        {
            if (!isValid(e.KeyChar, (TextBox)sender))
            {
                e.Handled = true;
            }
        }

        private bool isValid(char keyChar, TextBox textBox)
        {
            return char.IsControl(keyChar)
                || (char.IsDigit(keyChar))
                || keyChar == '-' && textBox.SelectionStart == 0;
        }

        private void OnIntegralOnlyClick(object sender, EventArgs e)
        {
            if (IntegralOnlyCheckedBox.Checked)
            {
                MustPreciseCheckedBox.Visible = false;
            }
            else
            {
                MustPreciseCheckedBox.Visible = true;
            }

            this.SuggestNumericType(this, null);
        }

        private void OnMustBePreciseClick(object sender, EventArgs e)
        {
            this.SuggestNumericType(this, null);
        }

        private void SuggestNumericType(object sender, EventArgs e)
        {
            BigInteger minValue;
            BigInteger maxValue;
            var isMinValueValid = BigInteger.TryParse(MinValueTextBox.Text, out minValue);
            var isMaxValueValid = BigInteger.TryParse(MaxValueTextBox.Text, out maxValue);

            if (!isMinValueValid || !isMaxValueValid)
            {
                return;
            }

            if (maxValue < minValue)
            {
                MaxValueTextBox.BackColor = Color.Red;
                return;
            }

            MaxValueTextBox.BackColor = Color.White;

            NumericType.Text = SuggestNumericType(minValue, maxValue);
        }

        private string SuggestNumericType(BigInteger minValue, BigInteger maxValue)
        {
            if (MustPreciseCheckedBox.Checked)
            {

                if (minValue.CompareTo(new BigInteger(decimal.MinValue)) >= 0
                     && maxValue.CompareTo(new BigInteger(decimal.MaxValue)) < 0)
                {
                    return "decimal";
                }
                else
                {
                    return "Impossible representation";
                }
            }

            if (!IntegralOnlyCheckedBox.Checked)
            {
                if (minValue.CompareTo(new BigInteger(float.MinValue)) >= 0
                     && maxValue.CompareTo(new BigInteger(float.MaxValue)) < 0)
                {
                    return "float";
                }

                if (minValue.CompareTo(new BigInteger(double.MinValue)) >= 0
                     && maxValue.CompareTo(new BigInteger(double.MaxValue)) < 0)
                {
                    return "double";
                }
            }

            if (minValue >= uint.MinValue && maxValue <= uint.MaxValue)
            {
                return "uint";
            }

            if (minValue >= int.MinValue && maxValue <= int.MaxValue)
            {
                return "int";
            }

            if (minValue >= long.MinValue && maxValue <= long.MaxValue)
            {
                return "long";
            }

            if (minValue >= long.MaxValue && IntegralOnlyCheckedBox.Checked)
            {
                return "BigInteger";
            }

            return "Impossible representation";
        }
    }
}
