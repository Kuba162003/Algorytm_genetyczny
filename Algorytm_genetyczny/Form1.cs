namespace Algorytm_genetyczny
{
    public partial class Form1 : Form
    {
        private int[]? currentInstance;
        private int[]? currentSolution;
        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratorBTN_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_k.Text, out int k) || k <= 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'd³ugoœæ'.");
                return;
            }

            if (!int.TryParse(textBox_maxLength.Text, out int maxLength) || maxLength <= 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'maksymalna d³ugoœæ'.");
                return;
            }

            if (!int.TryParse(textBox_minDistance.Text, out int minDistance) || minDistance <= 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'minimalna odleg³oœæ'.");
                return;
            }

            if (!int.TryParse(textBox_errors.Text, out int errors) || errors < 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'liczba b³êdów'.");
                return;
            }

            if (comboBox_dlugosc.SelectedItem is string wybor)
            {
                if (wybor == "rozwi¹zania")
                {
                    k = (k * (k - 1)) / 2;
                }
            }

            Generator instancja;

            try
            {
                instancja = new Generator(k, maxLength, minDistance, errors);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Nie uda³o siê wygenerowaæ instancji:\n{ex.Message}", "B³¹d parametrów", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string v = string.Join(", ", instancja.Get_Instance());
            InstanceBox.Text = v;
            Solution_label.Text = string.Join(", ", instancja.Get_Solution());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_dlugosc.SelectedItem = "instancji";
        }
    }
}
