using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class MainForm : Form
    {
        private const int NumberOfTests = 10000;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);

            var random = new Random();
            int[] firstRandomVariables = new int[NumberOfTests];
            int[] secondRandomVariables = new int[NumberOfTests];

            if (string.IsNullOrEmpty(tbFirstProbability.Text) || string.IsNullOrEmpty(tbSecondProbability.Text))
            {
                MessageBox.Show("Please enter valid probabilities!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double firstNumber, secondNumber;

            if (!double.TryParse(tbFirstProbability.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out firstNumber) ||
                !double.TryParse(tbSecondProbability.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out secondNumber))
            {
                MessageBox.Show("Error converting probabilities to numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsNumberCorrect(firstNumber, secondNumber))
            {
                MessageBox.Show("The entered values do not match the conditions!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                for (int i = 0; i < NumberOfTests; i++)
                {
                    firstRandomVariables[i] = random.Next(pictureBox.Width) - 100;
                    secondRandomVariables[i] = random.Next(pictureBox.Width) + 100;
                }

                double firstMathExpectation = CalculateMathExpectation(firstRandomVariables);
                double secondMathExpectation = CalculateMathExpectation(secondRandomVariables);

                double firstStandardDeviation =
                    CalculateStandardDeviation(firstRandomVariables, firstMathExpectation);
                double secondStandardDeviation =
                    CalculateStandardDeviation(secondRandomVariables, secondMathExpectation);

                double[] probabilityDensityForFirstRandomVariables = new double[NumberOfTests];
                double[] probabilityDensityForSecondRandomVariables = new double[NumberOfTests];

                for (int i = 0; i < NumberOfTests; i++)
                {
                    probabilityDensityForFirstRandomVariables[i] =
                        CalculateProbabilityDensity(i, firstMathExpectation, firstStandardDeviation);
                    probabilityDensityForSecondRandomVariables[i] =
                        CalculateProbabilityDensity(i, secondMathExpectation, secondStandardDeviation);
                }

                for (int i = 0; i < NumberOfTests; i++)
                {
                    var graphicsSecond = pictureBox.CreateGraphics();
                    graphicsSecond.FillRectangle(Brushes.LawnGreen, i,
                        pictureBox.Height -
                        (int)(probabilityDensityForFirstRandomVariables[i] * firstNumber * 150000), 3, 3);
                    graphicsSecond.FillRectangle(Brushes.Gold, i,
                        pictureBox.Height -
                        (int)(probabilityDensityForSecondRandomVariables[i] * secondNumber * 150000), 3, 3);
                }

                tbFalseAlarmProbability.Text = Convert.ToString(
                    CalculateProbabilitiesOfFalseAlarms(firstNumber, secondNumber, firstMathExpectation,
                        secondMathExpectation, firstStandardDeviation, secondStandardDeviation),
                    CultureInfo.InvariantCulture);
                tbProbabilityOfMissingErrorDetection.Text = Convert.ToString(
                    CalculateProbabilitiesOfMissingErrors(firstNumber, secondNumber, firstMathExpectation,
                        secondMathExpectation, firstStandardDeviation, secondStandardDeviation),
                    CultureInfo.InvariantCulture);

                double totalClassificationErrorProbability;
                if (double.TryParse(tbFalseAlarmProbability.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double falseAlarmProbability) &&
                    double.TryParse(tbProbabilityOfMissingErrorDetection.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double probabilityOfMissingErrorDetection))
                {
                    totalClassificationErrorProbability = falseAlarmProbability + probabilityOfMissingErrorDetection;
                    tbProbabilityOfTotalClassificationError.Text = totalClassificationErrorProbability.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    MessageBox.Show("Error converting probabilities to numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter the correct number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public double CalculateProbabilitiesOfFalseAlarms(double firstProbability, double secondProbability,
            double firstMathExpectation,
            double secondMathExpectation, double firstStandardDeviation, double secondStandardDeviation)
        {
            const double eps = 0.001;

            double x = -100;
            double p1 = 1, p2 = 0;
            double probabilitiesOfFalseAlarms = 0;

            if (secondProbability != 0)
                while (p2 < p1)
                {
                    p1 = firstProbability *
                         CalculateProbabilityDensity(x, firstMathExpectation, firstStandardDeviation);
                    p2 = secondProbability *
                         CalculateProbabilityDensity(x, secondMathExpectation, secondStandardDeviation);
                    probabilitiesOfFalseAlarms += p2 * eps;
                    x += eps;
                }

            if (firstProbability == 0)
                probabilitiesOfFalseAlarms = 1;
            else if (secondProbability == 0)
                probabilitiesOfFalseAlarms = 0;
            else
                probabilitiesOfFalseAlarms /= firstProbability;

            return probabilitiesOfFalseAlarms;
        }

        public double CalculateProbabilitiesOfMissingErrors(double firstProbability, double secondProbability,
            double firstMathExpectation,
            double secondMathExpectation, double firstStandardDeviation, double secondStandardDeviation)
        {
            const double eps = 0.001;

            double x = -100;
            double p1 = 1, p2 = 0;
            double probabilitiesOfMissingErrors = 0;

            if (secondProbability != 0)
                while (p2 < p1)
                {
                    p1 = firstProbability *
                         CalculateProbabilityDensity(x, firstMathExpectation, firstStandardDeviation);
                    p2 = secondProbability *
                         CalculateProbabilityDensity(x, secondMathExpectation, secondStandardDeviation);
                    x += eps;
                }

            double tmp = x;

            while (x < pictureBox.Width + 100)
            {
                p1 = CalculateProbabilityDensity(x, firstMathExpectation, firstStandardDeviation);
                CalculateProbabilityDensity(x, secondMathExpectation, secondStandardDeviation);
                probabilitiesOfMissingErrors += p1 * firstProbability * eps;
                x += eps;
            }

            if (firstProbability != 0 && secondProbability != 0)
            {
                var graph = pictureBox.CreateGraphics();
                graph.DrawLine(new Pen(Brushes.Black), new Point((int)tmp, 0),
                    new Point((int)tmp, pictureBox.Height));
            }

            if (firstProbability == 0)
                probabilitiesOfMissingErrors = 0;
            else if (secondProbability == 0)
                probabilitiesOfMissingErrors = 0;
            else
                probabilitiesOfMissingErrors /= firstProbability;

            return probabilitiesOfMissingErrors;
        }

        public double CalculateProbabilityDensity(double number, double mathExpectation, double standardDeviation)
        {
            double numerator = Math.Exp(-0.5 * Math.Pow((number - mathExpectation) / standardDeviation, 2));
            double denominator = standardDeviation * Math.Sqrt(2 * Math.PI);
            return numerator / denominator;
        }

        public double CalculateMathExpectation(int[] randomVariables)
        {
            int sumOfRandomVariables = 0;
            for (int i = 0; i < NumberOfTests; i++) sumOfRandomVariables += randomVariables[i];

            return (double)sumOfRandomVariables / NumberOfTests;
        }

        public double CalculateStandardDeviation(int[] randomVariables, double mathExpectation)
        {
            double sum = 0;
            for (int i = 0; i < NumberOfTests; i++) sum += Math.Pow(randomVariables[i] - mathExpectation, 2);

            return Math.Sqrt(sum / NumberOfTests);
        }

        public bool IsNumberCorrect(double firstNumber, double secondNumber)
        {
            return firstNumber >= 0 && firstNumber <= 1 && secondNumber >= 0 && secondNumber <= 1 &&
                   Math.Abs(firstNumber + secondNumber - 1) <= 0;
        }

        private void tbProbabilityOfTotalClassificationError_TextChanged(object sender, EventArgs e)
        {
            // Ничего не делаем в этом обработчике, так как это поле только для вывода результатов
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Сбрасываем значения текстовых полей
            tbFirstProbability.Text = "";
            tbSecondProbability.Text = "";
            tbFalseAlarmProbability.Text = "";
            tbProbabilityOfMissingErrorDetection.Text = "";
            tbProbabilityOfTotalClassificationError.Text = "";
        }

        private void tbProbabilityOfMissingErrorDetection_TextChanged(object sender, EventArgs e)
        {

        }
    }
}