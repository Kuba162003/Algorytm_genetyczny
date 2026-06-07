using System;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace Algorytm_genetyczny
{
    public partial class Form1 : Form
    {
        Metaheuristics? metaheurystyka;
        volatile bool Active = true;
        volatile bool Stop = false;
        volatile bool IsRunning = false;
        Chart? chart1;

        private int[]? solution;
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
            solution = instancja.Get_Solution().ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_dlugosc.SelectedItem = "rozwi¹zania";

            chart1 = new Chart();

            chart1.Parent = zakladki.TabPages[2];

            chart1.Size = new Size(600, 300);
            chart1.Location = new Point(100, 0);

            // Dodajemy obszar rysowania (t³o z siatk¹)
            ChartArea obszar = new ChartArea("MainArea");
            obszar.AxisX.Title = "Liczba pokoleñ";
            obszar.AxisY.Title = "Wartoœæ funkcji celu";
            obszar.AxisX.TitleFont = new Font("Segoe UI", 10);
            obszar.AxisY.TitleFont = new Font("Segoe UI", 10);
            chart1.ChartAreas.Add(obszar);

            // Konfigurujemy liniê (Seriê)
            Series linia = new Series("Wynik");
            linia.ChartType = SeriesChartType.Line; // Wykres liniowy
            linia.Color = Color.MediumVioletRed;               // Kolor linii
            linia.BorderWidth = 4;                  // Gruboœæ linii

            // Podpinamy liniê pod wykres
            chart1.Series.Add(linia);
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

            try
            {
                metaheurystyka = new Metaheuristics(instance);
                zakladki.SelectedIndex = 1;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "B³¹d instancji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Uruchomienie_metaheurystyki_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_pop_size.Text, out int population_size) || population_size < 2)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Wielkoœæ populacji'.");
                return;
            }
            if (!int.TryParse(textBox_c_random.Text, out int c_random) || c_random < 0 || c_random > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ <= 100 dla 'Osobniki ca³kowicie losowe'.");
                return;
            }
            if (!int.TryParse(textBox_i_random.Text, out int i_random) || i_random < 0 || i_random > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ <= 100 dla 'Osobniki losowane z instancji'.");
                return;
            }
            if (c_random + i_random > 100)
            {
                MessageBox.Show("Osobników ca³kowicie losowych i losowanych z instancji nie mo¿e byæ wiêcej ni¿ 100%.");
                return;
            }
            if (!int.TryParse(textBox_mut_chance.Text, out int mutation_chance) || mutation_chance < 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Iloœæ mutacji'.");
                return;
            }
            if (!int.TryParse(textBox_random_mut.Text, out int random_mutation) || random_mutation < 0 || random_mutation > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ <= 100 dla 'Szansa na mutacjê ca³kowicie losow¹'.");
                return;
            }
            if (!int.TryParse(textBox_tour_size.Text, out int tournament_size) || tournament_size < 1 || tournament_size > population_size)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Wielkoœæ turnieju'.");
                return;
            }
            if (!int.TryParse(textBox_time.Text, out int time) || time < 0)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ dla 'Czas dzia³ania'.");
                return;
            }
            if (IsRunning)
            {
                MessageBox.Show("Obliczenia trwaj¹. Najpierw zatrzymaj poprzenie obliczenia.");
                return;
            }


            if (metaheurystyka != null)
            {
                textBox_Wynik.Clear();
                textBox_solution.Clear();
                label_solution.Text = "Zgodnoœæ z prawdziwym rozwi¹zaniem:";
                label_function.Text = "Wartoœæ funkcji celu:";
                label_sol.Text = "Rozwi¹zanie z generatora";
                progressBar1.Value = 0;

                Active = true;
                Stop = false;
                IsRunning = true;

                zakladki.SelectedIndex = 2;
                label_wynik.Text = "Inicjalizacja...";

                chart1!.Series[0].Points.Clear();

                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;

                bw.DoWork += new DoWorkEventHandler(
                    delegate (object? o, DoWorkEventArgs args)
                    {
                        BackgroundWorker worker = (BackgroundWorker)o!; //zamist BackgroundWorker worker = o as BackgroundWorker;

                        Func<bool> funkcjaPauzy = () => !Active;
                        Func<bool> funkcjaStopu = () => Stop;
                        Action<int, int> funkcjaRaportowania = (uplynietyCzas, aktualnyWynik) =>
                        {
                            int procent = (int)(((double)uplynietyCzas / time) * 100);

                            if (procent > 100) procent = 100;

                            worker!.ReportProgress(procent, aktualnyWynik);
                        };

                        Individual ostateczne_rozwiazanie = metaheurystyka.Evolve(
                            population_size, c_random, i_random, random_mutation,
                            mutation_chance, tournament_size, time,
                            funkcjaPauzy, funkcjaStopu, funkcjaRaportowania
                        );

                        args.Result = ostateczne_rozwiazanie;
                    }
                );

                int dlugosc_instancji = metaheurystyka.GetInstanceLength();
                bw.ProgressChanged += new ProgressChangedEventHandler(
                delegate (object? o, ProgressChangedEventArgs args)
                {
                    int aktualny_wynik = (int)args.UserState!;

                    int procentPostepu = args.ProgressPercentage;

                    label_wynik.Text = $"Aktualna wartoœæ funkcji celu: {aktualny_wynik} / {dlugosc_instancji}";

                    progressBar1.Value = procentPostepu;

                    chart1.Series[0].Points.AddY(aktualny_wynik);
                }
            );

                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                    delegate (object? o, RunWorkerCompletedEventArgs args)
                    {
                        Individual wynik = (Individual)args.Result!;

                        IsRunning = false;

                        label_wynik.Text = $"Koñcowa wartoœæ funkcji celu: {wynik.Value} / {dlugosc_instancji}";

                        zakladki.SelectedIndex = 3;
                        textBox_Wynik.Text = string.Join(", ", wynik.Chromosome);
                        label_function.Text = $"Wartoœæ funkcji celu: {wynik.Value} / {dlugosc_instancji} ({(double)wynik.Value / dlugosc_instancji:P2})";
                        if (solution != null)
                        {
                            // Wyznaczanie odbicia lustrzanego
                            int maxElement = solution.Max();
                            int[] mirror = solution.Select(x => maxElement - x).OrderBy(x => x).ToArray();

                            int normalCount = wynik.Chromosome.Intersect(solution).Count();
                            int mirrorCount = wynik.Chromosome.Intersect(mirror).Count();

                            int bestCount = Math.Max(normalCount, mirrorCount);

                            double procent = Math.Round((double)bestCount / solution.Length * 100, 2);
                            label_solution.Text = $"Zgodnoœæ z prawdziwym rozwi¹zaniem: {bestCount} / {solution.Length} ({procent}%)";

                            if (mirrorCount > normalCount)
                            {
                                label_sol.Text = "Rozwi¹zanie z generatora (odbicie lustrzane)";
                                textBox_solution.Text = $"{string.Join(", ", mirror)}";
                            }
                            else
                            {
                                textBox_solution.Text = $"{string.Join(", ", solution)}";
                            }
                        }
                        else
                        {
                            // Scenariusz rêcznego wpisania (nie znamy orygina³u)
                            label_solution.Text = "Zgodnoœæ z prawdziwym rozwi¹zaniem: Nieznana (instancja wprowadzona rêcznie)";
                            textBox_solution.Text = "Brak danych o oryginale";
                        }
                    }
                );

                bw.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("B³¹d: Nie przekazano instancji do metaheurystyki",
                                "Brak instancji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonPauza_Click(object sender, EventArgs e)
        {
            if (Active)
            {
                Active = false;
                buttonPauza.Text = "Wznów";
                buttonPauza.BackColor = Color.Green;
            }
            else
            {
                Active = true;
                buttonPauza.Text = "Pauza";
                buttonPauza.BackColor = Color.Orange;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void textBox_Wynik_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
