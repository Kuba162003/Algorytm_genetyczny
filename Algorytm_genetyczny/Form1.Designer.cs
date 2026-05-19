namespace Algorytm_genetyczny
{
    partial class Form1
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
            GeneratorBTN = new Button();
            InstanceBox = new TextBox();
            errors_label = new Label();
            label_k = new Label();
            label_maxLenght = new Label();
            textBox_maxLength = new TextBox();
            textBox_k = new TextBox();
            textBox_errors = new TextBox();
            minDistance_label = new Label();
            textBox_minDistance = new TextBox();
            comboBox_dlugosc = new ComboBox();
            zakladki = new TabControl();
            generator_tab = new TabPage();
            Przekazanie = new Button();
            metaheurystyka_tab = new TabPage();
            textBox_time = new TextBox();
            label_time = new Label();
            textBox_tour_size = new TextBox();
            label_tour_size = new Label();
            textBox_random_mut = new TextBox();
            label_random_mut = new Label();
            textBox_mut_chance = new TextBox();
            label_mut_chance = new Label();
            textBox_i_random = new TextBox();
            textBox_c_random = new TextBox();
            label_i_random = new Label();
            label_c_random = new Label();
            textBox_pop_size = new TextBox();
            label_pop_size = new Label();
            Uruchomienie_metaheurystyki = new Button();
            obliczenia_tab = new TabPage();
            progressBar1 = new ProgressBar();
            buttonStop = new Button();
            buttonPauza = new Button();
            label_wynik = new Label();
            wyniki_tab = new TabPage();
            label1 = new Label();
            textBox_solution = new TextBox();
            label_sol = new Label();
            label_function = new Label();
            label_solution = new Label();
            textBox_Wynik = new TextBox();
            zakladki.SuspendLayout();
            generator_tab.SuspendLayout();
            metaheurystyka_tab.SuspendLayout();
            obliczenia_tab.SuspendLayout();
            wyniki_tab.SuspendLayout();
            SuspendLayout();
            // 
            // GeneratorBTN
            // 
            GeneratorBTN.Location = new Point(238, 139);
            GeneratorBTN.Name = "GeneratorBTN";
            GeneratorBTN.Size = new Size(94, 29);
            GeneratorBTN.TabIndex = 0;
            GeneratorBTN.Text = "Generuj";
            GeneratorBTN.UseVisualStyleBackColor = true;
            GeneratorBTN.Click += GeneratorBTN_Click;
            // 
            // InstanceBox
            // 
            InstanceBox.Location = new Point(6, 183);
            InstanceBox.MaxLength = 200000;
            InstanceBox.Multiline = true;
            InstanceBox.Name = "InstanceBox";
            InstanceBox.ScrollBars = ScrollBars.Vertical;
            InstanceBox.Size = new Size(780, 182);
            InstanceBox.TabIndex = 1;
            // 
            // errors_label
            // 
            errors_label.AutoSize = true;
            errors_label.Location = new Point(17, 109);
            errors_label.Name = "errors_label";
            errors_label.Size = new Size(112, 20);
            errors_label.TabIndex = 3;
            errors_label.Text = "Liczba błędów: ";
            // 
            // label_k
            // 
            label_k.AutoSize = true;
            label_k.Location = new Point(17, 20);
            label_k.Name = "label_k";
            label_k.Size = new Size(70, 20);
            label_k.TabIndex = 4;
            label_k.Text = "Długość: ";
            // 
            // label_maxLenght
            // 
            label_maxLenght.AutoSize = true;
            label_maxLenght.Location = new Point(17, 50);
            label_maxLenght.Name = "label_maxLenght";
            label_maxLenght.Size = new Size(154, 20);
            label_maxLenght.TabIndex = 5;
            label_maxLenght.Text = "Maksymalna długość: ";
            // 
            // textBox_maxLength
            // 
            textBox_maxLength.Location = new Point(207, 47);
            textBox_maxLength.Name = "textBox_maxLength";
            textBox_maxLength.Size = new Size(125, 27);
            textBox_maxLength.TabIndex = 6;
            textBox_maxLength.Text = "10000";
            // 
            // textBox_k
            // 
            textBox_k.Location = new Point(207, 17);
            textBox_k.Name = "textBox_k";
            textBox_k.Size = new Size(125, 27);
            textBox_k.TabIndex = 7;
            textBox_k.Text = "4950";
            // 
            // textBox_errors
            // 
            textBox_errors.Location = new Point(207, 106);
            textBox_errors.Name = "textBox_errors";
            textBox_errors.Size = new Size(125, 27);
            textBox_errors.TabIndex = 8;
            textBox_errors.Text = "5";
            // 
            // minDistance_label
            // 
            minDistance_label.AutoSize = true;
            minDistance_label.Location = new Point(17, 80);
            minDistance_label.Name = "minDistance_label";
            minDistance_label.Size = new Size(152, 20);
            minDistance_label.TabIndex = 10;
            minDistance_label.Text = "Minimalne odległości";
            // 
            // textBox_minDistance
            // 
            textBox_minDistance.Location = new Point(207, 77);
            textBox_minDistance.Name = "textBox_minDistance";
            textBox_minDistance.Size = new Size(125, 27);
            textBox_minDistance.TabIndex = 11;
            textBox_minDistance.Text = "10";
            // 
            // comboBox_dlugosc
            // 
            comboBox_dlugosc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_dlugosc.FormattingEnabled = true;
            comboBox_dlugosc.Items.AddRange(new object[] { "instancji", "rozwiązania" });
            comboBox_dlugosc.Location = new Point(81, 17);
            comboBox_dlugosc.Name = "comboBox_dlugosc";
            comboBox_dlugosc.Size = new Size(106, 28);
            comboBox_dlugosc.TabIndex = 12;
            // 
            // zakladki
            // 
            zakladki.Controls.Add(generator_tab);
            zakladki.Controls.Add(metaheurystyka_tab);
            zakladki.Controls.Add(obliczenia_tab);
            zakladki.Controls.Add(wyniki_tab);
            zakladki.Location = new Point(2, 1);
            zakladki.Name = "zakladki";
            zakladki.SelectedIndex = 0;
            zakladki.Size = new Size(800, 449);
            zakladki.TabIndex = 13;
            // 
            // generator_tab
            // 
            generator_tab.Controls.Add(Przekazanie);
            generator_tab.Controls.Add(textBox_maxLength);
            generator_tab.Controls.Add(InstanceBox);
            generator_tab.Controls.Add(comboBox_dlugosc);
            generator_tab.Controls.Add(GeneratorBTN);
            generator_tab.Controls.Add(textBox_minDistance);
            generator_tab.Controls.Add(errors_label);
            generator_tab.Controls.Add(minDistance_label);
            generator_tab.Controls.Add(label_k);
            generator_tab.Controls.Add(label_maxLenght);
            generator_tab.Controls.Add(textBox_errors);
            generator_tab.Controls.Add(textBox_k);
            generator_tab.Location = new Point(4, 29);
            generator_tab.Name = "generator_tab";
            generator_tab.Padding = new Padding(3);
            generator_tab.Size = new Size(792, 416);
            generator_tab.TabIndex = 0;
            generator_tab.Text = "Generator";
            generator_tab.UseVisualStyleBackColor = true;
            // 
            // Przekazanie
            // 
            Przekazanie.Location = new Point(257, 373);
            Przekazanie.Name = "Przekazanie";
            Przekazanie.Size = new Size(286, 29);
            Przekazanie.TabIndex = 13;
            Przekazanie.Text = "Przekaż instancję do metaheurystyki";
            Przekazanie.UseVisualStyleBackColor = true;
            Przekazanie.Click += Przekazanie_Click;
            // 
            // metaheurystyka_tab
            // 
            metaheurystyka_tab.Controls.Add(textBox_time);
            metaheurystyka_tab.Controls.Add(label_time);
            metaheurystyka_tab.Controls.Add(textBox_tour_size);
            metaheurystyka_tab.Controls.Add(label_tour_size);
            metaheurystyka_tab.Controls.Add(textBox_random_mut);
            metaheurystyka_tab.Controls.Add(label_random_mut);
            metaheurystyka_tab.Controls.Add(textBox_mut_chance);
            metaheurystyka_tab.Controls.Add(label_mut_chance);
            metaheurystyka_tab.Controls.Add(textBox_i_random);
            metaheurystyka_tab.Controls.Add(textBox_c_random);
            metaheurystyka_tab.Controls.Add(label_i_random);
            metaheurystyka_tab.Controls.Add(label_c_random);
            metaheurystyka_tab.Controls.Add(textBox_pop_size);
            metaheurystyka_tab.Controls.Add(label_pop_size);
            metaheurystyka_tab.Controls.Add(Uruchomienie_metaheurystyki);
            metaheurystyka_tab.Location = new Point(4, 29);
            metaheurystyka_tab.Name = "metaheurystyka_tab";
            metaheurystyka_tab.Padding = new Padding(3);
            metaheurystyka_tab.Size = new Size(792, 416);
            metaheurystyka_tab.TabIndex = 1;
            metaheurystyka_tab.Text = "Metaheurystyka";
            metaheurystyka_tab.UseVisualStyleBackColor = true;
            // 
            // textBox_time
            // 
            textBox_time.Location = new Point(304, 229);
            textBox_time.Name = "textBox_time";
            textBox_time.Size = new Size(125, 27);
            textBox_time.TabIndex = 16;
            textBox_time.Text = "10";
            // 
            // label_time
            // 
            label_time.AutoSize = true;
            label_time.Location = new Point(175, 232);
            label_time.Name = "label_time";
            label_time.Size = new Size(123, 20);
            label_time.TabIndex = 15;
            label_time.Text = "Czas działania (s)";
            // 
            // textBox_tour_size
            // 
            textBox_tour_size.Location = new Point(304, 196);
            textBox_tour_size.Name = "textBox_tour_size";
            textBox_tour_size.Size = new Size(125, 27);
            textBox_tour_size.TabIndex = 14;
            textBox_tour_size.Text = "3";
            // 
            // label_tour_size
            // 
            label_tour_size.AutoSize = true;
            label_tour_size.Location = new Point(176, 199);
            label_tour_size.Name = "label_tour_size";
            label_tour_size.Size = new Size(122, 20);
            label_tour_size.TabIndex = 13;
            label_tour_size.Text = "Wielkość turnieju";
            // 
            // textBox_random_mut
            // 
            textBox_random_mut.Location = new Point(304, 163);
            textBox_random_mut.Name = "textBox_random_mut";
            textBox_random_mut.Size = new Size(125, 27);
            textBox_random_mut.TabIndex = 12;
            textBox_random_mut.Text = "10";
            // 
            // label_random_mut
            // 
            label_random_mut.AutoSize = true;
            label_random_mut.Location = new Point(17, 166);
            label_random_mut.Name = "label_random_mut";
            label_random_mut.Size = new Size(281, 20);
            label_random_mut.TabIndex = 11;
            label_random_mut.Text = "Szansa na całkowicie losową mutację (%)";
            // 
            // textBox_mut_chance
            // 
            textBox_mut_chance.Location = new Point(304, 130);
            textBox_mut_chance.Name = "textBox_mut_chance";
            textBox_mut_chance.Size = new Size(125, 27);
            textBox_mut_chance.TabIndex = 10;
            textBox_mut_chance.Text = "2";
            // 
            // label_mut_chance
            // 
            label_mut_chance.AutoSize = true;
            label_mut_chance.Location = new Point(114, 133);
            label_mut_chance.Name = "label_mut_chance";
            label_mut_chance.Size = new Size(184, 20);
            label_mut_chance.TabIndex = 9;
            label_mut_chance.Text = "Ilość mutacji (% populacji)";
            // 
            // textBox_i_random
            // 
            textBox_i_random.Location = new Point(304, 97);
            textBox_i_random.Name = "textBox_i_random";
            textBox_i_random.Size = new Size(125, 27);
            textBox_i_random.TabIndex = 8;
            textBox_i_random.Text = "30";
            // 
            // textBox_c_random
            // 
            textBox_c_random.Location = new Point(304, 64);
            textBox_c_random.Name = "textBox_c_random";
            textBox_c_random.Size = new Size(125, 27);
            textBox_c_random.TabIndex = 7;
            textBox_c_random.Text = "20";
            // 
            // label_i_random
            // 
            label_i_random.AutoSize = true;
            label_i_random.Location = new Point(69, 100);
            label_i_random.Name = "label_i_random";
            label_i_random.Size = new Size(229, 20);
            label_i_random.TabIndex = 6;
            label_i_random.Text = "Osobniki losowane z instancji (%)";
            // 
            // label_c_random
            // 
            label_c_random.AutoSize = true;
            label_c_random.Location = new Point(81, 67);
            label_c_random.Name = "label_c_random";
            label_c_random.Size = new Size(217, 20);
            label_c_random.TabIndex = 5;
            label_c_random.Text = "Osobniki całkowicie losowe (%)";
            // 
            // textBox_pop_size
            // 
            textBox_pop_size.Location = new Point(304, 31);
            textBox_pop_size.Name = "textBox_pop_size";
            textBox_pop_size.Size = new Size(125, 27);
            textBox_pop_size.TabIndex = 4;
            textBox_pop_size.Text = "100";
            // 
            // label_pop_size
            // 
            label_pop_size.AutoSize = true;
            label_pop_size.Location = new Point(161, 34);
            label_pop_size.Name = "label_pop_size";
            label_pop_size.Size = new Size(134, 20);
            label_pop_size.TabIndex = 3;
            label_pop_size.Text = "Wielkość populacji";
            // 
            // Uruchomienie_metaheurystyki
            // 
            Uruchomienie_metaheurystyki.Location = new Point(343, 333);
            Uruchomienie_metaheurystyki.Name = "Uruchomienie_metaheurystyki";
            Uruchomienie_metaheurystyki.Size = new Size(171, 29);
            Uruchomienie_metaheurystyki.TabIndex = 0;
            Uruchomienie_metaheurystyki.Text = "Uruchom obliczenia";
            Uruchomienie_metaheurystyki.UseVisualStyleBackColor = true;
            Uruchomienie_metaheurystyki.Click += Uruchomienie_metaheurystyki_Click;
            // 
            // obliczenia_tab
            // 
            obliczenia_tab.Controls.Add(progressBar1);
            obliczenia_tab.Controls.Add(buttonStop);
            obliczenia_tab.Controls.Add(buttonPauza);
            obliczenia_tab.Controls.Add(label_wynik);
            obliczenia_tab.Location = new Point(4, 29);
            obliczenia_tab.Name = "obliczenia_tab";
            obliczenia_tab.Padding = new Padding(3);
            obliczenia_tab.Size = new Size(792, 416);
            obliczenia_tab.TabIndex = 2;
            obliczenia_tab.Text = "Obliczenia";
            obliczenia_tab.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(28, 328);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(726, 29);
            progressBar1.TabIndex = 5;
            // 
            // buttonStop
            // 
            buttonStop.BackColor = Color.Firebrick;
            buttonStop.ForeColor = SystemColors.ButtonHighlight;
            buttonStop.Location = new Point(419, 369);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(94, 29);
            buttonStop.TabIndex = 4;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonPauza
            // 
            buttonPauza.BackColor = Color.Orange;
            buttonPauza.ForeColor = SystemColors.ButtonHighlight;
            buttonPauza.Location = new Point(254, 369);
            buttonPauza.Name = "buttonPauza";
            buttonPauza.Size = new Size(94, 29);
            buttonPauza.TabIndex = 3;
            buttonPauza.Text = "Pauza";
            buttonPauza.UseVisualStyleBackColor = false;
            buttonPauza.Click += buttonPauza_Click;
            // 
            // label_wynik
            // 
            label_wynik.Location = new Point(28, 305);
            label_wynik.Name = "label_wynik";
            label_wynik.Size = new Size(726, 20);
            label_wynik.TabIndex = 2;
            label_wynik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // wyniki_tab
            // 
            wyniki_tab.Controls.Add(label1);
            wyniki_tab.Controls.Add(textBox_solution);
            wyniki_tab.Controls.Add(label_sol);
            wyniki_tab.Controls.Add(label_function);
            wyniki_tab.Controls.Add(label_solution);
            wyniki_tab.Controls.Add(textBox_Wynik);
            wyniki_tab.Location = new Point(4, 29);
            wyniki_tab.Name = "wyniki_tab";
            wyniki_tab.Padding = new Padding(3);
            wyniki_tab.Size = new Size(792, 416);
            wyniki_tab.TabIndex = 3;
            wyniki_tab.Text = "Wynik";
            wyniki_tab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 11);
            label1.Name = "label1";
            label1.Size = new Size(198, 20);
            label1.TabIndex = 11;
            label1.Text = "Rozwiązanie metaheurystyki:";
            // 
            // textBox_solution
            // 
            textBox_solution.Location = new Point(3, 196);
            textBox_solution.Multiline = true;
            textBox_solution.Name = "textBox_solution";
            textBox_solution.ReadOnly = true;
            textBox_solution.ScrollBars = ScrollBars.Vertical;
            textBox_solution.Size = new Size(783, 127);
            textBox_solution.TabIndex = 10;
            // 
            // label_sol
            // 
            label_sol.AutoSize = true;
            label_sol.Location = new Point(10, 173);
            label_sol.Name = "label_sol";
            label_sol.Size = new Size(180, 20);
            label_sol.TabIndex = 9;
            label_sol.Text = "Rozwiązanie z generatora";
            // 
            // label_function
            // 
            label_function.AutoSize = true;
            label_function.Location = new Point(10, 372);
            label_function.Name = "label_function";
            label_function.Size = new Size(0, 20);
            label_function.TabIndex = 8;
            // 
            // label_solution
            // 
            label_solution.AutoSize = true;
            label_solution.Location = new Point(10, 340);
            label_solution.Name = "label_solution";
            label_solution.Size = new Size(0, 20);
            label_solution.TabIndex = 7;
            // 
            // textBox_Wynik
            // 
            textBox_Wynik.Location = new Point(10, 34);
            textBox_Wynik.Multiline = true;
            textBox_Wynik.Name = "textBox_Wynik";
            textBox_Wynik.ReadOnly = true;
            textBox_Wynik.ScrollBars = ScrollBars.Vertical;
            textBox_Wynik.Size = new Size(776, 127);
            textBox_Wynik.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(zakladki);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            zakladki.ResumeLayout(false);
            generator_tab.ResumeLayout(false);
            generator_tab.PerformLayout();
            metaheurystyka_tab.ResumeLayout(false);
            metaheurystyka_tab.PerformLayout();
            obliczenia_tab.ResumeLayout(false);
            wyniki_tab.ResumeLayout(false);
            wyniki_tab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button GeneratorBTN;
        private TextBox InstanceBox;
        private Label errors_label;
        private Label label_k;
        private Label label_maxLenght;
        private TextBox textBox_maxLength;
        private TextBox textBox_k;
        private TextBox textBox_errors;
        private Label minDistance_label;
        private TextBox textBox_minDistance;
        private ComboBox comboBox_dlugosc;
        private TabControl zakladki;
        private TabPage generator_tab;
        private TabPage metaheurystyka_tab;
        private Button Przekazanie;
        private Button Uruchomienie_metaheurystyki;
        private Label label_wynik;
        private Label label_pop_size;
        private TextBox textBox_pop_size;
        private Label label_i_random;
        private Label label_c_random;
        private TextBox textBox_i_random;
        private TextBox textBox_c_random;
        private Label label_mut_chance;
        private TextBox textBox_mut_chance;
        private TextBox textBox_random_mut;
        private Label label_random_mut;
        private TextBox textBox_tour_size;
        private Label label_tour_size;
        private TextBox textBox_time;
        private Label label_time;
        private TabPage obliczenia_tab;
        private Button buttonStop;
        private Button buttonPauza;
        private ProgressBar progressBar1;
        private TextBox textBox_Wynik;
        private TabPage wyniki_tab;
        private Label label_solution;
        private Label label_function;
        private Label label_sol;
        private Label label1;
        private TextBox textBox_solution;
    }
}
