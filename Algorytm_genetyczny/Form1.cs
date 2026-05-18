using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Algorytm_genetyczny
{
    public partial class Form1 : Form
    {
        Metaheuristics? metaheurystyka;
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
            if (k > 50000)
            {
                MessageBox.Show("Instancja jest zbyt du¿a. Instancja nie mo¿e byæ d³u¿sza ni¿ 50000");
                return;
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

        private void Przekazanie_Click(object sender, EventArgs e)
        {
            string input = InstanceBox.Text;
            // sprawdzenie czy nie jest pusty
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("B³¹d: Pole tekstowe z instancj¹ nie mo¿e byæ puste",
                                "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] string_input = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] instance = new int[string_input.Length];

            for (int i = 0; i < string_input.Length; i++)
            {
                // 2. Trim() usuwa spacje. TryParse sprawdza, czy to poprawny int.
                bool correct = int.TryParse(string_input[i].Trim(), out int element);

                if (correct)
                {
                    instance[i] = element;
                }
                else
                {
                    MessageBox.Show($"B³¹d! Wartoœæ '{string_input[i].Trim()}' nie jest poprawn¹ liczb¹ ca³kowit¹.",
                                    "B³¹d formatu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            metaheurystyka = new Metaheuristics(instance);
            tabControl1.SelectedIndex = 1;
        }

        private void Uruchomienie_metaheurystyki_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_pop_size.Text, out int population_size) || population_size <= 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Wielkoœæ populacji'.");
                return;
            }
            if (!int.TryParse(textBox_c_random.Text, out int c_random) || c_random < 0 || c_random > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ mniejsz¹ ni¿ 100 dla 'Osobniki ca³kowicie losowe'.");
                return;
            }
            if (!int.TryParse(textBox_i_random.Text, out int i_random) || i_random < 0 || i_random > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ mniejsz¹ ni¿ 100 dla 'Osobniki losowane z instancji'.");
                return;
            }
            if (c_random + i_random > 100)
            {
                MessageBox.Show("Osobników ca³kowicie losowych i losowanych z instancji nie mo¿e byæ wiêcej ni¿ 100%.");
                return;
            }
            if (!int.TryParse(textBox_mut_chance.Text, out int mutation_chance) || mutation_chance < 0 || mutation_chance > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ mniejsz¹ ni¿ 100 dla 'Iloœæ mutacji'.");
                return;
            }
            if (!int.TryParse(textBox_random_mut.Text, out int random_mutation) || random_mutation < 0 || random_mutation > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ mniejsz¹ ni¿ 100 dla 'Szansa na mutacjê ca³kowicie losow¹'.");
                return;
            }
            if (!int.TryParse(textBox_tour_size.Text, out int tournament_size) || tournament_size < 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Wielkoœæ turnieju'.");
                return;
            }
            if (!int.TryParse(textBox_time.Text, out int time) || time < 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Czas dzia³ania'.");
                return;
            }


            if (metaheurystyka != null)
            {
                Individual rozwiazanie = metaheurystyka.Evolve(population_size, c_random, i_random, random_mutation, mutation_chance, tournament_size, time);
                label1.Text = string.Join(", ", rozwiazanie.Chromosome);
                label2.Text = $"{rozwiazanie.Value} / {metaheurystyka.GetInstanceLength()}";
            }
            else
            {
                MessageBox.Show("B³¹d: Nie przekazano instancji do metaheurystyki",
                                "Brak instancji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
