using System;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Algorytm_genetyczny
{
    public partial class Form1 : Form
    {
        Metaheuristics? metaheurystyka;
        volatile bool Active = true;
        volatile bool Stop = false;
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
            zakladki.SelectedIndex = 1;
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
            if (!int.TryParse(textBox_mut_chance.Text, out int mutation_chance) || mutation_chance < 0 || mutation_chance > 100)
            {
                MessageBox.Show("Proszê wpisaæ poprawn¹ liczbê ca³kowit¹ <= 100 dla 'Iloœæ mutacji'.");
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

            zakladki.SelectedIndex = 2;

            if (metaheurystyka != null)
            {
                Active = true;
                Stop = false;

                label_wynik.Text = "Inicjalizacja...";

                chart1.Series[0].Points.Clear();

                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;

                bw.DoWork += new DoWorkEventHandler(
                    delegate (object o, DoWorkEventArgs args)
                    {
                        BackgroundWorker worker = o as BackgroundWorker;

                        Func<bool> funkcjaPauzy = () => !Active;
                        Func<bool> funkcjaStopu = () => Stop;
                        Action<int, int> funkcjaRaportowania = (uplynietyCzas, aktualnyWynik) =>
                        {
                            // Obliczamy procent postêpu (up³yniête sekundy / ca³kowity czas * 100)
                            int procent = (int)(((double)uplynietyCzas / time) * 100);

                            // Zabezpieczenie, ¿eby pasek nie wyszed³ poza 100% (np. przez ma³e opóŸnienia)
                            if (procent > 100) procent = 100;

                            // Wysy³amy procent jako g³ówny parametr, a wynik jako dodatek (UserState)
                            worker.ReportProgress(procent, aktualnyWynik);
                        };

                        Individual ostateczne_rozwiazanie = metaheurystyka.Evolve(
                            population_size, c_random, i_random, random_mutation,
                            mutation_chance, tournament_size, time,
                            funkcjaPauzy, funkcjaStopu, funkcjaRaportowania
                        );

                        args.Result = ostateczne_rozwiazanie;
                    }
                );

                bw.ProgressChanged += new ProgressChangedEventHandler(
                delegate (object o, ProgressChangedEventArgs args)
                {
                    // 1. Odbieramy nasz wynik
                    int aktualny_wynik = (int)args.UserState;

                    // 2. Odbieramy obliczony procent czasu!
                    int procentPostepu = args.ProgressPercentage;

                    // Aktualizujemy label z wynikiem
                    label_wynik.Text = $"{aktualny_wynik} / {metaheurystyka.GetInstanceLength()}";

                    progressBar1.Value = procentPostepu;

                    chart1.Series[0].Points.AddY(aktualny_wynik);
                }
            );

                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                    delegate (object o, RunWorkerCompletedEventArgs args)
                    {
                        Individual wynik = (Individual)args.Result;

                        label1.Text = string.Join(", ", wynik.Chromosome);
                        label_wynik.Text = $"{wynik.Value} / {metaheurystyka.GetInstanceLength()}";
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
                // Opcjonalnie: zmiana tekstu na przycisku na "Wznów"
            }
            else
            {
                Active = true;
                // Opcjonalnie: zmiana tekstu na przycisku z powrotem na "Pauza"
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }
    }
}
